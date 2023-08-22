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
    public partial class Ayarlar : Form
    {
        dB_İslemleri dB = new dB_İslemleri();
        public Ayarlar()
        {
            InitializeComponent();
            ToolTip aciklama_Kayit = new ToolTip();
            aciklama_Kayit.SetToolTip(Goster_Gizle_Ayarlar, "Şifrenizi göstermek veya gizlemek için;Eski Şifre, Şifre ve Şifre Tekrar kutularını doldurunuz...");
            aciklama_Kayit.ToolTipTitle = "Dikkat!";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }
        int sayac;
        private void Goster_Gizle_Ayarlar_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                //Eğer sayac 2 ye tam bölünüyorsa karakterini * yap ve resmini kilitli yap. Bölünmüyorsa karakter görünür olsun kilit de açık olsun.
                sayac++;
                if (sayac % 2 == 0)
                {
                    textBox5.PasswordChar = char.Parse("*");
                    textBox6.PasswordChar = char.Parse("*");
                    textBox7.PasswordChar = char.Parse("*");
                    Goster_Gizle_Ayarlar.BackgroundImage = Properties.Resources.close_Eye_Black;
                }
                else
                {
                    textBox5.PasswordChar = char.Parse("\0");
                    textBox6.PasswordChar = char.Parse("\0");
                    textBox7.PasswordChar = char.Parse("\0");
                    Goster_Gizle_Ayarlar.BackgroundImage = Properties.Resources.eye_Black;
                }
            }
        }

        private void kayit_Sil_Click(object sender, EventArgs e)
        {
            dB.sifre_Cek(textBox7.Text);
            if (dB.durum_Sifre==true)
            {
                if (MessageBox.Show("Kaydınızı silmek istediğinizden emin misiniz?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dB.dB_Sil();
                    Application.Restart();
                }
                
            }
            else if (dB.durum_Sifre==false)
            {
                MessageBox.Show("Eski şifrenle yazdığın şifre doğru değil.");
            }
            else
            {
                MessageBox.Show("Boş alanlar var.");
            }
           
            
        }

        private void güncelle_Click(object sender, EventArgs e)
        {
            if (textBox6.Text!="" && textBox7.Text !="" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox5.Text != "")
            {
                dB.sifre_Cek(textBox7.Text);
                if (dB.durum_Sifre == true)
                {
                    if (textBox5.Text == textBox6.Text)
                    {
                        if (MessageBox.Show("Kaydınızı güncellemek istediğinizden emin misiniz?", "Kayıt Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            dB.dB_Güncelle(textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text);
                            Application.Restart();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Yeni Şifre ile Yeni Şifre Tekrar eşleşmiyor.");
                    }

                }
                else if (dB.durum_Sifre == false)
                {
                    MessageBox.Show("Eski şifrenle yazdığın şifre doğru değil.");
                }
            }
            else
            {
                MessageBox.Show("Boş alanlar var.");
            }
            
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            dB.dB_Tum_Veriler();
            textBox1.Text = dB_İslemleri.a_S;
            textBox2.Text = dB_İslemleri.e_P;
            textBox3.Text = dB_İslemleri.k_Adi_DB;
        }
    }
}
