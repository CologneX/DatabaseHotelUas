﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DatabaseHotelUas
{
    public partial class form_historiRestoran : Form
    {
        public form_historiRestoran()
        {
            InitializeComponent();
        }
        public MySqlCommand sqlCommand;
        public MySqlDataAdapter sqlAdapter;
        string sqlQuery;
        new DataTable historiPemesanan = new DataTable();
        private void form_historiRestoran_Load(object sender, EventArgs e)
        {
            historiPemesanan.Clear();
            try
            {
                sqlQuery = $"SELECT * FROM DETAIL_ORDER_MENU WHERE NOT ORDER_ID = '0' ORDER BY CAST(ORDER_ID as SIGNED)";
                sqlCommand = new MySqlCommand(sqlQuery, form_main.sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(historiPemesanan);
                DGV_historiRestoran.DataSource = historiPemesanan;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DGV_historiRestoran.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV_historiRestoran.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV_historiRestoran.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            for (int i = 0; i <= DGV_historiRestoran.Columns.Count - 1; i++)
            {
                int lebar = DGV_historiRestoran.Columns[i].Width;
                DGV_historiRestoran.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                DGV_historiRestoran.Columns[i].Width = lebar;
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void form_historiRestoran_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
