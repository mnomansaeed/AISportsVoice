/*****************************************************************************************************************
Author: Code generated by Shinersoft Code Plumber 2008.
Date: Monday, November 11, 2024
Time: 7:12:00 AM
TableName: Location_Detail
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
/// Summary description for Location_DetailService
/// </summary>
[Authorize]
public class Location_DetailController : ApiController
{
private EventLog eventLog;
private DomainContext objContext;
public Location_DetailController()
{
eventLog = new EventLog("Location_DetailServiceLog", "localhost", "Location_DetailService");
}
[HttpGet]
[Route("api/Location_Detail/GetLocation_DetailsByID/{ID}")]
public POCO.Location_Detail GetLocation_DetailsByID(long ID)
{
POCO.Location_Detail items = new POCO.Location_Detail();
objContext = new DomainContext(new DomainLayer.DomainClass());
objContext.AddField(EntityMapper.Location_Detail.LOC_DETAIL_ID, ID);
IList responseList = objContext.Load(EntityMapper.Entities.LOCATION_DETAIL, DomainMapper.GET_LOCATION_DETAIL_BY_ID);
if (responseList != null)
{ if (responseList.Count > 0) { items = responseList.Cast<POCO.Location_Detail>().ToList()[0]; }}
return items;
}
[HttpGet]
[Route("api/Location_Detail/GetLocation_Details")]
[ResponseType(typeof(POCO.Location_Detail))]
public POCO.Location_Detail GetLocation_Details()
{
POCO.Location_Detail items = new POCO.Location_Detail();
objContext = new DomainContext(new DomainLayer.DomainClass());
IList responseList = objContext.Load(EntityMapper.Entities.LOCATION_DETAIL, DomainMapper.GET_LOCATION_DETAILS);
if (responseList != null)
{ if (responseList.Count > 0) { items.lstLocation_Detail = responseList.Cast<POCO.Location_Detail>().ToList(); }}
return items;
}
[HttpGet]
[Route("api/Location_Detail/GetLocation_DetailsByLocationID/{ID}")]
[ResponseType(typeof(POCO.Location_Detail))]
public POCO.Location_Detail GetLocation_DetailsByLocationID(long ID)
{
POCO.Location_Detail items = new POCO.Location_Detail();
objContext = new DomainContext(new DomainLayer.DomainClass());
objContext.AddField(EntityMapper.Location_Detail.LOCATION_ID, ID);
IList responseList = objContext.Load(EntityMapper.Entities.LOCATION_DETAIL, DomainMapper.GET_LOCATION_DETAIL_BY_LOCATION_ID);
if (responseList != null)
{ if (responseList.Count > 0) { items.lstLocation_Detail = responseList.Cast<POCO.Location_Detail>().ToList(); }}
return items;
}
[HttpPost]
[Route("api/Location_Detail/AddLocation_Detail")]
public long AddLocation_Detail(POCO.Location_Detail entity)
{
objContext = new DomainContext(new DomainLayer.DomainClass());
try
{
objContext.AddField(EntityMapper.Location_Detail.LOCATION_ID, entity.Location_ID);
objContext.AddField(EntityMapper.Location_Detail.DOWNTIME, entity.Downtime);
objContext.AddField(EntityMapper.Location_Detail.ADDRESSLINE1, entity.AddressLine1);
objContext.AddField(EntityMapper.Location_Detail.ADDRESSLINE2, entity.AddressLine2);
objContext.AddField(EntityMapper.Location_Detail.CITY, entity.City);
objContext.AddField(EntityMapper.Location_Detail.STATE, entity.State);
objContext.AddField(EntityMapper.Location_Detail.COUNTRY, entity.Country);
objContext.AddField(EntityMapper.Location_Detail.POSTALCODE, entity.PostalCode);
objContext.AddField(EntityMapper.Location_Detail.FAXNUMBER, entity.FaxNumber);
objContext.AddField(EntityMapper.Location_Detail.PHONENUMBER1, entity.PhoneNumber1);
objContext.AddField(EntityMapper.Location_Detail.PHONENUMBER2, entity.PhoneNumber2);
objContext.AddField(EntityMapper.Location_Detail.EMAIL, entity.Email);
objContext.AddField(EntityMapper.Location_Detail.WEBSITEURL, entity.WebsiteURL);
objContext.AddField(EntityMapper.Location_Detail.IS_ACTIVE, entity.Is_Active);
objContext.AddField(EntityMapper.Location_Detail.CREATED_DATE, entity.Created_Date);
objContext.AddField(EntityMapper.Location_Detail.CREATED_BY, entity.Created_By);
objContext.AddField(EntityMapper.Location_Detail.MODIFIED_DATE, entity.Modified_Date);
objContext.AddField(EntityMapper.Location_Detail.MODIFIED_BY, entity.Modified_By);
objContext.AddField(EntityMapper.Location_Detail.AUDIT_ID, entity.Audit_Id);
objContext.AddField(EntityMapper.Location_Detail.USER_IP, entity.User_IP);
objContext.AddField(EntityMapper.Location_Detail.SITE_ID, entity.Site_Id);
objContext.AddRecord(EntityMapper.Entities.LOCATION_DETAIL);
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
[Route("api/Location_Detail/UpdateLocation_Detail")]
public long UpdateLocation_Detail(POCO.Location_Detail entity)
{
objContext = new DomainContext(new DomainLayer.DomainClass());
try
{
objContext.AddField(EntityMapper.Location_Detail.LOC_DETAIL_ID, entity.Loc_Detail_Id);
objContext.AddField(EntityMapper.Location_Detail.LOCATION_ID, entity.Location_ID);
objContext.AddField(EntityMapper.Location_Detail.DOWNTIME, entity.Downtime);
objContext.AddField(EntityMapper.Location_Detail.ADDRESSLINE1, entity.AddressLine1);
objContext.AddField(EntityMapper.Location_Detail.ADDRESSLINE2, entity.AddressLine2);
objContext.AddField(EntityMapper.Location_Detail.CITY, entity.City);
objContext.AddField(EntityMapper.Location_Detail.STATE, entity.State);
objContext.AddField(EntityMapper.Location_Detail.COUNTRY, entity.Country);
objContext.AddField(EntityMapper.Location_Detail.POSTALCODE, entity.PostalCode);
objContext.AddField(EntityMapper.Location_Detail.FAXNUMBER, entity.FaxNumber);
objContext.AddField(EntityMapper.Location_Detail.PHONENUMBER1, entity.PhoneNumber1);
objContext.AddField(EntityMapper.Location_Detail.PHONENUMBER2, entity.PhoneNumber2);
objContext.AddField(EntityMapper.Location_Detail.EMAIL, entity.Email);
objContext.AddField(EntityMapper.Location_Detail.WEBSITEURL, entity.WebsiteURL);
objContext.AddField(EntityMapper.Location_Detail.IS_ACTIVE, entity.Is_Active);
objContext.AddField(EntityMapper.Location_Detail.CREATED_DATE, entity.Created_Date);
objContext.AddField(EntityMapper.Location_Detail.CREATED_BY, entity.Created_By);
objContext.AddField(EntityMapper.Location_Detail.MODIFIED_DATE, entity.Modified_Date);
objContext.AddField(EntityMapper.Location_Detail.MODIFIED_BY, entity.Modified_By);
objContext.AddField(EntityMapper.Location_Detail.AUDIT_ID, entity.Audit_Id);
objContext.AddField(EntityMapper.Location_Detail.USER_IP, entity.User_IP);
objContext.AddField(EntityMapper.Location_Detail.SITE_ID, entity.Site_Id);
objContext.AddRecord(EntityMapper.Entities.LOCATION_DETAIL);
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
[Route("api/Location_Detail/DeleteLocation_Detail")]
public void DeleteLocation_Detail(POCO.Location_Detail entity)
{
objContext = new DomainContext(new DomainLayer.DomainClass());
try
{
objContext.AddField(EntityMapper.Location_Detail.LOC_DETAIL_ID, entity.Loc_Detail_Id);
objContext.Load(EntityMapper.Entities.LOCATION_DETAIL, DomainMapper.GET_LOCATION_DETAIL_BY_ID_DATA);
objContext.AddDeleteEntity(objContext.BusinessObject.DataList[0].ConvertLocation_Detail());
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

