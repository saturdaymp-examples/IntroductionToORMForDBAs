using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaturdayMP.GameTracker.Models
{

    public enum GameResultTypeEnums
    {
        Win = 10,
        Loss = 11,
        Tie = 12
    }

    public class GameResultType
    {
        public GameResultType()
        {
        }

        public GameResultType(GameResultTypeEnums @enum)
        {
            KeyCode = (int)@enum;
            Type = @enum.ToString();
        }

        public int Id { get; set; }

        public int KeyCode { get; set; }

        [MaxLength(10)]
        public string Type { get; set; }

        public static implicit operator GameResultType(GameResultTypeEnums @enum) => new GameResultType(@enum);

        public static implicit operator GameResultTypeEnums(GameResultType gameResultType) => (GameResultTypeEnums)gameResultType.Id;
    }
}
