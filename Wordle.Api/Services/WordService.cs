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
        public IEnumerable<Word> GetWords(int pageNum, int pageSize)
        {
            List<Word> words = _context.Words
                .OrderBy(x => x.Value)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return words;
        }

        public IEnumerable<Word> GetFilteredWords(int pageNum, int pageSize, string filter)
        {
            if (pageNum < 1 || pageSize < 1)
            {
                return Enumerable.Empty<Word>();
            }
            List<Word> words = _context.Words
                .Where(x => x.Value.Contains(filter))
                .OrderBy(x => x.Value)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return words;
        }

        public bool AddWord(WordData wordData)
        {
            var dbWord = _context.Words.FirstOrDefault(x => x.Value.Equals(wordData.Value));
            if (dbWord is null && wordData.Value.Length == 5 && !wordData.Value.Any(x => char.IsDigit(x)))
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

        public int GetListSize()
        {
            return _context.Words.Count();
        }

        public int GetFilteredListSize(string filter)
        {
            return _context.Words.Where(x => x.Value.Contains(filter)).Count();
        }
    }
}
