using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Utility
{
    public class AccessRights
    {
        public bool View
        {
            get;
            set;
        }

        public bool Add
        {
            get;
            set;
        }

        public bool Edit
        {
            get;
            set;
        }

        public bool Delete
        {
            get;
            set;
        }

        public bool UnDelete
        {
            get;
            set;
        }

        public bool Print
        {
            get;
            set;
        }

        public bool PrintPreview
        {
            get;
            set;
        }
    }
}
