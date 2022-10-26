
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Models
{
    public class Player
    {
        public int playerId { get; set; }
        public string playerName { get; set; }
        public DateTime dateofBirth { get; set; }
        [ForeignKey("team")]
        public int teamId { get; set; }
        [ForeignKey("country")]
        public int countryId { get; set; }
        public Team team { get; set; }
         public Country country { get; set; }
    }
}
