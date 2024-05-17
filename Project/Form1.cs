namespace Project
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using System.Xml;
    using Npgsql;//класс для работы с БД Postgres

    public partial class Form1 : Form
    {//подключение к БД
        private NpgsqlConnection con;
        private string connString =
    "Host=127.0.0.1;Username=postgres;Password=123;Database=TourFirm";

        public Form1()
        {
            InitializeComponent();
            con = new NpgsqlConnection(connString);
            con.Open();
            loadTables();
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView2.CellEndEdit += dataGridView2_CellEndEdit;
            dataGridView3.CellEndEdit += dataGridView3_CellEndEdit;
            dataGridView4.CellEndEdit += dataGridView4_CellEndEdit;
            dataGridView6.CellEndEdit += dataGridView6_CellEndEdit;
        }

        private void loadTourists()
        {
            // Проверяем, был ли вызван метод из другого потока
            if (InvokeRequired)
            {
                // Если да, используем Invoke для вызова метода в UI-потоке
                Invoke(new MethodInvoker(loadTourists));
                return;
            }

            // Код, который будет выполняться в UI-потоке
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM Tourist", con);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void loadTouristsInfo()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(loadTouristsInfo));
                return;
            }

            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM TouristInfo", con);
            adap.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void loadTours()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(loadTours));
                return;
            }

            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM Tour", con);
            adap.Fill(dt);
            dataGridView3.DataSource = dt;
        }

        private void loadSeasons()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(loadSeasons));
                return;
            }

            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM Season", con);
            adap.Fill(dt);
            dataGridView4.DataSource = dt;
        }

        private void loadTicket()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(loadTicket));
                return;
            }

            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM Ticket", con);
            adap.Fill(dt);
            dataGridView5.DataSource = dt;
        }

        private void loadPayment()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(loadPayment));
                return;
            }

            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM Payment", con);
            adap.Fill(dt);
            dataGridView6.DataSource = dt;
        }

        private void loadTables()
        {
            loadTourists();
            loadTouristsInfo();
            loadTours();
            loadSeasons();
            loadTicket();
            loadPayment();
        }

        private void button_addRecord_Click(object sender, EventArgs e)
        {

            Form2 form = new Form2(con);
            form.DataChanged += new Form2.DataChangedEventHandler(loadTables);
            form.ShowDialog();
        }

        private void button_addChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.EditMode == DataGridViewEditMode.EditOnEnter || dataGridView2.EditMode == DataGridViewEditMode.EditOnEnter
                || dataGridView3.EditMode == DataGridViewEditMode.EditOnEnter || dataGridView4.EditMode == DataGridViewEditMode.EditOnEnter
                || dataGridView5.EditMode == DataGridViewEditMode.EditOnEnter)
            {
                button_addChange.BackColor = Color.FromArgb(255, 192, 255, 192);
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
                dataGridView3.EditMode = DataGridViewEditMode.EditProgrammatically;
                dataGridView4.EditMode = DataGridViewEditMode.EditProgrammatically;
                dataGridView5.EditMode = DataGridViewEditMode.EditProgrammatically;
                dataGridView6.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else
            {
                button_addChange.BackColor = Color.LightGray;
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
                dataGridView2.EditMode = DataGridViewEditMode.EditOnEnter;
                dataGridView3.EditMode = DataGridViewEditMode.EditOnEnter;
                dataGridView4.EditMode = DataGridViewEditMode.EditOnEnter;
                dataGridView5.EditMode = DataGridViewEditMode.EditOnEnter;
                dataGridView6.EditMode = DataGridViewEditMode.EditOnEnter;
                dataGridView1.Columns["code_tourist"].ReadOnly = true;
                dataGridView2.Columns["code_tourist"].ReadOnly = true;
                dataGridView3.Columns["code_tour"].ReadOnly = true;
                dataGridView4.Columns["code_season"].ReadOnly = true;
                dataGridView4.Columns["code_tour"].ReadOnly = true;
                dataGridView5.Columns["code_ticket"].ReadOnly = true;
                dataGridView5.Columns["code_tourist"].ReadOnly = true;
                dataGridView5.Columns["code_season"].ReadOnly = true;
                dataGridView6.Columns["code_payment"].ReadOnly = true;
                dataGridView6.Columns["code_ticket"].ReadOnly = true;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // получаем индекс отредактированной строки и колонки
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            // получаем ID туриста
            int touristId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["code_tourist"].Value);

            // получаем новое значение из отредактированной ячейки
            var newValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();

            // определяем имя колонки, которая была отредактирована, для формирования корректного SQL запроса
            string columnName = dataGridView1.Columns[columnIndex].Name;

            // формируем SQL запрос на обновление
            string sql = $"UPDATE Tourist SET {columnName} = @newValue WHERE code_tourist = {touristId}";

            // выполняем SQL запрос на обновление
            using (var cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@newValue", newValue);
                cmd.ExecuteNonQuery();
            }

            loadTables();
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            int touristId = Convert.ToInt32(dataGridView2.Rows[rowIndex].Cells["code_tourist"].Value);
            string columnName = dataGridView2.Columns[columnIndex].Name;
            string sql = $"UPDATE TouristInfo SET {columnName} = @newValue WHERE code_tourist = {touristId}";

            using (var cmd = new NpgsqlCommand(sql, con))
            {
                if (columnName == "postcode")
                {
                    // для числовых значений преобразуем newValue в соответствующий тип
                    int newValueInt = Convert.ToInt32(dataGridView2.Rows[rowIndex].Cells[columnIndex].Value);
                    cmd.Parameters.AddWithValue("@newValue", newValueInt);
                }
                else
                {
                    // для строковых значений используем newValue напрямую
                    var newValue = dataGridView2.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                    cmd.Parameters.AddWithValue("@newValue", newValue);
                }
                cmd.ExecuteNonQuery();
            }

            loadTables();
        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            int codeTour = Convert.ToInt32(dataGridView3.Rows[rowIndex].Cells["code_tour"].Value);
            string columnName = dataGridView3.Columns[columnIndex].Name;
            var cellValue = dataGridView3.Rows[rowIndex].Cells[columnIndex].Value;

            if (columnName == "price")
            {
                if (!decimal.TryParse(cellValue.ToString(), out decimal newValue))
                {
                    MessageBox.Show("Некорректное значение для цены.");
                    return;
                }
                string sql = $"UPDATE Tour SET {columnName} = @newValue WHERE code_tour = {codeTour}";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@newValue", newValue);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                string sql = $"UPDATE Tour SET {columnName} = @newValue WHERE code_tour = {codeTour}";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@newValue", cellValue);
                    cmd.ExecuteNonQuery();
                }
            }

            loadTables();
        }

        private void dataGridView4_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            // получаем ID сезона из первой колонки
            int codeSeason = Convert.ToInt32(dataGridView4.Rows[rowIndex].Cells["code_season"].Value);

            // имя колонки, которая была отредактирована
            string columnName = dataGridView4.Columns[columnIndex].Name;

            // получаем новое значение из отредактированной ячейки
            var cellValue = dataGridView4.Rows[rowIndex].Cells[columnIndex].Value;

            // проверка типа данных и форматирование нового значения в соответствии с типом данных в базе
            object newValue;
            switch (columnName)
            {
                case "start_date":
                case "end_date":
                    if (DateTime.TryParse(cellValue.ToString(), out DateTime dateValue))
                    {
                        newValue = dateValue;
                    }
                    else
                    {
                        MessageBox.Show("Некорректное значение даты.");
                        return;
                    }
                    break;
                case "is_open":
                    newValue = Convert.ToBoolean(cellValue);
                    break;
                case "seat_count":
                    newValue = Convert.ToInt32(cellValue);
                    break;
                default:
                    newValue = cellValue.ToString();
                    break;
            }

            string sql = $"UPDATE Season SET {columnName} = @newValue WHERE code_season = {codeSeason}";
            using (var cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@newValue", newValue);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка обновления данных: {ex.Message}");
                }
            }

            loadTables();
        }

        private void dataGridView6_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            int codePayment = Convert.ToInt32(dataGridView6.Rows[rowIndex].Cells["code_payment"].Value);

            string columnName = dataGridView6.Columns[columnIndex].Name;

            var cellValue = dataGridView6.Rows[rowIndex].Cells[columnIndex].Value;

            object newValue;
            if (columnName == "payment_date")
            {
                if (!DateTime.TryParse(cellValue.ToString(), out DateTime dateValue))
                {
                    MessageBox.Show("Некорректное значение даты.");
                    return;
                }
                newValue = dateValue;
            }
            else if (columnName == "amount")
            {
                // для MONEY используем тип decimal
                if (!decimal.TryParse(cellValue.ToString(), out decimal amountValue))
                {
                    MessageBox.Show("Некорректное значение суммы.");
                    return;
                }
                newValue = amountValue;
            }
            else
            {
                newValue = cellValue; // для code_ticket
            }

            string sql = $"UPDATE Payment SET {columnName} = @newValue WHERE code_payment = {codePayment}";
            using (var cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@newValue", newValue);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}");
                }
            }

            loadTables();
        }

        private void button_deleteRecord_Click(object sender, EventArgs e)
        {
            var selectedTab = tabControl1.SelectedTab;

            if (selectedTab == tabPage1)
            {
                DeleteRecord(dataGridView1, "Tourist");
            }
            else if (selectedTab == tabPage2)
            {
                DeleteRecord(dataGridView2, "TouristInfo");
            }
            else if (selectedTab == tabPage3)
            {
                DeleteRecord(dataGridView3, "Tour");
            }
            else if (selectedTab == tabPage4)
            {
                DeleteRecord(dataGridView4, "Season");
            }
            else if (selectedTab == tabPage5)
            {
                DeleteRecord(dataGridView5, "Ticket");
            }
            else
            {
                DeleteRecord(dataGridView6, "Payment");
            }
        }

        private void DeleteRecord(DataGridView dataGridView, string tableName)
        {
            if (dataGridView.CurrentRow != null)
            {
                var confirmationResult = MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmationResult == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
                    string columnName;

                    if (dataGridView == dataGridView1 || dataGridView == dataGridView2)
                    {
                        columnName = "code_tourist";
                    }
                    else if (dataGridView == dataGridView3)
                    {
                        columnName = "code_tour";
                    }
                    else if (dataGridView == dataGridView4)
                    {
                        columnName = "code_season";
                    }
                    else if (dataGridView == dataGridView5)
                    {
                        columnName = "code_ticket";
                    }
                    else
                    {
                        columnName = "code_payment";
                    }
                    string sql = $"DELETE FROM {tableName} WHERE {columnName} = {id}";

                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при удалении записи: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.");
            }

            loadTables();
        }

        private void button_request_Click(object sender, EventArgs e)
        {
            if (this.Width == 993)
            {
                this.Width = 1282;
                button_request.Location = new Point(1163, 624);
            }
            else
            {
                this.Width = 993;
                button_request.Location = new Point(874, 624);
            }
        }

        private void button_agrRequest_Click(object sender, EventArgs e)
        {
            string query = textBox1.Text;

            string connectionString =
                "Host=127.0.0.1;Username=postgres;Password=123;Database=TourFirm";

            ExecuteQuery(connectionString, query);
        }

        private void button_paramRequest_Click(object sender, EventArgs e)
        {
            string query = richTextBox1.Text;

            string connectionString = 
                "Host=127.0.0.1;Username=postgres;Password=123;Database=TourFirm";

            ExecuteQueryWithParameters(connectionString, query);
        }

        private void ExecuteQuery(string connectionString, string query)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = query;
                        lastQuery = query;

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);

                                // проверяем, сколько строк в результате запроса
                                if (dataTable.Rows.Count > 1)
                                {
                                    // если строк больше одной, отображаем результат в новом окне
                                    Form resultForm = new Form();
                                    DataGridView dataGridView = new DataGridView();
                                    dataGridView.DataSource = dataTable;
                                    dataGridView.Dock = DockStyle.Fill;
                                    resultForm.Controls.Add(dataGridView);
                                    resultForm.Width = 600;
                                    resultForm.Height = 400;
                                    resultForm.ShowDialog();
                                }
                                else
                                {
                                    // если строка одна, отображаем результат в MessageBox
                                    MessageBox.Show($"Результат запроса: {dataTable.Rows[0].ItemArray[0].ToString()}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Результат запроса пуст.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // в случае ошибки показываем сообщение об ошибке
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteQueryWithParameters(string connectionString, string query)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand())
                    {
                        command.Connection = connection;

                        // находим место, где начинаются параметры и их значения
                        int paramStartIndex = query.IndexOf('|');
                        if (paramStartIndex != -1)
                        {
                            // извлекаем часть запроса с параметрами
                            string paramString = query.Substring(paramStartIndex + 1).Trim();
                            // удаляем эту часть из основного запроса
                            query = query.Substring(0, paramStartIndex).Trim();

                            // обрабатываем параметры
                            string[] paramPairs = paramString.Split(',');
                            foreach (string paramPair in paramPairs)
                            {
                                string[] paramValuePair = paramPair.Split('=');
                                if (paramValuePair.Length == 2)
                                {
                                    string paramName = paramValuePair[0].Trim();
                                    string paramValue = paramValuePair[1].Trim();
                                    // добавляем параметр к команде
                                    command.Parameters.AddWithValue(paramName, paramValue);
                                }
                            }
                        }

                        // устанавливаем командный текст без значений параметров
                        command.CommandText = query;
                        lastQuery = FormatQueryWithParameters(command);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);

                                if (dataTable.Rows.Count > 1)
                                {
                                    Form resultForm = new Form();
                                    DataGridView dataGridView = new DataGridView();
                                    dataGridView.DataSource = dataTable;
                                    dataGridView.Dock = DockStyle.Fill;
                                    resultForm.Controls.Add(dataGridView);
                                    resultForm.Width = 600;
                                    resultForm.Height = 400;
                                    resultForm.ShowDialog();
                                }
                                else
                                {
                                    string result = "Результат запроса:\n";
                                    for (int i = 0; i < dataTable.Columns.Count; i++)
                                    {
                                        result += dataTable.Rows[0][i].ToString() + "\t";
                                    }
                                    MessageBox.Show(result, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Результат запроса пуст.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string lastQuery;

        private string FormatQueryWithParameters(NpgsqlCommand command)
        {
            string formattedQuery = command.CommandText;

            foreach (NpgsqlParameter param in command.Parameters)
            {
                string paramName = param.ParameterName;
                string paramValue = param.Value.ToString();
                formattedQuery = formattedQuery.Replace(paramName, $"'{paramValue}'");
            }

            return formattedQuery;
        }

        private void button_xmlWriterExport_Click(object sender, EventArgs e)
        {
            // проверяем, был ли выполнен хотя бы один запрос
            if (string.IsNullOrWhiteSpace(lastQuery))
            {
                MessageBox.Show("Сначала выполните запрос.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // указываем путь для сохранения XML-файла
            string filePath = "result.xml";

            // создаем объект XmlWriter для записи данных в XML
            using (XmlWriter writer = XmlWriter.Create(filePath))
            {
                // начинаем запись корневого элемента
                writer.WriteStartDocument();
                writer.WriteStartElement("Result");

                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection("Host=127.0.0.1;Username=postgres;Password=123;Database=TourFirm"))
                    {
                        connection.Open();
                        using (NpgsqlCommand command = new NpgsqlCommand(lastQuery, connection))
                        {
                            using (NpgsqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    writer.WriteStartElement("Row");
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        writer.WriteElementString(reader.GetName(i), reader[i].ToString());
                                    }
                                    writer.WriteEndElement(); // Row
                                }
                            }
                        }
                    }

                    writer.WriteEndElement(); // Result
                    writer.WriteEndDocument();
                    MessageBox.Show("Данные успешно экспортированы в XML.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при экспорте данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_xmlReaderImport_Click(object sender, EventArgs e)
        {
            string filePath = "result.xml";

            // проверяем, существует ли файл
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataTable dataTable = new DataTable();
                bool schemaRead = false;

                // создаем объект XmlReader для чтения данных из XML
                using (XmlReader reader = XmlReader.Create(filePath))
                {
                    // читаем данные из XML
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {
                                case "Row":
                                    DataRow dataRow = dataTable.NewRow();
                                    while (reader.Read())
                                    {
                                        if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Row")
                                        {
                                            break;
                                        }
                                        if (reader.NodeType == XmlNodeType.Element)
                                        {
                                            string columnName = reader.Name;
                                            reader.Read();
                                            string columnValue = reader.Value;

                                            if (!schemaRead)
                                            {
                                                dataTable.Columns.Add(columnName);
                                            }

                                            dataRow[columnName] = columnValue;
                                        }
                                    }
                                    schemaRead = true;
                                    dataTable.Rows.Add(dataRow);
                                    break;
                            }
                        }
                    }
                }

                if (dataTable.Rows.Count > 1)
                {
                    Form resultForm = new Form();
                    DataGridView dataGridView = new DataGridView();
                    dataGridView.DataSource = dataTable;
                    dataGridView.Dock = DockStyle.Fill;
                    resultForm.Controls.Add(dataGridView);
                    resultForm.Width = 600;
                    resultForm.Height = 400;
                    resultForm.ShowDialog();
                }
                else if (dataTable.Rows.Count == 1)
                {
                    string result = "Результат импорта:\n";
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        result += dataTable.Columns[i].ColumnName + ": " + dataTable.Rows[0][i].ToString() + "\n";
                    }
                    MessageBox.Show(result, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Результат импорта пуст.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при импорте данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xmlDocumentExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lastQuery))
            {
                MessageBox.Show("Сначала выполните запрос.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string filePath = "result.xml";

            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Result");
            doc.AppendChild(root);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection("Host=127.0.0.1;Username=postgres;Password=123;Database=TourFirm"))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(lastQuery, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                XmlElement rowElement = doc.CreateElement("Row");
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    XmlElement columnElement = doc.CreateElement(reader.GetName(i));
                                    columnElement.InnerText = reader[i].ToString();
                                    rowElement.AppendChild(columnElement);
                                }
                                root.AppendChild(rowElement);
                            }
                        }
                    }
                }

                doc.Save(filePath);
                MessageBox.Show("Данные успешно экспортированы в XML.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при экспорте данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xmlDocumentImport_Click(object sender, EventArgs e)
        {
            string filePath = "result.xml";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);

                DataTable dataTable = new DataTable();
                XmlNodeList rowNodes = doc.SelectNodes("//Row");
                if (rowNodes.Count == 0)
                {
                    MessageBox.Show("Результат импорта пуст.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // создаем столбцы
                foreach (XmlNode columnNode in rowNodes[0].ChildNodes)
                {
                    dataTable.Columns.Add(columnNode.Name);
                }

                // заполняем строки
                foreach (XmlNode rowNode in rowNodes)
                {
                    DataRow dataRow = dataTable.NewRow();
                    foreach (XmlNode columnNode in rowNode.ChildNodes)
                    {
                        dataRow[columnNode.Name] = columnNode.InnerText;
                    }
                    dataTable.Rows.Add(dataRow);
                }

                if (dataTable.Rows.Count > 1)
                {
                    Form resultForm = new Form();
                    DataGridView dataGridView = new DataGridView();
                    dataGridView.DataSource = dataTable;
                    dataGridView.Dock = DockStyle.Fill;
                    resultForm.Controls.Add(dataGridView);
                    resultForm.Width = 600;
                    resultForm.Height = 400;
                    resultForm.ShowDialog();
                }
                else if (dataTable.Rows.Count == 1)
                {
                    string result = "Результат импорта:\n";
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        result += dataTable.Columns[i].ColumnName + ": " + dataTable.Rows[0][i].ToString() + "\n";
                    }
                    MessageBox.Show(result, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при импорте данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_trigger_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
            loadTables();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage7)
            {
                CreatePieChart();
                CreateBarChart();
            }
        }

        private DataTable GetTourPurchaseData()
        {
            string sql = @"
        SELECT T.tour_name, 
               COUNT(TK.code_ticket) AS purchase_count,
               (SELECT COUNT(*) FROM Ticket) AS total_count
        FROM Tour T
        LEFT JOIN Season S ON T.code_tour = S.code_tour
        LEFT JOIN Ticket TK ON S.code_season = TK.code_season
        GROUP BY T.tour_name
    ";

            using (NpgsqlConnection connection = new NpgsqlConnection("Host=127.0.0.1;Username=postgres;Password=123;Database=TourFirm"))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        private DataTable GetTotalPurchaseAmountData()
        {
            string sql = @"
        SELECT T.tour_name, 
               SUM(P.amount) AS total_amount
        FROM Tour T
        LEFT JOIN Season S ON T.code_tour = S.code_tour
        LEFT JOIN Ticket TK ON S.code_season = TK.code_season
        LEFT JOIN Payment P ON TK.code_ticket = P.code_ticket
        GROUP BY T.tour_name
    ";

            using (NpgsqlConnection connection = new NpgsqlConnection("Host=127.0.0.1;Username=postgres;Password=123;Database=TourFirm"))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        private void CreatePieChart()
        {
            DataTable data = GetTourPurchaseData();

            chart_pie.Series.Clear();
            chart_pie.Titles.Clear();

            chart_pie.Titles.Add("Процент выкупа туров клиентами");

            Series series = new Series
            {
                Name = "Tours",
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Pie
            };

            chart_pie.Series.Add(series);

            foreach (DataRow row in data.Rows)
            {
                double purchaseCount = Convert.ToDouble(row["purchase_count"]);
                double totalCount = Convert.ToDouble(row["total_count"]);
                double percentage = (totalCount > 0) ? (purchaseCount / totalCount) * 100 : 0;

                DataPoint point = new DataPoint();
                point.SetValueXY(row["tour_name"], percentage);
                point.Label = string.Format("{0}: {1:P0}", row["tour_name"], percentage / 100);

                series.Points.Add(point);
            }

            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";

            chart_pie.Invalidate();
        }

        private void CreateBarChart()
        {
            DataTable data = GetTotalPurchaseAmountData();

            chart_bar.Series.Clear();
            chart_bar.Titles.Clear();

            chart_bar.Titles.Add("Общая сумма выкупа всех туров");

            Series series = new Series
            {
                Name = "Tours",
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Bar
            };

            chart_bar.Series.Add(series);

            foreach (DataRow row in data.Rows)
            {
                series.Points.AddXY(row["tour_name"], row["total_amount"]);
            }

            chart_bar.Invalidate();
        }
    }
}