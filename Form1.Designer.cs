﻿namespace DatabaseHotelUas
{
    partial class form_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_main));
            this.btn_bookKamar = new System.Windows.Forms.Button();
            this.btn_checktrans = new System.Windows.Forms.Button();
            this.gb_kamar = new System.Windows.Forms.GroupBox();
            this.btn_lihatkamar = new System.Windows.Forms.Button();
            this.btn_restoran = new System.Windows.Forms.Button();
            this.gb_restoran = new System.Windows.Forms.GroupBox();
            this.gb_pelanggan = new System.Windows.Forms.GroupBox();
            this.btn_tmbhPelanggan = new System.Windows.Forms.Button();
            this.btn_cekidPelanggan = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gb_kamar.SuspendLayout();
            this.gb_restoran.SuspendLayout();
            this.gb_pelanggan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_bookKamar
            // 
            this.btn_bookKamar.Location = new System.Drawing.Point(46, 442);
            this.btn_bookKamar.Name = "btn_bookKamar";
            this.btn_bookKamar.Size = new System.Drawing.Size(158, 54);
            this.btn_bookKamar.TabIndex = 0;
            this.btn_bookKamar.Text = "Book Kamar";
            this.btn_bookKamar.UseVisualStyleBackColor = true;
            this.btn_bookKamar.Click += new System.EventHandler(this.btn_bookKamar_Click);
            // 
            // btn_checktrans
            // 
            this.btn_checktrans.Location = new System.Drawing.Point(226, 442);
            this.btn_checktrans.Name = "btn_checktrans";
            this.btn_checktrans.Size = new System.Drawing.Size(158, 54);
            this.btn_checktrans.TabIndex = 11;
            this.btn_checktrans.Text = "Cek Transaksi";
            this.btn_checktrans.UseVisualStyleBackColor = true;
            this.btn_checktrans.Click += new System.EventHandler(this.button2_Click);
            // 
            // gb_kamar
            // 
            this.gb_kamar.Controls.Add(this.btn_lihatkamar);
            this.gb_kamar.Location = new System.Drawing.Point(437, 201);
            this.gb_kamar.Name = "gb_kamar";
            this.gb_kamar.Size = new System.Drawing.Size(460, 100);
            this.gb_kamar.TabIndex = 12;
            this.gb_kamar.TabStop = false;
            this.gb_kamar.Text = "Kamar";
            // 
            // btn_lihatkamar
            // 
            this.btn_lihatkamar.Location = new System.Drawing.Point(26, 31);
            this.btn_lihatkamar.Name = "btn_lihatkamar";
            this.btn_lihatkamar.Size = new System.Drawing.Size(158, 54);
            this.btn_lihatkamar.TabIndex = 13;
            this.btn_lihatkamar.Text = "Lihat Kamar";
            this.btn_lihatkamar.UseVisualStyleBackColor = true;
            this.btn_lihatkamar.Click += new System.EventHandler(this.btn_lihatkamar_Click);
            // 
            // btn_restoran
            // 
            this.btn_restoran.Location = new System.Drawing.Point(26, 40);
            this.btn_restoran.Name = "btn_restoran";
            this.btn_restoran.Size = new System.Drawing.Size(158, 54);
            this.btn_restoran.TabIndex = 14;
            this.btn_restoran.Text = "Restoran";
            this.btn_restoran.UseVisualStyleBackColor = true;
            this.btn_restoran.Click += new System.EventHandler(this.btn_fasilitasKamar_Click);
            // 
            // gb_restoran
            // 
            this.gb_restoran.Controls.Add(this.btn_restoran);
            this.gb_restoran.Location = new System.Drawing.Point(437, 307);
            this.gb_restoran.Name = "gb_restoran";
            this.gb_restoran.Size = new System.Drawing.Size(460, 107);
            this.gb_restoran.TabIndex = 14;
            this.gb_restoran.TabStop = false;
            this.gb_restoran.Text = "Restoran";
            // 
            // gb_pelanggan
            // 
            this.gb_pelanggan.Controls.Add(this.btn_tmbhPelanggan);
            this.gb_pelanggan.Controls.Add(this.btn_cekidPelanggan);
            this.gb_pelanggan.Location = new System.Drawing.Point(437, 420);
            this.gb_pelanggan.Name = "gb_pelanggan";
            this.gb_pelanggan.Size = new System.Drawing.Size(460, 107);
            this.gb_pelanggan.TabIndex = 15;
            this.gb_pelanggan.TabStop = false;
            this.gb_pelanggan.Text = "Pelanggan";
            this.gb_pelanggan.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btn_tmbhPelanggan
            // 
            this.btn_tmbhPelanggan.Location = new System.Drawing.Point(275, 40);
            this.btn_tmbhPelanggan.Name = "btn_tmbhPelanggan";
            this.btn_tmbhPelanggan.Size = new System.Drawing.Size(158, 54);
            this.btn_tmbhPelanggan.TabIndex = 15;
            this.btn_tmbhPelanggan.Text = "Tambah Pelanggan";
            this.btn_tmbhPelanggan.UseVisualStyleBackColor = true;
            this.btn_tmbhPelanggan.Click += new System.EventHandler(this.btn_tmbhPelanggan_Click);
            // 
            // btn_cekidPelanggan
            // 
            this.btn_cekidPelanggan.Location = new System.Drawing.Point(26, 40);
            this.btn_cekidPelanggan.Name = "btn_cekidPelanggan";
            this.btn_cekidPelanggan.Size = new System.Drawing.Size(158, 54);
            this.btn_cekidPelanggan.TabIndex = 14;
            this.btn_cekidPelanggan.Text = "Cek ID Pelanggan";
            this.btn_cekidPelanggan.UseVisualStyleBackColor = true;
            this.btn_cekidPelanggan.Click += new System.EventHandler(this.btn_cekidPelanggan_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DatabaseHotelUas.Properties.Resources.D_Mario_hotel;
            this.pictureBox1.Location = new System.Drawing.Point(671, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 239);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 539);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gb_pelanggan);
            this.Controls.Add(this.gb_restoran);
            this.Controls.Add(this.gb_kamar);
            this.Controls.Add(this.btn_checktrans);
            this.Controls.Add(this.btn_bookKamar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_main";
            this.Text = "D\'Mario Hotel ";
            this.Load += new System.EventHandler(this.form_main_Load);
            this.gb_kamar.ResumeLayout(false);
            this.gb_restoran.ResumeLayout(false);
            this.gb_pelanggan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_bookKamar;
        private System.Windows.Forms.Button btn_checktrans;
        private System.Windows.Forms.GroupBox gb_kamar;
        private System.Windows.Forms.Button btn_lihatkamar;
        private System.Windows.Forms.Button btn_restoran;
        private System.Windows.Forms.GroupBox gb_restoran;
        private System.Windows.Forms.GroupBox gb_pelanggan;
        private System.Windows.Forms.Button btn_cekidPelanggan;
        private System.Windows.Forms.Button btn_tmbhPelanggan;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

