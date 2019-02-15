using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EtbUniv
{
    public partial class Absence : Form
    {
        public Absence()
        {
            InitializeComponent();
        }

        private void Absence_Load(object sender, EventArgs e)
        {
            nSemaine.Items.AddRange(Enumerable.Range(1, 100).Select(i => (object)i).ToArray());
        }
    }
}
