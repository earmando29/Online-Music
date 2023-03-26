using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CoogMusic.Pages.Upload
{
    public class CreateModel : PageModel {
    public String errorMessage="";
    public String successMessage="";
        public SongInfo songInfo = new SongInfo();

        public void OnGet() {

        }

        public void OnPost() {
            songInfo.title = Request.Form["title"];
            songInfo.artist = Request.Form["artist"];
            songInfo.genre = Request.Form["genre"];

            if (songInfo.title.Length == 0 || songInfo.artist.Length == 0 || songInfo.genre. Length == 0){
                errorMessage = "All the fields are required";
                return;
            }

            try {
                String connectionString="server=localhost;database=online_music;uid=root;password=7985;";
                using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                    connection.Open();
                    String sql = "INSERT INTO song" +
                                "(tile, genre) VALUES" + 
                                "(@title, @genre);";
                    using (MySqlCommand command = new MySqlCommand(sql, connection)) {
                        command.Parameters.AddWithValue("@title", songInfo.title);
                        command.Parameters.AddWithValue("@genre", songInfo.genre);
                        command.ExecuteNonQuery();
                    }  
                }
            }
            catch (Exception ex) {
                errorMessage = ex.Message;
                return;
            }

            songInfo.title = ""; songInfo.artist = ""; songInfo.genre = "";
                successMessage = "New Client Added Correctly";
        }
    }   
}