using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SquarePuzzleGame
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            FileRead();
        }
        Bitmap choose;
        private void btnGozAt_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter= "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";
           

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                choose = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                btnStart.Enabled = true;
                lblError.Visible = false;
                btnStart.Visible = true;
                label1.Visible = true;
                txtName.Visible = true;
            }
            else
            {
                lblError.Text = "Lütfen bir resim seçiniz";
                lblError.Visible = true;
                btnStart.Enabled = false;
            }
         
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.headimage = choose;
            if (txtName.Text.Length > 0)
            {
                frm.lblName.Text = txtName.Text;
            }
            else
            {
                frm.lblName.Text = "Anonim";
            }
            this.Hide();
            frm.ShowDialog();
        }

        public void FileRead()
        {
            string dosya_yolu = Application.StartupPath + @"\enyüksekskor.txt";
            if (File.Exists(dosya_yolu))
            {

                FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
                //2.parametre dosyanın açılacağını,
                //3.parametre dosyaya erişimin veri okumak için olacağını gösterir.
                StreamReader sw = new StreamReader(fs);
                string numbertemp = "";
                string number = "";
                ArrayList sayilar = new ArrayList();
                while (number != null)
                {
                    number = sw.ReadLine();
                    if (number != null && number != "")
                    {
                      
                       // numbertemp = number.Substring(number.LastIndexOf(" ")+1, number.Length - number.LastIndexOf(" ")-1);
                        sayilar.Add(number);
                    }
                }
                int high = 0;
                int indexcoor= 0;
                for (int index = 0; index < sayilar.Count; index++)
                {
                    string veri=sayilar[index].ToString().Substring(sayilar[index].ToString().LastIndexOf(" ")+1, sayilar[index].ToString().Length - sayilar[index].ToString().LastIndexOf(" ")-1);
                    if (IsNumeric(veri.ToString()))
                    {
                        if (Convert.ToInt32(veri) > high)
                        {
                            high = Convert.ToInt32(veri);
                            indexcoor = index;
                        }
                    }
                }
                lblPoint.Text = sayilar[indexcoor].ToString();

                //Veriyi tampon bölgeden dosyaya aktardık.
                sw.Close();
                fs.Close();
            }
            else
            {
                var myFile = File.Create(dosya_yolu);
                myFile.Close();
                TextWriter tw = new StreamWriter(dosya_yolu);
                tw.WriteLine("İlk Giriş: 0");
                tw.Close();
            }

        }
        bool IsNumeric(string text)
        {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            return true;
        }
    }
}
