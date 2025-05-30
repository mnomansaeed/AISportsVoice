/*****************************************************************************************************************
Author: Code generated by Shinersoft Code Plumber 2008.
Date: Thursday, November 14, 2024
Time: 10:49:00 AM
TableName: PhysicalLocation
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
/// Summary description for PhysicalLocationService
/// </summary>
[Authorize]
public class PhysicalLocationController : ApiController
{
private EventLog eventLog;
private DomainContext objContext;
public PhysicalLocationController()
{
eventLog = new EventLog("PhysicalLocationServiceLog", "localhost", "PhysicalLocationService");
}
[HttpGet]
[Route("api/PhysicalLocation/GetPhysicalLocationsByID/{ID}")]
public POCO.PhysicalLocation GetPhysicalLocationsByID(long ID)
{
POCO.PhysicalLocation items = new POCO.PhysicalLocation();
objContext = new DomainContext(new DomainLayer.DomainClass());
objContext.AddField(EntityMapper.PhysicalLocation.PHYSICALLOCATION_ID, ID);
IList responseList = objContext.Load(EntityMapper.Entities.PHYSICALLOCATION, DomainMapper.GET_PHYSICALLOCATION_BY_ID);
if (responseList != null)
{ if (responseList.Count > 0) { items = responseList.Cast<POCO.PhysicalLocation>().ToList()[0]; }}
return items;
}
[HttpGet]
[Route("api/PhysicalLocation/GetPhysicalLocations")]
[ResponseType(typeof(POCO.PhysicalLocation))]
public POCO.PhysicalLocation GetPhysicalLocations()
{
POCO.PhysicalLocation items = new POCO.PhysicalLocation();
objContext = new DomainContext(new DomainLayer.DomainClass());
IList responseList = objContext.Load(EntityMapper.Entities.PHYSICALLOCATION, DomainMapper.GET_PHYSICALLOCATIONS);
if (responseList != null)
{ if (responseList.Count > 0) { items.lstPhysicalLocation = responseList.Cast<POCO.PhysicalLocation>().ToList(); }}
return items;
}
[HttpGet]
[Route("api/PhysicalLocation/GetPhysicalLocationsByLocationID/{ID}")]
[ResponseType(typeof(POCO.PhysicalLocation))]
public POCO.PhysicalLocation GetPhysicalLocationsByLocationID(long ID)
{
POCO.PhysicalLocation items = new POCO.PhysicalLocation();
objContext = new DomainContext(new DomainLayer.DomainClass());
objContext.AddField(EntityMapper.PhysicalLocation.LOCATION_ID, ID);
IList responseList = objContext.Load(EntityMapper.Entities.PHYSICALLOCATION, DomainMapper.GET_PHYSICALLOCATION_BY_LOCATION_ID);
if (responseList != null)
{ if (responseList.Count > 0) { items.lstPhysicalLocation = responseList.Cast<POCO.PhysicalLocation>().ToList(); }}
return items;
}
[HttpPost]
[Route("api/PhysicalLocation/AddPhysicalLocation")]
public long AddPhysicalLocation(POCO.PhysicalLocation entity)
{
objContext = new DomainContext(new DomainLayer.DomainClass());
try
{
objContext.AddField(EntityMapper.PhysicalLocation.LOCATION_ID, entity.Location_ID);
objContext.AddField(EntityMapper.PhysicalLocation.PHYSICALLOCATIONNAME, entity.PhysicalLocationName);
objContext.AddField(EntityMapper.PhysicalLocation.SHORT_CODE, entity.Short_Code);
objContext.AddField(EntityMapper.PhysicalLocation.LONG_CODE, entity.Long_Code);
objContext.AddField(EntityMapper.PhysicalLocation.SHORT_NAME, entity.Short_Name);
objContext.AddField(EntityMapper.PhysicalLocation.DESCRIPTION, entity.Description);
objContext.AddField(EntityMapper.PhysicalLocation.PARENT_PHYSICALLOCATION_ID, entity.Parent_PhysicalLocation_ID);
objContext.AddField(EntityMapper.PhysicalLocation.PHYSICALLOCATION_TYPE_ID, entity.PhysicalLocation_Type_Id);
objContext.AddField(EntityMapper.PhysicalLocation.IS_ACTIVE, entity.Is_Active);
objContext.AddField(EntityMapper.PhysicalLocation.CREATED_DATE, entity.Created_Date);
objContext.AddField(EntityMapper.PhysicalLocation.CREATED_BY, entity.Created_By);
objContext.AddField(EntityMapper.PhysicalLocation.MODIFIED_DATE, entity.Modified_Date);
objContext.AddField(EntityMapper.PhysicalLocation.MODIFIED_BY, entity.Modified_By);
objContext.AddField(EntityMapper.PhysicalLocation.AUDIT_ID, entity.Audit_Id);
objContext.AddField(EntityMapper.PhysicalLocation.USER_IP, entity.User_IP);
objContext.AddField(EntityMapper.PhysicalLocation.SITE_ID, entity.Site_Id);
objContext.AddRecord(EntityMapper.Entities.PHYSICALLOCATION);
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
[Route("api/PhysicalLocation/UpdatePhysicalLocation")]
public long UpdatePhysicalLocation(POCO.PhysicalLocation entity)
{
objContext = new DomainContext(new DomainLayer.DomainClass());
try
{
objContext.AddField(EntityMapper.PhysicalLocation.PHYSICALLOCATION_ID, entity.PhysicalLocation_ID);
objContext.AddField(EntityMapper.PhysicalLocation.LOCATION_ID, entity.Location_ID);
objContext.AddField(EntityMapper.PhysicalLocation.PHYSICALLOCATIONNAME, entity.PhysicalLocationName);
objContext.AddField(EntityMapper.PhysicalLocation.SHORT_CODE, entity.Short_Code);
objContext.AddField(EntityMapper.PhysicalLocation.LONG_CODE, entity.Long_Code);
objContext.AddField(EntityMapper.PhysicalLocation.SHORT_NAME, entity.Short_Name);
objContext.AddField(EntityMapper.PhysicalLocation.DESCRIPTION, entity.Description);
objContext.AddField(EntityMapper.PhysicalLocation.PARENT_PHYSICALLOCATION_ID, entity.Parent_PhysicalLocation_ID);
objContext.AddField(EntityMapper.PhysicalLocation.PHYSICALLOCATION_TYPE_ID, entity.PhysicalLocation_Type_Id);
objContext.AddField(EntityMapper.PhysicalLocation.IS_ACTIVE, entity.Is_Active);
objContext.AddField(EntityMapper.PhysicalLocation.CREATED_DATE, entity.Created_Date);
objContext.AddField(EntityMapper.PhysicalLocation.CREATED_BY, entity.Created_By);
objContext.AddField(EntityMapper.PhysicalLocation.MODIFIED_DATE, entity.Modified_Date);
objContext.AddField(EntityMapper.PhysicalLocation.MODIFIED_BY, entity.Modified_By);
objContext.AddField(EntityMapper.PhysicalLocation.AUDIT_ID, entity.Audit_Id);
objContext.AddField(EntityMapper.PhysicalLocation.USER_IP, entity.User_IP);
objContext.AddField(EntityMapper.PhysicalLocation.SITE_ID, entity.Site_Id);
objContext.AddRecord(EntityMapper.Entities.PHYSICALLOCATION);
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
[Route("api/PhysicalLocation/DeletePhysicalLocation")]
public void DeletePhysicalLocation(POCO.PhysicalLocation entity)
{
objContext = new DomainContext(new DomainLayer.DomainClass());
try
{
objContext.AddField(EntityMapper.PhysicalLocation.PHYSICALLOCATION_ID, entity.PhysicalLocation_ID);
objContext.Load(EntityMapper.Entities.PHYSICALLOCATION, DomainMapper.GET_PHYSICALLOCATION_BY_ID_DATA);
objContext.AddDeleteEntity(objContext.BusinessObject.DataList[0].ConvertPhysicalLocation());
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

