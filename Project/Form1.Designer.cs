namespace Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();   
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_addRecord = new System.Windows.Forms.Button();
            this.button_addChange = new System.Windows.Forms.Button();
            this.button_deleteRecord = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_trigger = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.button_request = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button_xmlReaderImport = new System.Windows.Forms.Button();
            this.button_xmlDocumentImport = new System.Windows.Forms.Button();
            this.button_xmlDocumentExport = new System.Windows.Forms.Button();
            this.button_xmlWriterExport = new System.Windows.Forms.Button();
            this.button_paramRequest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_agrRequest = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chart_pie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_bar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_pie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // button_addRecord
            // 
            this.button_addRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button_addRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addRecord.Location = new System.Drawing.Point(12, 624);
            this.button_addRecord.Name = "button_addRecord";
            this.button_addRecord.Size = new System.Drawing.Size(91, 31);
            this.button_addRecord.TabIndex = 1;
            this.button_addRecord.Text = "Добавить";
            this.button_addRecord.UseVisualStyleBackColor = false;
            this.button_addRecord.Click += new System.EventHandler(this.button_addRecord_Click);
            // 
            // button_addChange
            // 
            this.button_addChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_addChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addChange.Location = new System.Drawing.Point(109, 624);
            this.button_addChange.Name = "button_addChange";
            this.button_addChange.Size = new System.Drawing.Size(91, 31);
            this.button_addChange.TabIndex = 2;
            this.button_addChange.Text = "Изменить";
            this.button_addChange.UseVisualStyleBackColor = false;
            this.button_addChange.Click += new System.EventHandler(this.button_addChange_Click);
            // 
            // button_deleteRecord
            // 
            this.button_deleteRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_deleteRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_deleteRecord.Location = new System.Drawing.Point(206, 624);
            this.button_deleteRecord.Name = "button_deleteRecord";
            this.button_deleteRecord.Size = new System.Drawing.Size(91, 31);
            this.button_deleteRecord.TabIndex = 3;
            this.button_deleteRecord.Text = "Удалить";
            this.button_deleteRecord.UseVisualStyleBackColor = false;
            this.button_deleteRecord.Click += new System.EventHandler(this.button_deleteRecord_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridView4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(966, 592);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Сезоны";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.AllowUserToResizeColumns = false;
            this.dataGridView4.AllowUserToResizeRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView4.Location = new System.Drawing.Point(0, 0);
            this.dataGridView4.MultiSelect = false;
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(966, 592);
            this.dataGridView4.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(966, 592);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Туры";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(966, 592);
            this.dataGridView3.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(966, 592);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Информация о туристах";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(966, 592);
            this.dataGridView2.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_trigger);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(966, 592);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Туристы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_trigger
            // 
            this.button_trigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_trigger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_trigger.Location = new System.Drawing.Point(826, 549);
            this.button_trigger.Name = "button_trigger";
            this.button_trigger.Size = new System.Drawing.Size(134, 37);
            this.button_trigger.TabIndex = 1;
            this.button_trigger.Text = "Триггер";
            this.button_trigger.UseVisualStyleBackColor = false;
            this.button_trigger.Click += new System.EventHandler(this.button_trigger_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(966, 592);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(974, 618);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dataGridView5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(966, 592);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Билет";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridView5
            // 
            this.dataGridView5.AllowUserToAddRows = false;
            this.dataGridView5.AllowUserToDeleteRows = false;
            this.dataGridView5.AllowUserToResizeColumns = false;
            this.dataGridView5.AllowUserToResizeRows = false;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView5.Location = new System.Drawing.Point(0, 0);
            this.dataGridView5.MultiSelect = false;
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(966, 592);
            this.dataGridView5.TabIndex = 2;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dataGridView6);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(966, 592);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Оплата";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dataGridView6
            // 
            this.dataGridView6.AllowUserToAddRows = false;
            this.dataGridView6.AllowUserToDeleteRows = false;
            this.dataGridView6.AllowUserToResizeColumns = false;
            this.dataGridView6.AllowUserToResizeRows = false;
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView6.Location = new System.Drawing.Point(0, 0);
            this.dataGridView6.MultiSelect = false;
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.Size = new System.Drawing.Size(966, 592);
            this.dataGridView6.TabIndex = 2;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.chart_bar);
            this.tabPage7.Controls.Add(this.chart_pie);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(966, 592);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Диаграммы отчётов";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // button_request
            // 
            this.button_request.BackColor = System.Drawing.Color.LightGray;
            this.button_request.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_request.Location = new System.Drawing.Point(874, 624);
            this.button_request.Name = "button_request";
            this.button_request.Size = new System.Drawing.Size(91, 31);
            this.button_request.TabIndex = 5;
            this.button_request.Text = "Запросы";
            this.button_request.UseVisualStyleBackColor = false;
            this.button_request.Click += new System.EventHandler(this.button_request_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.button_xmlReaderImport);
            this.panel1.Controls.Add(this.button_xmlDocumentImport);
            this.panel1.Controls.Add(this.button_xmlDocumentExport);
            this.panel1.Controls.Add(this.button_xmlWriterExport);
            this.panel1.Controls.Add(this.button_paramRequest);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button_agrRequest);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(980, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 592);
            this.panel1.TabIndex = 6;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(23, 183);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(238, 118);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "SELECT *\nFROM Tourist\nWHERE first_name = @name | @name=Алексей";
            // 
            // button_xmlReaderImport
            // 
            this.button_xmlReaderImport.BackColor = System.Drawing.SystemColors.Info;
            this.button_xmlReaderImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_xmlReaderImport.Location = new System.Drawing.Point(3, 564);
            this.button_xmlReaderImport.Name = "button_xmlReaderImport";
            this.button_xmlReaderImport.Size = new System.Drawing.Size(132, 23);
            this.button_xmlReaderImport.TabIndex = 9;
            this.button_xmlReaderImport.Text = "Импорт XmlReader";
            this.button_xmlReaderImport.UseVisualStyleBackColor = false;
            this.button_xmlReaderImport.Click += new System.EventHandler(this.button_xmlReaderImport_Click);
            // 
            // button_xmlDocumentImport
            // 
            this.button_xmlDocumentImport.BackColor = System.Drawing.SystemColors.Info;
            this.button_xmlDocumentImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_xmlDocumentImport.Location = new System.Drawing.Point(143, 564);
            this.button_xmlDocumentImport.Name = "button_xmlDocumentImport";
            this.button_xmlDocumentImport.Size = new System.Drawing.Size(132, 23);
            this.button_xmlDocumentImport.TabIndex = 8;
            this.button_xmlDocumentImport.Text = "Импорт XmlDocument";
            this.button_xmlDocumentImport.UseVisualStyleBackColor = false;
            this.button_xmlDocumentImport.Click += new System.EventHandler(this.button_xmlDocumentImport_Click);
            // 
            // button_xmlDocumentExport
            // 
            this.button_xmlDocumentExport.BackColor = System.Drawing.SystemColors.Info;
            this.button_xmlDocumentExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_xmlDocumentExport.Location = new System.Drawing.Point(143, 539);
            this.button_xmlDocumentExport.Name = "button_xmlDocumentExport";
            this.button_xmlDocumentExport.Size = new System.Drawing.Size(132, 23);
            this.button_xmlDocumentExport.TabIndex = 7;
            this.button_xmlDocumentExport.Text = "Экспорт XmlDocument";
            this.button_xmlDocumentExport.UseVisualStyleBackColor = false;
            this.button_xmlDocumentExport.Click += new System.EventHandler(this.button_xmlDocumentExport_Click);
            // 
            // button_xmlWriterExport
            // 
            this.button_xmlWriterExport.BackColor = System.Drawing.SystemColors.Info;
            this.button_xmlWriterExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_xmlWriterExport.ForeColor = System.Drawing.Color.Black;
            this.button_xmlWriterExport.Location = new System.Drawing.Point(3, 539);
            this.button_xmlWriterExport.Name = "button_xmlWriterExport";
            this.button_xmlWriterExport.Size = new System.Drawing.Size(132, 23);
            this.button_xmlWriterExport.TabIndex = 6;
            this.button_xmlWriterExport.Text = "Экспорт XmlWriter";
            this.button_xmlWriterExport.UseVisualStyleBackColor = false;
            this.button_xmlWriterExport.Click += new System.EventHandler(this.button_xmlWriterExport_Click);
            // 
            // button_paramRequest
            // 
            this.button_paramRequest.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_paramRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_paramRequest.Location = new System.Drawing.Point(162, 307);
            this.button_paramRequest.Name = "button_paramRequest";
            this.button_paramRequest.Size = new System.Drawing.Size(99, 28);
            this.button_paramRequest.TabIndex = 5;
            this.button_paramRequest.Text = "Выполнить";
            this.button_paramRequest.UseVisualStyleBackColor = false;
            this.button_paramRequest.Click += new System.EventHandler(this.button_paramRequest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(20, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Параметризованный запрос";
            // 
            // button_agrRequest
            // 
            this.button_agrRequest.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_agrRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_agrRequest.Location = new System.Drawing.Point(162, 96);
            this.button_agrRequest.Name = "button_agrRequest";
            this.button_agrRequest.Size = new System.Drawing.Size(99, 28);
            this.button_agrRequest.TabIndex = 2;
            this.button_agrRequest.Text = "Выполнить";
            this.button_agrRequest.UseVisualStyleBackColor = false;
            this.button_agrRequest.Click += new System.EventHandler(this.button_agrRequest_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(238, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "SELECT COUNT(*) FROM Tourist";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Агрегированный запрос (MAX, MIN)";
            // 
            // chart_pie
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_pie.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_pie.Legends.Add(legend2);
            this.chart_pie.Location = new System.Drawing.Point(6, 6);
            this.chart_pie.Name = "chart_pie";
            this.chart_pie.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_pie.Series.Add(series2);
            this.chart_pie.Size = new System.Drawing.Size(493, 580);
            this.chart_pie.TabIndex = 0;
            this.chart_pie.Text = "chart1";
            // 
            // chart_bar
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_bar.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_bar.Legends.Add(legend1);
            this.chart_bar.Location = new System.Drawing.Point(505, 6);
            this.chart_bar.Name = "chart_bar";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_bar.Series.Add(series1);
            this.chart_bar.Size = new System.Drawing.Size(456, 580);
            this.chart_bar.TabIndex = 1;
            this.chart_bar.Text = "chart2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 667);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_request);
            this.Controls.Add(this.button_deleteRecord);
            this.Controls.Add(this.button_addChange);
            this.Controls.Add(this.button_addRecord);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Туристическая фирма";
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_pie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_bar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_addRecord;
        private System.Windows.Forms.Button button_addChange;
        private System.Windows.Forms.Button button_deleteRecord;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.Button button_request;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_paramRequest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_agrRequest;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_xmlReaderImport;
        private System.Windows.Forms.Button button_xmlDocumentImport;
        private System.Windows.Forms.Button button_xmlDocumentExport;
        private System.Windows.Forms.Button button_xmlWriterExport;
        private System.Windows.Forms.Button button_trigger;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_pie;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_bar;
    }
}

