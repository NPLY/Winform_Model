using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Winform_Model.Form_Dir
{
    public partial class Fm1_ChPw : Form
    {
        public Fm1_ChPw()
        {
            InitializeComponent();
        }

        private void btn_ChPw_Click(object sender, EventArgs e)
        {
            if (Change_Password())
            {
                MessageBox.Show("修改完成");
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失敗");
                return;
            }
        }
        private bool Change_Password()
        {
            return true;
        }
    }
}
