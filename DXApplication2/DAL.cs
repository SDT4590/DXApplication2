using Dapper;
using DataGridBindingExampleCore.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataGridBindingExampleCore
{
    public class DAL
    {
        private static readonly string ConnString = "Data Source=(local);Initial Catalog=CollegeDB;Integrated Security=True";
        public static async Task<List<StudentsModel>> LoadStudentsAsync()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                var students = (await conn.QueryAsync<StudentsModel>("SELECT * FROM Students")).ToList();
                var allPlacesOfInterest = (await conn.QueryAsync<PlacesOfInterest>("SELECT * FROM PlacesOfInterest")).ToList();

                foreach (var student in students)
                {
                    var placesOfInterest = allPlacesOfInterest.Where(p => p.StudentID == student.StudentID).ToList();
                    student.PlacesOfInterest = new ObservableCollection<PlacesOfInterest>(placesOfInterest);
                }

                return students;
            }
        }
        public static async Task<List<CountriesModel>> LoadCountriesAsync()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                var result = await conn.QueryAsync<CountriesModel>("SELECT * FROM Countries");
                return result.ToList();
            }
        }
        public static async Task<List<ProvincesModel>> LoadProvincesAsync()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                var result = await conn.QueryAsync<ProvincesModel>("SELECT * FROM Provinces");
                return result.ToList();
            }
        }
        public static async Task<List<DistrictsModel>> LoadDistrictsAsync()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                var result = await conn.QueryAsync<DistrictsModel>("SELECT * FROM Districts");
                return result.ToList();
            }
        }
    }
}
