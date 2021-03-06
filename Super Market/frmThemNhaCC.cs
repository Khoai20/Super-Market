using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Super_Market
{
    public partial class frmThemNhaCC : Form
    {
        private static SqlConnection conn;// = new SqlConnection(@"Data Source=SP-47C50C180EE0\DUONGDX;AttachDbFilename=D:\c#\project\Super Market Management\Super Market Management\spMarketmgmt.mdf;Integrated Security=True");
        public frmThemNhaCC()
        {
            InitializeComponent();
            conn = new SqlConnection(ConnectionString.getConnect());
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Insert into Providers(Name,Address,Tel,TypeName) values(@p1,@p2,@p3,@p4)", conn);
                command.Parameters.Add("@p1", SqlDbType.NVarChar, 50).Value = TxtName.Text;
                command.Parameters.Add("@p2", SqlDbType.NVarChar, 50).Value = TxtDiachi.Text;
                command.Parameters.Add("@p3", SqlDbType.NVarChar, 10).Value = TxtDienThoai.Text;
                command.Parameters.Add("@p4", SqlDbType.NChar, 50).Value = txtMatHangCC.Text;
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Cập nhật thành công", "Norther says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Norther says", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn.Close();
            }
        }

        private void frmThemNhaCC_Load(object sender, EventArgs e)
        {

        }
    }
}