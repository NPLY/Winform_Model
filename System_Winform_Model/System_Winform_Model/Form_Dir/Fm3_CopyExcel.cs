using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace System_Winform_Model.Form_Dir
{
    public partial class Fm3_CopyExcel : Form
    {
        public Fm3_CopyExcel()
        {
            InitializeComponent();
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            string pasteText = Clipboard.GetText();
            //判斷是否有字元存在
            if (string.IsNullOrEmpty(pasteText))
            {
                return;
            }
            pasteText = pasteText.Replace('\t', ',');
            //以換行符分割的陣列
            string[] lines = pasteText.Trim().Split('\n');
            //以製表符分割的陣列
            //       string[] vals = lines[0].Split(',');
            //dataarray = lines;
            richTextBox1.Text = string.Join("", lines);
            //  richTextBox2.Text = string.Join("", lines);
            Console.WriteLine(pasteText);

            int start = Convert.ToInt32(textBox1.Text);
            richTextBox2.Text = "";
            int end = Convert.ToInt32(textBox2.Text);

            DataTable table = new DataTable();
            int col = 0;
            string ouput = "";
            foreach (var item in lines)
            {
                string[] splits = item.Split(',');
                if (splits.Count() > 0)
                {
                    for (int i = 0; i < splits.Count() - col; i++)
                    {
                        table.Columns.Add("欄位:" + (col + i + 1));
                    }
                    col = splits.Count();
                }
                DataRow row = table.NewRow();
                var str = "";
                for (int i = 0; i < splits.Count(); i++)
                {
                    row[i] = splits[i];
                    if (i >= start && i < end)
                    {
                        str += (checkBox1.Checked) ? "\"" +splits[i] + "\"," : splits[i] + ",";
                        
                    }
                    if (i == end)
                    {
                        str += (checkBox1.Checked) ? "\"" + splits[i] + "\"" : splits[i];
                    }
                }
                table.Rows.Add(row);
                if (!string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    ouput += String.Format(textBox3.Text, str);
                }
                else
                {
                    ouput += str;
                }
                ouput += "\n";

            }

            dataGridView1.DataSource = table;
            richTextBox2.Text = ouput;


        }
    }
}
