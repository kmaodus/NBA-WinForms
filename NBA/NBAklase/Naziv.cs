using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBA.NBAklase
{
    class Klub
    {
        public int  KlubID { get; set; }
        public string Naziv { get; set; }
        public string Grad { get; set; }
        public string SaveznaDrzavaID { get; set; }
        public string KonferencijaID { get; set; }
        public string DivizijaID { get; set; }
        public string Trener { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM Klubovi";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public bool Insert(Klub k)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "Select KonferencijaID from Konferencije WHERE Naziv = @Naziv";
                int IDkonferencije = 0;
                using (SqlCommand cmd2 = new SqlCommand(sql, conn))
                {
                    cmd2.Parameters.AddWithValue("@Naziv", k.KonferencijaID);
                    conn.Open();
                    SqlDataReader read = cmd2.ExecuteReader();
                    read.Read();
                    IDkonferencije = read.GetInt32(0);
                    conn.Close();
                }

                sql = "Select DivizijaID from Divizije WHERE Naziv = @Naziv";
                int IDDivizije = 0;
                using (SqlCommand cmd2 = new SqlCommand(sql, conn))
                {
                    cmd2.Parameters.AddWithValue("@Naziv", k.DivizijaID);
                    conn.Open();
                    SqlDataReader read = cmd2.ExecuteReader();
                    read.Read();
                    IDDivizije = read.GetInt32(0);
                    conn.Close();
                }


                sql = "INSERT INTO Klubovi " +
                "(Naziv, Grad, SaveznaDržavaID, KonferencijaID, DivizijaID, Trener)" +
                " VALUES (@Naziv, @Grad, @SaveznaDržavaID, @KonferencijaID, @DivizijaID, @Trener)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Naziv", k.Naziv);
                cmd.Parameters.AddWithValue("@Grad", k.Grad);
                cmd.Parameters.AddWithValue("@SaveznaDržavaID", k.SaveznaDrzavaID);
                cmd.Parameters.AddWithValue("@KonferencijaID", IDkonferencije); 
                cmd.Parameters.AddWithValue("@DivizijaID", IDDivizije);
                cmd.Parameters.AddWithValue("@Trener", k.Trener);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        public bool Update(Klub k)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                

                string sql = "UPDATE Klubovi SET Naziv=@Naziv, Grad=@Grad, SaveznaDržavaID=@SaveznaDržavaID, " +
                    "KonferencijaID=@KonferencijaID, DivizijaID=@DivizijaID, Trener=@Trener WHERE KlubID=@KlubID ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Naziv", k.Naziv);
                cmd.Parameters.AddWithValue("@Grad", k.Grad);
                cmd.Parameters.AddWithValue("@SaveznaDržavaID", k.SaveznaDrzavaID);
                cmd.Parameters.AddWithValue("@KonferencijaID", k.KonferencijaID);
                cmd.Parameters.AddWithValue("@DivizijaID", k.DivizijaID);
                cmd.Parameters.AddWithValue("@Trener", k.Trener);
                cmd.Parameters.AddWithValue("@KlubID", k.KlubID);


                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;

        }
        public bool Delete(Klub k)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM Klubovi WHERE KlubID=@KlubID ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@KlubID", k.KlubID);
                

                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess = true;
        }
    }
}
