using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderboardManager
{
    public enum CryptoAlgo { RC4, AES }
    public class CryptionService
    {
        public CryptoAlgo ChosenAlgo { get; private set; }
        public CryptionService(CryptoAlgo chosenAlgo)
        {
            ChosenAlgo = chosenAlgo;
        }

        public bool ValidateKey(string key)
        {
            throw new NotImplementedException();
        }
    }
}
