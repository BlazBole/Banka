namespace Banka.UsersControls
{
    partial class UC_Dvig
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
            this.btnDvig = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDvig
            // 
            this.btnDvig.Location = new System.Drawing.Point(117, 291);
            this.btnDvig.Name = "btnDvig";
            this.btnDvig.Size = new System.Drawing.Size(75, 23);
            this.btnDvig.TabIndex = 0;
            this.btnDvig.Text = "button1";
            this.btnDvig.UseVisualStyleBackColor = true;
            this.btnDvig.Click += new System.EventHandler(this.btnDvig_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDvig);
            this.groupBox1.Location = new System.Drawing.Point(130, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 333);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // UC_Dvig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UC_Dvig";
            this.Size = new System.Drawing.Size(984, 445);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDvig;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
