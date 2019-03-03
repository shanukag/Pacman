namespace PacmanIEDigital
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
            this.placeButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.displayBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Man = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Man)).BeginInit();
            this.SuspendLayout();
            // 
            // placeButton
            // 
            this.placeButton.AccessibleName = "placeButton";
            this.placeButton.Location = new System.Drawing.Point(398, 63);
            this.placeButton.Name = "placeButton";
            this.placeButton.Size = new System.Drawing.Size(75, 23);
            this.placeButton.TabIndex = 0;
            this.placeButton.Text = "Place";
            this.placeButton.UseVisualStyleBackColor = true;
            this.placeButton.Click += new System.EventHandler(this.placeButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.AccessibleName = "moveButton";
            this.moveButton.Location = new System.Drawing.Point(398, 100);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(75, 23);
            this.moveButton.TabIndex = 1;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.AccessibleName = "leftButton";
            this.leftButton.Location = new System.Drawing.Point(398, 138);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(75, 23);
            this.leftButton.TabIndex = 2;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.AccessibleName = "rightButton";
            this.rightButton.Location = new System.Drawing.Point(398, 176);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(75, 23);
            this.rightButton.TabIndex = 3;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // reportButton
            // 
            this.reportButton.AccessibleName = "reportButton";
            this.reportButton.Location = new System.Drawing.Point(398, 218);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(75, 23);
            this.reportButton.TabIndex = 4;
            this.reportButton.Text = "Report";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // displayBox
            // 
            this.displayBox.AccessibleName = "displayBox";
            this.displayBox.Location = new System.Drawing.Point(66, 63);
            this.displayBox.Name = "displayBox";
            this.displayBox.Size = new System.Drawing.Size(285, 20);
            this.displayBox.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(66, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(285, 285);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Man
            // 
            this.Man.BackColor = System.Drawing.SystemColors.Control;
            this.Man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Man.Location = new System.Drawing.Point(72, 325);
            this.Man.Name = "Man";
            this.Man.Size = new System.Drawing.Size(48, 50);
            this.Man.TabIndex = 7;
            this.Man.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 450);
            this.Controls.Add(this.Man);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.displayBox);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.placeButton);
            this.Name = "Form1";
            this.Text = "Pacman";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Man)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button placeButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.TextBox displayBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Man;
    }
}

