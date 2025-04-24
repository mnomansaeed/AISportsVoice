using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class RequestHelper
    {
        public static GlobalVar MyGlobalVar { get { return TicketHelper.GetUserData(); } }

     
    }
}
