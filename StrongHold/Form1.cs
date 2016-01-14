using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrongHold
{
    public partial class Form1 : Form
    {
        GameField field;
        public Form1()
        {
            InitializeComponent();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            field = new GameField();
            field.setup();
            field.run();
            MessageBox.Show("Done!");
        }
    }
}
