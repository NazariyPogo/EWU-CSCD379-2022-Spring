﻿using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string? Name { get; set; }
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }

        public Player Clone()
        {
            return new Player
            {
                PlayerId = PlayerId,
                Name = Name,
                GameCount = GameCount,
                AverageAttempts = AverageAttempts,

            };
        }
    }
}
