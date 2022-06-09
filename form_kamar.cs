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
    public partial class form_kamar : Form
    {
        public form_kamar()
        {
            InitializeComponent();
        }

        private MySqlCommand sqlCommand;
        private MySqlDataAdapter sqlAdapter;
        /* 
         * @filled_kamar is list of kamar WHERE kamar_status is 1
         * @cart = temporary cart source for 
         * @pelanggan = feed some suggestion to list_box_suggestion
         * @temp_pelanggan = for pic_status
         */

        public static List<String> filled_kamar = new List<string>();
        public DataTable cart = new DataTable();
        private DataTable pelanggan = new DataTable();
        private List<string> temp_pelanggan = new List<string>();
        private void form_kamar_Load(object sender, EventArgs e)
        {
            lbl_check_in.Hide();
            lbl_check_out.Hide();
            datetime_check_in.Hide();
            datetime_check_out.Hide();

            /*
             * query check for KAMAR_STATUS = 1
             * append(btn_A{KAMAR_NO})
             * change it to red
             */

            DataTable filled_kamar_dt = new DataTable();

            try
            {
                string sqlQuery = "SELECT KAMAR_NO FROM KAMAR WHERE KAMAR_STATUS = 1";
                new MySqlDataAdapter(sqlQuery, form_main.sqlConnect).Fill(filled_kamar_dt);
                filled_kamar = filled_kamar_dt.AsEnumerable().Select(x => x.Field<String>("KAMAR_NO")).ToList();

                sqlQuery = $"SELECT CONCAT(CUST_NAMA,' - ',CUST_ID) as 'id dan nama', CUST_ID as 'nama' FROM CUSTOMER ORDER BY 2 DESC";
                sqlCommand = new MySqlCommand(sqlQuery, form_main.sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(pelanggan);

                cb_pelanggan.DataSource = pelanggan;
                cb_pelanggan.ValueMember = "nama";
                cb_pelanggan.DisplayMember = "id dan nama";

                // fill first column of pelanggan to temp_pelanggan
                temp_pelanggan = pelanggan.AsEnumerable().Select(x => x.Field<String>("id dan nama")).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("error occurred: " + ex.Message);
            }

            // append "btn_A" to every child in filled_kamar and change it as button backColor to red
            foreach (string kamar_no in filled_kamar)
            {
                Button btn = this.Controls.Find("btn_A" + kamar_no, true).FirstOrDefault() as Button;
                btn.BackColor = Color.Red;
            }
        }

        private void btn_lantai2_Click(object sender, EventArgs e)
        {
            btn_lantai2.BackColor = Color.BlueViolet;
            btn_lantai1.BackColor = Color.White;
            for (int i = 101; i <= 140; i++)
            {
                Button btn = this.Controls.Find("btn_A" + i, true).FirstOrDefault() as Button;
                btn.Hide();
            }
            for (int i = 201; i <= 240; i++)
            {
                Button btn = this.Controls.Find("btn_A" + i, true).FirstOrDefault() as Button;
                btn.Show();
            }
        }

        private void btn_lantai1_Click(object sender, EventArgs e)
        {
            btn_lantai2.BackColor = Color.White;
            btn_lantai1.BackColor = Color.BlueViolet;
            for (int i = 101; i <= 140; i++)
            {
                Button btn = this.Controls.Find("btn_A" + i, true).FirstOrDefault() as Button;
                btn.Show();
            }
            for (int i = 201; i <= 240; i++)
            {
                Button btn = this.Controls.Find("btn_A" + i, true).FirstOrDefault() as Button;
                btn.Hide();
            }
        }

        /*
            @pressed_button = reference to the button that was pressed for form_popupKamar
            @btn_child_onClick = dynamic func that return value to pressed_button & do query whether the button is available or not (red / green)
            @tipe_kamar = tipe_kamar of the button that was pressed PS, S, JS, D
        */

        public static string pressed_button;
        public static string tipe_kamar;
        
        private void btn_child_onClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Red; // only temporary :)

            // cast system.windows.forms.button btn to string and remove "btn_a"
            pressed_button = btn.Name.Substring(5);
            // remove "A" and whitespace and 0-9 from btn.Text
            tipe_kamar = new string(btn.Text.Where(c => !char.IsDigit(c) && !char.IsWhiteSpace(c) && c != 'A').ToArray());

            form_popupKamar popup = new form_popupKamar();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ShowDialog();
        }

        private void cb_pelanggan_KeyDown(object sender, KeyEventArgs e) // change status to red if user pressed some key
        {
            pic_status.BackColor = Color.Red;
            if (temp_pelanggan.Contains(cb_pelanggan.Text))
            {
                pic_status.BackColor = Color.Green;
            }
        }

        private void cb_pelanggan_SelectedValueChanged(object sender, EventArgs e)
        {
            pic_status.BackColor = Color.Green;
        }
    }
}
