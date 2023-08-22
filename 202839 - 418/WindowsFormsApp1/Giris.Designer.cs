namespace WindowsFormsApp1
{
    partial class Giris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Goster_Gizle_Giris = new System.Windows.Forms.Button();
            this.Cikis = new System.Windows.Forms.Button();
            this.Kayit_İslem = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Giris_Gonder = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(103, 312);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 1);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(103, 377);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(226, 1);
            this.panel3.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox1.Location = new System.Drawing.Point(103, 284);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(226, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.TabStop = false;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.MouseLeave += new System.EventHandler(this.textBox1_MouseLeave);
            this.textBox1.MouseHover += new System.EventHandler(this.textBox1_MouseHover);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox2.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox2.Location = new System.Drawing.Point(103, 348);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(226, 22);
            this.textBox2.TabIndex = 4;
            this.textBox2.TabStop = false;
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            this.textBox2.MouseLeave += new System.EventHandler(this.textBox2_MouseLeave);
            this.textBox2.MouseHover += new System.EventHandler(this.textBox2_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.Goster_Gizle_Giris);
            this.panel1.Controls.Add(this.Cikis);
            this.panel1.Controls.Add(this.Kayit_İslem);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.Giris_Gonder);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 470);
            this.panel1.TabIndex = 10;
            // 
            // Goster_Gizle_Giris
            // 
            this.Goster_Gizle_Giris.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.icons8_lock_30px;
            this.Goster_Gizle_Giris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Goster_Gizle_Giris.FlatAppearance.BorderSize = 0;
            this.Goster_Gizle_Giris.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.Goster_Gizle_Giris.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Goster_Gizle_Giris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Goster_Gizle_Giris.ForeColor = System.Drawing.SystemColors.Control;
            this.Goster_Gizle_Giris.Location = new System.Drawing.Point(326, 339);
            this.Goster_Gizle_Giris.Name = "Goster_Gizle_Giris";
            this.Goster_Gizle_Giris.Size = new System.Drawing.Size(39, 39);
            this.Goster_Gizle_Giris.TabIndex = 11;
            this.Goster_Gizle_Giris.UseVisualStyleBackColor = true;
            this.Goster_Gizle_Giris.Click += new System.EventHandler(this.Goster_Gizle_Giris_Click);
            // 
            // Cikis
            // 
            this.Cikis.BackColor = System.Drawing.SystemColors.Control;
            this.Cikis.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.icons8_delete_25px;
            this.Cikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Cikis.FlatAppearance.BorderSize = 0;
            this.Cikis.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.Cikis.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Cikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cikis.ForeColor = System.Drawing.SystemColors.Control;
            this.Cikis.Location = new System.Drawing.Point(3, 436);
            this.Cikis.Name = "Cikis";
            this.Cikis.Size = new System.Drawing.Size(33, 34);
            this.Cikis.TabIndex = 10;
            this.Cikis.UseVisualStyleBackColor = false;
            this.Cikis.Click += new System.EventHandler(this.Cikis_Click);
            this.Cikis.MouseLeave += new System.EventHandler(this.Cikis_MouseLeave);
            this.Cikis.MouseHover += new System.EventHandler(this.Cikis_MouseHover);
            // 
            // Kayit_İslem
            // 
            this.Kayit_İslem.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.icons8_new_copy_50px;
            this.Kayit_İslem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Kayit_İslem.FlatAppearance.BorderSize = 0;
            this.Kayit_İslem.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.Kayit_İslem.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Kayit_İslem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Kayit_İslem.ForeColor = System.Drawing.SystemColors.Control;
            this.Kayit_İslem.Location = new System.Drawing.Point(162, 390);
            this.Kayit_İslem.Name = "Kayit_İslem";
            this.Kayit_İslem.Size = new System.Drawing.Size(71, 66);
            this.Kayit_İslem.TabIndex = 9;
            this.Kayit_İslem.UseVisualStyleBackColor = true;
            this.Kayit_İslem.Click += new System.EventHandler(this.Kayit_İslem_Click);
            this.Kayit_İslem.MouseLeave += new System.EventHandler(this.Kayit_İslem_MouseLeave);
            this.Kayit_İslem.MouseHover += new System.EventHandler(this.Kayit_İslem_MouseHover);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(391, 243);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApp1.Properties.Resources.icons8_male_user_30px;
            this.pictureBox2.Location = new System.Drawing.Point(46, 274);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // Giris_Gonder
            // 
            this.Giris_Gonder.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.icons8_login_50px;
            this.Giris_Gonder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Giris_Gonder.FlatAppearance.BorderSize = 0;
            this.Giris_Gonder.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.Giris_Gonder.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.Giris_Gonder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Giris_Gonder.ForeColor = System.Drawing.SystemColors.Control;
            this.Giris_Gonder.Location = new System.Drawing.Point(305, 401);
            this.Giris_Gonder.Name = "Giris_Gonder";
            this.Giris_Gonder.Size = new System.Drawing.Size(72, 66);
            this.Giris_Gonder.TabIndex = 7;
            this.Giris_Gonder.UseVisualStyleBackColor = true;
            this.Giris_Gonder.Click += new System.EventHandler(this.Giris_Gonder_Click);
            this.Giris_Gonder.MouseLeave += new System.EventHandler(this.Giris_Gonder_MouseLeave);
            this.Giris_Gonder.MouseHover += new System.EventHandler(this.Giris_Gonder_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.icons8_secure_30px;
            this.pictureBox1.Location = new System.Drawing.Point(46, 339);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(389, 470);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Giris";
            this.Text = "Giris";
            this.Load += new System.EventHandler(this.Giris_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button Giris_Gonder;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button Kayit_İslem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Cikis;
        private System.Windows.Forms.Button Goster_Gizle_Giris;
    }
}

