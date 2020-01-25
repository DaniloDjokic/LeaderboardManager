namespace LeaderboardManagerClientLibrary
{
    public class KeyIVPair
    {
        public byte[] Key { get; set; }
        public byte[] IV { get; set; }
        public KeyIVPair(byte[] key, byte[] iv)
        {
            Key = key;
            IV = iv;
        }
    }
}
