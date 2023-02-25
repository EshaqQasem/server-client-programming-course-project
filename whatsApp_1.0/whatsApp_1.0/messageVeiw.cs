using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace whatsApp_1._0
{
    class messageVeiw:Label
    {
        private  const int maxLenght = 35;
        public messageVeiw()
        {
            AutoSize = true;
            Font = new System.Drawing.Font("Tahoma", 10F);
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        }
        public void setText(string msg)
        {
            string[] words = msg.Split(' ');

            int lineCapcity = maxLenght;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length < lineCapcity)
                {
                    this.Text += words[i] + ' ';
                    lineCapcity -= words[i].Length + 1;
                }
                else if (lineCapcity == 35) //افترضنا حاليا انها حاله نادره ا
                {
                    // this.Text+= words[i].
                }
                else
                {
                    this.Text += "\r\n" + words[i];
                    lineCapcity = maxLenght - words[i].Length;
                }

            }
        }

    }
}
