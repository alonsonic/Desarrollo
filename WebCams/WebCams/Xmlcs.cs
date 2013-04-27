using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCams
{
    public partial class Xmlcs : Form
    {
        public Xmlcs()
        {
            InitializeComponent();
        }
        public Xmlcs(string xml)
        {
            InitializeComponent();
            labelXml.Text = xml;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
