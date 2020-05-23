namespace Lab04_DUCHP
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textKbegin = new System.Windows.Forms.TextBox();
            this.textKend = new System.Windows.Forms.TextBox();
            this.textAlphaBegin = new System.Windows.Forms.TextBox();
            this.textAlphaEnd = new System.Windows.Forms.TextBox();
            this.textL = new System.Windows.Forms.TextBox();
            this.textT0 = new System.Windows.Forms.TextBox();
            this.textR = new System.Windows.Forms.TextBox();
            this.textF0 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Вычислить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textKbegin
            // 
            this.textKbegin.Location = new System.Drawing.Point(119, 39);
            this.textKbegin.Name = "textKbegin";
            this.textKbegin.Size = new System.Drawing.Size(100, 26);
            this.textKbegin.TabIndex = 1;
            this.textKbegin.Text = "0,4";
            // 
            // textKend
            // 
            this.textKend.Location = new System.Drawing.Point(119, 82);
            this.textKend.Name = "textKend";
            this.textKend.Size = new System.Drawing.Size(100, 26);
            this.textKend.TabIndex = 2;
            this.textKend.Text = "0,1";
            // 
            // textAlphaBegin
            // 
            this.textAlphaBegin.Location = new System.Drawing.Point(119, 126);
            this.textAlphaBegin.Name = "textAlphaBegin";
            this.textAlphaBegin.Size = new System.Drawing.Size(100, 26);
            this.textAlphaBegin.TabIndex = 3;
            this.textAlphaBegin.Text = "0,05";
            // 
            // textAlphaEnd
            // 
            this.textAlphaEnd.Location = new System.Drawing.Point(119, 171);
            this.textAlphaEnd.Name = "textAlphaEnd";
            this.textAlphaEnd.Size = new System.Drawing.Size(100, 26);
            this.textAlphaEnd.TabIndex = 4;
            this.textAlphaEnd.Text = "0,01";
            // 
            // textL
            // 
            this.textL.Location = new System.Drawing.Point(119, 219);
            this.textL.Name = "textL";
            this.textL.Size = new System.Drawing.Size(100, 26);
            this.textL.TabIndex = 5;
            this.textL.Text = "10";
            // 
            // textT0
            // 
            this.textT0.Location = new System.Drawing.Point(119, 268);
            this.textT0.Name = "textT0";
            this.textT0.Size = new System.Drawing.Size(100, 26);
            this.textT0.TabIndex = 6;
            this.textT0.Text = "300";
            // 
            // textR
            // 
            this.textR.Location = new System.Drawing.Point(119, 313);
            this.textR.Name = "textR";
            this.textR.Size = new System.Drawing.Size(100, 26);
            this.textR.TabIndex = 7;
            this.textR.Text = "0,5";
            // 
            // textF0
            // 
            this.textF0.Location = new System.Drawing.Point(119, 358);
            this.textF0.Name = "textF0";
            this.textF0.Size = new System.Drawing.Size(100, 26);
            this.textF0.TabIndex = 8;
            this.textF0.Text = "50";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textL);
            this.groupBox1.Controls.Add(this.textF0);
            this.groupBox1.Controls.Add(this.textKbegin);
            this.groupBox1.Controls.Add(this.textR);
            this.groupBox1.Controls.Add(this.textKend);
            this.groupBox1.Controls.Add(this.textT0);
            this.groupBox1.Controls.Add(this.textAlphaBegin);
            this.groupBox1.Controls.Add(this.textAlphaEnd);
            this.groupBox1.Location = new System.Drawing.Point(25, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 467);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пожалуйста, введите даные";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 361);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "F0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "R";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "T0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "L";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "alphaN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "alpha0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "KN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "K0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1578, 744);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Lab3";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textKbegin;
        private System.Windows.Forms.TextBox textKend;
        private System.Windows.Forms.TextBox textAlphaBegin;
        private System.Windows.Forms.TextBox textAlphaEnd;
        private System.Windows.Forms.TextBox textL;
        private System.Windows.Forms.TextBox textT0;
        private System.Windows.Forms.TextBox textR;
        private System.Windows.Forms.TextBox textF0;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

