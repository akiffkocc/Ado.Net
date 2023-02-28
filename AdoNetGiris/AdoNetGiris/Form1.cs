using System.Data.SqlClient;

namespace AdoNetGiris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=(LocalDb)\\MSSQLLocalDB;Database=Northwind;Integrated Security=True");
            SqlCommand komut = new SqlCommand("select * from Employees", baglanti);
            baglanti.Open();
            SqlDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                ListViewItem satir = new ListViewItem();
                satir.Text = okuyucu["EmployeeId"].ToString();
                satir.SubItems.Add(okuyucu["FirstName"].ToString());
                satir.SubItems.Add(okuyucu["LastName"].ToString());
                satir.SubItems.Add(okuyucu["Title"].ToString());
                satir.SubItems.Add(okuyucu["HomePhone"].ToString());
                listView1.Items.Add(satir);
            }
            baglanti.Close();
        }
    }
}