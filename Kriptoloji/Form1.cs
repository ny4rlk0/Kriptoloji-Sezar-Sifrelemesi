using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kriptoloji
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decryptME();
        }

        private void decryptME()
        {
            //Alfabe Karakterlerin Liste Hali
            List<string> alfabe = new List<string>(new string[] {"A", "B", "C", "Ç", "D", "E", "F", "G", "Ğ", "H", "I", "İ", "J", "K", "L", "M", "N", "O", "Ö", "P", "R", "S", "Ş", "T", "U", "Ü", "V", "Y", "Z" });
            //Şifreli Karakterlerin Liste Hali
            List<string> sifreliKarakterler = new List<string>(new string[] {});
            string t = textBox1.Text.ToString().ToUpper();
            foreach (char x in t)
                sifreliKarakterler.Add(x.ToString().ToUpper());
            //Şifre Çözmek İçin Maksimum deneme sayısı
            int maxDeneme = 28;
            for (int i = 0; i <= maxDeneme; i++) //0-28
            {//28 Kere Tekrar Et
                //Şifreli Karakterlerin Sayısı Kadar tekrar et
                foreach (var k in sifreliKarakterler)
                {
                    #region Eğer Boşluk Karakteri İse Atla
                    //Eğer Boşluk Karakteri İse Atla
                    if (k==" ")
                    {
                        richTextBox1.Text += " ";
                        continue;
                    }
                    #endregion
                    int harf = alfabe.IndexOf(k);
                    if (harf==-1)
                    {
                        richTextBox1.Text += " ";
                        continue;
                    }
                    int snc = harf + i;
                    if (snc > 28)
                    {
                        snc %=28;
                        if (snc!=0)
                            snc = snc - 1;
                    }
                    richTextBox1.Text += alfabe[snc];
                }
                richTextBox1.Text += "\n";
            }
        }
    }
}
