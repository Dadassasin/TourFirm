using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form2 : Form
    {
        private NpgsqlConnection con; // Предполагаем, что соединение установлено

        public delegate void DataChangedEventHandler();
        public event DataChangedEventHandler DataChanged;

        public Form2(NpgsqlConnection existingConnection)
        {
            InitializeComponent();
            con = existingConnection; // Используем существующее соединение
            FillComboBoxWithTourCodes();
            FillComboBoxWithTouristCodes();
            FillComboBoxWithTicketCodes();
            FillComboBoxWithSeasonCodes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Name)
            {
                case "tabPage1":
                    InsertTourist();
                    break;
                case "tabPage2":
                    InsertTouristInfo();
                    break;
                case "tabPage3":
                    InsertTour();
                    break;
                case "tabPage4":
                    InsertSeason();
                    break;
                case "tabPage5":
                    InsertTicket();
                    break;
                case "tabPage6":
                    InsertPayment();
                    break;
                default:
                    break;
            }
        }

        private void InsertTourist()
        {
            // Сбор данных из формы
            string lastName = textBox2.Text; // Фамилия
            string firstName = textBox1.Text; // Имя
            string patronymic = textBox3.Text; // Отчество

            // Проверка на пустые значения
            if (string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(patronymic))
            {
                MessageBox.Show("Поля 'Фамилия', 'Имя' и 'Отчество' не могут быть пустыми.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация данных
            if (!ValidateText(lastName) || !ValidateText(firstName) || !ValidateText(patronymic))
            {
                MessageBox.Show("Поля 'Фамилия', 'Имя' и 'Отчество' должны содержать только буквы.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Прерываем выполнение метода, если данные не валидны
            }

            // SQL запрос на вставку
            string sql = @"INSERT INTO Tourist (last_name, first_name, patronymic) VALUES (@lastName, @firstName, @patronymic)";

            using (var cmd = new NpgsqlCommand(sql, con))
            {
                // Параметризованный запрос для избежания SQL инъекции
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@patronymic", patronymic);

                // Выполнение запроса
                cmd.ExecuteNonQuery();
                MessageBox.Show("Новая запись успешно добавлена в базу данных", "Запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DataChanged?.Invoke();
        }


        private void InsertTouristInfo()
        {
            // Проверка на пустое значение comboBox
            if (string.IsNullOrEmpty(comboBox5.Text))
            {
                MessageBox.Show("Выберите код туриста.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int codeTourist = int.Parse(comboBox5.Text); // Предполагается, что значение корректно

            string passportSeries = textBox4.Text; // Серия паспорта
            string city = textBox5.Text; // Город
            string country = textBox6.Text; // Страна
            string phone = textBox7.Text; // Телефон
            string postcodeText = textBox9.Text; // Почтовый индекс текст для валидации

            // Проверки на пустоту
            if (string.IsNullOrEmpty(passportSeries) || string.IsNullOrEmpty(city) ||
                string.IsNullOrEmpty(country) || string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(postcodeText))
            {
                MessageBox.Show("Все поля должны быть заполнены.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Продолжение валидации
            if (!ValidatePassportSeries(passportSeries))
            {
                MessageBox.Show("Поле 'Серия паспорта' должно содержать только цифры.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateText(city) || !ValidateText(country))
            {
                MessageBox.Show("Поля 'Город' и 'Страна' должны содержать только буквы.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidatePhone(phone))
            {
                MessageBox.Show("Поле 'Телефон' содержит некорректный номер.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int postcode; // Почтовый индекс как число
            if (!int.TryParse(postcodeText, out postcode) || !ValidatePostalCode(postcodeText))
            {
                MessageBox.Show("Поле 'Почтовый индекс' должно содержать ровно 6 цифр.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL запрос на вставку
            string sql = @"INSERT INTO TouristInfo (code_tourist, passport_series, city, country, phone, postcode) 
                   VALUES (@codeTourist, @passportSeries, @city, @country, @phone, @postcode)";

            using (var cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@codeTourist", codeTourist);
                cmd.Parameters.AddWithValue("@passportSeries", passportSeries);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@postcode", postcode);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Новая запись успешно добавлена в базу данных", "Запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DataChanged?.Invoke();
        }

        private void InsertTour()
        {
            // Сбор данных из формы
            string tourName = textBox15.Text; // Название тура
            string priceText = textBox14.Text; // Цена как текст для проверки
            string tourInfo = richTextBox1.Text; // Информация о туре

            if (string.IsNullOrWhiteSpace(tourName) || string.IsNullOrWhiteSpace(priceText) || string.IsNullOrEmpty(tourInfo))
            {
                MessageBox.Show("Поля 'Название тура', 'Информация о туре' и 'Цена' не могут быть пустыми.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка цены на корректность
            if (!decimal.TryParse(priceText, out decimal price) || price <= 0)
            {
                MessageBox.Show("Поле 'Цена' должно быть положительным числом.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация названия тура на содержание только букв не требуется, если оно может включать и другие символы

            // SQL запрос на вставку
            string sql = @"INSERT INTO Tour (tour_name, price, tour_info) VALUES (@tourName, @price, @tourInfo)";

            using (var cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@tourName", tourName);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@tourInfo", tourInfo ?? string.Empty); // Обеспечиваем, что null преобразуется в пустую строку
                cmd.ExecuteNonQuery();
                MessageBox.Show("Новая запись успешно добавлена в базу данных", "Запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DataChanged?.Invoke();
        }


        private void InsertSeason()
        {
            // Валидация и преобразование кода тура и количества мест
            bool codeTourIsValid = int.TryParse(comboBox1.Text, out int codeTour);
            bool seatCountIsValid = int.TryParse(textBox12.Text, out int seatCount);

            // Валидация дат
            bool startDateIsValid = DateTime.TryParse(textBox16.Text, out DateTime startDate);
            bool endDateIsValid = DateTime.TryParse(textBox13.Text, out DateTime endDate);

            // Проверки валидности
            if (!codeTourIsValid || !seatCountIsValid)
            {
                MessageBox.Show("Поля 'Код тура' и 'Количество мест' должны содержать только цифры.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!startDateIsValid || !endDateIsValid)
            {
                MessageBox.Show("Убедитесь, что даты начала и окончания сезона введены корректно.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (endDate <= startDate)
            {
                MessageBox.Show("Дата окончания сезона должна быть позже даты начала.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL запрос на вставку
            string sql = @"INSERT INTO Season (code_tour, start_date, end_date, is_open, seat_count) 
           VALUES (@codeTour, @startDate, @endDate, @isOpen, @seatCount)";

            using (var cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@codeTour", codeTour);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Parameters.AddWithValue("@isOpen", checkBox1.Checked);
                cmd.Parameters.AddWithValue("@seatCount", seatCount);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Новая запись успешно добавлена в базу данных", "Запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DataChanged?.Invoke();
        }


        private void InsertTicket()
        {
            // Валидация и преобразование кода туриста
            bool codeTouristIsValid = int.TryParse(comboBox2.Text, out int codeTourist);
            // Валидация и преобразование кода сезона
            bool codeSeasonIsValid = int.TryParse(comboBox3.Text, out int codeSeason);

            // Проверки валидности
            if (!codeTouristIsValid)
            {
                MessageBox.Show("Выберите корректный код туриста.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!codeSeasonIsValid)
            {
                MessageBox.Show("Выберите корректный код сезона.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Подготовка SQL запроса на вставку
            string sql = @"INSERT INTO Ticket (code_tourist, code_season) VALUES (@codeTourist, @codeSeason)";

            using (var cmd = new NpgsqlCommand(sql, con))
            {
                // Добавление параметров с использованием безопасного способа для предотвращения SQL-инъекций
                cmd.Parameters.AddWithValue("@codeTourist", codeTourist);
                cmd.Parameters.AddWithValue("@codeSeason", codeSeason);

                // Выполнение запроса
                cmd.ExecuteNonQuery();
                MessageBox.Show("Новая запись успешно добавлена в базу данных", "Запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DataChanged?.Invoke();
        }


        private void InsertPayment()
        {
            // Валидация кода билета
            bool codeTicketIsValid = int.TryParse(comboBox4.Text, out int codeTicket);
            if (!codeTicketIsValid)
            {
                MessageBox.Show("Выберите корректный код билета.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация даты оплаты
            bool paymentDateIsValid = DateTime.TryParse(textBox22.Text, out DateTime paymentDate);
            if (!paymentDateIsValid)
            {
                MessageBox.Show("Введите корректную дату оплаты.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Валидация оплаченной суммы
            bool amountIsValid = decimal.TryParse(textBox19.Text, out decimal amount) && amount > 0;
            if (!amountIsValid)
            {
                MessageBox.Show("Поле 'Оплаченная сумма' должно быть положительным числом.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL запрос на вставку
            string sql = @"INSERT INTO Payment (code_ticket, payment_date, amount) VALUES (@codeTicket, @paymentDate, @amount)";

            using (var cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@codeTicket", codeTicket);
                cmd.Parameters.AddWithValue("@paymentDate", paymentDate);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Новая запись успешно добавлена в базу данных", "Запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DataChanged?.Invoke();
        }


        private bool ValidateText(string input)
        {
            var regex = new Regex(@"^[a-zA-Zа-яА-ЯёЁ\s]+$");
            return regex.IsMatch(input);
        }

        private bool ValidatePassportSeries(string input)
        {
            var regex = new Regex(@"^\d{4}$");
            return regex.IsMatch(input);
        }

        private bool ValidatePhone(string input)
        {
            var regex = new Regex(@"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$");
            return regex.IsMatch(input);
        }

        private bool ValidatePostalCode(string input)
        {
            var regex = new Regex(@"^\d{6}$");
            return regex.IsMatch(input);
        }

        private void FillComboBoxWithTourCodes()
        {
            comboBox1.Items.Clear();
            string sql = "SELECT code_tour FROM Tour ORDER BY code_tour ASC;";
            using (var cmd = new NpgsqlCommand(sql, con))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["code_tour"].ToString());
                    }
                }
            }
        }

        private void FillComboBoxWithTouristCodes()
        {
            comboBox2.Items.Clear();
            string sql = "SELECT code_tourist FROM Tourist ORDER BY code_tourist ASC;";
            using (var cmd = new NpgsqlCommand(sql, con))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader["code_tourist"].ToString());
                        comboBox5.Items.Add(reader["code_tourist"].ToString());
                    }
                }
            }
        }

        private void FillComboBoxWithSeasonCodes()
        {
            comboBox3.Items.Clear();
            string sql = "SELECT code_season FROM Season ORDER BY code_season ASC;";
            using (var cmd = new NpgsqlCommand(sql, con))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader["code_season"].ToString());
                    }
                }
            }
        }

        private void FillComboBoxWithTicketCodes()
        {
            comboBox4.Items.Clear();
            string sql = "SELECT code_ticket FROM Ticket ORDER BY code_ticket ASC;";
            using (var cmd = new NpgsqlCommand(sql, con))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox4.Items.Add(reader["code_ticket"].ToString());
                    }
                }
            }
        }
    }

}
