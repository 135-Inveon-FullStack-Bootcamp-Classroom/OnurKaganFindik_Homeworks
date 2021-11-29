using System;

namespace FootballManagerApi.EntityBases
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
    }
}
