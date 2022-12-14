using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class PlayerDTO
    {
        public int playerId { get; set; }
        public string playerName { get; set; }
        public string? teamName { get; set; }
        public string? countryName { get; set; }
        public DateTime dateofBirth { get; set; }
        public int teamId { get; set; }
        public int countryId { get; set; }
    }
}
