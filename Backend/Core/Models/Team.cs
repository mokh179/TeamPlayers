namespace Core.Models
{
    public class Team
    {
        public int teamId { get; set; }
        public string teamName { get; set; }
        public string coachName { get; set; }
        [ForeignKey("country")]
        public int  nationality { get; set; }
        public DateTime foundedIn { get; set; }
        public List<Player> Players { get; set; }
        public Country country { get; set; }
    }
}