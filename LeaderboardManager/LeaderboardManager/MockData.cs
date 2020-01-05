using LeaderboardManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderboardManager
{
    public enum CrypotAlgo { RC4, AES }

    public static class MockData
    {
        public static List<Leaderboard> leaderboards = new List<Leaderboard>();

        static MockData()
        {
            leaderboards.Add(new Leaderboard { Id = 1, Name = "First", Password = "penicbagomal", Key = "asdfg", Algorithm = CrypotAlgo.RC4, Format = "zxc" });
        }
    }
}
