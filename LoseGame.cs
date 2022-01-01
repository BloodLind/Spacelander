using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceLander
{
    public partial class LoseGame : Form
    {
        private Form form;
        public LoseGame(Form form)
        {
            this.form = form;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoseGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Close();
        }
    }
}
