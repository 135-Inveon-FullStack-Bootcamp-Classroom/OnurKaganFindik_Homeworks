using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballManagerApi.EntityBases;

namespace FootballManagerApi.Entities
{
    public class Tactic: IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
