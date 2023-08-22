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
    public partial class Ana_Sayfa : Form
    {
        dB_İslemleri dB = new dB_İslemleri();
        static public bool klavye;
        static public double bakiye;
        public Ana_Sayfa()
        {
            InitializeComponent();
            
        }
        //Bir metod oluşturduk ki aynı kodları tekrardan yazmayalım.
        private void getir (Form frm)
        {
            //bakiye_Ana_Sayfa.Text = odeme_İslemleri_Form.bakiye.ToString();
            bakiye_Ana_Sayfa.Text = Ana_Sayfa.bakiye.ToString();
            //Burada panelimize getireceğimiz formu tanımlıyoruz.
            //Paneli temizle
            panel5.Controls.Clear();
            //Üst düzey bir pencere olmasın yani diğerlerinin de önüne geçmesin. Bunu yazıyoruz ki bu kodları üst düzey denetim olarak algılamasın. 
            frm.TopLevel = false;
            //Panele formu ekle
            panel5.Controls.Add(frm);
            //Formu göster
            frm.Show();
            //Form  panelde ne yapsın.
            frm.Dock = DockStyle.None;
            //Formu öne çıkartma
            frm.BringToFront();
            
        }
        
        private void cikis_Ana_Sayfa_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Girise_Don_Ana_Click(object sender, EventArgs e)
        {
            panel4.Location = new Point(0, 74);
            if (MessageBox.Show("Tekrardan giriş yapmak istiyor musun?", "Girişe Dön", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Giris giris = new Giris();
                //Başka bir yolu 
                // Application.OpenForms["Giris"].Show();
                giris.Show();
                this.Hide();
            }
            
        }

        private void btn_Ana_Sayfa_Click(object sender, EventArgs e)
        {
            bakiye_Ana_Sayfa.Text = Ana_Sayfa.bakiye.ToString();
            panel4.Location = new Point(0, 216);
            

            //Bu form üzerinden form geçişleri yapılıyor. Başka formdan bu sayfadaki getir metodunun tetikleyemiyoruz.
            //Bu yüzden nesnelerimizi her defasında ekliyoruz.
            panel5.Controls.Clear();
            panel5.Controls.Add(pictureBox4);
            panel5.Controls.Add(pictureBox5);
            pictureBox4.Dock = DockStyle.Left;
            pictureBox4.Size = new Size(402, 577);
            pictureBox5.Dock = DockStyle.Right;
            pictureBox5.Size = new Size(402, 577);

        }
        //Başlangıç
        //PictureBox larımızın eventları
        
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.BackgroundImage = Properties.Resources.oyna;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackgroundImage = Properties.Resources.KatlaSamanıpng;
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = Properties.Resources.oyna;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = Properties.Resources.isim_250x500;
        }

        //Bitiş
        
        private void btn_Odeme_Click(object sender, EventArgs e)
        {
            panel4.Location = new Point(0, 350);
            odeme_İslemleri_Form odeme = new odeme_İslemleri_Form();
            getir(odeme);

        }

        private void btn_Ayarlar_Click(object sender, EventArgs e)
        {
            panel4.Location = new Point(0, 490);
            Ayarlar ayar = new Ayarlar();
            getir(ayar);
            
        }
        //Zamanlar için sayaç tanımı

        int sayac_Saniye = 0;
        int sayac_Dakika = 0;
        int sayac_Saat = 0;
        //Tetiklenmesini istediğimiz timer komutlarını buraya yazıyoruz.
        public static bool gorunum;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Her 1 saniyede bir saniyeyi arttır.
            sayac_Saniye++;
            label3.Text = sayac_Saniye.ToString();
            //Eğer 1 dk olduysa onu yazdır.
            if (sayac_Saniye%60==0)
            {
                sayac_Dakika++;
                label4.Text = sayac_Dakika.ToString()+ "  :" ;
                sayac_Saniye = 0;
                //Eğer bir saat olduysa da onu da yazdır ne olcak ki.
                if (sayac_Dakika%60==0)
                {
                    sayac_Saat++;
                    label5.Text =  sayac_Saat.ToString() + "  :";
                    sayac_Dakika = 0;
                }
            }
            //Burda UcSharp oyunumuzu yeniden başlatmamız için bir deyim yazdık.
            UcSharp uc = new UcSharp();
            if (UcSharp.bitis_Dogrula == true)
            {
                getir(uc);
                gorunum = true;
                
            }
        }
       
        private void Ana_Sayfa_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = dB_İslemleri.k_Adi_DB;
            dB.dB_P_Cek();
            
            bakiye = Convert.ToDouble( dB_İslemleri.money);
            bakiye_Ana_Sayfa.Text = bakiye.ToString();
        }

        private void cikis_Ana_Sayfa_MouseHover(object sender, EventArgs e)
        {
            cikis_Ana_Sayfa.BackgroundImage = Properties.Resources.okey_Ana_Sayfa;
        }

        private void cikis_Ana_Sayfa_MouseLeave(object sender, EventArgs e)
        {
            cikis_Ana_Sayfa.BackgroundImage = Properties.Resources.cikis_2;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Katla_Samanı k_Samanı = new Katla_Samanı();
            getir(k_Samanı);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UcSharp uc = new UcSharp();
            getir(uc);
        }
    }
}
