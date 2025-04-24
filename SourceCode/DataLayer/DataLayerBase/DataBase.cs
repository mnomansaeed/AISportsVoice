using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using DataLayer;
using System.Collections;
using Utility;
/// <summary>
/// Summary description for DataBase
/// </summary>
namespace DataLayer
{
    public class DataBase
    {
        #region Protected Members
            protected IQueryable _Query;
            protected object _Tag;
            protected int _PageSize;
            protected int _PageNum;
            protected double _RecordCount;
            protected double _TotalPages;

            protected double getPageCount(double Value)
            {
                _TotalPages = Math.Ceiling(Value);
                return _TotalPages;
            }
            protected void setPagingParameters(Hashtable tempHash)
            {
               // _PageSize = tempHash[EntityMapper.PagingTable.PAGESIZE].ConvertInteger();
               // _PageNum = tempHash[EntityMapper.PagingTable.PAGENUMBER].ConvertInteger();
            }

        #endregion

        public DataBase()
        {
        
        }
        ~DataBase()
        {
        
        }
       
        public object Tag
        {
            get
            {
                return this._Tag;
            }
            set
            {
                this._Tag = value;
            }
        }

    }
}