using System.Data.SqlClient;

namespace partisecim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data source=BATUPC\SQLEXPRESS;initial catalog=secimproje;integrated security=true");
        private void btnoy_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into secimoy(ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) values(@ilcead,@aparti,@bparti,@cparti,@dparti,@eparti)", baglanti);
            cmd.Parameters.AddWithValue("@ilcead", txtilce.Text);
            cmd.Parameters.AddWithValue("@aparti", txtap.Text);
            cmd.Parameters.AddWithValue("@bparti", txtbp.Text);
            cmd.Parameters.AddWithValue("@cparti", txtcp.Text);
            cmd.Parameters.AddWithValue("@dparti", txtdp.Text);
            cmd.Parameters.AddWithValue("@eparti", txtep.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oy Giriþi Yapýldý");
        }

        private void btngrf_Click(object sender, EventArgs e)
        {
            frmgrafik frmgrafik = new frmgrafik();
            frmgrafik.Show();
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}