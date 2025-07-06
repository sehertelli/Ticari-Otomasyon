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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_NOTLAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            txtBaslik.Text = "";
            txtHitap.Text = "";
            txtId.Text = "";
            txtOlusturan.Text = "";
            rchDetay.Text = "";
            mskSaat.Text = "";
            mskTarih.Text = "";
        }
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_NOTLAR (TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP) VALUES (@P1,@P2,@P3,@P4,@P5,@P6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", mskTarih.Text);
            komut.Parameters.AddWithValue("@P2", mskSaat.Text);
            komut.Parameters.AddWithValue("@P3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@P4", rchDetay.Text);
            komut.Parameters.AddWithValue("@P5", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@P6", txtHitap.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Veriler sisteme kaydedilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["ID"].ToString();
                txtBaslik.Text = dr["BASLIK"].ToString();
                rchDetay.Text = dr["DETAY"].ToString();
                txtOlusturan.Text = dr["OLUSTURAN"].ToString();
                txtHitap.Text = dr["HITAP"].ToString();
                mskTarih.Text = dr["TARIH"].ToString();
                mskSaat.Text = dr["SAAT"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBL_NOTLAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not sistemden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_NOTLAR set TARIH=@P1,SAAT=@P2,BASLIK=@P3,DETAY=@P4,OLUSTURAN=@P5,HITAP=@P6 where ID=@P7", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", mskTarih.Text);
            komut.Parameters.AddWithValue("@P2", mskSaat.Text);
            komut.Parameters.AddWithValue("@P3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@P4", rchDetay.Text);
            komut.Parameters.AddWithValue("@P5", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@P6", txtHitap.Text);
            komut.Parameters.AddWithValue("@P7", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Veriler sistemden güncellenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay fr = new FrmNotDetay();

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.metin = dr["DETAY"].ToString();
                fr.Show();
            }
        }
    }
}
