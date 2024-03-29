﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace DatabaseHotelUas
{
    public partial class form_resto : Form
    {
        public MySqlCommand sqlCommand;
        public MySqlDataAdapter sqlAdapter;
        public string sqlQuery;
        int maxorderID = 0;
        DataTable Pelanggan = new DataTable();
        DataTable Menu = new DataTable();
        DataTable Invoice = new DataTable();
        public form_resto()
        {
            InitializeComponent();
        }
        private void btn_pesan_Click(object sender, EventArgs e)
        {
            try
            {
                sqlQuery = $"INSERT INTO DETAIL_ORDER_MENU VALUES('{maxorderID}', '{DGV_Menu.CurrentRow.Cells[0].Value.ToString()}','{num_jumlahMakanan.Value}' , (SELECT SUM({num_jumlahMakanan.Value} * MENU.MENU_HARGA) FROM MENU WHERE MENU.MENU_ID = '{DGV_Menu.CurrentRow.Cells[0].Value.ToString()}'))";
                commandAndadapter();
                sqlCommand.ExecuteNonQuery();
                Invoice = new DataTable();
                sqlQuery = $"SELECT M.MENU_NAMA as`Nama Menu` , D.ORDER_QTY as `Jumlah Menu`, M.MENU_HARGA as `Harga Menu`, D.ORDER_PRICE AS `Sub-Total` FROM DETAIL_ORDER_MENU D, MENU M WHERE M.MENU_ID = D.MENU_ID AND ORDER_ID= '{maxorderID}';";
                commandAndadapter();
                sqlAdapter.Fill(Invoice);
                DGV_invoice.DataSource = Invoice;
                lbl_totalHarga.Text = "Rp. " + totalHargaOrder().ToString();
                lbl_isiiteminCart.Text = jumlahOrderID().ToString();
                cb_pelanggan.Enabled = false;
                btn_cancelPelanggan.BackColor = Color.Red;
                if (jumlahOrderID() > 0)
                {
                    btn_checkout.Enabled = true;
                }
                else if (jumlahOrderID() == 0)
                {
                    btn_checkout.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void commandAndadapter()
        {
            sqlCommand = new MySqlCommand(sqlQuery, form_main.sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
        }
        public int jumlahOrderID()
        {
            try
            {
                sqlQuery = $"SELECT COUNT(ORDER_ID) FROM DETAIL_ORDER_MENU WHERE ORDER_ID = {maxorderID}";
                commandAndadapter();
                return Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public int totalHargaOrder()
        {
            try
            {
                sqlQuery = $"SELECT SUM(ORDER_PRICE) FROM DETAIL_ORDER_MENU WHERE ORDER_ID = {maxorderID}";
                commandAndadapter();
                return Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public int maxORDER_ID()
        {
            try
            {
                sqlQuery = $"select MAX(CAST(ORDER_ID as SIGNED)) from ORDER_FOOD";
                commandAndadapter();
                return Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        private void form_resto_Load(object sender, EventArgs e)
        {
            this.Width = 540;
            pic_crossmark.Hide();
            DGV_Menu.RowTemplate.MinimumHeight = 35;
            cb_pelanggan.Enabled = true;
            DGV_invoice.DataSource = Invoice;
            maxorderID = maxORDER_ID() + 1;
            num_jumlahMakanan.Value = 1;
            lbl_isiiteminCart.Text = "0";
            lbl_totalHarga.Text = "0";
            lbl_isiOrderID.Text = maxorderID.ToString();
            Menu.Clear();
            Invoice.Clear();
            Pelanggan.Clear();
            btn_cancelPelanggan.BackColor = Color.Green;
            try
            {
                sqlQuery = $"SELECT `MENU_ID` AS 'ID MENU', `MENU_NAMA` AS 'NAMA MENU', CONCAT('Rp. ',`MENU_HARGA`) AS 'HARGA MENU' FROM MENU";
                commandAndadapter();
                sqlAdapter.Fill(Menu);
                DGV_Menu.DataSource = Menu;

                sqlQuery = $"SELECT CONCAT(CUST_NAMA,' - ',CUST_ID) as 'id dan nama', CUST_ID as 'nama' FROM CUSTOMER ORDER BY 2 DESC";
                commandAndadapter();
                sqlAdapter.Fill(Pelanggan);

                cb_pelanggan.DataSource = Pelanggan;
                cb_pelanggan.DisplayMember = "id dan nama";
                cb_pelanggan.ValueMember = "nama";

                DGV_Menu.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV_Menu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV_Menu.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                for (int i = 0; i <= DGV_Menu.Columns.Count - 1; i++)
                {
                    int lebar = DGV_Menu.Columns[i].Width;
                    DGV_Menu.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    DGV_Menu.Columns[i].Width = lebar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btn_checkout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda yakin untuk melakukan Checkout pesanan?", "Checkout Restoran", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    sqlQuery = $"INSERT INTO ORDER_FOOD VALUES ('{maxorderID}','{form_main.transID + 1}','{cb_pelanggan.SelectedValue.ToString()}', date_format(now(),'%Y-%m-%d') , null , (SELECT COUNT(ORDER_ID) FROM DETAIL_ORDER_MENU WHERE ORDER_ID = '{maxorderID}') , (select sum(ORDER_PRICE) FROM DETAIL_ORDER_MENU WHERE ORDER_ID = '{maxorderID}'),0);";
                    commandAndadapter();
                    sqlCommand.ExecuteNonQuery();
                    sqlQuery = $"INSERT INTO TRANS_SETTLEMENT VALUES ('{form_main.transID + 1}', date_format(now(),'%Y-%m-%d') , (select sum(ORDER_PRICE) FROM DETAIL_ORDER_MENU WHERE ORDER_ID = '{maxorderID}') , 'Transaksi Restoran', 0);";
                    commandAndadapter();
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show($"Pesanan dengan ID: {maxorderID} berhasil di Checkout");
                    maxorderID++;
                    lbl_isiOrderID.Text = maxorderID.ToString();
                    lbl_isiiteminCart.Text = "0";
                    lbl_totalHarga.Text = "0";
                    Invoice.Clear();
                    form_main.transID++;
                    btn_cancelPelanggan.Enabled = true;
                    cb_pelanggan.Enabled = true;
                    btn_checkout.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void form_resto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Apakah anda yakin untuk menutup sebelum Checkout pesanan?", "Tutup Pemesanan", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                sqlQuery = $"DELETE FROM DETAIL_ORDER_MENU WHERE ORDER_ID = '{maxorderID}'";
                commandAndadapter();
                sqlCommand.ExecuteNonQuery();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda ingin mengganti Pelanggan?", "Ganti", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    sqlQuery = $"DELETE FROM DETAIL_ORDER_MENU WHERE ORDER_ID = '{maxorderID}'";
                    commandAndadapter();
                    sqlCommand.ExecuteNonQuery();
                    Invoice.Clear();
                    Invoice = new DataTable();
                    cb_pelanggan.Enabled = true;
                    btn_cancelPelanggan.BackColor = Color.Green;
                    lbl_isiiteminCart.Text = "0";
                    lbl_totalHarga.Text = "0";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (tb_cariMenu.Text.Length > 0)
            {
                pic_crossmark.Show();
            }
            else if (tb_cariMenu.Text.Length == 0)
            {
                pic_crossmark.Hide();
            }
            try
            {
                Menu.DefaultView.RowFilter = string.Format("`NAMA MENU` LIKE '%{0}%'", tb_cariMenu.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pic_crossmark_Click(object sender, EventArgs e)
        {
            tb_cariMenu.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_nama_Click(object sender, EventArgs e)
        {

        }

        private void cb_pelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl_isiOrderID_Click(object sender, EventArgs e)
        {

        }

        private void lbl_orderID_Click(object sender, EventArgs e)
        {

        }

        private void lbl_isiiteminCart_Click(object sender, EventArgs e)
        {

        }

        private void lbl_iteminCart_Click(object sender, EventArgs e)
        {

        }

        private void num_jumlahMakanan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pBoxCart_Click(object sender, EventArgs e)
        {
            this.Width = 1085;

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Width = 540;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            form_main.fhr.ShowDialog();
        }
    }
}
