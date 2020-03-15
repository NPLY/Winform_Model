using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_Winform_Model.Model;

namespace System_Winform_Model.Form_Dir
{
    public partial class Main_Fm : Form
    {
        private const int LEADING_SPACE = 12;
        private const int CLOSE_SPACE = 15;
        private const int CLOSE_AREA = 15;
        public static string N_TC = "N_TC";

        private Fm1_ChPw fm_chpw = null;

        public Main_Fm()
        {
            InitializeComponent();
        }

        private void Main_Fm_Load(object sender, EventArgs e)
        {
            ToolStrip ts = new ToolStrip();
            ts.Items.Add(new ToolStripLabel("帳號： " + Login_Fm.user_id));
            ts.Items.Add(new ToolStripSeparator());
            ts.Items.Add(new ToolStripLabel("程式內部紀錄版本：" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString()));
            ts.Items.Add(new ToolStripSeparator());
            ts.Items.Add(new ToolStripLabel("外部紀錄版本：" + Login_Fm.program_ver));
            ts.Items.Add(new ToolStripSeparator());
            ts.Items.Add(new ToolStripLabel("Global IP：" + Login_Fm.global_ip));
            ts.Items.Add(new ToolStripSeparator());
            ts.Dock = DockStyle.Bottom;
            Controls.Add(ts);
            Create_TOP_MENU();
        }
        public void Create_TOP_MENU()
        {
            menuStrip_Top.Items.Clear();
            MenuModel mainMenu = new MenuModel();
            List<MenuModel> menutree = new List<MenuModel>();
            menutree = mainMenu.GetMENUTREE();
            var menuitem = menutree.FindAll(x => x.ParentID == 1).OrderBy(x => x.ID);
            foreach (var item in menutree)
            {
                Console.WriteLine(item.ID + "," + item.ParentID + "," + item.Value + "," + item.Leaf + " , " + item.ChineseName + " , " + item.root);
            }
            foreach (var item in menuitem)
            {
                ToolStripMenuItem MnuStripItem = new ToolStripMenuItem(item.ChineseName);
                MnuStripItem.DropDownItems.AddRange(遞迴產生MENUITEM(item.ID, menutree));
                menuStrip_Top.Items.Add(MnuStripItem);
            }

            //   menuStrip1.DropDownItems.AddRange(遞迴產生MENUITEM(0, menutree));

        }

        public ToolStripMenuItem[] 遞迴產生MENUITEM(int pid, List<MenuModel> menutree)
        {
            List<MenuModel> same = new List<MenuModel>();

            foreach (var item in menutree)
            {
                if (pid == item.ParentID)
                {
                    same.Add(item);

                }
            }

            ToolStripMenuItem[] toolStripMenuItems = new ToolStripMenuItem[same.Count];

            for (int i = 0; i < same.Count; i++)
            {
                toolStripMenuItems[i] = new ToolStripMenuItem();

                    toolStripMenuItems[i].Name = same[i].root.ToString() + "." + same[i].Value.ToString();
                    toolStripMenuItems[i].Tag = same[i].Value;
                    toolStripMenuItems[i].Text = same[i].ChineseName;
                    if (same[i].Leaf == 1)
                    {
                        if (same[i].PERMISSIONS == N_TC)
                        {
                            toolStripMenuItems[i].Click += new EventHandler(EDI彈出事件);
                        }
                        else
                        {
                            toolStripMenuItems[i].Click += new EventHandler(EDI選單事件);
                        }

                    }
                    toolStripMenuItems[i].DropDownItems.AddRange(遞迴產生MENUITEM(same[i].ID, menutree));
              
            }
            toolStripMenuItems = Array.FindAll(toolStripMenuItems, val => val.Name != "").ToArray();

            return toolStripMenuItems;
        }

        //開啟程式
        private void EDI選單事件(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            string[] cutname = clickedItem.Name.Split('.');

            try
            {

                showform(clickedItem.Tag.ToString(), string.Format(@"System_Winform_Model.Form_Dir.{0}", clickedItem.Tag.ToString()));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }

        }

        //開啟程式
        private void EDI彈出事件(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            switch (clickedItem.Tag.ToString())
            {
                case "Fm1_ChPw":
                    變更密碼();
                    break;
                case "關閉程式":
                    Close();
                    Environment.Exit(Environment.ExitCode);
                    break;
                default:
                    break;
            }

        }
        public void 變更密碼()
        {
            if (fm_chpw == null)
            {
                fm_chpw = new Fm1_ChPw();

                fm_chpw.Show();

                /*Create an event where the form is closed(dispose)*/
                fm_chpw.Disposed += new EventHandler(fm_Disposed);
            }
            else
            {
                /*Set form to default size*/
                fm_chpw.WindowState = FormWindowState.Normal;
                /*把form帶到疊置順序的前面(讓縮小的Form2跳出來)*/
                fm_chpw.BringToFront();
            }
        }
        /*關閉Form時會觸發的事件*/
        private void fm_Disposed(object sender, EventArgs e)
        {
            string FormName = ((Form)sender).Name;
            if (fm_chpw != null && fm_chpw.Name == FormName)
            {

                fm_chpw = null;

            }
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //This code will render a "x" mark at the end of the Tab caption. 
            e.Graphics.DrawString("x", e.Font, Brushes.Red, e.Bounds.Right - CLOSE_AREA, e.Bounds.Top + 4);
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + LEADING_SPACE, e.Bounds.Top + 4);

            e.DrawFocusRectangle();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            //Looping through the controls.
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);

                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("是否要關閉此分頁", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        TabPage TabP = tc.TabPages[tc.SelectedIndex];
                        tabControl1.TabPages.Remove(TabP);
                        break;
                    }
                }
            }
        }

        private void showform(string formname, string form)
        {
            bool tabpage = false;
            int i = 0;
            //Looping through the controls.
            for (i = 0; i < tabControl1.TabPages.Count; i++)
            {
                TabPage tp = tabControl1.TabPages[i];
                if (tp.Text.Trim() == formname)
                {
                    tabpage = true;

                    break;
                }
            }

            if (tabpage == true)
            {
                tabControl1.SelectedIndex = i;
            }
            else
            {
                Form fm = (Form)Activator.CreateInstance(Type.GetType(form));

                AddNewTab(fm);
                //  frm11.FormClosed += new FormClosedEventHandler(formclose);
                fm.Show();
            }

        }

        private void AddNewTab(Form frm)
        {
            tabControl1.Dock = DockStyle.Fill;
            TabPage tab = new TabPage();
            tab.Text = frm.Text;
            Size s = new Size(tab.Width, 0);
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.Parent = tab;
            frm.Visible = true;
            tabControl1.TabPages.Add(tab);
            tabControl1.ItemSize = s;
            tabControl1.SelectedTab = tab;

        }
    }
}
