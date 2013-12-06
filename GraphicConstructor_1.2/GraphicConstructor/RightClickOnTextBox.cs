using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphicConstructor
{
    public partial class RightClickOnTextBox : Form
    {
        public string str = "";
        public RightClickOnTextBox()
        {
            InitializeComponent();
        }

        private void RightClickOnTextBox_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static void ShowWindow(string msg)
        {
            RightClickOnTextBox form = new RightClickOnTextBox();
            form.listBoxFunc.Items.Add(msg);
            form.Show();
        }
        public static void ShowDialogWindow(string msg)
        {
            RightClickOnTextBox form = new RightClickOnTextBox();
            form.listBoxFunc.Items.Add(msg);
            form.ShowDialog();
        }

        private void richTextBoxFunc_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = listBoxFunc.SelectedIndex;
            str = Convert.ToString(listBoxFunc.Items[idx]);
        }

        //public static string GetItem()
        //{
        //    return ;
        //}

    }
}
