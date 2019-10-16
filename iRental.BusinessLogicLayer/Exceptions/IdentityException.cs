using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRental.BusinessLogicLayer.Exceptions
{
    public class IdentityException : Exception
    {
        public IEnumerable<IdentityError> Errors { get; set; }

        public IdentityException() : base()
        {

        }

        public IdentityException(string message) : base (message)
        {

        }
    }
}
