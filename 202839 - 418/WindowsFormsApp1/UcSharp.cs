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
    public partial class UcSharp : Form
    {
        dB_İslemleri dB = new dB_İslemleri();
        public UcSharp()
        {
            InitializeComponent();
        }
        //Dikdörtgenlerin sayısının değeri
        int d_Sayisi = 0;
        //Karakterimizin düşüşü için bir sayaç.
        int k_Dusus = 0;
        //Zıplama sayaç.
        int k_Ziplama = 0;
        //
        int d_Sayac = 0;
        //Skor değeri
        public int skor = 0;

        bool artis = false;
        bool baslangic = false;

        //Dikdörtgenlerimizin tutulduğu list nesnesi
        List<PictureBox> pb_bilgi = new List<PictureBox>();


        private void dikdörtgen_Uret_Ust(int x, int y)
        {
            //Dikdörtgenlerin sayısının değişkeni
            d_Sayisi++;
            //PictureBox nesnesi
            PictureBox pb = new PictureBox();
            //PictureBox ismi
            pb.Name = "pb" + d_Sayisi;
            //PictureBox boyutları
            pb.SetBounds(x, 0, 100, y);
            //Üret babacım ama genelinin arkasında üret üst düzey yönetimin altında üret. Form denetiminin alt denetimi olduğu için.
            pb.SendToBack();
            //Resmini yapıştır.
            pb.Image = Properties.Resources.boru;
            //Resmin boyutunu ayarla
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            //Resmin arka plan rengini ayarla
            pb.BackColor = Color.Transparent;
            //Bunları da formumuza ekle
            this.Controls.Add(pb);
            //Formda bu dikdörtgenleri öne çıkart. Arkasından geçenlerin üstünde kalsın. Üst düzey yönetim.
            pb.BringToFront();
            //PictureBox list imize bu dikdörtgenlerin bilgisini ekle.
            pb_bilgi.Add(pb);
        }

        public void dikdortgen_Uret_Alt(int x, int y)
        {
            //Üsttekilerle aynı sadece BringToFront a gerek yok çünkü burda bir alt düzey yönetim yok ki üste çıksın.
            d_Sayisi++;
            PictureBox pb = new PictureBox();
            pb.Name = "pb" + d_Sayisi;
            pb.SetBounds(x, y + 200, 100, this.Size.Height-5);
            pb.SendToBack();
            pb.Image = Properties.Resources.boru2;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.BackColor = Color.Transparent;
            this.Controls.Add(pb);
            pb_bilgi.Add(pb);

        }

        static public bool bitis_Dogrula;
        public void bitir()
        {

            //Oyunu bitir pek bir şeyi yok klasik.
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            label2.Left = (this.Size.Width - label2.Size.Width) / 2;
            label2.Top = this.Size.Height / 2;
            label2.Visible = true;
            label2.Text = "Kaybettin";
            label3.Text = "Skor: " + skor;
            dB.dB_S_Guncelle(skor);
            //Bitirince de bu çalışıyor ardından 1 sny sonra yeniden başlatılıyor.
            bitis_Dogrula = true;
        }

        //Karakterimizi hareket ettirmme işlemmlerimiz.
        int sayac;

        private void UcSharp_Load(object sender, EventArgs e)
        {
            dB.dB_Sırala();
            dataGridView1.DataSource = dB.ds.Tables["k_Bilgileri"];
            
            //Her saniye yeniden başlatmasın diye ilk önce değerini false yapıyoruz.
            bitis_Dogrula = false;
            sayac = 0;
            //Form ilk açıldığında başlangıcı sıfırla ve dikdörtgenleri üret
            if (baslangic == false)
            {
                Random rastgele = new Random();
                int sayi = rastgele.Next(150, this.Size.Height - 250);
                dikdortgen_Uret_Alt(this.Size.Width, sayi);
                dikdörtgen_Uret_Ust(this.Size.Width, sayi);
                baslangic = true;
            }
            // karakteri hazırla.
            karakter.Left = this.Size.Width / 2;
            karakter.Top = this.Size.Height / 2;
            karakter.Image = Properties.Resources.logo;
            karakter.Width = 50;
            karakter.Height = 50;
            karakter.SizeMode = PictureBoxSizeMode.StretchImage;
            karakter.BackColor = Color.Transparent;
            this.Controls.Add(karakter);
        }

        private void UcSharp_KeyDown(object sender, KeyEventArgs e)
        {

            sayac++;
            if (sayac == 1)
            {
                label4.Visible = false;
                timer1.Enabled = true;
                timer2.Enabled = true;
                timer3.Enabled = true;
            }

            //Eğer space e tıklamışsa
            if (e.KeyCode == Keys.Space)
            {
                dataGridView1.Visible = false;
                //Zıplama ve zorluk dereceleri belli bir sayıda zıplamadan sonra arttırıyoruz.
                k_Ziplama++;
                if (k_Ziplama <= 2)
                {
                    karakter.Top -= 10;
                }
                else if (k_Ziplama > 2 && k_Ziplama < 5)
                {
                    karakter.Top -= 20;
                }
                else if (k_Ziplama >= 5)
                {
                    karakter.Top -= 45;
                }
                label3.Text = "SKOR:" + skor;
                //Her zıpladığımızda düşüş sıfırlansın ki ekstra düşüşler yaşanmasın. Mazallah çakılırız yere.
                k_Dusus = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Boruları sola kaydırma
            foreach (var item in pb_bilgi)
            {
                item.Left -= 6;
            }
            //Borulara değdi mi değmedi mi değdiyse bitir oyunu
            if (karakter.Right > pb_bilgi[d_Sayac].Left && karakter.Left < pb_bilgi[d_Sayac].Right)
            {
                if (karakter.Bottom > pb_bilgi[d_Sayac].Top + 5)
                {
                    bitir();
                }
                else if (karakter.Top < pb_bilgi[d_Sayac + 1].Bottom - 5)
                {
                    bitir();
                }
                else if (karakter.Bottom < pb_bilgi[d_Sayac].Top && karakter.Top > pb_bilgi[d_Sayac + 1].Bottom)
                {
                    artis = true;
                }
            }
            if (artis == true)
            {
                if (karakter.Left > pb_bilgi[d_Sayac].Right)
                {
                    //İkisinden de geçtiğini belirtmek için iki kez arttırdık
                    d_Sayac++;
                    d_Sayac++;
                    skor++;
                    artis = false;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Zorluk dereceleri
            if (skor <= 10)
            {
                //Skor 10a eşit ve küçükse 85 saniyede bir.
                Random rastgele = new Random();
                int sayi = rastgele.Next(150, this.Size.Height - 250);
                dikdortgen_Uret_Alt(this.Size.Width, sayi);
                dikdörtgen_Uret_Ust(this.Size.Width, sayi);
            }
            else if (skor > 10 && skor <= 20)
            {
                //Skor 10 dan büyükse ve 20ye eşit ve küçükse 58 saniyede bir.
                timer2.Interval = 3500;
                Random rastgele = new Random();
                int sayi = rastgele.Next(150, this.Size.Height - 250);
                dikdortgen_Uret_Alt(this.Size.Width, sayi);
                dikdörtgen_Uret_Ust(this.Size.Width, sayi);
            }
            else if (skor > 20)
            {
                //Skor 20 den büyükse 41 saniyede bir.
                timer2.Interval = 2500;
                Random rastgele = new Random();
                int sayi = rastgele.Next(150, this.Size.Height - 250);
                dikdortgen_Uret_Alt(this.Size.Width, sayi);
                dikdörtgen_Uret_Ust(this.Size.Width, sayi);
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //Karakterimizin düşüşü ve düşüş süreleri
            k_Dusus++;
            if (k_Dusus < 5)
            {
                karakter.Top += 0;
            }
            else if (k_Dusus <= 15)
            {
                karakter.Top += 1;
            }
            else if (k_Dusus > 15 && k_Dusus < 20)
            {
                karakter.Top += 5;
            }
            else if (k_Dusus >= 20)
            {
                karakter.Top += 10;
            }
            //Baktı çok düşüyor kaldır babam kaldır
            if (k_Dusus > 20)
            {
                k_Ziplama = 10;
            }
            //Eğer karakter ekranın sonundaysa bitir yavrum oyunu.
            if (karakter.Bottom >= this.Size.Height)
            {
                bitir();
            }
            //Eğer ekranın en üstüne çıkmak isterse daha da çıkamasın diye 0 lıyoruz ve üstte kalıyor.
            if (karakter.Top <= 0)
            {
                karakter.Top = 0;
            }
        }
    }
}
