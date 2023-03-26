using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CoogMusic.Pages
{
    public class IndexUploadModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly ILogger<IndexUploadModel> _logger;
        public IndexUploadModel(IConfiguration config, ILogger<IndexUploadModel> logger)
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

        public class SongInfo
        {
            public string song_name, artist, genre;
            
        }
        // public IActionResult OnPost()
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }

        //     // Get the connection string from appsettings.json
        //     string connectionString = _config.GetConnectionString("MySqlConnection");

        //     // Connect to the database
        //     using MySqlConnection connection = new MySqlConnection(connectionString);
        //     connection.Open();

        //     // Insert the data into the database
        //     string sql = "INSERT INTO songs (title, artist, genre, filename) VALUES (@title, @artist, @genre, @filename)";
        //     using MySqlCommand command = new MySqlCommand(sql, connection);
        //     command.Parameters.AddWithValue("@title", Title);
        //     command.Parameters.AddWithValue("@artist", Artist);
        //     command.Parameters.AddWithValue("@genre", Genre);
        //     command.Parameters.AddWithValue("@filename", File.FileName);
        //     command.ExecuteNonQuery();

        //     _logger.LogInformation("Data inserted into database");
        //     connection.Close();
        //     return RedirectToPage("Index");
        // }
    }
}
