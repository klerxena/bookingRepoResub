namespace Booking_GUI
{
    partial class ADD
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            txtname = new TextBox();
            textbday = new TextBox();
            textdate = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Rockwell", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 50);
            label1.Name = "label1";
            label1.Size = new Size(273, 24);
            label1.TabIndex = 0;
            label1.Text = "BOOK AN APPOINTMENT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Rockwell", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(70, 135);
            label2.Name = "label2";
            label2.Size = new Size(116, 38);
            label2.TabIndex = 1;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Rockwell", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(70, 191);
            label3.Name = "label3";
            label3.Size = new Size(157, 38);
            label3.TabIndex = 2;
            label3.Text = "Birthday:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Rockwell", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(70, 250);
            label4.Name = "label4";
            label4.Size = new Size(299, 38);
            label4.TabIndex = 3;
            label4.Text = "Appointment Date:";
            // 
            // button1
            // 
            button1.Location = new Point(509, 388);
            button1.Name = "button1";
            button1.Size = new Size(121, 36);
            button1.TabIndex = 4;
            button1.Text = "ADD";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(651, 388);
            button2.Name = "button2";
            button2.Size = new Size(121, 36);
            button2.TabIndex = 5;
            button2.Text = "EXIT";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtname
            // 
            txtname.Location = new Point(523, 126);
            txtname.Multiline = true;
            txtname.Name = "txtname";
            txtname.Size = new Size(249, 47);
            txtname.TabIndex = 6;
            // 
            // textbday
            // 
            textbday.Location = new Point(523, 191);
            textbday.Multiline = true;
            textbday.Name = "textbday";
            textbday.Size = new Size(249, 47);
            textbday.TabIndex = 7;
            // 
            // textdate
            // 
            textdate.Location = new Point(523, 260);
            textdate.Multiline = true;
            textdate.Name = "textdate";
            textdate.Size = new Size(249, 47);
            textdate.TabIndex = 8;
            // 
            // ADD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ADD;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(textdate);
            Controls.Add(textbday);
            Controls.Add(txtname);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ADD";
            Text = "ADD";
            Load += ADD_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
        private TextBox txtname;
        private TextBox textbday;
        private TextBox textdate;
    }
}