using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace  whatsApp_1._0
{
    class NumberBox : TextBox
    {

        public NumberBox()
        {
            this.KeyPress += NumberBox_KeyPress;
        }

        private void NumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool Numbers = e.KeyChar >= 48 && e.KeyChar < 58;
            bool BackspaceAndPointKeys = e.KeyChar == (char)Keys.Back || e.KeyChar == ('.');
            if (!(Numbers || BackspaceAndPointKeys))
                e.Handled = true;
        }



    }
}

