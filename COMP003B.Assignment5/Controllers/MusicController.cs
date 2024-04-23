// Added models reference
using COMP003B.Assignment5.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : Controller
    {
        // Added an in-memory list of music
        private List<Music> _music = new List<Music>();

        // added a constructor to pre-fill the list with some music
        public MusicController()
        {
            _music.Add(new Music { Title = "Runaway", Artist = "Linkin Park", Album = "Hybrid Theory", Genre = "Rock", Year = 2000 });
            _music.Add(new Music { Title = "Prodigal Son", Artist = "Steel Pulse", Album = "Handsworth Revolution", Genre = "Reggae", Year = 2015 });
            _music.Add(new Music { Title = "Hard to Please", Artist = "State Champs", Album = "The Acoustic Things", Genre = "Punk Rock", Year = 2014 });
        }


    }
}
