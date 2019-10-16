using System;
using System.Collections.Generic;
using System.Text;

namespace iRental.Domain
{
    public interface IEntity
    {
        string Id { get; set; }
        DateTimeOffset CreatedAt { get; set; }
    }
}
