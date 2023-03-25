using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MyWebApp.Pages
{
    public class UploadModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly ILogger<UploadModel> _logger;

        public UploadModel(IConfiguration config, ILogger<UploadModel> logger)
        {
            _config = config;
            _logger = logger;
        }

        [BindProperty]
        public string Title { get; set; }
        
        [BindProperty]
        public string Artist { get; set; }
        
        [BindProperty]
        public string Genre { get; set; }
        
        [BindProperty]
        public IFormFile File { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Get the connection string from appsettings.json
            string connectionString = _config.GetConnectionString("MySqlConnection");

            // Connect to the database
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            // Insert the data into the database
            string sql = "INSERT INTO songs (title, artist, genre, filename) VALUES (@title, @artist, @genre, @filename)";
            using MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@title", Title);
            command.Parameters.AddWithValue("@artist", Artist);
            command.Parameters.AddWithValue("@genre", Genre);
            command.Parameters.AddWithValue("@filename", File.FileName);
            command.ExecuteNonQuery();

            _logger.LogInformation("Data inserted into database");

            return RedirectToPage("Index");
        }
    }
}
