using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CoogMusic.Pages.Upload
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(IConfiguration config, ILogger<IndexModel> logger)
        {
            _config = config;
            _logger = logger;
        }
        
        public void OnGet()
        {
            try {
                string connectionString = "server=localhost;database=online_music;uid=root;password=7985;";
                using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                    connection.Open();

                }
            }
            catch(Exception ex) {
                Console.WriteLine("EXCEPTION: " + ex.ToString());
            }
        }
    }
    public class SongInfo
    {
        public string title, artist, genre;
        
    }
}
