using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderboardManager.Models
{
    public class Leaderboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Key { get; set; }
        public CrypotAlgo Algorithm { get; set; }
        public string Format { get; set; }
        public List<Entry> Entries { get; set; }

        public override string ToString()
        {
            return Id.ToString() + ": " + Name;
        }
    }
}
