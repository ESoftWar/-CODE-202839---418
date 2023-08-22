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
    public partial class Kayit : Form
    {
        Ana_Sayfa ana_Sayfa = new Ana_Sayfa();
        dB_İslemleri dB = new dB_İslemleri();
        
        //Giris giris = new Giris();
        //Fare üstüne açıklama yapmak için nesne türettik.
        public Kayit()
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // İlk fontu tutan nesne oluşturduk. Bu nesne bizim ilk fontumuzu size ımızın 3 eksiğini ve sitilini tutuyor.
            Font eski = textBox1.Font;
            textBox1.Font = new Font(eski.FontFamily, 9, eski.Style);
            textBox1.Text = "Ad Soyad";
            Font eski_2 = textBox2.Font;
            textBox2.Font = new Font(eski_2.FontFamily, 9, eski_2.Style);
            textBox2.Text = "E Posta";
            Font eski_3 = textBox3.Font;
            textBox3.Font = new Font(eski_3.FontFamily, 9, eski_3.Style);
            textBox3.Text = "Kullanıcı Adı";
            Font eski_4 = textBox4.Font;
            textBox4.Font = new Font(eski_4.FontFamily, 9, eski_4.Style);
            textBox4.Text = "Şifre";
            Font eski_5 = textBox5.Font;
            textBox5.Font = new Font(eski_5.FontFamily, 9, eski_5.Style);
            textBox5.Text = "Şifre Tekrar";
        }
        private void Kayit_Load(object sender, EventArgs e)
        {
            ToolTip aciklama_Kayit = new ToolTip();
            aciklama_Kayit.SetToolTip(Goster_Gizle_Kayit, "Şifrenizi göstermek veya gizlemek için; Şifre ve Şifre Tekrar kutularını doldurunuz...");
            aciklama_Kayit.ToolTipTitle = "Dikkat!";
            aciklama_Kayit.SetToolTip(Girise_Don, "Giriş sayfasına gitmek için tıklayınız...");
            aciklama_Kayit.ToolTipTitle = "Bilgilendirme";
            aciklama_Kayit.SetToolTip(Temizle, "Temizlemek için tıklayınız...");
            aciklama_Kayit.ToolTipTitle = "Bilgilendirme";
            aciklama_Kayit.SetToolTip(Kayit_Ol, "Kayıt olmak için tıklayınız...");
            aciklama_Kayit.ToolTipTitle = "Bilgilendirme";
        }
        // Çıkış Butonu
        private void Cikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Uygulamayı kapatmak üzeresin. Kapatmak istiyor musun ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
        private void Cikis_MouseHover(object sender, EventArgs e)
        {
            Cikis.BackgroundImage = Properties.Resources.ok_Kayit;
        }

        private void Cikis_MouseLeave(object sender, EventArgs e)
        {
            Cikis.BackgroundImage = Properties.Resources.cancel_Kayit;
        }
        // Goster_Gizle Butonu
        int sayac;
        private void Goster_Gizle_Kayit_Click(object sender, EventArgs e)
        {
            //Eğer Şifre kutuları bir değerle dolu ise diğer işlemleri yap
            if ((textBox4.Text != "Şifre" && textBox4.Text != "") && (textBox5.Text != "Şifre Tekrar" && textBox5.Text != ""))
            {
                //Eğer sayac 2 ye tam bölünüyorsa karakterini * yap ve resmini kilitli yap. Bölünmüyorsa karakter görünür olsun kilit de açık olsun.
                sayac++;
                if (sayac % 2 == 0)
                {
                    textBox4.PasswordChar = char.Parse("*");
                    textBox5.PasswordChar = char.Parse("*");
                    Goster_Gizle_Kayit.BackgroundImage = Properties.Resources.icons8_eyelashes_2d_30px_1;
                }
                else
                {
                    textBox4.PasswordChar = char.Parse("\0");
                    textBox5.PasswordChar = char.Parse("\0");
                    Goster_Gizle_Kayit.BackgroundImage = Properties.Resources.icons8_eye_30px_2;
                }
            }
        }
        // textBox1 Komutları
        bool tikla;

        private void textBox1_Click(object sender, EventArgs e)
        {

            Font eski = textBox1.Font;
            textBox1.Font = new Font(eski.FontFamily, 12, eski.Style);


            // TextBox a tıklandığında tiklamayı doğrula. Akabinde SaltOkunurluğu kapat ve yazı rengini değiştir.
            tikla = true;
            textBox1.ReadOnly = false;
            textBox1.ForeColor = Color.White;

            //Eğer textBox 2 nin içi boşsa ve textBox 1 e tıklanmışsa salt okunurluğu aç içine E Posta yaz karakterini değiştir rengini değiştir.

            if (textBox2.Text == "")
            {
                // Fontunu boyutunu ve stilini eski haline döndür.
                Font eski_2 = textBox1.Font;
                textBox2.Font = new Font(eski_2.FontFamily, 9, eski_2.Style);
                textBox2.Text = "E Posta";
                textBox2.ForeColor = Color.DarkGray;
                textBox2.ReadOnly = true;
            }
            if (textBox3.Text == "")
            {
                Font eski_3 = textBox3.Font;
                textBox3.Font = new Font(eski_3.FontFamily, 9, eski_3.Style);
                textBox3.Text = "Kullanıcı Adı";
                textBox3.ForeColor = Color.DarkGray;
                textBox3.ReadOnly = true;
            }
            if (textBox4.Text == "")
            {
                Font eski_4 = textBox4.Font;
                textBox4.Font = new Font(eski_4.FontFamily, 9, eski_4.Style);
                textBox4.Text = "Şifre";
                textBox4.PasswordChar = char.Parse("\0");
                textBox4.ForeColor = Color.DarkGray;
                textBox4.ReadOnly = true;
            }
            if (textBox5.Text == "")
            {
                Font eski_5 = textBox5.Font;
                textBox5.Font = new Font(eski_5.FontFamily, 9, eski_5.Style);
                textBox5.Text = "Şifre Tekrar";
                textBox5.PasswordChar = char.Parse("\0");
                textBox5.ForeColor = Color.DarkGray;
                textBox5.ReadOnly = true;
            }
            if (textBox1.Text == "Ad Soyad")
            {

                textBox1.Clear();
            }
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            //İlk önce içi bir veri ile dolu mu onu kontrol ettiriyoruz. Eğer doluysa o veriyi textbox içinde bırakıyor.

            if (textBox1.Text != "Ad Soyad")
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
            //Eğer textBox boş ise ve tıklanmamışsa rengini değiştir, Ad Soyad yazdır ve salt okunurluğu aç ki yanlış değer girilmesin.

            if (textBox1.Text == "" && tikla == false)
            {
                textBox1.ForeColor = Color.DarkGray;
                textBox1.Text = "Ad Soyad";
                textBox1.ReadOnly = true;
            }

            //Bunlar değilse textBox a tıklanmışsa ve textBox ın içi boşsa salt okunurluğu kapat.

            else if (tikla == true && textBox1.Text == "")
            {
                textBox1.ReadOnly = false;
            }
        }

        //TextBox2 Komutları
        bool tikla_2;
        private void textBox2_Click(object sender, EventArgs e)
        {
            Font eski_2 = textBox2.Font;
            textBox2.Font = new Font(eski_2.FontFamily, 12, eski_2.Style);

            //TextBox2 ye tıklamayı doğrula salt okunurluğu kapat, rengini değiştir, karakterini değiştir.

            tikla_2 = true;
            textBox2.ReadOnly = false;
            textBox2.ForeColor = Color.White;

            //Burda da imleci textBox 1 den ikiye aldığımızda eğer textBox1 in içi boşsa Ad Soyad yazdır ve salt okunurluğu kapat.
            if (textBox1.Text == "")
            {
                // Fontu eski haline çevirme
                Font eski = textBox1.Font;
                textBox1.Font = new Font(eski.FontFamily, 9, eski.Style);
                textBox1.Text = "Ad Soyad";
                textBox1.ForeColor = Color.DarkGray;
                textBox1.ReadOnly = true;
            }
            if (textBox3.Text == "")
            {
                Font eski_3 = textBox3.Font;
                textBox3.Font = new Font(eski_3.FontFamily, 9, eski_3.Style);
                textBox3.Text = "Kullanıcı Adı";
                textBox3.ForeColor = Color.DarkGray;
                textBox3.ReadOnly = true;
            }
            if (textBox4.Text == "")
            {
                Font eski_4 = textBox4.Font;
                textBox4.Font = new Font(eski_4.FontFamily, 9, eski_4.Style);
                textBox4.Text = "Şifre";
                textBox4.PasswordChar = char.Parse("\0");
                textBox4.ForeColor = Color.DarkGray;
                textBox4.ReadOnly = true;
            }
            if (textBox5.Text == "")
            {
                Font eski_5 = textBox5.Font;
                textBox5.Font = new Font(eski_5.FontFamily, 9, eski_5.Style);
                textBox5.Text = "Şifre Tekrar";
                textBox5.PasswordChar = char.Parse("\0");
                textBox5.ForeColor = Color.DarkGray;
                textBox5.ReadOnly = true;
            }
            if (textBox2.Text == "E Posta")
            {
                textBox2.Clear();
            }
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            //İlk önce içi bir veri ile dolu mu onu kontrol ettiriyoruz. Eğer doluysa o veriyi textbox içinde bırakıyor.

            if (textBox2.Text != "E Posta")
            {
                textBox2.Text = textBox2.Text;
            }

            //Dolu değilse textin içini boşaltıyor kullanıma hazır hale getirebilmek için.

            else
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
                textBox2.Text = "E Posta";
                textBox2.ReadOnly = true;
            }

            //Bunlar değilse textBox a tıklanmışsa ve textBox ın içi boşsa salt okunurluğu aç.

            else if (tikla_2 == true && textBox2.Text == "")
            {
                textBox2.ReadOnly = false;
            }
        }

        //TextBox3 Komutları
        bool tikla_3;
        private void textBox3_Click(object sender, EventArgs e)
        {
            Font eski_3 = textBox3.Font;
            textBox3.Font = new Font(eski_3.FontFamily, 12, eski_3.Style);
            //TextBox2 ye tıklamayı doğrula salt okunurluğu kapat, rengini değiştir, karakterini değiştir.

            tikla_3 = true;
            textBox3.ReadOnly = false;
            textBox3.ForeColor = Color.White;

            //Burda da imleci textBox 1 den ikiye aldığımızda eğer textBox1 in içi boşsa Ad Soyad yazdır ve salt okunurluğu kapat.
            if (textBox1.Text == "")
            {
                Font eski = textBox1.Font;
                textBox1.Font = new Font(eski.FontFamily, 9, eski.Style);
                textBox1.Text = "Ad Soyad";
                textBox1.ForeColor = Color.DarkGray;
                textBox1.ReadOnly = true;
            }
            if (textBox2.Text == "")
            {
                Font eski_2 = textBox1.Font;
                textBox2.Font = new Font(eski_2.FontFamily, 9, eski_2.Style);
                textBox2.Text = "E Posta";
                textBox2.ForeColor = Color.DarkGray;
                textBox2.ReadOnly = true;
            }
            if (textBox4.Text == "")
            {
                Font eski_4 = textBox4.Font;
                textBox4.Font = new Font(eski_4.FontFamily, 9, eski_4.Style);
                textBox4.Text = "Şifre";
                textBox4.PasswordChar = char.Parse("\0");
                textBox4.ForeColor = Color.DarkGray;
                textBox4.ReadOnly = true;
            }
            if (textBox5.Text == "")
            {
                Font eski_5 = textBox5.Font;
                textBox5.Font = new Font(eski_5.FontFamily, 9, eski_5.Style);
                textBox5.Text = "Şifre Tekrar";
                textBox5.PasswordChar = char.Parse("\0");
                textBox5.ForeColor = Color.DarkGray;
                textBox5.ReadOnly = true;
            }
            if (textBox3.Text == "Kullanıcı Adı")
            {
                textBox3.Clear();
            }
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            if (textBox3.Text != "Kullanıcı Adı")
            {
                textBox3.Text = textBox3.Text;
            }

            //Dolu değilse textin içini boşaltıyor kullanıma hazır hale getirebilmek için.

            else
            {
                textBox3.Clear();
            }
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            if (textBox3.Text == "" && tikla_3 == false)
            {
                textBox3.ForeColor = Color.DarkGray;
                textBox3.Text = "Kullanıcı Adı";
                textBox3.ReadOnly = true;
            }

            //Bunlar değilse textBox a tıklanmışsa ve textBox ın içi boşsa salt okunurluğu aç.

            else if (tikla_3 == true && textBox3.Text == "")
            {
                textBox3.ReadOnly = false;
            }
        }

        //TextBox4 Komutları
        bool tikla_4;

        private void textBox4_Click(object sender, EventArgs e)
        {
            Font eski_4 = textBox4.Font;
            textBox4.Font = new Font(eski_4.FontFamily, 12, eski_4.Style);

            tikla_4 = true;
            textBox4.ForeColor = Color.White;
            textBox4.PasswordChar = char.Parse("*");
            textBox4.ReadOnly = false;

            if (sayac % 2 == 1)
            {
                textBox4.PasswordChar = char.Parse("\0");
                textBox5.PasswordChar = char.Parse("\0");
            }
            if (textBox1.Text == "")
            {
                Font eski = textBox1.Font;
                textBox1.Font = new Font(eski.FontFamily, 9, eski.Style);
                textBox1.Text = "Ad Soyad";
                textBox1.ForeColor = Color.DarkGray;
                textBox1.ReadOnly = true;
            }
            if (textBox2.Text == "")
            {
                Font eski_2 = textBox1.Font;
                textBox2.Font = new Font(eski_2.FontFamily, 9, eski_2.Style);
                textBox2.Text = "E Posta";
                textBox2.ForeColor = Color.DarkGray;
                textBox2.ReadOnly = true;
            }
            if (textBox3.Text == "")
            {
                Font eski_3 = textBox3.Font;
                textBox3.Font = new Font(eski_3.FontFamily, 9, eski_3.Style);
                textBox3.Text = "Kullanıcı Adı";
                textBox3.ForeColor = Color.DarkGray;
                textBox3.ReadOnly = true;
            }
            if (textBox5.Text == "")
            {
                Font eski_5 = textBox5.Font;
                textBox5.Font = new Font(eski_5.FontFamily, 9, eski_5.Style);
                textBox5.Text = "Şifre Tekrar";
                textBox5.PasswordChar = char.Parse("\0");
                textBox5.ForeColor = Color.DarkGray;
                textBox5.ReadOnly = true;
            }
            if (textBox4.Text == "Şifre")
            {
                textBox4.Clear();
            }
        }

        private void textBox4_MouseHover(object sender, EventArgs e)
        {
            if (textBox4.Text != "Şifre")
            {
                textBox4.Text = textBox4.Text;
            }
            else
            {
                textBox4.Clear();
            }

        }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
            if (textBox4.Text == "" && tikla_4 == false)
            {
                textBox4.ForeColor = Color.DarkGray;
                textBox4.Text = "Şifre";
                textBox4.PasswordChar = char.Parse("\0");
                textBox4.ReadOnly = true;
            }

            //Bunlar değilse textBox a tıklanmışsa ve textBox ın içi boşsa salt okunurluğu aç.

            else if (tikla_4 == true && textBox4.Text == "")
            {
                textBox4.ReadOnly = false;
            }
        }

        // textBox5 Komutları
        bool tikla_5;
        private void textBox5_Click(object sender, EventArgs e)
        {
            Font eski_5 = textBox5.Font;
            textBox5.Font = new Font(eski_5.FontFamily, 12, eski_5.Style);

            tikla_5 = true;
            textBox5.ForeColor = Color.White;
            textBox5.PasswordChar = char.Parse("*");
            textBox5.ReadOnly = false;

            if (sayac % 2 == 1)
            {
                textBox4.PasswordChar = char.Parse("\0");
                textBox5.PasswordChar = char.Parse("\0");
            }
            if (textBox1.Text == "")
            {
                Font eski = textBox1.Font;
                textBox1.Font = new Font(eski.FontFamily, 9, eski.Style);
                textBox1.Text = "Ad Soyad";
                textBox1.ForeColor = Color.DarkGray;
                textBox1.ReadOnly = true;
            }
            if (textBox2.Text == "")
            {
                Font eski_2 = textBox1.Font;
                textBox2.Font = new Font(eski_2.FontFamily, 9, eski_2.Style);
                textBox2.Text = "E Posta";
                textBox2.ForeColor = Color.DarkGray;
                textBox2.ReadOnly = true;
            }
            if (textBox3.Text == "")
            {
                Font eski_3 = textBox3.Font;
                textBox3.Font = new Font(eski_3.FontFamily, 9, eski_3.Style);
                textBox3.Text = "Kullanıcı Adı";
                textBox3.ForeColor = Color.DarkGray;
                textBox3.ReadOnly = true;
            }
            if (textBox4.Text == "")
            {
                Font eski_4 = textBox4.Font;
                textBox4.Font = new Font(eski_4.FontFamily, 9, eski_4.Style);
                textBox4.Text = "Şifre";
                textBox4.PasswordChar = char.Parse("\0");
                textBox4.ForeColor = Color.DarkGray;
                textBox4.ReadOnly = true;
            }
            if (textBox5.Text == "Şifre Tekrar")
            {
                textBox5.Clear();
            }
        }

        private void textBox5_MouseHover(object sender, EventArgs e)
        {
            if (textBox5.Text != "Şifre Tekrar")
            {
                textBox5.Text = textBox5.Text;
            }
            else
            {
                textBox5.Clear();
            }
        }

        private void textBox5_MouseLeave(object sender, EventArgs e)
        {
            if (textBox5.Text == "" && tikla_5 == false)
            {
                textBox5.ForeColor = Color.DarkGray;
                textBox5.Text = "Şifre Tekrar";
                textBox5.PasswordChar = char.Parse("\0");
                textBox5.ReadOnly = true;
            }

            //Bunlar değilse textBox a tıklanmışsa ve textBox ın içi boşsa salt okunurluğu aç.

            else if (tikla_5 == true && textBox5.Text == "")
            {
                textBox5.ReadOnly = false;
            }
        }

        private void Girise_Don_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }

        private void Temizle_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            Font eski = textBox1.Font;
            textBox1.Font = new Font(eski.FontFamily, 9, eski.Style);
            Font eski_2 = textBox1.Font;
            textBox2.Font = new Font(eski.FontFamily, 9, eski.Style);
            Font eski_3 = textBox1.Font;
            textBox3.Font = new Font(eski.FontFamily, 9, eski.Style);
            Font eski_4 = textBox1.Font;
            textBox4.Font = new Font(eski.FontFamily, 9, eski.Style);
            Font eski_5 = textBox1.Font;
            textBox5.Font = new Font(eski.FontFamily, 9, eski.Style);
            textBox1.Text = "Ad Soyad";
            textBox2.Text = "E Posta";
            textBox3.Text = "Kullanıcı Adı";
            textBox4.Text = "Şifre";
            textBox5.Text = "Şifre Tekrar";
            textBox4.PasswordChar = char.Parse("\0");
            textBox5.PasswordChar = char.Parse("\0");
            textBox1.ForeColor = Color.DarkGray;
            textBox2.ForeColor = Color.DarkGray;
            textBox3.ForeColor = Color.DarkGray;
            textBox4.ForeColor = Color.DarkGray;
            textBox5.ForeColor = Color.DarkGray;

        }

        private void Girise_Don_MouseHover(object sender, EventArgs e)
        {
            Girise_Don.BackgroundImage = Properties.Resources.geri_don_Black;
        }

        private void Girise_Don_MouseLeave(object sender, EventArgs e)
        {
            Girise_Don.BackgroundImage = Properties.Resources.icons8_loginrout_80px;
        }

        private void Temizle_MouseHover(object sender, EventArgs e)
        {
            Temizle.BackgroundImage = Properties.Resources.cop;
        }

        private void Temizle_MouseLeave(object sender, EventArgs e)
        {
            Temizle.BackgroundImage = Properties.Resources.icons8_disposal_80px;
        }

        private void Kayit_Ol_Click(object sender, EventArgs e)
        {
            
            if ((textBox1.Text!="" && textBox2.Text!="" && textBox3.Text!="" && textBox4.Text!="" && textBox5.Text !="" )&& (textBox1.Text!="Ad Soyad" && textBox2.Text!="E Posta" && textBox3.Text!="Kullanıcı Adı" && textBox4.Text !="Şifre" && textBox5.Text!="Şifre Tekrar" ))
            {
                dB.dB_Kayit_Dogrula(textBox3.Text);
                if (dB.durum_Kayit == false)
                {
                    if (textBox4.Text == textBox5.Text)
                    {
                        dB.dB_Kayit_Olustur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                        ana_Sayfa.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Şifreler eşleşmiyor.");
                    }
                }
                else if (dB.durum_Kayit == true)
                {
                    MessageBox.Show("Kullanıcı adın başka biri tarafından alınmış. Lütfen başak bir kullanıcı adı gir.");
                }    
            }
            else
            {
                MessageBox.Show("Boş alanlar var.");
            }
        }

        private void Kayit_Ol_MouseHover(object sender, EventArgs e)
        {
            Kayit_Ol.BackgroundImage = Properties.Resources.ileri_git_Black;
        }

        private void Kayit_Ol_MouseLeave(object sender, EventArgs e)
        {
            Kayit_Ol.BackgroundImage = Properties.Resources.icons8_login_80px;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }
    }
}
