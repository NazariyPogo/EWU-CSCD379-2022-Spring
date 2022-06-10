using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    public class WordController : Controller
    {
        private readonly WordService _service;

        public WordController(WordService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Word> GetWords()
        {
            return _service.GetWords();
        }

        [HttpPost]
        public void AddWord(string word)
        {
            _service.AddWord(word);
        }

        [HttpDelete]
        public void DeleteWord(string word)
        {
            _service.DeleteWord(word);
        }

        [HttpPost]
        public void ChangeCommonFlag(string word)
        {
            _service.ChangeFlag(word);
        }
    }
}
