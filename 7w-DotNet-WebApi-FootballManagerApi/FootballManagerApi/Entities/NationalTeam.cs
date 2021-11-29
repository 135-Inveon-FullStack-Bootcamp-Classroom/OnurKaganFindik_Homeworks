using FootballManagerApi.EntityBases;
using System;

namespace FootballManagerApi.Entities
{
    public class NationalTeam : Team, IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
