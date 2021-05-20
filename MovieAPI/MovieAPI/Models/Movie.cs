using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string MovieName { get; set; }
        public decimal ImdbRating { get; set; }
        public string Director { get; set; }
        public int DurationMinutes { get; set; }
        public DateTime? ReleaseYear { get; set; }
        public decimal Budget { get; set; }
        public decimal GrossEarning { get; set; }
    }
}
