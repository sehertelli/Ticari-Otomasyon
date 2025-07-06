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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void bankalistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute BankaBilgileri", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR From ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        void firmalistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,AD From TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AD";
            lookUpEdit1.Properties.DataSource = dt;
        }
        void temizle()
        {
            txtId.Text = "";
            txtBankaAd.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            txtSube.Text = "";
            txtIBAN.Text = "";
            txtHesapNo.Text = "";
            txtYetkili.Text = "";
            mskTelefon.Text = "";
            mskTarih.Text = "";
            txtHesapTuru.Text = "";
            lookUpEdit1.Text = "";
        }
        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            bankalistesi();
            sehirlistesi();
            firmalistesi();
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_BANKALAR (BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBankaAd.Text);
            komut.Parameters.AddWithValue("@p2", cmbil.Text);
            komut.Parameters.AddWithValue("@p3", cmbilce.Text);
            komut.Parameters.AddWithValue("@p4", txtSube.Text);
            komut.Parameters.AddWithValue("@p5", txtIBAN.Text);
            komut.Parameters.AddWithValue("@p6", txtHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p9", mskTarih.Text);
            komut.Parameters.AddWithValue("@p10", txtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p11", lookUpEdit1.EditValue);
            komut.ExecuteNonQuery();
            bankalistesi();
            bgl.baglanti().Close();
            MessageBox.Show("Veriler sisteme kaydedilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE from ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["ID"].ToString();
                txtBankaAd.Text = dr["BANKAADI"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                txtSube.Text = dr["SUBE"].ToString();
                txtIBAN.Text = dr["IBAN"].ToString();
                txtHesapNo.Text = dr["HESAPNO"].ToString();
                txtYetkili.Text = dr["YETKILI"].ToString();
                mskTelefon.Text = dr["TELEFON"].ToString();
                mskTarih.Text = dr["TARIH"].ToString();
                txtHesapTuru.Text = dr["HESAPTURU"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_BANKALAR where ID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtId.Text);
            komut.ExecuteNonQuery();
            bankalistesi();
            bgl.baglanti().Close();
            temizle();
            MessageBox.Show("Banka bilgisi sistemden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_BANKALAR set BANKAADI=@P1,IL=@P2,ILCE=@P3,SUBE=@P4,IBAN=@P5,HESAPNO=@P6,YETKILI=@P7,TELEFON=@P8,TARIH=@P9,HESAPTURU=@P10,FIRMAID=@P11 where ID=@P12", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtBankaAd.Text);
            komut.Parameters.AddWithValue("@P2", cmbil.Text);
            komut.Parameters.AddWithValue("@P3", cmbilce.Text);
            komut.Parameters.AddWithValue("@P4", txtSube.Text);
            komut.Parameters.AddWithValue("@P5", txtIBAN.Text);
            komut.Parameters.AddWithValue("@P6", txtHesapNo.Text);
            komut.Parameters.AddWithValue("@P7", txtYetkili.Text);
            komut.Parameters.AddWithValue("@P8", mskTelefon.Text);
            komut.Parameters.AddWithValue("@P9", mskTarih.Text);
            komut.Parameters.AddWithValue("@P10", txtHesapTuru.Text);
            komut.Parameters.AddWithValue("@P11", lookUpEdit1.EditValue);
            komut.Parameters.AddWithValue("@P12", txtId.Text);
            komut.ExecuteNonQuery();
            bankalistesi();
            bgl.baglanti().Close();
            MessageBox.Show("Veriler sisteme güncellenmiştirmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
