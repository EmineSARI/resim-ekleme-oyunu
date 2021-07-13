using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calisma
{
    public partial class Form1 : Form
    {
        Image[] resimler =
        {
            Properties.Resources.a,
            Properties.Resources.b,
            Properties.Resources.c,
            Properties.Resources.d,
            Properties.Resources.f,
            Properties.Resources.g,
            Properties.Resources.h,
            Properties.Resources.j,

        };
        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        PictureBox ilkkutu;
        int ilkIndeks,bulunan, deneme;


        public Form1()
        {
            InitializeComponent();
        }


         private void Form1_Load(object sender, EventArgs e)
         {
            resimleriKaristir();

         }

        private void resimleriKaristir()
        {
            Random rnd = new Random();


            for (int i = 0; i <16 ; i++)
            {
                int sayi = rnd.Next(16);

                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;


            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox kutu = (PictureBox)sender;
            int kutuNo = int.Parse(kutu.Name.Substring(10));
            int indeksNo = indeksler[kutuNo-1];
            kutu.Image =resimler[indeksNo];
            kutu.Refresh();

            if (ilkkutu == null)
            {
                ilkkutu = kutu;
                ilkIndeks = indeksNo;
                deneme++;

            }

            else
            {
                System.Threading.Thread.Sleep(1000);

                ilkkutu.Image = null;
                kutu.Image = null;

                if (ilkIndeks == indeksNo)
                {
                    bulunan++;
                    ilkkutu.Visible = false;
                    kutu.Visible = false;

                    if (bulunan == 8)
                    {
                        MessageBox.Show("Tebrikler."+ deneme+ "denemede  buldunuz.");
                        bulunan = 0;
                        deneme = 0;

                        foreach (Control kontrol in Controls)
                        {
                            kontrol.Visible = true;

                        }

                        resimleriKaristir();
                    }
                   

                }
                ilkkutu = null;


            }
            }

        }

     
    }

