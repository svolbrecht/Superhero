﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHero.Models
{
    public class Superheroes
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alterego { get; set; }

        public string PrimaryAbility { get; set; }

        public string SecondaryAbility { get; set; }

        public string Catchphrase { get; set; }
    }
}