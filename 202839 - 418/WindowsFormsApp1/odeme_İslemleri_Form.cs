using System;
using System.Collections;
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
    public partial class odeme_İslemleri_Form : Form
    {

        dB_İslemleri dB = new dB_İslemleri();
        public odeme_İslemleri_Form()
        {
            InitializeComponent();
            
            for (int yil = 2021; yil < 2040; yil++)
            {
                comboBox2.Items.Add(yil);
            }
        }
        string ilk_Harf;
        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            label8.Text = maskedTextBox1.Text;
            //Burda maskedTextBox1' in ilk rakamını alma.
            ilk_Harf = maskedTextBox1.Text.Substring(0, 1);
            if (ilk_Harf == "4")
            {
                pictureBox1.Image = Properties.Resources.visa;
            }
            else if (ilk_Harf == "5")
            {
                pictureBox1.Image = Properties.Resources.master_Card;
            }
            else if (ilk_Harf == "3")
            {
                pictureBox1.Image = Properties.Resources.american_Express;
            }
            else if (ilk_Harf == "6")
            {
                pictureBox1.Image = Properties.Resources.Discover_Card_01;
            }
            else
            {
                pictureBox1.Image = null;
            }
        }
        

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            label12.Text = maskedTextBox2.Text;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label10.Text = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label10.Text += " / "+comboBox2.Text;
        }

        //KeyPressEventArgs e önemli burda basıaln tuşun değerini alıyoruz.
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char.IsLetter(); Unicode harfi olarak kategorize edilip edilemeyeceğini kontrol etmek için kullanılır.
            //char.IsControl(); Belirtilen bir dizede belirtilen konumdaki karakterin bir kontrol karakteri olarak kategorize edilip edilmediğini belirtmek için kullanılır.
            //char.IsSeparator(); Unicode karakterinin ayırıcı karakter olarak kategorilere ayrılmadığını gösterir.
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToUpper();
            textBox1.SelectionStart = textBox1.Text.Length;
            label13.Text = textBox1.Text;
        }

        private void yatir_Click(object sender, EventArgs e)
        {
            
            if (maskedTextBox1.Text.Length != 31)//maskedTextbox içindeki "  -  " ler dahil 31 karakter varmı diye soruyoruz
            {
                MessageBox.Show("Kart Numarası eksik"); //rakamlar eksik ise uyarı verelim
                maskedTextBox1.Focus(); //imlecimzi odaklayalım
            }
            else
            {
                //öncelikle kart numaralarımız tutacak bir dizi tanımlıyoruz
                ArrayList kart = new ArrayList();
                //_ _ _ _  -  _ _ _ _  -  _ _ _ _  -  _ _ _ _ :31karakter(16 rakam ve 3 tire ve 12 boşluk)
                for (int i = 0; i < 31; i++)
                {
                    kart.Add(maskedTextBox1.Text.Substring(i, 1)); //her bir karakter bir diziye alınıyor
                }
                //MasketTextBox kullandığımız için aradaki tireleri ve boşlukları atarak 16 tane olan numaramızı elde ediyoruz.
                kart.Remove("-"); kart.Remove("-"); kart.Remove("-");
                kart.Remove(" "); kart.Remove(" "); kart.Remove(" "); kart.Remove(" "); kart.Remove(" "); kart.Remove(" ");
                kart.Remove(" "); kart.Remove(" "); kart.Remove(" "); kart.Remove(" "); kart.Remove(" "); kart.Remove(" ");

                ArrayList cift = new ArrayList();//çift rakamları elde edeceğimiz için bir dizi daha tanımladık
                for (int k = 0; k < 16; k++)
                {
                    if (k % 2 == 0) //çift indisli rakamları(yani tek rakamları) almak için kontrol ediyoruz
                    {
                        cift.Add(2 * Convert.ToInt32(kart[k].ToString()));//diziye tek rakamlar 2 ile çarpılarak alınıyor
                    }

                }
                string tam = "";
                foreach (int a in cift)
                {
                    tam += a.ToString(); //aldığımız rakamaların basamak değerlerini toplamak için önce
                                         //tek bir string'e çeviriyoruz daha sonra bu stringi ayırıp basamak toplaması yapacağız

                }
                // tek ve cift rakamları elde ederek toplamını toplama tutacak değişkenlerimizi tanımladık
                int toplam_cift = 0, toplam_tek = 0, toplam = 0;
                for (int j = 0; j < tam.Length; j++)
                {
                    toplam_cift += Convert.ToInt32(tam.Substring(j, 1));
                }
                for (int m = 1; m < 16; m += 2)
                {
                    toplam_tek += Convert.ToInt32(kart[m]);
                }
                
                toplam = toplam_tek + toplam_cift; // toplamı elde ederek mod10 değerini alıyoruz
                if (toplam % 10 == 0) // eğer toplam sonucu 10'a tam bölünürse kart geçerli, değilse geçersiz
                {

                    if (textBox4.Text != "" && textBox4.Text != 0.ToString())
                    {
                        if (textBox1.Text!="" && maskedTextBox2.Text!="" && comboBox1.Text!="" && comboBox2.Text !="")
                        {
                            
                            MessageBox.Show("Kartınız geçerli. İşlem onaylandı.");
                            double sonBakiye = int.Parse(textBox4.Text);
                            double ilkBakiye = Ana_Sayfa.bakiye;
                            Ana_Sayfa.bakiye = sonBakiye + ilkBakiye;
                            dB.dB_P_Guncelle(Ana_Sayfa.bakiye);


                            textBox1.Clear();
                            comboBox1.Text = "";
                            label10.Text = "";
                            comboBox2.Text = "";
                            maskedTextBox1.Text = "";
                            maskedTextBox2.Text = "";
                            textBox3.Clear();
                            textBox4.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Boş alanlar var. Lütfen doldurun...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Yüklemek istediğiniz miktarı giriniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Kartınız geçersiz.");
                    maskedTextBox1.Text = "";
                    maskedTextBox1.Focus();
                }

            }
            
        }

        private void cek_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length != 31)//maskedTextbox içindeki "  -  " ler dahil 31 karakter varmı diye soruyoruz
            {
                MessageBox.Show("Kart Numarası eksik"); //rakamlar eksik ise uyarı verelim
                maskedTextBox1.Focus(); //imlecimzi odaklayalım
            }
            else
            {
                //öncelikle kart numaralarımız tutacak bir dizi tanımlıyoruz
                ArrayList kart = new ArrayList();
                //_ _ _ _  -  _ _ _ _  -  _ _ _ _  -  _ _ _ _ :31karakter(16 rakam ve 3 tire ve 12 boşluk)
                for (int i = 0; i < 31; i++)
                {
                    kart.Add(maskedTextBox1.Text.Substring(i, 1)); //her bir karakter bir diziye alınıyor
                }
                //MasketTextBox kullandığımız için aradaki tireleri ve boşlukları atarak 16 tane olan numaramızı elde ediyoruz.
                kart.Remove("-"); kart.Remove("-"); kart.Remove("-");
                kart.Remove(" "); kart.Remove(" "); kart.Remove(" "); kart.Remove(" "); kart.Remove(" "); kart.Remove(" ");
                kart.Remove(" "); kart.Remove(" "); kart.Remove(" "); kart.Remove(" "); kart.Remove(" "); kart.Remove(" ");

                ArrayList cift = new ArrayList();//çift rakamları elde edeceğimiz için bir dizi daha tanımladık
                for (int k = 0; k < 16; k++)
                {
                    if (k % 2 == 0) //çift indisli rakamları(yani tek rakamları) almak için kontrol ediyoruz
                    {
                        cift.Add(2 * Convert.ToInt32(kart[k].ToString()));//diziye tek rakamlar 2 ile çarpılarak alınıyor
                    }

                }
                string tam = "";
                foreach (int a in cift)
                {
                    tam += a.ToString(); //aldığımız rakamaların basamak değerlerini toplamak için önce
                                         //tek bir string'e çeviriyoruz daha sonra bu stringi ayırıp basamak toplaması yapacağız

                }
                // tek ve cift rakamları elde ederek toplamını toplama tutacak değişkenlerimizi tanımladık
                int toplam_cift = 0, toplam_tek = 0, toplam = 0;
                for (int j = 0; j < tam.Length; j++)
                {
                    toplam_cift += Convert.ToInt32(tam.Substring(j, 1));
                }
                for (int m = 1; m < 16; m += 2)
                {
                    toplam_tek += Convert.ToInt32(kart[m]);
                }

                toplam = toplam_tek + toplam_cift; // toplamı elde ederek mod10 değerini alıyoruz
                if (toplam % 10 == 0) // eğer toplam sonucu 10'a tam bölünürse kart geçerli, değilse geçersiz
                {

                    if (textBox3.Text != "" && textBox3.Text != 0.ToString())
                    {
                        if (double.Parse(textBox3.Text) <= Ana_Sayfa.bakiye && double.Parse(textBox3.Text) >= 5)
                        {
                            if (textBox1.Text != "" && maskedTextBox2.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
                            {
                                MessageBox.Show("Kartınız geçerli. İşlem onaylandı.");
                                double a = Ana_Sayfa.bakiye;
                                double b = double.Parse(textBox3.Text);
                                double kalan = a - b;
                                Ana_Sayfa.bakiye = kalan;
                                dB.dB_P_Guncelle(Ana_Sayfa.bakiye);


                                textBox1.Clear();
                                comboBox1.Text = "";
                                label10.Text = "";
                                comboBox2.Text = "";
                                maskedTextBox1.Text = "";
                                maskedTextBox2.Text = "";
                                textBox3.Clear();
                                textBox4.Clear();
                                
                            }
                            else
                            {
                                MessageBox.Show("Boş alanlar var. Lütfen doldurun...");
                            }
                        }
                        else if (int.Parse(textBox3.Text)<=5 && int.Parse(textBox3.Text)>0)
                        {
                            MessageBox.Show("Lütfen bakiyenizi kontrol edin. En küçük 5TL çekebilirsiniz.");
                        }
                        else
                        {
                            MessageBox.Show("Mevcut para yetersiz...");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Çekmek istediğiniz miktarı giriniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Kartınız geçersiz.");
                    maskedTextBox1.Text = "";
                    maskedTextBox1.Focus();
                }

            }
        }
    }
}
