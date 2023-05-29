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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FileRead();
         
        }


        public void ButtonControl()
        {
            int buttoncontrol = 0;
            for (int i = 0; i < 16; i++)
            {

                if (btn[i].Enabled == false)
                {
                    buttoncontrol++;
                }
            
            }
            if (buttoncontrol == 16)
            {
                lblError.Text = "Oyun bitti.Skorunuz sisteme kaydedilmiştir.";
                string dosya_yolu = Application.StartupPath + @"\enyüksekskor.txt";
                if (File.Exists(dosya_yolu))
                {

                    using (StreamWriter w = File.AppendText(dosya_yolu))
                    {
                        w.WriteLine(lblName.Text + ": " + lblPoint.Text.ToString());
                        w.Close();
                    }

                               

                    
                }
                else
                {
                    lblError.Text = "enyüksekskor.txt mevcut değil";
                    lblError.Visible = true;
                }
                lblError.Visible = true;
            }
        }
   

        public void Kontrol()
        {
            if (label1.Text != "")
            {
                if (truthimage == 16)
                {
                    label1.Text = "Tüm resim doğru yere yerleştirildi.En yüksek puanı aldınız.(100 Puan)";
                    lblPoint.Text = "100";
                    string dosya_yolu = Application.StartupPath + @"\enyüksekskor.txt";
                    if (File.Exists(dosya_yolu))
                    {
                        FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);

                        StreamWriter sw = new StreamWriter(fs);

                        sw.WriteLine(lblName.Text + ": " + lblPoint.Text.ToString());

                        sw.Flush();

                        sw.Close();
                        fs.Close();
                    }
                    else
                    {
                        lblError.Text = "enyüksekskor.txt mevcut değil";
                        lblError.Visible = true;
                    }
                }
                else
                {
                   int puan= truthimage * 5 + 20;
                    lblPoint.Text = puan.ToString();
                }
                btnKaristir.Enabled = false;
                tableLayoutPanel2.Visible = true;
            }
        }


     
        Button[] btn = new Button[16];

        ArrayList aList = new ArrayList();


       System.Drawing.Image[] imgarray = new System.Drawing.Image[16];
        public void Read(Bitmap image)
        {

            //BinaryReader br = new BinaryReader(File.Open(Server.MapPath("~/" + dosyaBilgisi.Name), FileMode.Open));
            //long numBytes = new FileInfo(Server.MapPath("~/" + dosyaBilgisi.Name)).Length;
            //byte[] buff = null;
            //buff = br.ReadBytes((int)numBytes);

            //FileInfo fileInfo = new FileInfo(yuklemeYeri);


            //var img = System.Drawing.Image.FromFile(Application.StartupPath + @"\indir.jpg");
   
            var img = image;
            //Bitmap image = new Bitmap(Application.StartupPath + @"\indir.jpg");

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var index = i * 4 + j;
                    imgarray[index] = new Bitmap(image.Width / 4, image.Height / 4);
                    var graphics = Graphics.FromImage(imgarray[index]);
                    graphics.DrawImage(img, new Rectangle(0, 0, image.Width / 4, image.Height / 4), new Rectangle(i * image.Width / 4, j * image.Height / 4, image.Width / 4, image.Height / 4), GraphicsUnit.Pixel);
                    graphics.Dispose();
                }
            }
            //   Button[] btn = new Button[16];

            //   ArrayList aList = new ArrayList();
            btn[0] = button0;
            btn[0].FlatStyle = FlatStyle.Flat;
           
          
            btn[1] = button1;
            btn[2] = button2;
            btn[3] = button3;
            btn[4] = button4;
            btn[5] = button5;
            btn[6] = button6;
            btn[7] = button7;
            btn[8] = button8;
            btn[9] = button9;
            btn[10] = button10;
            btn[11] = button11;
            btn[12] = button12;
            btn[13] = button13;
            btn[14] = button14;
            btn[15] = button15;

           
                for (int i = 0; i < 16; i++)
                {

                    btn[i].Visible = true;
                    btn[i].Enabled = true;
                }
            
            for (int i = 0; i < 16; i++)
            {
                aList.Add(i);
                btn[i].BackgroundImageLayout = ImageLayout.Stretch;
            }

            for (int i = 0; i < 16; i++)
            {
                Random rastgele = new Random();

                int sayi = rastgele.Next(aList.Count);
                btn[i].BackgroundImage = imgarray[Convert.ToInt32(aList[sayi])];

                //pictureBox3.Image = btn[0].Image;
                if (getrgb(btn[i].BackgroundImage, imgarray[i]) == "Doğru")
                {
                    btn[i].Enabled = false;
                    btn[i].ForeColor = Color.AliceBlue;
                    string resimnumarası = btn[i].Name.ToString().Replace("button", "");
                    int resimnum = Convert.ToInt32(resimnumarası);
                    resimnum++;
                    truthimage++;
                    label1.Text = label1.Text.Replace(" resim doğru yerde","") + resimnum.ToString() + ". resim doğru yerde";
                }
              
                aList.RemoveAt(sayi);

            }
            lblError.Visible = false;
            if (label1.Text.Length < 1)
            {
                for (int i = 0; i < 16; i++)
                {

                    btn[i].Enabled = false;
                }
                lblError.Text = "En az 1 resim doğru yerde değil.Karıştırmaya devam";
                lblError.Visible = true;
            }

        }
        int truthimage=0;
        public Bitmap headimage;

     
        private void btnKaristir_Click(object sender, EventArgs e)
        {
            Read(headimage);
            Kontrol();
        }


        private string getrgb(Image image1, Image image2)
        {

         
            Bitmap resim1 = (Bitmap)image1;
            Bitmap resim2 = (Bitmap)image2;




            int x = resim1.Width; //Resmin genişliğini alıyoruz


            int y = resim1.Height; //Resmin yüksekliğini alıyoruz
            float diff = 0;
            for (int r = 0; r < y; r++)


            {


                for (int c = 0; c < x; c++)


                {


                    Color pixel1 = resim1.GetPixel(c, r);
                    Color pixel2 = resim2.GetPixel(c, r);

                    diff += Math.Abs(pixel1.R - pixel2.R);
                    diff += Math.Abs(pixel1.G - pixel2.G);
                    diff += Math.Abs(pixel1.B - pixel2.B);


                  


                }


            }

            float threshold = 100 * (diff / 255) / (resim1.Width * resim1.Height * 3);
   
            if (threshold < 5)
            {
               
                return "Doğru";
            }
            else
            {
                
                return "";
            }

        }


      
   

       
        
        private void button0_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button0.BackgroundImage;
                button0.FlatAppearance.BorderColor = Color.Orange;
                button0.FlatAppearance.BorderSize = 3;

                lblResim.Text = "0";
            }
            else
            {
                pictureBox2.Image = button0.BackgroundImage;
                button0.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;

                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button0.BackgroundImage, imgarray[0]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[0].Enabled = false;
                    btn[0].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button1.BackgroundImage;
                button1.FlatAppearance.BorderColor = Color.Orange;
                button1.FlatAppearance.BorderSize = 3;
               
                lblResim.Text = "1";
            }
            else
            {
                pictureBox2.Image = button1.BackgroundImage;
                button1.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;

                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;

                if (getrgb(button1.BackgroundImage, imgarray[1]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[1].Enabled = false;
                    btn[1].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button2.BackgroundImage;
                button2.FlatAppearance.BorderColor = Color.Orange;
                button2.FlatAppearance.BorderSize = 3;
                lblResim.Text = "2";
            }
            else
            {
                pictureBox2.Image = button2.BackgroundImage;
                button2.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;

                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button2.BackgroundImage, imgarray[2]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[2].Enabled = false;
                    btn[2].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button3.BackgroundImage;
                button3.FlatAppearance.BorderColor = Color.Orange;
                button3.FlatAppearance.BorderSize = 3;
                lblResim.Text = "3";
            }
            else
            {
                pictureBox2.Image = button3.BackgroundImage;
                button3.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button3.BackgroundImage, imgarray[3]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[3].Enabled = false;
                    btn[3].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button4.BackgroundImage;
                button4.FlatAppearance.BorderColor = Color.Orange;
                button4.FlatAppearance.BorderSize = 3;
                lblResim.Text = "4";
            }
            else
            {
                pictureBox2.Image = button4.BackgroundImage;
                button4.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button4.BackgroundImage, imgarray[4]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[4].Enabled = false;
                    btn[4].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button5.BackgroundImage;
                button5.FlatAppearance.BorderColor = Color.Orange;
                button5.FlatAppearance.BorderSize = 3;
                lblResim.Text = "5";
            }
            else
            {
                pictureBox2.Image = button5.BackgroundImage;
                button5.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button5.BackgroundImage, imgarray[5]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[5].Enabled = false;
                    btn[5].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button6.BackgroundImage;
                button6.FlatAppearance.BorderColor = Color.Orange;
                button6.FlatAppearance.BorderSize = 3;
                lblResim.Text = "6";
            }
            else
            {
                pictureBox2.Image = button6.BackgroundImage;
                button6.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button6.BackgroundImage, imgarray[6]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[6].Enabled = false;
                    btn[6].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button7.BackgroundImage;
                button7.FlatAppearance.BorderColor = Color.Orange;
                button7.FlatAppearance.BorderSize = 3;
                lblResim.Text = "7";
            }
            else
            {
                pictureBox2.Image = button7.BackgroundImage;
                button7.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button7.BackgroundImage, imgarray[7]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[7].Enabled = false;
                    btn[7].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
               
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button8.BackgroundImage;
                button8.FlatAppearance.BorderColor = Color.Orange;
                button8.FlatAppearance.BorderSize = 3;
                lblResim.Text = "8";
            }
            else
            {
                pictureBox2.Image = button8.BackgroundImage;
                button8.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button8.BackgroundImage, imgarray[8]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[8].Enabled = false;
                    btn[8].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button9.BackgroundImage;
                button9.FlatAppearance.BorderColor = Color.Orange;
                button9.FlatAppearance.BorderSize = 3;
                lblResim.Text = "9";
            }
            else
            {
                pictureBox2.Image = button9.BackgroundImage;
                button9.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button9.BackgroundImage, imgarray[9]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[9].Enabled = false;
                    btn[9].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button10.BackgroundImage;
                button10.FlatAppearance.BorderColor = Color.Orange;
                button10.FlatAppearance.BorderSize = 3;
                lblResim.Text = "10";
            }
            else
            {
                pictureBox2.Image = button10.BackgroundImage;
                button10.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button10.BackgroundImage, imgarray[10]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[10].Enabled = false;
                    btn[10].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button11.BackgroundImage;
                button11.FlatAppearance.BorderColor = Color.Orange;
                button11.FlatAppearance.BorderSize = 3;
                lblResim.Text = "11";
            }
            else
            {
                pictureBox2.Image = button11.BackgroundImage;
                button11.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button11.BackgroundImage, imgarray[11]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[11].Enabled = false;
                    btn[11].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
               
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button12.BackgroundImage;
                button12.FlatAppearance.BorderColor = Color.Orange;
                button12.FlatAppearance.BorderSize = 3;
                lblResim.Text = "12";
            }
            else
            {
                pictureBox2.Image = button12.BackgroundImage;
                button12.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button12.BackgroundImage, imgarray[12]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[12].Enabled = false;
                    btn[12].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button13.BackgroundImage;
                button13.FlatAppearance.BorderColor = Color.Orange;
                button13.FlatAppearance.BorderSize = 3;
                lblResim.Text = "13";
            }
            else
            {
                pictureBox2.Image = button13.BackgroundImage;
                button13.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button13.BackgroundImage, imgarray[13]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[13].Enabled = false;
                    btn[13].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button14.BackgroundImage;
                button14.FlatAppearance.BorderColor = Color.Orange;
                button14.FlatAppearance.BorderSize = 3;
                lblResim.Text = "14";
            }
            else
            {
                pictureBox2.Image = button14.BackgroundImage;
                button14.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button14.BackgroundImage, imgarray[14]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[14].Enabled = false;
                    btn[14].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button15.BackgroundImage;
                button15.FlatAppearance.BorderColor = Color.Orange;
                button15.FlatAppearance.BorderSize = 3;
                lblResim.Text = "15";
            }
            else
            {
                pictureBox2.Image = button15.BackgroundImage;
                button15.BackgroundImage = pictureBox1.Image;
                btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage = pictureBox2.Image;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                btn[Convert.ToInt32(lblResim.Text.ToString())].FlatAppearance.BorderSize = 0;
                if (getrgb(button15.BackgroundImage, imgarray[15]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[15].Enabled = false;
                    btn[15].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
                else
                {
                    int puan = Convert.ToInt32(lblPoint.Text) - 10;
                    lblPoint.Text = puan.ToString();
                }
                if (getrgb(btn[Convert.ToInt32(lblResim.Text.ToString())].BackgroundImage, imgarray[Convert.ToInt32(lblResim.Text.ToString())]) == "Doğru")
                {
                    int puan = Convert.ToInt32(lblPoint.Text) + 5;
                    lblPoint.Text = puan.ToString();
                    btn[Convert.ToInt32(lblResim.Text.ToString())].Enabled = false;
                    btn[Convert.ToInt32(lblResim.Text.ToString())].ForeColor = Color.AliceBlue;
                    ButtonControl();
                }
               
            }
        }
        Bitmap denemeResimi1,denemeResimi2;
        ArrayList arr = new ArrayList();
        ArrayList arr2 = new ArrayList();

        private void btn2gozat_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            denemeResimi2 = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);

            for (int i = 0; i < denemeResimi2.Width; i++)
            {
                for (int j = 0; j < denemeResimi2.Height; j++)
                {
                    arr2.Add(denemeResimi2.GetPixel(i, j).Name);
                }
            }
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
                string number = "";

                ArrayList sayilar = new ArrayList();
                while (number != null)
                {
                    number = sw.ReadLine();


                    if (number != null && number != "")
                    {
                        number = number.Substring(number.LastIndexOf(" ") + 1, number.Length - number.LastIndexOf(" ") - 1);
                        sayilar.Add(number);
                    }
                }
                int high = 0;
                for (int index = 0; index < sayilar.Count; index++)
                {
                    if (IsNumeric(sayilar[index].ToString()))
                    {
                        if (Convert.ToInt32(sayilar[index]) > high)
                        {
                            high = Convert.ToInt32(sayilar[index]);
                        }
                    }
                }
                lblHightPoint.Text = high.ToString();

                //Veriyi tampon bölgeden dosyaya aktardık.
                sw.Close();
                fs.Close();
            }
            else
            {
                
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
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lblError.Text == "Oyun bitti.Skorunuz sisteme kaydedilmiştir.")
            {
                DialogResult dialog = MessageBox.Show("Çıkmaktan emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo);
                Login frm = new Login();
                this.Hide();
                frm.ShowDialog();
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Çıkmaktan emin misiniz ? Puanınız kaydedilecektir.", "Çıkış", MessageBoxButtons.YesNo);



                if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {

                    string dosya_yolu = Application.StartupPath + @"\enyüksekskor.txt";
                    if (File.Exists(dosya_yolu))
                    {


                        using (StreamWriter w = File.AppendText(dosya_yolu))
                        {
                            w.WriteLine(lblName.Text + ": "+lblPoint.Text.ToString());
                            w.Close();
                        }




                    }
                    Login frm = new Login();
                    this.Hide();
                    frm.ShowDialog();


                }
            }

        }

        private void btnGozAt_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            denemeResimi1 = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);

            for(int i = 0; i < denemeResimi1.Width; i++)
            {
                for(int j = 0; j < denemeResimi1.Height; j++)
                {
                    arr.Add(denemeResimi1.GetPixel(i, j).Name);
                }
            }
        }
    }
}
