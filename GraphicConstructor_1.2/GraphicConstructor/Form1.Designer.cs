namespace GraphicConstructor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox_Function = new System.Windows.Forms.TextBox();
            this.contextMenuStripFunc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDend = new System.Windows.Forms.TextBox();
            this.textBoxDbeg = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxEpsStep = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PointCheckBox = new System.Windows.Forms.CheckBox();
            this.Update_button = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxY0 = new System.Windows.Forms.TextBox();
            this.Okrestnost_button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Build_button = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.ZGcontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьИзображениеКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменаМасштабированияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.масштабНаНачальныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показыватьЗначенияТочекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Clear_button = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox_Width = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_MinWidth = new System.Windows.Forms.TextBox();
            this.textBox_CurentWidth = new System.Windows.Forms.TextBox();
            this.listBox_delta = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.кToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button_help = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.GraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewNetzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewOXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.ZGcontextMenuStrip.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Function
            // 
            this.textBox_Function.ContextMenuStrip = this.contextMenuStripFunc;
            this.textBox_Function.Location = new System.Drawing.Point(42, 13);
            this.textBox_Function.Name = "textBox_Function";
            this.textBox_Function.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_Function.Size = new System.Drawing.Size(181, 20);
            this.textBox_Function.TabIndex = 0;
            this.textBox_Function.TextChanged += new System.EventHandler(this.textBox_Function_TextChanged);
            this.textBox_Function.Click += new System.EventHandler(this.textBox_Function_Click);
            // 
            // contextMenuStripFunc
            // 
            this.contextMenuStripFunc.Name = "contextMenuStrip2";
            this.contextMenuStripFunc.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "f(x) =";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxDend);
            this.groupBox1.Controls.Add(this.textBoxDbeg);
            this.groupBox1.Location = new System.Drawing.Point(6, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 68);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Интервал построения";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "До";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "От ";
            // 
            // textBoxDend
            // 
            this.textBoxDend.Location = new System.Drawing.Point(33, 42);
            this.textBoxDend.Name = "textBoxDend";
            this.textBoxDend.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxDend.Size = new System.Drawing.Size(92, 20);
            this.textBoxDend.TabIndex = 1;
            this.textBoxDend.Click += new System.EventHandler(this.textBoxDend_Click);
            this.textBoxDend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDend_KeyPress);
            this.textBoxDend.Enter += new System.EventHandler(this.TextBoxEnter);
            // 
            // textBoxDbeg
            // 
            this.textBoxDbeg.Location = new System.Drawing.Point(33, 16);
            this.textBoxDbeg.Name = "textBoxDbeg";
            this.textBoxDbeg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxDbeg.Size = new System.Drawing.Size(92, 20);
            this.textBoxDbeg.TabIndex = 0;
            this.textBoxDbeg.Click += new System.EventHandler(this.textBoxDbeg_Click);
            this.textBoxDbeg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDbeg_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBoxEpsStep);
            this.groupBox2.Location = new System.Drawing.Point(6, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(137, 45);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Шаг построения";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 22);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "r =";
            // 
            // textBoxEpsStep
            // 
            this.textBoxEpsStep.Location = new System.Drawing.Point(30, 19);
            this.textBoxEpsStep.Name = "textBoxEpsStep";
            this.textBoxEpsStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxEpsStep.Size = new System.Drawing.Size(101, 20);
            this.textBoxEpsStep.TabIndex = 14;
            this.textBoxEpsStep.Click += new System.EventHandler(this.textBoxEpsStep_Click);
            this.textBoxEpsStep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEpsStep_KeyPress);
            this.textBoxEpsStep.Enter += new System.EventHandler(this.TextBoxEnter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PointCheckBox);
            this.groupBox3.Controls.Add(this.Update_button);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBox_Function);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.Build_button);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(1, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(229, 226);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Функция";
            // 
            // PointCheckBox
            // 
            this.PointCheckBox.AutoSize = true;
            this.PointCheckBox.Checked = true;
            this.PointCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PointCheckBox.Location = new System.Drawing.Point(143, 86);
            this.PointCheckBox.Name = "PointCheckBox";
            this.PointCheckBox.Size = new System.Drawing.Size(77, 17);
            this.PointCheckBox.TabIndex = 36;
            this.PointCheckBox.Text = "с точками";
            this.PointCheckBox.UseVisualStyleBackColor = true;
            // 
            // Update_button
            // 
            this.Update_button.Enabled = false;
            this.Update_button.Location = new System.Drawing.Point(152, 113);
            this.Update_button.Name = "Update_button";
            this.Update_button.Size = new System.Drawing.Size(71, 45);
            this.Update_button.TabIndex = 28;
            this.Update_button.Text = "Обновить";
            this.Update_button.UseVisualStyleBackColor = true;
            this.Update_button.Click += new System.EventHandler(this.Update_button_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.textBoxY0);
            this.groupBox4.Controls.Add(this.Okrestnost_button);
            this.groupBox4.Location = new System.Drawing.Point(6, 164);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(217, 52);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Расположение эпсилон-трубки";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 23);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "y0 =";
            // 
            // textBoxY0
            // 
            this.textBoxY0.Location = new System.Drawing.Point(36, 20);
            this.textBoxY0.Name = "textBoxY0";
            this.textBoxY0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxY0.Size = new System.Drawing.Size(95, 20);
            this.textBoxY0.TabIndex = 26;
            this.textBoxY0.Click += new System.EventHandler(this.textBoxY0_Click);
            this.textBoxY0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxY0_KeyPress);
            // 
            // Okrestnost_button
            // 
            this.Okrestnost_button.Enabled = false;
            this.Okrestnost_button.Location = new System.Drawing.Point(146, 19);
            this.Okrestnost_button.Name = "Okrestnost_button";
            this.Okrestnost_button.Size = new System.Drawing.Size(65, 22);
            this.Okrestnost_button.TabIndex = 18;
            this.Okrestnost_button.Text = "Показать окрестность точки";
            this.Okrestnost_button.UseVisualStyleBackColor = true;
            this.Okrestnost_button.Click += new System.EventHandler(this.Okrestnost_button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(175, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.Visible = false;
            // 
            // Build_button
            // 
            this.Build_button.Location = new System.Drawing.Point(152, 39);
            this.Build_button.Name = "Build_button";
            this.Build_button.Size = new System.Drawing.Size(71, 41);
            this.Build_button.TabIndex = 14;
            this.Build_button.Text = "Построить";
            this.Build_button.UseVisualStyleBackColor = true;
            this.Build_button.Click += new System.EventHandler(this.Build_button_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.ContextMenuStrip = this.ZGcontextMenuStrip;
            this.zedGraphControl1.Location = new System.Drawing.Point(236, 27);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(795, 536);
            this.zedGraphControl1.TabIndex = 13;
            this.zedGraphControl1.Resize += new System.EventHandler(this.Form1_Resize);
            // 
            // ZGcontextMenuStrip
            // 
            this.ZGcontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.копироватьToolStripMenuItem,
            this.сохранитьИзображениеКакToolStripMenuItem,
            this.отменаМасштабированияToolStripMenuItem,
            this.масштабНаНачальныйToolStripMenuItem,
            this.показыватьЗначенияТочекToolStripMenuItem});
            this.ZGcontextMenuStrip.Name = "ZGcontextMenuStrip";
            this.ZGcontextMenuStrip.Size = new System.Drawing.Size(258, 114);
            this.ZGcontextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ZGcontextMenuStrip_Opening);
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            this.копироватьToolStripMenuItem.Click += new System.EventHandler(this.копироватьToolStripMenuItem_Click);
            // 
            // сохранитьИзображениеКакToolStripMenuItem
            // 
            this.сохранитьИзображениеКакToolStripMenuItem.Name = "сохранитьИзображениеКакToolStripMenuItem";
            this.сохранитьИзображениеКакToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.сохранитьИзображениеКакToolStripMenuItem.Text = "Сохранить изображение как...";
            this.сохранитьИзображениеКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьИзображениеКакToolStripMenuItem_Click);
            // 
            // отменаМасштабированияToolStripMenuItem
            // 
            this.отменаМасштабированияToolStripMenuItem.Name = "отменаМасштабированияToolStripMenuItem";
            this.отменаМасштабированияToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.отменаМасштабированияToolStripMenuItem.Text = "Отмена масштабирования";
            this.отменаМасштабированияToolStripMenuItem.Click += new System.EventHandler(this.отменаМасштабированияToolStripMenuItem_Click);
            // 
            // масштабНаНачальныйToolStripMenuItem
            // 
            this.масштабНаНачальныйToolStripMenuItem.Name = "масштабНаНачальныйToolStripMenuItem";
            this.масштабНаНачальныйToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.масштабНаНачальныйToolStripMenuItem.Text = "Масштаб в начальное состояние";
            this.масштабНаНачальныйToolStripMenuItem.Click += new System.EventHandler(this.масштабНаНачальныйToolStripMenuItem_Click);
            // 
            // показыватьЗначенияТочекToolStripMenuItem
            // 
            this.показыватьЗначенияТочекToolStripMenuItem.Name = "показыватьЗначенияТочекToolStripMenuItem";
            this.показыватьЗначенияТочекToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.показыватьЗначенияТочекToolStripMenuItem.Text = "Показывать значения точек";
            this.показыватьЗначенияТочекToolStripMenuItem.Click += new System.EventHandler(this.показыватьЗначенияТочекToolStripMenuItem_Click);
            // 
            // Clear_button
            // 
            this.Clear_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Clear_button.Enabled = false;
            this.Clear_button.Location = new System.Drawing.Point(115, 490);
            this.Clear_button.Name = "Clear_button";
            this.Clear_button.Size = new System.Drawing.Size(115, 22);
            this.Clear_button.TabIndex = 22;
            this.Clear_button.Text = "Очистить";
            this.Clear_button.UseVisualStyleBackColor = true;
            this.Clear_button.Click += new System.EventHandler(this.Clear_button_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.groupBox8);
            this.groupBox5.Controls.Add(this.listBox_delta);
            this.groupBox5.Location = new System.Drawing.Point(1, 254);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(229, 230);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Дельта-трубки";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.listBox_Width);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.textBox_MinWidth);
            this.groupBox8.Controls.Add(this.textBox_CurentWidth);
            this.groupBox8.Location = new System.Drawing.Point(105, 10);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox8.Size = new System.Drawing.Size(118, 214);
            this.groupBox8.TabIndex = 33;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Ширина";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Все значения";
            // 
            // listBox_Width
            // 
            this.listBox_Width.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_Width.FormattingEnabled = true;
            this.listBox_Width.Location = new System.Drawing.Point(6, 114);
            this.listBox_Width.Name = "listBox_Width";
            this.listBox_Width.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox_Width.Size = new System.Drawing.Size(106, 95);
            this.listBox_Width.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Выделенной";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Минимальной";
            // 
            // textBox_MinWidth
            // 
            this.textBox_MinWidth.Location = new System.Drawing.Point(6, 71);
            this.textBox_MinWidth.Name = "textBox_MinWidth";
            this.textBox_MinWidth.ReadOnly = true;
            this.textBox_MinWidth.Size = new System.Drawing.Size(106, 20);
            this.textBox_MinWidth.TabIndex = 29;
            // 
            // textBox_CurentWidth
            // 
            this.textBox_CurentWidth.Location = new System.Drawing.Point(6, 32);
            this.textBox_CurentWidth.Name = "textBox_CurentWidth";
            this.textBox_CurentWidth.ReadOnly = true;
            this.textBox_CurentWidth.Size = new System.Drawing.Size(106, 20);
            this.textBox_CurentWidth.TabIndex = 30;
            // 
            // listBox_delta
            // 
            this.listBox_delta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_delta.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox_delta.FormattingEnabled = true;
            this.listBox_delta.Location = new System.Drawing.Point(9, 19);
            this.listBox_delta.Name = "listBox_delta";
            this.listBox_delta.Size = new System.Drawing.Size(90, 199);
            this.listBox_delta.TabIndex = 26;
            this.listBox_delta.SelectedIndexChanged += new System.EventHandler(this.listBox_delta_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 26);
            // 
            // кToolStripMenuItem
            // 
            this.кToolStripMenuItem.Name = "кToolStripMenuItem";
            this.кToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.кToolStripMenuItem.Text = "Показать таблицу";
            this.кToolStripMenuItem.Click += new System.EventHandler(this.ViewTableToolStripMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(1, 518);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(229, 32);
            this.progressBar1.TabIndex = 33;
            // 
            // button_help
            // 
            this.button_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_help.Location = new System.Drawing.Point(1, 490);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(111, 22);
            this.button_help.TabIndex = 34;
            this.button_help.Text = "Справка";
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GraphToolStripMenuItem,
            this.фонToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.ShowItemToolTips = true;
            this.menu.Size = new System.Drawing.Size(1031, 24);
            this.menu.TabIndex = 38;
            this.menu.Text = "График";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // GraphToolStripMenuItem
            // 
            this.GraphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewNetzToolStripMenuItem,
            this.ViewOXToolStripMenuItem});
            this.GraphToolStripMenuItem.Name = "GraphToolStripMenuItem";
            this.GraphToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.GraphToolStripMenuItem.Text = "График";
            this.GraphToolStripMenuItem.Click += new System.EventHandler(this.GraphToolStripMenuItem_Click);
            // 
            // ViewNetzToolStripMenuItem
            // 
            this.ViewNetzToolStripMenuItem.Name = "ViewNetzToolStripMenuItem";
            this.ViewNetzToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.ViewNetzToolStripMenuItem.Text = "Показать сетку";
            this.ViewNetzToolStripMenuItem.Click += new System.EventHandler(this.ViewNetzToolStripMenuItem_Click);
            // 
            // ViewOXToolStripMenuItem
            // 
            this.ViewOXToolStripMenuItem.Name = "ViewOXToolStripMenuItem";
            this.ViewOXToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.ViewOXToolStripMenuItem.Text = "Сокрыть оси координат";
            this.ViewOXToolStripMenuItem.Click += new System.EventHandler(this.ViewOXToolStripMenuItem_Click);
            // 
            // фонToolStripMenuItem
            // 
            this.фонToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackgroundToolStripMenuItem});
            this.фонToolStripMenuItem.Name = "фонToolStripMenuItem";
            this.фонToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.фонToolStripMenuItem.Text = "Фон";
            // 
            // BackgroundToolStripMenuItem
            // 
            this.BackgroundToolStripMenuItem.Name = "BackgroundToolStripMenuItem";
            this.BackgroundToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.BackgroundToolStripMenuItem.Text = "Включить фон";
            this.BackgroundToolStripMenuItem.Click += new System.EventHandler(this.BackgroundToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1031, 562);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Clear_button);
            this.Controls.Add(this.button_help);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "Form1";
            this.Text = "Построитель графиков, эпсилон и дельта трубок ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ZGcontextMenuStrip.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Function;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDbeg;
        private System.Windows.Forms.TextBox textBoxDend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxEpsStep;
        private System.Windows.Forms.GroupBox groupBox3;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button Build_button;
        private System.Windows.Forms.Button Okrestnost_button;
        private System.Windows.Forms.Button Clear_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxY0;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox listBox_delta;
        private System.Windows.Forms.TextBox textBox_MinWidth;
        private System.Windows.Forms.TextBox textBox_CurentWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox_Width;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Button Update_button;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem кToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem GraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фонToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewNetzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewOXToolStripMenuItem;
        private System.Windows.Forms.CheckBox PointCheckBox;
        private System.Windows.Forms.ContextMenuStrip ZGcontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьИзображениеКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменаМасштабированияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem масштабНаНачальныйToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFunc;
        private System.Windows.Forms.ToolStripMenuItem показыватьЗначенияТочекToolStripMenuItem;
    }
}

