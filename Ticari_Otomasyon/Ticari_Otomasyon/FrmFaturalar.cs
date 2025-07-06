using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Ticari_Otomasyon
{
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {

            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FATURABILGI", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void Temizle()
        {
            txtId.Text = "";
            txtSeri.Text = "";
            txtSiraNo.Text = "";
            mskTarih.Text = "";
            mskSaat.Text = "";
            mskSaat.Text = "";
            txtVergiDaire.Text = "";
            txtAlici.Text = "";
            txtTeslimEden.Text = "";
            txtTeslimAlan.Text = "";
        }
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            listele();
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //*************************  Fatura Bigi Kaydetme     ******************
            if (txtFaturaId.Text == "")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI(SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", txtSeri.Text);
                komut.Parameters.AddWithValue("@P2", txtSiraNo.Text);
                komut.Parameters.AddWithValue("@P3", mskTarih.Text);
                komut.Parameters.AddWithValue("@P4", mskSaat.Text);
                komut.Parameters.AddWithValue("@P5", txtVergiDaire.Text);
                komut.Parameters.AddWithValue("@P6", txtAlici.Text);
                komut.Parameters.AddWithValue("@P7", txtTeslimEden.Text);
                komut.Parameters.AddWithValue("@P8", txtTeslimAlan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura sisteme kaydedilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }


            //*************************  Fatura Detay Kaydetme     ******************

            //Firma Carisi
            if (txtFaturaId.Text != "" && comboBox1.Text=="Firma")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtFiyat.Text);
                miktar = Convert.ToDouble(txtMiktar.Text);
                tutar = fiyat * miktar;
                txtTutar.Text = tutar.ToString();

                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) values (@P1,@P2,@P3,@P4,@P5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@P1", txtUrunAd.Text);
                komut2.Parameters.AddWithValue("@P2", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@P3", decimal.Parse( txtFiyat.Text));
                komut2.Parameters.AddWithValue("@P4",decimal.Parse( txtTutar.Text));
                komut2.Parameters.AddWithValue("@P5", txtFaturaId.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Hareket Taplosuna Veri Kaydetme
                SqlCommand komut3 = new SqlCommand("insert into TBL_FIRMAHAREKETLER (URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,TARIH) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", txtUrunId.Text);
                komut3.Parameters.AddWithValue("@h2", txtMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", txtPersonel.Text);
                komut3.Parameters.AddWithValue("@h4", txtFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(txtTutar.Text));
                komut3.Parameters.AddWithValue("@h7", txtFaturaId.Text);
                komut3.Parameters.AddWithValue("@h8", mskTarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();


                //Stok Sayısını Azaltma
                SqlCommand komut4 = new SqlCommand("Update TBL_URUNLER set ADET=ADET-@s1 where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", txtMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", txtUrunId.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Faturata ait ürün kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //Müşteri Carisi
            if (txtFaturaId.Text != "" && comboBox1.Text == "Müşteri")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtFiyat.Text);
                miktar = Convert.ToDouble(txtMiktar.Text);
                tutar = fiyat * miktar;
                txtTutar.Text = tutar.ToString();

                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) values (@P1,@P2,@P3,@P4,@P5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@P1", txtUrunAd.Text);
                komut2.Parameters.AddWithValue("@P2", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@P3", decimal.Parse(txtFiyat.Text));
                komut2.Parameters.AddWithValue("@P4", decimal.Parse(txtTutar.Text));
                komut2.Parameters.AddWithValue("@P5", txtFaturaId.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Hareket Taplosuna Veri Kaydetme
                SqlCommand komut3 = new SqlCommand("insert into TBL_MUSTERIHAREKETLER (URUNID,ADET,PERSONEL,MUSTERI,FIYAT,TOPLAM,FATURAID,TARIH) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", txtUrunId.Text);
                komut3.Parameters.AddWithValue("@h2", txtMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", txtPersonel.Text);
                komut3.Parameters.AddWithValue("@h4", txtFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(txtTutar.Text));
                komut3.Parameters.AddWithValue("@h7", txtFaturaId.Text);
                komut3.Parameters.AddWithValue("@h8", mskTarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();


                //Stok Sayısını Azaltma
                SqlCommand komut4 = new SqlCommand("Update TBL_URUNLER set ADET=ADET-@s1 where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", txtMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", txtUrunId.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Faturata ait ürün kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["FATURABILGIID"].ToString();
                txtSeri.Text = dr["SERI"].ToString();
                txtSiraNo.Text = dr["SIRANO"].ToString();
                mskTarih.Text = dr["TARIH"].ToString();
                mskSaat.Text = dr["SAAT"].ToString();
                txtVergiDaire.Text = dr["VERGIDAIRE"].ToString();
                txtAlici.Text = dr["ALICI"].ToString();
                txtTeslimEden.Text = dr["TESLIMEDEN"].ToString();
                txtTeslimAlan.Text = dr["TESLIMALAN"].ToString();
            }
        }

        private void btnTemizle_Click_1(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_FATURABILGI where FATURABILGIID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura sistemden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURABILGI set SERI=@P1,SIRANO=@P2,TARIH=@P3,SAAT=@P4,VERGIDAIRE=@P5,ALICI=@P6, TESLIMEDEN=@P7,TESLIMALAN=@P8 where FATURABILGIID=@P9", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtSeri.Text);
            komut.Parameters.AddWithValue("@P2", txtSiraNo.Text);
            komut.Parameters.AddWithValue("@P3", mskTarih.Text);
            komut.Parameters.AddWithValue("@P4", mskSaat.Text);
            komut.Parameters.AddWithValue("@P5", txtVergiDaire.Text);
            komut.Parameters.AddWithValue("@P6", txtAlici.Text);
            komut.Parameters.AddWithValue("@P7", txtTeslimEden.Text);
            komut.Parameters.AddWithValue("@P8", txtTeslimAlan.Text);
            komut.Parameters.AddWithValue("@P9", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura sisteme güncellenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
        
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay fr = new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.Show();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select URUNAD,SATISFIYAT From TBL_URUNLER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunId.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtUrunAd.Text = dr[0].ToString();
                txtFiyat.Text = dr[1].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnFaturaDetayTemizle_Click(object sender, EventArgs e)
        {
            txtUrunId.Text = "";
            txtUrunAd.Text = "";
            txtMiktar.Text = "";
            txtFiyat.Text = "";
            txtTutar.Text = "";
            txtPersonel.Text = "";
            txtFirma.Text = "";
            txtFaturaId.Text = "";
        }
    }
}
