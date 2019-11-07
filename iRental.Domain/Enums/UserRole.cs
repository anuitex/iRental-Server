using System;
using System.Collections.Generic;
using System.Text;

namespace iRental.Domain.Enums
{
    public partial class iRentalEnums
    {
        public enum UserRole
        {
            None = 0,
            Advertiser = 1,
            Influencer = 2,
            Admin = 3,
            SuperAdmin = 4
        }
    }
}
