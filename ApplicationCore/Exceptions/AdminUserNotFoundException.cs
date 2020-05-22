using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Exceptions
{
    public class AdminUserNotFoundException : Exception
    {
        public AdminUserNotFoundException() 
            : base($"No Admin user information found in the system configuration") { }
    }
}
