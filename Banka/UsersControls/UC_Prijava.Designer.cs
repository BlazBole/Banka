namespace Banka.UsersControls
{
    partial class UC_Prijava
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
            this.txtGeslo = new System.Windows.Forms.TextBox();
            this.txtUpIme = new System.Windows.Forms.TextBox();
            this.lblUpGeslo = new System.Windows.Forms.Label();
            this.lblUpIme = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrijava = new System.Windows.Forms.Button();
            this.lblRegistracija = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtGeslo
            // 
            this.txtGeslo.AccessibleDescription = "";
            this.txtGeslo.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtGeslo.ForeColor = System.Drawing.Color.DimGray;
            this.txtGeslo.Location = new System.Drawing.Point(85, 330);
            this.txtGeslo.Name = "txtGeslo";
            this.txtGeslo.Size = new System.Drawing.Size(382, 30);
            this.txtGeslo.TabIndex = 20;
            this.txtGeslo.Tag = "";
            // 
            // txtUpIme
            // 
            this.txtUpIme.AccessibleDescription = "";
            this.txtUpIme.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtUpIme.ForeColor = System.Drawing.Color.DimGray;
            this.txtUpIme.Location = new System.Drawing.Point(173, 280);
            this.txtUpIme.Name = "txtUpIme";
            this.txtUpIme.Size = new System.Drawing.Size(294, 30);
            this.txtUpIme.TabIndex = 19;
            this.txtUpIme.Tag = "";
            // 
            // lblUpGeslo
            // 
            this.lblUpGeslo.AutoSize = true;
            this.lblUpGeslo.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUpGeslo.Location = new System.Drawing.Point(23, 330);
            this.lblUpGeslo.Name = "lblUpGeslo";
            this.lblUpGeslo.Size = new System.Drawing.Size(56, 23);
            this.lblUpGeslo.TabIndex = 18;
            this.lblUpGeslo.Text = "Geslo:";
            // 
            // lblUpIme
            // 
            this.lblUpIme.AutoSize = true;
            this.lblUpIme.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUpIme.Location = new System.Drawing.Point(23, 280);
            this.lblUpIme.Name = "lblUpIme";
            this.lblUpIme.Size = new System.Drawing.Size(144, 23);
            this.lblUpIme.TabIndex = 17;
            this.lblUpIme.Text = "Uporabniško ime:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(135, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 32);
            this.label3.TabIndex = 16;
            this.label3.Text = "E-Banka - PRIJAVA";
            // 
            // btnPrijava
            // 
            this.btnPrijava.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrijava.BackColor = System.Drawing.Color.OrangeRed;
            this.btnPrijava.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrijava.FlatAppearance.BorderSize = 0;
            this.btnPrijava.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrijava.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrijava.ForeColor = System.Drawing.Color.White;
            this.btnPrijava.Location = new System.Drawing.Point(98, 407);
            this.btnPrijava.Name = "btnPrijava";
            this.btnPrijava.Size = new System.Drawing.Size(343, 34);
            this.btnPrijava.TabIndex = 21;
            this.btnPrijava.Text = "PRIJAVA";
            this.btnPrijava.UseVisualStyleBackColor = false;
            this.btnPrijava.Click += new System.EventHandler(this.btnPrijava_Click);
            // 
            // lblRegistracija
            // 
            this.lblRegistracija.AutoSize = true;
            this.lblRegistracija.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRegistracija.Location = new System.Drawing.Point(94, 468);
            this.lblRegistracija.Name = "lblRegistracija";
            this.lblRegistracija.Size = new System.Drawing.Size(241, 17);
            this.lblRegistracija.TabIndex = 22;
            this.lblRegistracija.Text = "Še niste registrirani? Registriraj se tukaj!";
            this.lblRegistracija.Click += new System.EventHandler(this.lblRegistracija_Click);
            // 
            // UC_Prijava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRegistracija);
            this.Controls.Add(this.btnPrijava);
            this.Controls.Add(this.txtGeslo);
            this.Controls.Add(this.txtUpIme);
            this.Controls.Add(this.lblUpGeslo);
            this.Controls.Add(this.lblUpIme);
            this.Controls.Add(this.label3);
            this.Name = "UC_Prijava";
            this.Size = new System.Drawing.Size(500, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGeslo;
        private System.Windows.Forms.TextBox txtUpIme;
        private System.Windows.Forms.Label lblUpGeslo;
        private System.Windows.Forms.Label lblUpIme;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrijava;
        private System.Windows.Forms.Label lblRegistracija;
    }
}
