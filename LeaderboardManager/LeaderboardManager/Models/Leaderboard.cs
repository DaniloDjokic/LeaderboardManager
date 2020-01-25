using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaderboardManagerClientLibrary;

namespace LeaderboardManager.Models
{
    public class Leaderboard
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public byte[] Password { get; set; }
        public KeyIVPair KeyIVPair { get; set; }
        public CryptoAlgo Algorithm { get; set; }
        public string Format { get; set; }

        public override string ToString()
        {
            return Id.ToString() + ": " + Name;
        }
    }
}
