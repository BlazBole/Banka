﻿namespace Banka.UsersControls
{
    partial class UC_Nakazilo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPolog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPolog
            // 
            this.btnPolog.Location = new System.Drawing.Point(719, 204);
            this.btnPolog.Name = "btnPolog";
            this.btnPolog.Size = new System.Drawing.Size(75, 23);
            this.btnPolog.TabIndex = 0;
            this.btnPolog.Text = "button1";
            this.btnPolog.UseVisualStyleBackColor = true;
            this.btnPolog.Click += new System.EventHandler(this.btnPolog_Click);
            // 
            // UC_Polog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPolog);
            this.Name = "UC_Polog";
            this.Size = new System.Drawing.Size(984, 445);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPolog;
    }
}
