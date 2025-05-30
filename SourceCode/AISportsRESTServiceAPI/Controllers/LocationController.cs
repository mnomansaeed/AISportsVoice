/*****************************************************************************************************************
Author: Code generated by Shinersoft Code Plumber 2008.
Date: Monday, November 11, 2024
Time: 7:12:00 AM
TableName: Location
/*****************************************************************************************************************/
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using DomainLayer;
using DataLayer;
using Utility;
using POCO;
using System.Web.Http;
using System.Web.Http.Description;
using System.Diagnostics;
namespace WebAPI
{
    /// <summary>
    /// Summary description for LocationService
    /// </summary>
    [Authorize]
    public class LocationController : ApiController
    {
        private EventLog eventLog;
        private DomainContext objContext;
        public LocationController()
        {
            eventLog = new EventLog("LocationServiceLog", "localhost", "LocationService");
        }
        [HttpGet]
        [Route("api/Location/GetLocationsByID/{ID}")]
        public POCO.Location GetLocationsByID(long ID)
        {
            POCO.Location items = new POCO.Location();
            objContext = new DomainContext(new DomainLayer.DomainClass());
            objContext.AddField(EntityMapper.Location.LOCATION_ID, ID);
            IList responseList = objContext.Load(EntityMapper.Entities.LOCATION, DomainMapper.GET_LOCATION_BY_ID);
            if (responseList != null)
            { if (responseList.Count > 0) { items = responseList.Cast<POCO.Location>().ToList()[0]; } }
            return items;
        }
        [HttpGet]
        [Route("api/Location/GetLocations")]
        [ResponseType(typeof(POCO.Location))]
        public POCO.Location GetLocations()
        {
            POCO.Location items = new POCO.Location();
            objContext = new DomainContext(new DomainLayer.DomainClass());
            IList responseList = objContext.Load(EntityMapper.Entities.LOCATION, DomainMapper.GET_LOCATIONS);
            if (responseList != null)
            { if (responseList.Count > 0) { items.lstLocation = responseList.Cast<POCO.Location>().ToList(); } }
            return items;
        }
        [HttpGet]
        [Route("api/Location/GetLocationsByLocationID/{ID}")]
        [ResponseType(typeof(POCO.Location))]
        public POCO.Location GetLocationsByLocationID(long ID)
        {
            POCO.Location items = new POCO.Location();
            objContext = new DomainContext(new DomainLayer.DomainClass());
            objContext.AddField(EntityMapper.Location.LOCATION_ID, ID);
            IList responseList = objContext.Load(EntityMapper.Entities.LOCATION, DomainMapper.GET_LOCATION_BY_LOCATION_ID);
            if (responseList != null)
            { if (responseList.Count > 0) { items.lstLocation = responseList.Cast<POCO.Location>().ToList(); } }
            return items;
        }
        [HttpPost]
        [Route("api/Location/AddLocation")]
        public long AddLocation(POCO.Location entity)
        {
            objContext = new DomainContext(new DomainLayer.DomainClass());
            try
            {
                objContext.AddField(EntityMapper.Location.TENANTID, entity.TenantId);
                objContext.AddField(EntityMapper.Location.LOCATIONNAME, entity.LocationName);
                objContext.AddField(EntityMapper.Location.SHORT_CODE, entity.Short_Code);
                objContext.AddField(EntityMapper.Location.LONG_CODE, entity.Long_Code);
                objContext.AddField(EntityMapper.Location.SHORT_NAME, entity.Short_Name);
                objContext.AddField(EntityMapper.Location.DESCRIPTION, entity.Description);
                objContext.AddField(EntityMapper.Location.PARENT_LOCATION_ID, entity.Parent_Location_ID);
                objContext.AddField(EntityMapper.Location.LOCATION_TYPE_ID, entity.Location_Type_Id);
                objContext.AddField(EntityMapper.Location.IS_ACTIVE, entity.Is_Active);
                objContext.AddField(EntityMapper.Location.CREATED_DATE, entity.Created_Date);
                objContext.AddField(EntityMapper.Location.CREATED_BY, entity.Created_By);
                objContext.AddField(EntityMapper.Location.MODIFIED_DATE, entity.Modified_Date);
                objContext.AddField(EntityMapper.Location.MODIFIED_BY, entity.Modified_By);
                objContext.AddField(EntityMapper.Location.AUDIT_ID, entity.Audit_Id);
                objContext.AddField(EntityMapper.Location.USER_IP, entity.User_IP);
                objContext.AddField(EntityMapper.Location.SITE_ID, entity.Site_Id);
                objContext.AddRecord(EntityMapper.Entities.LOCATION);
                objContext.Submit();
                objContext.Insert(UseTransaction.NO);
                return objContext.BusinessObject.ConvertDomainClass().ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objContext = null;
            }
        }
        [HttpPost]
        [Route("api/Location/UpdateLocation")]
        public long UpdateLocation(POCO.Location entity)
        {
            objContext = new DomainContext(new DomainLayer.DomainClass());
            try
            {
                objContext.AddField(EntityMapper.Location.LOCATION_ID, entity.Location_ID);
                objContext.AddField(EntityMapper.Location.TENANTID, entity.TenantId);
                objContext.AddField(EntityMapper.Location.LOCATIONNAME, entity.LocationName);
                objContext.AddField(EntityMapper.Location.SHORT_CODE, entity.Short_Code);
                objContext.AddField(EntityMapper.Location.LONG_CODE, entity.Long_Code);
                objContext.AddField(EntityMapper.Location.SHORT_NAME, entity.Short_Name);
                objContext.AddField(EntityMapper.Location.DESCRIPTION, entity.Description);
                objContext.AddField(EntityMapper.Location.PARENT_LOCATION_ID, entity.Parent_Location_ID);
                objContext.AddField(EntityMapper.Location.LOCATION_TYPE_ID, entity.Location_Type_Id);
                objContext.AddField(EntityMapper.Location.IS_ACTIVE, entity.Is_Active);
                objContext.AddField(EntityMapper.Location.CREATED_DATE, entity.Created_Date);
                objContext.AddField(EntityMapper.Location.CREATED_BY, entity.Created_By);
                objContext.AddField(EntityMapper.Location.MODIFIED_DATE, entity.Modified_Date);
                objContext.AddField(EntityMapper.Location.MODIFIED_BY, entity.Modified_By);
                objContext.AddField(EntityMapper.Location.AUDIT_ID, entity.Audit_Id);
                objContext.AddField(EntityMapper.Location.USER_IP, entity.User_IP);
                objContext.AddField(EntityMapper.Location.SITE_ID, entity.Site_Id);
                objContext.AddRecord(EntityMapper.Entities.LOCATION);
                objContext.Submit();
                objContext.Update(UseTransaction.NO);
                return objContext.BusinessObject.ConvertDomainClass().ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objContext = null;
            }
        }
        [HttpPost]
        [Route("api/Location/DeleteLocation")]
        public void DeleteLocation(POCO.Location entity)
        {
            objContext = new DomainContext(new DomainLayer.DomainClass());
            try
            {
                objContext.AddField(EntityMapper.Location.LOCATION_ID, entity.Location_ID);
                objContext.Load(EntityMapper.Entities.LOCATION, DomainMapper.GET_LOCATION_BY_ID_DATA);
                objContext.AddDeleteEntity(objContext.BusinessObject.DataList[0].ConvertLocation());
                objContext.Delete(UseTransaction.NO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objContext = null;
            }
        }
    }
}
/*****************************************************************************************************************/

