namespace GraphLab2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textTw = new System.Windows.Forms.TextBox();
            this.labelCk = new System.Windows.Forms.Label();
            this.textCk = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textLk = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textRk = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textUc0 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textI0 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textL0 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textTbeg = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textTend = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textTstep = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1659, 874);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1287, 554);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // textR
            // 
            this.textR.Location = new System.Drawing.Point(1749, 589);
            this.textR.Name = "textR";
            this.textR.ReadOnly = true;
            this.textR.Size = new System.Drawing.Size(102, 26);
            this.textR.TabIndex = 2;
            this.textR.Text = "0,35";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1681, 592);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "R";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1681, 626);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tw";
            // 
            // textTw
            // 
            this.textTw.Location = new System.Drawing.Point(1749, 623);
            this.textTw.Name = "textTw";
            this.textTw.ReadOnly = true;
            this.textTw.Size = new System.Drawing.Size(102, 26);
            this.textTw.TabIndex = 4;
            this.textTw.Text = "2000";
            // 
            // labelCk
            // 
            this.labelCk.AutoSize = true;
            this.labelCk.Location = new System.Drawing.Point(1681, 660);
            this.labelCk.Name = "labelCk";
            this.labelCk.Size = new System.Drawing.Size(28, 20);
            this.labelCk.TabIndex = 7;
            this.labelCk.Text = "Ck";
            // 
            // textCk
            // 
            this.textCk.Location = new System.Drawing.Point(1749, 657);
            this.textCk.Name = "textCk";
            this.textCk.Size = new System.Drawing.Size(102, 26);
            this.textCk.TabIndex = 6;
            this.textCk.Text = "150";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1681, 696);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Lk";
            // 
            // textLk
            // 
            this.textLk.Location = new System.Drawing.Point(1749, 693);
            this.textLk.Name = "textLk";
            this.textLk.Size = new System.Drawing.Size(102, 26);
            this.textLk.TabIndex = 8;
            this.textLk.Text = "60";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1681, 731);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Rk";
            // 
            // textRk
            // 
            this.textRk.Location = new System.Drawing.Point(1749, 728);
            this.textRk.Name = "textRk";
            this.textRk.Size = new System.Drawing.Size(102, 26);
            this.textRk.TabIndex = 10;
            this.textRk.Text = "0,5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1681, 765);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Uc0";
            // 
            // textUc0
            // 
            this.textUc0.Location = new System.Drawing.Point(1749, 762);
            this.textUc0.Name = "textUc0";
            this.textUc0.Size = new System.Drawing.Size(102, 26);
            this.textUc0.TabIndex = 12;
            this.textUc0.Text = "1500";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1681, 803);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "I0";
            // 
            // textI0
            // 
            this.textI0.Location = new System.Drawing.Point(1749, 800);
            this.textI0.Name = "textI0";
            this.textI0.Size = new System.Drawing.Size(102, 26);
            this.textI0.TabIndex = 14;
            this.textI0.Text = "0,5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1682, 554);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "L0";
            // 
            // textL0
            // 
            this.textL0.Location = new System.Drawing.Point(1750, 551);
            this.textL0.Name = "textL0";
            this.textL0.ReadOnly = true;
            this.textL0.Size = new System.Drawing.Size(102, 26);
            this.textL0.TabIndex = 16;
            this.textL0.Text = "12";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1289, 830);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Tbegin";
            // 
            // textTbeg
            // 
            this.textTbeg.Location = new System.Drawing.Point(1357, 827);
            this.textTbeg.Name = "textTbeg";
            this.textTbeg.Size = new System.Drawing.Size(102, 26);
            this.textTbeg.TabIndex = 18;
            this.textTbeg.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1289, 862);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Tend";
            // 
            // textTend
            // 
            this.textTend.Location = new System.Drawing.Point(1357, 859);
            this.textTend.Name = "textTend";
            this.textTend.Size = new System.Drawing.Size(102, 26);
            this.textTend.TabIndex = 20;
            this.textTend.Text = "5e-3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1289, 894);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Tstep";
            // 
            // textTstep
            // 
            this.textTstep.Location = new System.Drawing.Point(1357, 891);
            this.textTstep.Name = "textTstep";
            this.textTstep.Size = new System.Drawing.Size(102, 26);
            this.textTstep.TabIndex = 22;
            this.textTstep.Text = "1e-6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 1005);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textTstep);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textTend);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textTbeg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textL0);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textI0);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textUc0);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textRk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textLk);
            this.Controls.Add(this.labelCk);
            this.Controls.Add(this.textCk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textTw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textR);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Laba 2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTw;
        private System.Windows.Forms.Label labelCk;
        private System.Windows.Forms.TextBox textCk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textLk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textRk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textUc0;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textI0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textL0;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textTbeg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textTend;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textTstep;
    }
}

