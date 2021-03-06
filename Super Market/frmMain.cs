using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Super_Market
{
    public partial class frmMain : Form
    {
        //vd
        public frmMain()
        {
            InitializeComponent();
        }

        private void MainTreeMenu_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = MainTreeMenu.SelectedNode;
                if (node.Name.Equals("DanhMucChungLoaiSP")&&Session._Title.Equals("Quan Ly"))
                {
                    frmQuanLyChungLoaiHang frmType = new frmQuanLyChungLoaiHang();
                    frmType.MdiParent = this;
                    gbMain.Controls.Add(frmType);
                    frmType.Show();

                }
                else if (node.Name.Equals("LapHoaDonBH")&&Session._Username!="")
                {
                    frmLapHoaDonBanHang frmBH = new frmLapHoaDonBanHang();
                    frmBH.MdiParent = this;
                    gbMain.Controls.Add(frmBH);
                    frmBH.Show();
                }
                else if (node.Name.Equals("DanhMucLoaiSP") && Session._Title.Equals("Quan Ly"))
                {
                    frmQuanLyLoaiHang frmCategory = new frmQuanLyLoaiHang();
                    frmCategory.MdiParent = this;
                    gbMain.Controls.Add(frmCategory);
                    frmCategory.Show();
                }
                else if (node.Name.Equals("QLHangHoa") && Session._Title.Equals("Quan Ly"))
                {
                    frmQuanLyHangHoa frmQLHH = new frmQuanLyHangHoa();
                    frmQLHH.MdiParent = this;
                    gbMain.Controls.Add(frmQLHH);
                    frmQLHH.Show();
                }
                else if (node.Name.Equals("QLNhanVien") && Session._Title.Equals("Quan Ly"))
                {
                    frmQuanLyNhanVien frmNV = new frmQuanLyNhanVien();
                    frmNV.MdiParent = this;
                    gbMain.Controls.Add(frmNV);
                    frmNV.Show();
                }
                else if (node.Name.Equals("DanhMucNhaCungCap") && Session._Title.Equals("Quan Ly"))
                {
                    frmDanhMucNhaCungCap frm = new frmDanhMucNhaCungCap();
                    frm.MdiParent = this;
                    gbMain.Controls.Add(frm);
                    frm.Show();
                }
                else if (node.Name.Equals("HoaDonBH"))
                {
                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDangNhap Login = new frmDangNhap();
            Login.ShowDialog();
            LblUer.Text = Session._Title + ": " + Session._EmployeeName;
            if (Session._Title != null)
            {
                this.Text = "Smart Market" + " [" + Session._Title + "]";
            }
            if (Session._Title == "Quan Ly")
            {
                TreeNode node = new TreeNode("Quản lý Nhân viên");
                node.Name = "QLNhanVien";
                node.ImageIndex = 0;
                MainTreeMenu.Nodes.Add(node);
            }
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Do you want to quit the Application", "Norther says", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session._EmployeeId = 0;
            Session._EmployeeName = "";
            Session._Sex = "";
            Session._Title = "";
            Session._Username = "";
            gbMain.Controls.Clear();
        
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap dangnhap = new frmDangNhap();
            dangnhap.ShowDialog();

        }

        private void MainTreeMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}