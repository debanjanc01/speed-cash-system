namespace scs1
{
    partial class TransferForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferForm));
            this.label1 = new System.Windows.Forms.Label();
            this.accnoText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.amountText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.namelabelText = new System.Windows.Forms.Label();
            this.ifsclabelText = new System.Windows.Forms.Label();
            this.filldetailsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(159, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account No";
            // 
            // accnoText
            // 
            this.accnoText.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.accnoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accnoText.Location = new System.Drawing.Point(273, 53);
            this.accnoText.Name = "accnoText";
            this.accnoText.Size = new System.Drawing.Size(189, 24);
            this.accnoText.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(159, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Account Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(159, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Amount";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(255, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(369, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 45);
            this.button2.TabIndex = 8;
            this.button2.Text = "Proceed";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // amountText
            // 
            this.amountText.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.amountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountText.Location = new System.Drawing.Point(273, 167);
            this.amountText.Name = "amountText";
            this.amountText.Size = new System.Drawing.Size(189, 24);
            this.amountText.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(159, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "IFSC Code";
            // 
            // namelabelText
            // 
            this.namelabelText.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.namelabelText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.namelabelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelabelText.Location = new System.Drawing.Point(273, 95);
            this.namelabelText.Name = "namelabelText";
            this.namelabelText.Size = new System.Drawing.Size(189, 20);
            this.namelabelText.TabIndex = 13;
            this.namelabelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ifsclabelText
            // 
            this.ifsclabelText.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ifsclabelText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ifsclabelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ifsclabelText.Location = new System.Drawing.Point(273, 128);
            this.ifsclabelText.Name = "ifsclabelText";
            this.ifsclabelText.Size = new System.Drawing.Size(189, 20);
            this.ifsclabelText.TabIndex = 14;
            this.ifsclabelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // filldetailsButton
            // 
            this.filldetailsButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.filldetailsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filldetailsButton.Location = new System.Drawing.Point(497, 53);
            this.filldetailsButton.Name = "filldetailsButton";
            this.filldetailsButton.Size = new System.Drawing.Size(75, 23);
            this.filldetailsButton.TabIndex = 15;
            this.filldetailsButton.Text = "Fill Details";
            this.filldetailsButton.UseVisualStyleBackColor = false;
            this.filldetailsButton.Click += new System.EventHandler(this.filldetailsButton_Click);
            // 
            // TransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(692, 303);
            this.Controls.Add(this.filldetailsButton);
            this.Controls.Add(this.ifsclabelText);
            this.Controls.Add(this.namelabelText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.amountText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.accnoText);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TransferForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox accnoText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox amountText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label namelabelText;
        private System.Windows.Forms.Label ifsclabelText;
        private System.Windows.Forms.Button filldetailsButton;
    }
}