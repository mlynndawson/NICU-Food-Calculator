using System;
using System.Collections.Generic;
using System.Text;

namespace NICU_foodcalculator.Models
{
    public class Baby
    {
        public int BabyId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public decimal BirthWeight { get; set; }

        public DateTime CurrentDate { get; set; }

        public decimal CurrentWeight { get; set; }

        public decimal? FoodMouth { get; set; }

        public decimal? MouthCalorie { get; set; }

        public decimal? FoodTube { get; set; }

        public decimal? TubeCalorie { get; set; }

        public decimal? FoodIV { get; set; }

        public decimal? IVCalorie { get; set; }

    }
}
