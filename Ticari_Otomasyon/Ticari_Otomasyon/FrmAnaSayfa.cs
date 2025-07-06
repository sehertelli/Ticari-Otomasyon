﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD,Sum(ADET) As 'Adet' from TBL_URUNLER group by URUNAD having Sum(ADET)<=20 order by Sum(ADET)", bgl.baglanti());
            da.Fill(dt);
            GridControlStok.DataSource = dt;
        }

        void ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select top 9 TARIH,SAAT,BASLIK from TBL_NOTLAR order by ID desc", bgl.baglanti());
            da.Fill(dt);
            GridControlAjanda.DataSource = dt;
        }
        void firmahareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute FirmaHareket2", bgl.baglanti());
            da.Fill(dt);
            gridControlFirmaHareket.DataSource = dt;
        }
        void fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,TELEFON1 From TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            gridControlFihrist.DataSource = dt;
        }

        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku.Name == "title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }


        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            stoklar();

            ajanda();

            firmahareket();

            fihrist();

            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/kurlar_tr.html");

            haberler();
        }
    }
}
