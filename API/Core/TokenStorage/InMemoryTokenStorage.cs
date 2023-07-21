using System.Collections.Concurrent;

namespace API.Core.TokenStorage
{
    public class InMemoryTokenStorage : ITokenStorage
    {
        private static ConcurrentDictionary<string, bool> Tokens { get; }

        static InMemoryTokenStorage()
        {
            Tokens = new ConcurrentDictionary<string, bool>();  //d58cb037-1565-48ac-9e33-4eb7e08537b0
        }                                                       //{[d58cb037-1565-48ac-9e33-4eb7e08537b0, true]}

        public void AddToken(string id)
        {
            Tokens.TryAdd(id, true);
        }

        public bool TokenExists(string id)
        {
            bool exists = Tokens.ContainsKey(id);

            if (!exists)
            {
                return false;
            }

            return Tokens[id];
        }

        public void InvalidateToken(string id)
        {
            bool value = false;
            Tokens.Remove(id, out value);
        }
    }
}
