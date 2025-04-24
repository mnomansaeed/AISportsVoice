using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Utility
{
    public class GlobalVar
    {
        private int mUserId;
        public int UserId
        {
            get { return mUserId; }
            set { mUserId = value; }
        }

        private Int64 mUserGroupId;
        public Int64 UserGroupId
        {
            get { return mUserGroupId; }
            set { mUserGroupId = value; }
        }

        private string mUserGroupName;
        public string UserGroupName
        {
            get { return mUserGroupName; }
            set { mUserGroupName = value; }
        }

        private long mCustomerId;
        public long CustomerId
        {
            get { return mCustomerId; }
            set { mCustomerId = value; }
        }

        private int mLocationId;
        public int LocationId
        {
            get { return mLocationId; }
            set { mLocationId = value; }
        }

        public string GetData()
        {
            return mUserId.ToString() + "," + mCustomerId.ToString() + "," + mLocationId.ToString() + "," + mUserGroupId.ToString() + "," + mUserGroupName.ToString();
        }
        public void SetData(string data)
        {
            string[] strArr = data.Split(',');
            mUserId = Convert.ToInt32(strArr[0]);
            mCustomerId = Convert.ToInt64(strArr[1]);
            mLocationId = Convert.ToInt32(strArr[2]);
            mUserGroupId = Convert.ToInt64(strArr[3]);
            mUserGroupName = strArr[4].ToString();
        }

        public string BaseUrl
        {
            get
            {
                return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";

            }
        }

        public string IPAddress { get { return GlobalConstants.IPAddress; } }

    }
}
