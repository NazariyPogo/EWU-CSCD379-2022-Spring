using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class WordService
    {
        private readonly AppDbContext _context;

        public WordService(AppDbContext context)
        {
            _context = context;
        }

        internal void AddWord(string word)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<Word> GetWords()
        {
            throw new NotImplementedException();
        }

        internal void DeleteWord(string word)
        {
            throw new NotImplementedException();
        }

        internal void ChangeFlag(string word)
        {
            throw new NotImplementedException();
        }
    }
}
