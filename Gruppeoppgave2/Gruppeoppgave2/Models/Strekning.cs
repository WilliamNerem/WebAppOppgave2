﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gruppeoppgave2.Models
{
    public class Strekning
    {
        public int Id { get; set; }
        [RegularExpression(@"[A-ZÆØÅ][a-zæøå]+ - [A-ZÆØÅ][a-zæøå]")]
        public string Navn { get; set; }
        [RegularExpression(@"[0-9]{2}:[0-9]{2}")]
        public string Tid { get; set; }
        [RegularExpression(@"[0-9]+")]
        public int Pris { get; set; }
    }
}