using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class TeamDTO
    {

        public string teamName { get; set; }
        public string coachName { get; set; }
        public int nationality { get; set; }
        public int teamId { get; set; }
        public DateTime foundedIn { get; set; }
    }
}
