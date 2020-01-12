using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderboardManager.Models
{
    public class Entry
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Points { get; set; }
        public string Message { get; set; }
    }
}
