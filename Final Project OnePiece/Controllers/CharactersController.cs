using Final_Project_OnePiece.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_OnePiece.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ICharactersRepo _repo;

        public CharactersController(ICharactersRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var characters = _repo.GetAllCharacters();
            return View(characters);
        }

        public IActionResult ViewCharacters(int id)
        {
            var characters = _repo.GetCharacters(id);
            return View(characters);
        }

        public IActionResult UpdateCharacters(int id)
        {
            Characters charac = _repo.GetCharacters(id);
            if (charac == null)
            {
                return View("CharactersNotFound");
            }
            return View(charac);

        }
       public IActionResult UpdateCharactersToDatabase(Characters characters)
        {
          _repo.UpdateCharacters(characters);

        return RedirectToAction("ViewCharacters", new { id = characters.ID });
        }


        public IActionResult AddCharacter(Characters characterToAdd)
        {
            if (characterToAdd == null)
            {
                return View("characternotFound");
            }
            return View(characterToAdd);
        }

        public IActionResult AddCharacterToDataBase(Characters characters)
        {
            _repo.AddCharacter(characters);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCharacter(Characters characters)
        {
            _repo.DeleteCharacter(characters);
            return RedirectToAction("Index");
        }
    }
}
