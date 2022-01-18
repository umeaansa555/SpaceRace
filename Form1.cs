using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceRace
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(10, 170, 10, 60);
        Rectangle player2 = new Rectangle(10, 170, 10, 60);

        public Form1()
        {
            InitializeComponent();
        }

        private void engine_Tick(object sender, EventArgs e)
        {


            Refresh();
        }
    }
}
