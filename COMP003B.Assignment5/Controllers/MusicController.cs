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
            _music.Add(new Music { Id = 1, Title = "Runaway", Artist = "Linkin Park", Album = "Hybrid Theory", Genre = "Rock", Year = 2000 });
            _music.Add(new Music { Id = 2, Title = "Prodigal Son", Artist = "Steel Pulse", Album = "Handsworth Revolution", Genre = "Reggae", Year = 2015 });
            _music.Add(new Music { Id = 3, Title = "Hard to Please", Artist = "State Champs", Album = "The Acoustic Things", Genre = "Punk Rock", Year = 2014 });
            _music.Add(new Music { Id = 4, Title = "Here Without You", Artist = "3 Doors Down", Album = "Away From The Sun", Genre = "Rock", Year = 2002 });
            _music.Add(new Music { Id = 5, Title = "Kryptonite", Artist = "3 Doors Down", Album = "The Better Life", Genre = "Rock", Year = 2000 });
        }

        // CRUD operations

        // GET ALL (READ): api/music
        [HttpGet]
        public ActionResult<IEnumerable<Music>> GetAllMusic()
        {
            return _music;
        }

        // GET by ID (READ): api/music/1
        [HttpGet("{id}")]
        public ActionResult<Music> GetMusicById(int id)
        {
            var music = _music.FirstOrDefault(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }
            return music;
        }

        // POST (CREATE): api/music
        [HttpPost]
        public ActionResult<Music> CreateMusic(Music music)
        {
            // automatically assign ID
            music.Id = _music.Max(m => m.Id) + 1;

            // add to list
            _music.Add(music);

            return CreatedAtAction(nameof(GetMusicById), new { id = music.Id }, music);
        }

        // PUT (UPDATE): api/music/1
        [HttpPut]
        public ActionResult<Music> UpdateMusic(int id, Music updatedMusic)
        {
            // look for music by id
            var music = _music.Find(_music => _music.Id == id);

            // if not found, return BadRequest
            if (music == null)
            {
                return BadRequest();
            }

            // update the music
            music.Title = updatedMusic.Title;
            music.Artist = updatedMusic.Artist;
            music.Album = updatedMusic.Album;
            music.Genre = updatedMusic.Genre;
            music.Year = updatedMusic.Year;

            return NoContent();
        }

        // DELETE (delete): api/music/1
        [HttpDelete]

    }
}
