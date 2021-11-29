using FootballManagerApi.EntityBases;
using System;
using System.Collections.Generic;

namespace FootballManagerApi.Entities
{
    public class Coach : Person, IEntity
    {
        public ICollection<Tactic> Tactics { get; set; }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
