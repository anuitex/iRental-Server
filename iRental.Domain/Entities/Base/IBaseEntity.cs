using System;

namespace iRental.Domain.Entities.Base
{ 
    public interface IBaseEntity
    {
        long Id { get; set; }
        DateTime CreationDateTimeUTC { get; set; } 
    }
}
