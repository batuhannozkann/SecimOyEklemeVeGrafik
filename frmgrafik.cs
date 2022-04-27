using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace partisecim
{
    public partial class frmgrafik : Form
    {
        double Aparti,Bparti,Cparti,Dparti,Eparti;
        double yuzdea, yuzdeb, yuzdec, yuzded, yuzdee;
        string ILCE;
        SqlConnection baglanti = new SqlConnection(@"Data source=BATUPC\SQLEXPRESS;initial catalog=secimproje;integrated security=true");
        public frmgrafik()
        {
            InitializeComponent();
        }

        private void frm2apart_Click(object sender, EventArgs e)
        {

        }
        void editprogress()
        {
            progressBarA.Minimum = 0;
            progressBarB.Minimum = 0;
            progressBarC.Minimum = 0;
            progressBarD.Minimum = 0;
            progressBarE.Minimum = 0;
            progressBarA.Maximum = Convert.ToInt32(getbiggerthan() + 100);
            progressBarB.Maximum = Convert.ToInt32(getbiggerthan() + 100);
            progressBarC.Maximum = Convert.ToInt32(getbiggerthan() + 100);
            progressBarD.Maximum = Convert.ToInt32(getbiggerthan() + 100);
            progressBarE.Maximum = Convert.ToInt32(getbiggerthan() + 100);
        }
            void getperc()
        {
            double sub = Aparti + Bparti + Cparti + Dparti + Eparti;
            yuzdea = (Aparti / sub)*100;
            yuzdeb= (Bparti / sub)*100;
            yuzdec = (Cparti / sub) *100;
            yuzded = (Dparti / sub) *100;
            yuzdee =(Eparti / sub) *100;
        }
        private void progressBarA_Click(object sender, EventArgs e)
        {

            



        }
        double getbiggerthan()
        {
            double[] parti = new double[] { Aparti, Bparti, Cparti, Dparti, Eparti };
            double big = parti[0];
            for(var i=0; i<parti.Length;i++)
            {
                if(parti[i]>big)
                {
                    big = parti[i];
                }
            }
            return big;
        }

    private void frmgrafik_Load(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand cmd1 = new SqlCommand("select ILCEAD from secimoy", baglanti);            
            SqlDataReader reader1=cmd1.ExecuteReader();
            while (reader1.Read())
            {
                frm2ilcesec.Items.Add(reader1[0]);
            }
            baglanti.Close();
            HideOy();
            
        }
        void HideOy()
            {
            oyA.Hide();
            oyB.Hide();
            oyC.Hide();
            oyD.Hide();
            oyE.Hide();
        }
        void ShowOy()
        {
            oyA.Show();
            oyB.Show();
            oyC.Show();
            oyD.Show();
            oyE.Show();
        }
        void OyInt()
        {
            editprogress();
            progressBarA.Value = Convert.ToInt32(Math.Round(Aparti));
            progressBarB.Value = Convert.ToInt32(Math.Round(Bparti));
            progressBarC.Value = Convert.ToInt32(Math.Round(Cparti));
            progressBarD.Value = Convert.ToInt32(Math.Round(Dparti));
            progressBarE.Value = Convert.ToInt32(Math.Round(Eparti));
            oyA.Text = Aparti.ToString();
            oyB.Text = Bparti.ToString();
            oyC.Text = Cparti.ToString();
            oyD.Text = Dparti.ToString();
            oyE.Text = Eparti.ToString();
        }
        void OyPerc()
        {
            getperc();
            progressBarA.Value = Convert.ToInt32(Math.Round(yuzdea));
            progressBarB.Value = Convert.ToInt32(Math.Round(yuzdeb));
            progressBarC.Value = Convert.ToInt32(Math.Round(yuzdec));
            progressBarD.Value = Convert.ToInt32(Math.Round(yuzded));
            progressBarE.Value = Convert.ToInt32(Math.Round(yuzdee));
            oyA.Text = yuzdea.ToString("0.##");
            oyB.Text = yuzdeb.ToString("0.##");
            oyC.Text = yuzdec.ToString("0.##");
            oyD.Text = yuzded.ToString("0.##");
            oyE.Text = yuzdee.ToString("0.##");
        }
        
        private void frm2ilcesec_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select APARTI,BPARTI,CPARTI,DPARTI,EPARTI from secimoy WHERE ILCEAD=@ilcead1;", baglanti);
            cmd.Parameters.AddWithValue("@ilcead1",frm2ilcesec.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Aparti = int.Parse(reader[0].ToString());
                Bparti = int.Parse(reader[1].ToString());
                Cparti = int.Parse(reader[2].ToString());
                Dparti = int.Parse(reader[3].ToString());
                Eparti = int.Parse(reader[4].ToString());
                
            }
            //editprogress();
            
            OyInt();
            ilcelbl.Text = frm2ilcesec.Text;
            ShowOy();
            baglanti.Close();
        }

        private void oyA_Click(object sender, EventArgs e)
        {

        }
    }
}
