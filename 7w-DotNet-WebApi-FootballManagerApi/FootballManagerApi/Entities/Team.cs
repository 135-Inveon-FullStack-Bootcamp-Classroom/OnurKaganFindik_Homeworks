using FootballManagerApi.EntityBases;
using System;
using System.Collections.Generic;

namespace FootballManagerApi.Entities
{
    public class Team : IEntity
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public ICollection<Footballer> Footballers { get; set; }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
