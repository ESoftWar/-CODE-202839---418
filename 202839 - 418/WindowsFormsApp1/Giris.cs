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
    public partial class Giris : Form
    {
        Kayit kayit = new Kayit();
        Ana_Sayfa ana_Sayfa = new Ana_Sayfa();
        dB_İslemleri dB = new dB_İslemleri();
        public Giris()
        {
            
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Font eski = textBox1.Font;
            textBox1.Font = new Font(eski.FontFamily, 9, eski.Style);
            Font eski_2 = textBox2.Font;
            textBox2.Font = new Font(eski_2.FontFamily, 9, eski_2.Style);
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            ToolTip aciklama_Giris = new ToolTip();
            textBox1.Text = "Kullanıcı Adı";
            textBox2.Text = "Şifre";
            aciklama_Giris.SetToolTip(Goster_Gizle_Giris, "Şifrenizi göstermek veya gizlemek için; Şifre kutusunu doldurunuz...");
            aciklama_Giris.ToolTipTitle = "Dikkat!";
            aciklama_Giris.SetToolTip(Kayit_İslem, "Kullanıcı kaydı oluşturmak için tıklayınız...");
            aciklama_Giris.ToolTipTitle = "Bilgilendirme";
            aciklama_Giris.SetToolTip(Giris_Gonder, "Ana sayfaya erişim için tıklayınız...");
            aciklama_Giris.ToolTipTitle = "Bilgilendirme";
        }

        private void Giris_Gonder_MouseHover(object sender, EventArgs e)
        {
            Giris_Gonder.Height = 66;
            Giris_Gonder.Width = 72;
        }

        private void Giris_Gonder_MouseLeave(object sender, EventArgs e)
        {
            Giris_Gonder.Height = 56;
            Giris_Gonder.Width = 62;
        }

        private void Kayit_İslem_MouseHover(object sender, EventArgs e)
        {
            Kayit_İslem.Height = 66;
            Kayit_İslem.Width = 72;
        }

        private void Kayit_İslem_MouseLeave(object sender, EventArgs e)
        {
            Kayit_İslem.Height = 56;
            Kayit_İslem.Width = 62;
        }
        //TextBox1 Komutları

        bool tikla;
        private void textBox1_Click(object sender, EventArgs e)
        {
            Font eski = textBox1.Font;
            textBox1.Font = new Font(eski.FontFamily, 12, eski.Style);
            // TextBox a tıklandığında tiklamayı doğrula. Akabinde SaltOkunurluğu kapat ve yazı rengini değiştir.

            tikla = true;
            textBox1.ReadOnly = false;
            textBox1.ForeColor = Color.Black;

            //Eğer textBox 2 nin içi boşsa ve textBox 1 e tıklanmışsa salt okunurluğu aç içine şifre yaz karakterini değiştir rengini değiştir.

            if (textBox2.Text == "")
            {
                Font eski_2 = textBox1.Font;
                textBox2.Font = new Font(eski_2.FontFamily, 9, eski_2.Style);
                textBox2.Text = "Şifre";
                textBox2.PasswordChar = char.Parse("\0");
                textBox2.ForeColor = Color.DarkGray;
                textBox2.ReadOnly = true;
            }
            if (textBox1.Text=="Kullanıcı Adı")
            {
                textBox1.Clear();
            }
        }
        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            //İlk önce içi bir veri ile dolu mu onu kontrol ettiriyoruz. Eğer doluysa o veriyi textbox içinde bırakıyor.

            if (textBox1.Text != "Kullanıcı Adı")
            {
                textBox1.Text = textBox1.Text;
            }

            //Dolu değilse textin içini boşaltıyor kullanıma hazır hale getirebilmek için.

            else
            {
                textBox1.Clear();
            }
        }
        
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            //Eğer textBox boş ise ve tıklanmamışsa rengini değiştir, kullanıcı adı yazdır ve salt okunurluğu aç ki yanlış değer girilmesin.

            if (textBox1.Text == "" && tikla == false)
            {
                textBox1.ForeColor = Color.DarkGray;
                textBox1.Text = "Kullanıcı Adı";
                textBox1.ReadOnly = true;
            }

            //Bunlar değilse textBox a tıklanmışsa ve textBox ın içi boşsa salt okunurluğu kapat.

           else if (tikla==true && textBox1.Text=="")
            {
                textBox1.ReadOnly = false;
            }
        }
        //TextBox2 Komutları
        bool tikla_2;
        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            //İlk önce içi bir veri ile dolu mu onu kontrol ettiriyoruz. Eğer doluysa o veriyi textbox içinde bırakıyor.

            if (textBox2.Text!="Şifre")
            {
                textBox2.Text = textBox2.Text;
            }

            //Dolu değilse textin içini boşaltıyor kullanıma hazır hale getirebilmek için.

            else 
            {
                textBox2.Clear();
            }
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            Font eski_2 = textBox2.Font;
            textBox2.Font = new Font(eski_2.FontFamily, 12, eski_2.Style);
            //TextBox2 ye tıklamayı doğrula salt okunurluğu kapat, rengini değiştir, karakterini değiştir.

            tikla_2 = true;
            textBox2.ReadOnly = false;
            textBox2.ForeColor = Color.Black;
            textBox2.PasswordChar = char.Parse("*");

            /*Eğer sayacın 2 ile bölümünden kalanı 1 ise onu açık bırak.Çünkü tıklama işleminde passwordChar * oluyor her tıklandığında. Bunu önlemek
            için böyle bir satır yazıyoruz.*/

            if (sayac%2==1)
            {
                textBox2.PasswordChar = char.Parse("\0");
            }

            //Burda da imleci textBox 1 den ikiye aldığımızda eğer textBox1 in içi boşsa Kullanıcı adı yazdır ve salt okunurluğu kapat.
            if (textBox1.Text=="")
            {
                Font eski = textBox1.Font;
                textBox1.Font = new Font(eski.FontFamily, 9, eski.Style);
                textBox1.Text = "Kullanıcı Adı";
                textBox1.ForeColor = Color.DarkGray;
                textBox1.ReadOnly = true;
            }
            if (textBox2.Text=="Şifre")
            {
                textBox2.Clear();
            }
        }
        private void textBox2_MouseLeave(object sender, EventArgs e)
        {

            //Eğer textBox boş ise ve tıklanmamışsa rengini değiştir, kullanıcı adı yazdır ve salt okunurluğu kapat ki yanlış değer girilmesin.

            if (textBox2.Text == "" && tikla_2 == false)
            {
                textBox2.ForeColor = Color.DarkGray;
                textBox2.Text = "Şifre";
                textBox2.PasswordChar = char.Parse("\0");
                textBox2.ReadOnly = true;
            }

            //Bunlar değilse textBox a tıklanmışsa ve textBox ın içi boşsa salt okunurluğu aç.

            else if (tikla_2 == true && textBox2.Text == "")
            {
                textBox2.ReadOnly = false;
            }
            
        }
        //Cikis Komutları
        //Butonun üstüne gelindiğinde resmini değiştirmek. 

        private void Cikis_MouseHover(object sender, EventArgs e)
        {
            Cikis.BackgroundImage = Properties.Resources.icons8_checkmark_25px;
        }

        private void Cikis_MouseLeave(object sender, EventArgs e)
        {
            Cikis.BackgroundImage = Properties.Resources.icons8_delete_25px;
        }

        /*
         Butonumuza tıklandığında çıkış işlemi için soru soran kod. Baştan sona sırasıyla Verilecek mesaj, başlık, butonlar, simge
         Abort,Retry,Ignore - Durdur, Yeniden Dene, Yoksay
         OK - Tamam
         OK, Cancel - Tamam, İptal
         Retry, Cancel - Yeniden Dene, İptal
         Yes, No - Evet, Hayır
         Yes,No,Cancel -  Evet, Hayır, İptal 
         */

        private void Cikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Uygulamayı kapatmak üzeresin. Kapatmak istiyor musun ?", "Çıkış", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        //Goster_Gizle Komutları
        //Göster gizle tıklama sayacı
        int sayac;
        private void Goster_Gizle_Giris_Click(object sender, EventArgs e)
        {
            //Eğer Şifre kutuları bir değerle dolu ise diğer işlemleri yap
            if (textBox2.Text!="Şifre"&&textBox2.Text!="")
            {
                //Eğer sayac 2 ye tam bölünüyorsa karakterini * yap ve resmini kilitli yap. Bölünmüyorsa karakter görünür olsun kilit de açık olsun.
                sayac++;
                if (sayac % 2 == 0)
                {
                    textBox2.PasswordChar = char.Parse("*");
                    Goster_Gizle_Giris.BackgroundImage = Properties.Resources.icons8_lock_30px;
                }
                else
                {
                    textBox2.PasswordChar = char.Parse("\0");
                    Goster_Gizle_Giris.BackgroundImage = Properties.Resources.icons8_unlock_30px;
                }
            }
            
        }
        //Kayıt_İslem Butonu 

        private void Kayit_İslem_Click(object sender, EventArgs e)
        { 
            //Tool tip nesnesi ürettiğimiz için ve kayit formunda da bulunduğu için program aşırı yükleme hatası veriyor bu yüzden kullanacağımız yerde
            //tanımlıyoruz.
            
            kayit.Show();
            this.Hide();
        }

        private void Giris_Gonder_Click(object sender, EventArgs e)
        {
            dB.dB_Giris_Dogrula(textBox1.Text, textBox2.Text);
            if (textBox1.Text!=""&&textBox2.Text!="")
            {
                if (dB.durum_Giris_Dogrula==true)
                {
                    ana_Sayfa.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı giriş.");
                }
                
            }
            else
            {
                MessageBox.Show("Doldurulmayan alanlar var.");
            }
            

        }
    }
}
