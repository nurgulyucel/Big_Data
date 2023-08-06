using Casgem_BigData.Dal.Entities;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Casgem_BigData.Controllers
{
    public class DefaultController : Controller
    {
        private readonly string connectionString = "server =LAPTOP-DMD5S6B7; initial Catalog=CARPLATES; integrated security=true";
        public ActionResult MarkayaGoreArama(string brand)
        {
            if (!string.IsNullOrEmpty(brand))
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Dapper ile sorguyu gerçekleştir
                    string query = "SELECT top 100 * FROM vw_PlatesBrand WHERE BRAND = @Brand";
                    var plates = connection.Query<Carplates>(query, new { Brand = brand }).ToList();

                    return View(plates);
                }
            }
            else
            {
                return View(new List<Carplates>());
            }
        }

        public int GetSedanPlateCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM vw_SedanPlateCount", connection);
                int sedanPlateCount = (int)command.ExecuteScalar();

                return sedanPlateCount;
            }
        }

        public int GetBenzinPlateCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT BenzinPlateCount FROM vw_BenzinPlateCount", connection);
                int benzinPlateCount = (int)command.ExecuteScalar();

                return benzinPlateCount;
            }
        }

        public int GetTotalCarCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT TotalCarCount FROM vw_TotalCarCount", connection);
                int totalCarCount = (int)command.ExecuteScalar();

                return totalCarCount;
            }
        }
        public int GetDuzPlateCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT DuzPlateCount FROM vw_DuzPlateCount", connection);
                int duzPlateCount = (int)command.ExecuteScalar();

                return duzPlateCount;
            }
        } 
        public int GetYariOtomatikPlateCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT YariOtomatikPlateCount FROM vw_YariOtomatikPlateCount", connection);
                int yariOtomatikPlateCount = (int)command.ExecuteScalar();

                return yariOtomatikPlateCount;
            }
        }

        public string GetMostCommonModel()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT TOP 1 MODEL FROM vw_MostCommonModel", connection);
                string enYaygınModel = (string)command.ExecuteScalar();

                return enYaygınModel;
            }
        }

    }



}
