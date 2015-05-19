using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace MyEncryption
{
    
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public static List<string> lstString;
        Regex reg = new Regex(@"[\u4e00-\u9fa5]");//正则表达式判断是不是汉字
        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName==string.Empty)
            {
                return;
            }
            lstString = new List<string>();
            string path = openFileDialog1.FileName;
            StreamReader objStreamReader = new StreamReader(path,Encoding.Default);
            string strTemp = objStreamReader.ReadToEnd();
            for (int i = 0; i < strTemp.Length;i++ )
            {
                string hans = strTemp[i].ToString();
                if (!reg.IsMatch(hans))
                {
                    continue;
                }
                else
                {
                    lstString.Add(hans);
                    listBoxNew.Items.Add(hans);
                }
            }
            objStreamReader.Close();

            
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (listBoxNew.Items.Count==0)
            {
                MessageBox.Show("不能生成空文件！","警告");
                return;
            }
            saveFileDialog1.ShowDialog();
            string path=saveFileDialog1.FileName;
            if (path==string.Empty)
            {
                return;
            }
            StreamWriter objStreamWriter = new StreamWriter(path, true);
            for (int i = 0; i < lstString.Count;i++ )
            {
                objStreamWriter.WriteLine(lstString[i]);
            }
            objStreamWriter.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBoxNew.Items.Clear();
        }
    }
}
