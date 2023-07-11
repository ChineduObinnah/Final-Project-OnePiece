using Dapper;
using Final_Project_OnePiece.Models;
using System.Data;

namespace Final_Project_OnePiece
{
    public class CharactersRepo : ICharactersRepo
    {
        private readonly IDbConnection _conn;

        public CharactersRepo(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Characters> GetAllCharacters()
        {
            return _conn.Query<Characters>("select * from characters;");
        }

        public Characters GetCharacters(int id)
        {
                return _conn.QuerySingle<Characters>("SELECT * FROM CHARACTERS WHERE ID = @id", new { id = id });
        }

        public void UpdateCharacters(Characters characters)
        {
            _conn.Execute("UPDATE characters SET Name = @name, Role = @role, Bounty = @bounty, Title = @title, Haki = @haki  WHERE ID = @id",
             new { name = characters.Name, role = characters.Role, bounty = characters.Bounty, /*devil_fruit = characters.DevilFruit,*/ title = characters.Title, haki = characters.Haki, id = characters.ID });
        }

        public void AddCharacter(Characters characterToAdd)
        {
            _conn.Execute("INSERT INTO characters (name, role, bounty,title, haki) VALUES (@name, @role, @bounty, @title, @haki);",
                new { name = characterToAdd.Name, role = characterToAdd.Role, bounty = characterToAdd.Bounty, /*devil_fruit = characterToAdd.DevilFruit,*/ title = characterToAdd.Title, haki = characterToAdd.Haki});
        }

        public void DeleteCharacter(Characters characters)
        {
            _conn.Execute("DELETE FROM Characters WHERE ID = @id;", new { id = characters.ID });
        }
    }
}
