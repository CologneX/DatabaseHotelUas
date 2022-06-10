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
    public partial class Form_Cek_Transaksi : Form
    {
        public MySqlCommand sqlCommand;
        public MySqlDataAdapter sqlAdapter;
        string sqlQuery;
        new DataTable kamarBelumLunas = new DataTable();
        new DataTable restoBelumLunas = new DataTable();
        new DataTable semuaTransaksiKamar = new DataTable();
        new DataTable semuaTransaksiResto = new DataTable();
        public Form_Cek_Transaksi()
        {
            InitializeComponent();
        }


        private void btn_exit_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            
        }

        private void btn_prosesCekTransaksi_Click(object sender, EventArgs e)
        {
            if (cBoxBookKamar.Checked == false && cBoxOrderResto.Checked == false)
            {
                MessageBox.Show("Tolong pilih jenis transaksi yang ingin ditampilkan");
            }
            else
            {
                if (cBoxBookKamar.Checked == true && cBoxOrderResto.Checked == false)
                {
                    TransaksiBookingKamarBelumLunas();
                    TransaksiBookingKamar();
                }
                else if (cBoxOrderResto.Checked == true && cBoxBookKamar.Checked == false)
                {
                    TransaksiOrderFoodBelumLunas();
                    TransaksiOrderFood();
                }
                else if (cBoxOrderResto.Checked == true && cBoxBookKamar.Checked == true)
                {
                    dgv_cekTransBlmLunas2.Show();
                    dgv_SemuaTransaksi2.Show();
                    TransaksiBookingKamarBelumLunas();
                    TransaksiOrderFoodBelumLunas2();
                    TransaksiBookingKamar();
                    TransaksiOrderFood2();
                }
            }
        }
        public void TransaksiBookingKamarBelumLunas()
        {
            try
            {
                kamarBelumLunas = new DataTable();
                sqlQuery = $"SELECT BOOK_ID, CUST_ID, BOOK_TGL_CIN, BOOK_TGL_COUT, BOOK_KAMAR_COUNT, BOOK_TOTAL FROM BOOKING_KAMAR WHERE TRANS_ID is null; ";
                sqlCommand = new MySqlCommand(sqlQuery, form_main.sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(kamarBelumLunas);
                dgv_cekTransBlmLunas.RowHeadersVisible = false;
                dgv_cekTransBlmLunas.DataSource = kamarBelumLunas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void TransaksiOrderFoodBelumLunas()
        {
            try
            {
                restoBelumLunas = new DataTable();
                sqlQuery = $"SELECT ORDER_ID, CUST_ID, ORDER_TGL, ORDER_KAMAR_NO, ORDER_MENU_COUNT, ORDER_TOTAL FROM ORDER_FOOD WHERE TRANS_ID is null; ";
                sqlCommand = new MySqlCommand(sqlQuery, form_main.sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(restoBelumLunas);
                dgv_cekTransBlmLunas.RowHeadersVisible = false;
                dgv_cekTransBlmLunas.DataSource = restoBelumLunas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void TransaksiBookingKamar()
        {
            try
            {
                semuaTransaksiKamar = new DataTable();
                sqlQuery = $"SELECT BOOK_ID, CUST_ID, BOOK_TGL_CIN, BOOK_TGL_COUT, BOOK_KAMAR_COUNT, BOOK_TOTAL FROM BOOKING_KAMAR; ";
                sqlCommand = new MySqlCommand(sqlQuery, form_main.sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(semuaTransaksiKamar);
                dgv_SemuaTransaksi.RowHeadersVisible = false;
                dgv_SemuaTransaksi.DataSource = semuaTransaksiKamar;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void TransaksiOrderFood()
        {
            try
            {
                semuaTransaksiResto = new DataTable();
                sqlQuery = $"SELECT ORDER_ID, CUST_ID, ORDER_TGL, ORDER_KAMAR_NO, ORDER_MENU_COUNT, ORDER_TOTAL FROM ORDER_FOOD; ";
                sqlCommand = new MySqlCommand(sqlQuery, form_main.sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(semuaTransaksiResto);
                dgv_SemuaTransaksi.RowHeadersVisible = false;
                dgv_SemuaTransaksi.DataSource = semuaTransaksiResto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void TransaksiOrderFoodBelumLunas2()
        {
            try
            {
                restoBelumLunas = new DataTable();
                sqlQuery = $"SELECT ORDER_ID, CUST_ID, ORDER_TGL, ORDER_KAMAR_NO, ORDER_MENU_COUNT, ORDER_TOTAL FROM ORDER_FOOD WHERE TRANS_ID is null; ";
                sqlCommand = new MySqlCommand(sqlQuery, form_main.sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(restoBelumLunas);
                dgv_cekTransBlmLunas2.RowHeadersVisible = false;
                dgv_cekTransBlmLunas2.DataSource = restoBelumLunas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void TransaksiOrderFood2()
        {
            try
            {
                semuaTransaksiResto = new DataTable();
                sqlQuery = $"SELECT ORDER_ID, CUST_ID, ORDER_TGL, ORDER_KAMAR_NO, ORDER_MENU_COUNT, ORDER_TOTAL FROM ORDER_FOOD; ";
                sqlCommand = new MySqlCommand(sqlQuery, form_main.sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(semuaTransaksiResto);
                dgv_SemuaTransaksi2.RowHeadersVisible = false;
                dgv_SemuaTransaksi2.DataSource = semuaTransaksiResto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form_Cek_Transaksi_Load(object sender, EventArgs e)
        {
            dgv_cekTransBlmLunas2.Hide();
            dgv_SemuaTransaksi2.Hide();
        }
    }
}
