﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital_Management_System
{
    public partial class Building_Info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-A2BU9MO;Initial " + "Catalog=" + "Hospital Management System" + ";Integrated Security=True");

        public Building_Info()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                con.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("select * from Building where buildingID ='" + textBox1.Text + "'", con);
                DataTable dtb1 = new DataTable();
                sqlda.Fill(dtb1);
                dgv.DataSource = dtb1;
                con.Close();
            }
            else
            {
                MessageBox.Show("please write a name to search", "Error Message");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from Building", con);
            DataTable dtb1 = new DataTable();
            sqlda.Fill(dtb1);
            dgv.DataSource = dtb1;
            con.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-A2BU9MO;Initial " + "Catalog=" + "Hospital Management System" + ";Integrated Security=True");
                con.Open();

                try
                {
                    string str = "DELETE FROM Building WHERE buildingID ='" + textBox1.Text + "';";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    string str1 = "select max(roomID) from Room;";
                    SqlCommand cmd1 = new SqlCommand(str1, con);
                    SqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Building Information Deleted Successfully..", "Successfully Message");

                    }
                }
                catch (SqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
                con.Close();
            }

            else
            {
                MessageBox.Show("Search about what you want to delete ", "Error Message");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Buildings b = new Buildings();
            b.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Update_Building u = new Update_Building();
            u.Show();
        }
    }
}
