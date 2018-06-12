namespace scs1
{
    partial class CheckBalanceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckBalanceForm));
            this.RequestBalanceButton = new System.Windows.Forms.Button();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.balancelabeltext = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RequestBalanceButton
            // 
            this.RequestBalanceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestBalanceButton.Location = new System.Drawing.Point(147, 396);
            this.RequestBalanceButton.Name = "RequestBalanceButton";
            this.RequestBalanceButton.Size = new System.Drawing.Size(177, 45);
            this.RequestBalanceButton.TabIndex = 0;
            this.RequestBalanceButton.Text = "Send Request";
            this.RequestBalanceButton.UseVisualStyleBackColor = true;
            this.RequestBalanceButton.Click += new System.EventHandler(this.RequestBalanceButton_Click);
            // 
            // balanceLabel
            // 
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.balanceLabel.Location = new System.Drawing.Point(255, 140);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(0, 13);
            this.balanceLabel.TabIndex = 4;
            this.balanceLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // balancelabeltext
            // 
            this.balancelabeltext.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.balancelabeltext.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.balancelabeltext.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balancelabeltext.ForeColor = System.Drawing.Color.SeaGreen;
            this.balancelabeltext.Location = new System.Drawing.Point(138, 212);
            this.balancelabeltext.Name = "balancelabeltext";
            this.balancelabeltext.Size = new System.Drawing.Size(196, 37);
            this.balancelabeltext.TabIndex = 5;
            this.balancelabeltext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.balancelabeltext.Visible = false;
            // 
            // CheckBalanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(464, 471);
            this.Controls.Add(this.balancelabeltext);
            this.Controls.Add(this.balanceLabel);
            this.Controls.Add(this.RequestBalanceButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CheckBalanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balance Check";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RequestBalanceButton;
        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.Label balancelabeltext;
    }
}