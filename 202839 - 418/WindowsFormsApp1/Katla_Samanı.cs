using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Katla_Samanı : Form
    {
        dB_İslemleri dB = new dB_İslemleri();
        public Katla_Samanı()
        {
            InitializeComponent();
        }

        private void label3_doubleClick(object sender, EventArgs e)
        {
            label3.ForeColor = Color.RoyalBlue;
            label3.Text = "vazgeçtiysen tek tıkla.";
            richTextBox2.Visible = true;

        }

        private void label3_Click(object sender, EventArgs e)
        {
            richTextBox2.Visible = false;
            label3.ForeColor = Color.DarkOrange;
            label3.Text = "tamam tamam kızma çift tıkla.";
        }
        public double yatirilan;
        public double katlanan;
        void MayinDoldur(int mayin, int boyut, int boyut2)
        {
            //Mayınlar için bir dizi atıyoruz. Boyutunu da başlayı cliklediğimizde yazıyoruz.
            int[] mayinlar = new int[mayin];
            //Random nesnesi türettik.
            Random rnd = new Random();
            //Her mayın doldur metodu çalıştığında mayınları boşalt.
            flowLayoutPanel1.Controls.Clear();
            //Mayınlarımızı diziye dolduruyoruz.
            //0 ile yüksekli genişlik çarıpımı arasında mayın türetiyor.
            for (int i = 0; i < mayin; i++)
            {
                int secilen = rnd.Next(0, boyut * boyut2);
                //Mayınların belirtilen koşulda olup olmadığını kontrol ediyoruz.
                if (mayinlar.Contains(secilen))
                {
                    i--;
                    continue;
                }
                mayinlar[i] = secilen;

            }
            //Burda mayınlarımız için dolu ve boş butonları tanımlıyoruz
            for (int i = 0; i < boyut * boyut2; i++)
            {
                Button btn = new Button();
                btn.Width = 40;
                btn.Height = 40;
                btn.Tag = mayinlar.Contains(i);
                btn.Click += Btn_Click;
                flowLayoutPanel1.Controls.Add(btn);
                btn.BackColor = Color.Black;
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            //Tıklanan butonun bilgisini alıyoruz.
            Button tıklananButon = (Button)sender;
            //Tıklanan butonun true ya da false olduğunu .Tag properties inden çekiyoruz.
            bool durum = (bool)tıklananButon.Tag;
            if (durum == true)
            {
                //Mayına bastın geçmiş olsun :)
                tıklananButon.Enabled = false;
                tıklananButon.BackColor = Color.Red;
                OyunuBitir();
            }
            else
            {
                //Vayy basmadın helal olsun.
                tıklananButon.Enabled = false;
                tıklananButon.BackColor = Color.Green;
                //Yatırılan parayı katlıyoruz.
                yatirilan *= 1.2;
            }
            katlanan = Math.Ceiling(yatirilan); 
            
        }
        void OyunuBitir()
        {
            katlanan = 0;
            //Butonların hepsini çekmemizi sağlıyor.
            foreach (Button item in flowLayoutPanel1.Controls)
            {
                //Butonların hepsini kullanılamaz hale getiriyoruz
                bool durum = (bool)item.Tag;
                if (durum == true)
                {
                    item.Enabled = false;
                }
                else
                {
                    item.Enabled = false;
                }
            }
            MessageBox.Show("Kaybettiniz.");
            bitir.Enabled = false;
        }
        private void basla_Click(object sender, EventArgs e)
        {

          int x = (int)numericUpDown1.Value;
          if (x <= Ana_Sayfa.bakiye && x >= 10)
          {
                //Parayı veri tabanından çekeceksin ve her işlem yapıldığında güncelleyeceksin.
                //bakiyeye de veri tabanındaki sayıyı yazacaksın
                bitir.Enabled = true;
                MayinDoldur(25, 4, 15);
                Ana_Sayfa.bakiye -= x;
                dB.dB_P_Guncelle(Ana_Sayfa.bakiye);
                yatirilan = x;
                label2.Text = 0.ToString();

           }
           else if (x<=10)
           {
                MessageBox.Show("En az 10 TL ile oynayabilirsin.");
           }
           else
           {
                MessageBox.Show("Para yükleyin.");
           }
     
        }

        private void bitir_Click(object sender, EventArgs e)
        {
            label2.Text = katlanan.ToString();
            flowLayoutPanel1.Controls.Clear();
            double total = Ana_Sayfa.bakiye + katlanan;
            Ana_Sayfa.bakiye = total;
            dB.dB_P_Guncelle(Ana_Sayfa.bakiye);
            bitir.Enabled = false;
        }

        private void Katla_Samanı_Load(object sender, EventArgs e)
        {
            bitir.Enabled = false;
        }
    }
}
