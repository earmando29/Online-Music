using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CoogMusic.Pages
{
    public class UploadModel : PageModel {
        // public SongInfo songInfo = new SongInfo();

        public void OnGet() {

        }

        public void OnPost() {
            // songInfo.name = Request.Form["title"];
        }
    }
}