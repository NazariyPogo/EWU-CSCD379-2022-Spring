using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly WordService _service;

        public WordController(WordService service)
        {
            _service = service;
        }

        [HttpGet("GetList")]
        public IEnumerable<Word> GetWords()
        {
            return _service.GetWords();
        }

        [HttpPost("AddWord")]
        public ActionResult AddWord([FromBody] WordData wordData)
        {
            if (_service.AddWord(wordData) == true)
            {
                return Ok("Word has been added successfully");
            }
            return BadRequest("Word already exists");
        }

        [HttpPost("RemoveWord")]
        public ActionResult DeleteWord(string word)
        {
            if (_service.DeleteWord(word) == true)
            {
                return Ok("Word has been removed successfully");
            }
            return BadRequest("Word does not exist");
        }

        [HttpPost("ChangeFlag")]
        public ActionResult ChangeFlag(WordData wordData)
        {
            if (_service.ChangeFlag(wordData) == true)
            {
                return Ok("Flag has been changed successfully");
            }
            return BadRequest("Error, flag could not be changed");
        }
    }

    public class WordData
    {
        public string Value { get; set; }
        public bool Common { get; set; }
        public WordData(string value, bool common)
        {
            Value = value;
            Common = common;
        }
    }
}
