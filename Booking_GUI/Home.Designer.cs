
namespace Booking_GUI
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btn_add = new Button();
            btn_view = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("NewYork", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(213, 46);
            label1.Name = "label1";
            label1.Size = new Size(367, 52);
            label1.TabIndex = 0;
            label1.Text = "LASH AND NAILS";
            // 
            // btn_add
            // 
            btn_add.Font = new Font("Rockwell", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_add.Location = new Point(422, 188);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(311, 37);
            btn_add.TabIndex = 1;
            btn_add.Text = "Add Appointment";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // btn_view
            // 
            btn_view.BackColor = Color.Transparent;
            btn_view.Font = new Font("Rockwell", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_view.ForeColor = SystemColors.ControlText;
            btn_view.Location = new Point(422, 257);
            btn_view.Name = "btn_view";
            btn_view.Size = new Size(311, 37);
            btn_view.TabIndex = 2;
            btn_view.Text = "View Appointment";
            btn_view.UseVisualStyleBackColor = false;
            btn_view.Click += btn_view_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.HOMEPAGE;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_view);
            Controls.Add(btn_add);
            Controls.Add(label1);
            Name = "Home";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_add;
        private Button btn_view;
    }
}
