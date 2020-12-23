
namespace WAR_Card_Game
{
    partial class IntroFormWAR
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
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtBxTopPlayerName = new System.Windows.Forms.TextBox();
            this.txtBxBottomPlayerName = new System.Windows.Forms.TextBox();
            this.lblTopPlayerName = new System.Windows.Forms.Label();
            this.lblBottomPlayerName = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(260, 321);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(95, 37);
            this.btnContinue.TabIndex = 2;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Red;
            this.lblWelcome.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(137, 98);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(526, 32);
            this.lblWelcome.TabIndex = 3;
            this.lblWelcome.Text = "Welcome to WAR!!! ... the card game!";
            // 
            // txtBxTopPlayerName
            // 
            this.txtBxTopPlayerName.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBxTopPlayerName.Location = new System.Drawing.Point(479, 170);
            this.txtBxTopPlayerName.Name = "txtBxTopPlayerName";
            this.txtBxTopPlayerName.Size = new System.Drawing.Size(184, 30);
            this.txtBxTopPlayerName.TabIndex = 0;
            // 
            // txtBxBottomPlayerName
            // 
            this.txtBxBottomPlayerName.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBxBottomPlayerName.Location = new System.Drawing.Point(479, 240);
            this.txtBxBottomPlayerName.Name = "txtBxBottomPlayerName";
            this.txtBxBottomPlayerName.Size = new System.Drawing.Size(184, 30);
            this.txtBxBottomPlayerName.TabIndex = 1;
            // 
            // lblTopPlayerName
            // 
            this.lblTopPlayerName.AutoSize = true;
            this.lblTopPlayerName.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopPlayerName.Location = new System.Drawing.Point(139, 173);
            this.lblTopPlayerName.Name = "lblTopPlayerName";
            this.lblTopPlayerName.Size = new System.Drawing.Size(301, 24);
            this.lblTopPlayerName.TabIndex = 4;
            this.lblTopPlayerName.Text = "Enter the Top Player\'s first name: ";
            // 
            // lblBottomPlayerName
            // 
            this.lblBottomPlayerName.AutoSize = true;
            this.lblBottomPlayerName.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomPlayerName.Location = new System.Drawing.Point(139, 243);
            this.lblBottomPlayerName.Name = "lblBottomPlayerName";
            this.lblBottomPlayerName.Size = new System.Drawing.Size(334, 24);
            this.lblBottomPlayerName.TabIndex = 5;
            this.lblBottomPlayerName.Text = "Enter the Bottom Player\'s first name: ";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(445, 321);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(95, 37);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // InfoFormWAR
            // 
            this.AcceptButton = this.btnContinue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblBottomPlayerName);
            this.Controls.Add(this.lblTopPlayerName);
            this.Controls.Add(this.txtBxBottomPlayerName);
            this.Controls.Add(this.txtBxTopPlayerName);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnContinue);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoFormWAR";
            this.Text = "Intro Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IntroFormClosing);
            this.Load += new System.EventHandler(this.IntroFormWAR_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblTopPlayerName;
        private System.Windows.Forms.Label lblBottomPlayerName;
        public System.Windows.Forms.TextBox txtBxTopPlayerName;
        public System.Windows.Forms.TextBox txtBxBottomPlayerName;
        private System.Windows.Forms.Button btnExit;
    }
}