using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_IMDb_Clone.Entities
{
    public class Movies
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string DirectorFullName { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
    }
}
