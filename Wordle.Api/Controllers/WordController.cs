﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Identity;
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
        public IEnumerable<Word> GetWords(int pageNum, int pageSize)
        {
            return _service.GetWords(pageNum, pageSize);
        }

        [HttpGet("GetFilteredList")]
        public IEnumerable<Word> GetFilteredWords(int pageNum, int pageSize, string filter)
        {
            return _service.GetFilteredWords(pageNum, pageSize, filter);
        }

        [HttpPost("AddWord")]
        [Authorize(Roles = Roles.MasterOfTheUniverse, Policy = Policies.OldEnough)]
        public ActionResult AddWord([FromBody] WordData wordData)
        {
            if (_service.AddWord(wordData) == true)
            {
                return Ok("Word has been added successfully");
            }
            return BadRequest("Word is invalid or already exists");
        }

        [HttpPost("RemoveWord")]
        [Authorize(Roles = Roles.MasterOfTheUniverse, Policy = Policies.OldEnough)]
        public ActionResult DeleteWord(string word)
        {
            if (_service.DeleteWord(word) == true)
            {
                return Ok("Word has been removed successfully");
            }
            return BadRequest("Word does not exist");
        }

        [HttpPost("ChangeFlag")]
        [Authorize]
        public ActionResult ChangeFlag(WordData wordData)
        {
            if (_service.ChangeFlag(wordData) == true)
            {
                return Ok("Flag has been changed successfully");
            }
            return BadRequest("Error, flag could not be changed");
        }

        [HttpGet("GetListSize")]
        public int GetListSize()
        {
            return _service.GetListSize();
        }

        [HttpGet("GetFilteredListSize")]
        public int GetFilteredListSize(string filter)
        {
            return _service.GetFilteredListSize(filter);
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
