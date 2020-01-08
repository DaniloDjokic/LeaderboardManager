using LeaderboardManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderboardManager
{
    public static class MockData
    {
        public static List<Leaderboard> leaderboards = new List<Leaderboard>();

        static MockData()
        {
            Leaderboard leaderboard = new Leaderboard { Id = 1, Name = "First", Password = "penicbagomal", Key = "asdfg", Algorithm = CryptoAlgo.RC4, Format = "zxc" };
            List<Entry> entries = new List<Entry>();
            entries.Add(new Entry { Id = 1, Name = "DjiDji", Points = 100, Message = "Abe" });
            entries.Add(new Entry { Id = 2, Name = "Djolo", Points = 81.9, Message = "Tebro" });
            entries.Add(new Entry { Id = 3, Name = "Koki", Points = 50.5, Message = "BeTebro" });
            leaderboard.Entries = entries;
            leaderboards.Add(leaderboard);
        }
    }
}
