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
    public partial class form_resto : Form
    {
        public form_resto()
        {
            InitializeComponent();
        }

        
        private void btn_exit_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cb_jumlahMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        
        private void btn_pesan_Click(object sender, EventArgs e)
        {

        }

        private void cb_pilihMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //disable btn_pesan if cb_pilihMenu and cb_jumlah is empty
            
            
            if (cb_pilihMenu.Text == "" || cb_jumlahMenu.Text == "")
            {
                btn_pesan.Enabled = false;
            }
            else
            {
                btn_pesan.Enabled = true;
            }



        }
    }
}
