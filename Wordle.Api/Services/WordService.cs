using Microsoft.EntityFrameworkCore;
using Wordle.Api.Controllers;
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
        public IEnumerable<Word> GetWords()
        {
            List<Word> words = _context.Words
                .OrderBy(x => x.Value)
                .Take(100)
                .ToList();
            return words;
        }

        public bool AddWord(WordData wordData)
        {
            var dbWord = _context.Words.FirstOrDefault(x => x.Value.Equals(wordData.Value));
            if (dbWord is not null && dbWord.Value.Length != 5 && dbWord.Value.Any(x => char.IsDigit(x)))
            {
                _context.Words.Add(new Word { Value = wordData.Value, Common = wordData.Common.ToString().ToUpper() == "TRUE" });
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteWord(string word)
        {
            var dbWord = _context.Words.FirstOrDefault(x => x.Value.Equals(word));
            if (dbWord is not null)
            {
                _context.Words.Remove(dbWord);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ChangeFlag(WordData wordData)
        {
            var dbWord = _context.Words.FirstOrDefault(x => x.Value.Equals(wordData.Value));
            if (dbWord is not null)
            {
                dbWord.Common = wordData.Common;

                _context.Words.Update(dbWord);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
