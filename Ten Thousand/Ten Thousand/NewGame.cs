using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ten_Thousand
{
    public partial class NewGame : Form
    {
        public string[] names;

        public NewGame()
        {
            InitializeComponent();
            nameTxt.Focus();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            nameList.Clear();
            nameTxt.Focus();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text.Length == 0)
                return;
            nameList.Text = nameTxt.Text + "\r\n" + nameList.Text;
            nameTxt.Clear();
            nameTxt.Focus();
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            string[] delim = { "\r\n" };
            names = nameList.Text.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            if (names.Length == 0)
            {
                MessageBox.Show("You need atleast one player to play");
                nameTxt.Focus();
                return;
            }
            this.Close();
        }
    }
}
