using Final_Project_OnePiece.Models;

namespace Final_Project_OnePiece
{
    public interface ICharactersRepo
    {
        public IEnumerable<Characters> GetAllCharacters();
        public Characters GetCharacters(int id);
        public void UpdateCharacters(Characters character);

        public void AddCharacter(Characters characterToAdd);

        public void DeleteCharacter(Characters characters);


    }



}
