using FootballManagerApi.EntityBases;
using System;
using System.Collections.Generic;

namespace FootballManagerApi.Entities
{
    public class Position : IEntity
    {
        public string Name { get; set; }
        public ICollection<Footballer> Footballers { get; set; }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
