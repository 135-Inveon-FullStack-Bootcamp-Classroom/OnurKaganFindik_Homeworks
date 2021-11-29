using FootballManagerApi.Entities;
using System;

namespace FootballManagerApi.EntityBases
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Team Team { get; set; }
        public NationalTeam NationalTeam { get; set; }
    }
}
