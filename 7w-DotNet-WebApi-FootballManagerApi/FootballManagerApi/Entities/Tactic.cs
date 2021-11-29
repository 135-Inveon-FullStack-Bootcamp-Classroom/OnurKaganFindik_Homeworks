using FootballManagerApi.EntityBases;
using System;

namespace FootballManagerApi.Entities
{
    public class Tactic: IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
