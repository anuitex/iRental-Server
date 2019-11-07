using iRental.Domain.Entities.Base;
using iRental.Domain.Enums;
using System;
using System.Collections.Generic;

namespace iRental.Domain.Entities.Items
{
    public interface IApartment : IBaseEntity
    {
        string Title { get; set; }
        string Area { get; set; }
        DateTime StartActivityPeriodUTC { get; set; }
        DateTime EndActivityPeriodUTC { get; set; }
        IEnumerable<DateTime> DaysOfWeek { get; set; } //TODO: check request property
        string Location { get; set; } //TODO:  check what property need for google

        int RoomsCount { get; set; }
        int BathroomsCount {get;set;}
        int AnnexesCount { get; set; }        

        DateTime CheckInUTC { get; set; } 
        DateTime UntilUTC { get; set; }

        string GuestInformstion { get; set; }

        IEnumerable<long> AdditionalOptionsIds { get; set; }

        IEnumerable<long> AdvertisingImages { get; set; }

        iRentalEnums.AdvertisingType AdvertisingType { get; set; }
        iRentalEnums.ApartmentType ApartmentType { get; set; }
        //TODO: wallet costs syste, link
    }
}
