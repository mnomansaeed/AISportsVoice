/*****************************************************************************************************************
Author: Code generated by Shinersoft Code Plumber 2008.
Date: Thursday, April 24, 2025
Time: 10:42:00 AM
TableName: Location_Detail
/*****************************************************************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using DataLayer;
using Utility;
namespace DataLayer
{
public partial class Location_Detail: DataBase,IData
{
#region IData Members
string IData.InsertQuery()
{
throw new NotImplementedException();
}
string IData.UpdateQuery()
{
throw new NotImplementedException();
}
string IData.DeleteQuery()
{
throw new NotImplementedException();
}
string IData.SelectQuery()
{
throw new NotImplementedException();
}
string IData.SelectAllQuery()
{
throw new NotImplementedException();
}
IDbCommand IData.InsertSP()
{
 throw new NotImplementedException();
}
IDbCommand IData.UpdateSP()
{
 throw new NotImplementedException();
}
IDbCommand IData.DeleteSP()
{
 throw new NotImplementedException();
}
IDbCommand IData.SelectSP()
{
 throw new NotImplementedException();
}
IDbCommand IData.SelectAllSP()
{
 throw new NotImplementedException();
}
void IData.Fill(Hashtable Entity)
{
Loc_Detail_Id=Entity[EntityMapper.Location_Detail.LOC_DETAIL_ID].ConvertLong();
Location_ID=Entity[EntityMapper.Location_Detail.LOCATION_ID].ConvertInteger();
Downtime=Entity[EntityMapper.Location_Detail.DOWNTIME].ConvertBoolean();
AddressLine1=Entity[EntityMapper.Location_Detail.ADDRESSLINE1].ConvertString();
AddressLine2=Entity[EntityMapper.Location_Detail.ADDRESSLINE2].ConvertString();
City=Entity[EntityMapper.Location_Detail.CITY].ConvertString();
State=Entity[EntityMapper.Location_Detail.STATE].ConvertString();
Country=Entity[EntityMapper.Location_Detail.COUNTRY].ConvertString();
PostalCode=Entity[EntityMapper.Location_Detail.POSTALCODE].ConvertString();
FaxNumber=Entity[EntityMapper.Location_Detail.FAXNUMBER].ConvertString();
PhoneNumber1=Entity[EntityMapper.Location_Detail.PHONENUMBER1].ConvertString();
PhoneNumber2=Entity[EntityMapper.Location_Detail.PHONENUMBER2].ConvertString();
Email=Entity[EntityMapper.Location_Detail.EMAIL].ConvertString();
WebsiteURL=Entity[EntityMapper.Location_Detail.WEBSITEURL].ConvertString();
Is_Active=Entity[EntityMapper.Location_Detail.IS_ACTIVE].ConvertByte();
Created_Date=Entity[EntityMapper.Location_Detail.CREATED_DATE].ConvertDateTime();
Created_By=Entity[EntityMapper.Location_Detail.CREATED_BY].ConvertInteger();
Modified_Date=Entity[EntityMapper.Location_Detail.MODIFIED_DATE].ConvertDateTime();
Modified_By=Entity[EntityMapper.Location_Detail.MODIFIED_BY].ConvertInteger();
Audit_Id=Entity[EntityMapper.Location_Detail.AUDIT_ID].ConvertLong();
User_IP=Entity[EntityMapper.Location_Detail.USER_IP].ConvertString();
Site_Id=Entity[EntityMapper.Location_Detail.SITE_ID].ConvertInteger();
}
void IData.InsertOnSubmit(DALEntities objDataContext, IData Entity)
{
objDataContext.Location_Detail.Add(Entity.ConvertLocation_Detail());
}
void IData.UpdateOnSubmit(DALEntities objDataContext, IData Entity)
{
Location_Detail objEntity = Entity.ConvertLocation_Detail();
objDataContext.Location_Detail.Attach(objEntity);
}
public IList SelectEntity(DALEntities objDataContext, string Behaviour)
{
try
 {
switch(Behaviour.ToString())
 {
 case DomainMapper.GET_LOCATION_DETAILS_DATA:
  var _Result2 = objDataContext.Location_Detail.Select(j =>
new {Loc_Detail_Id = j.Loc_Detail_Id,
Location_ID = j.Location_ID,
Downtime = j.Downtime,
AddressLine1 = j.AddressLine1,
AddressLine2 = j.AddressLine2,
City = j.City,
State = j.State,
Country = j.Country,
PostalCode = j.PostalCode,
FaxNumber = j.FaxNumber,
PhoneNumber1 = j.PhoneNumber1,
PhoneNumber2 = j.PhoneNumber2,
Email = j.Email,
WebsiteURL = j.WebsiteURL,
Is_Active = j.Is_Active,
Created_Date = j.Created_Date,
Created_By = j.Created_By,
Modified_Date = j.Modified_Date,
Modified_By = j.Modified_By,
Audit_Id = j.Audit_Id,
User_IP = j.User_IP,
Site_Id = j.Site_Id
}).ToList();
 return _Result2.ToList();
 case DomainMapper.GET_LOCATION_DETAILS:
  var _Result = objDataContext.Location_Detail.Select(j =>
new POCO.Location_Detail{Loc_Detail_Id = j.Loc_Detail_Id,
Location_ID = j.Location_ID,
Downtime = j.Downtime,
AddressLine1 = j.AddressLine1,
AddressLine2 = j.AddressLine2,
City = j.City,
State = j.State,
Country = j.Country,
PostalCode = j.PostalCode,
FaxNumber = j.FaxNumber,
PhoneNumber1 = j.PhoneNumber1,
PhoneNumber2 = j.PhoneNumber2,
Email = j.Email,
WebsiteURL = j.WebsiteURL,
Is_Active = j.Is_Active,
Created_Date = j.Created_Date,
Created_By = j.Created_By,
Modified_Date = j.Modified_Date,
Modified_By = j.Modified_By,
Audit_Id = j.Audit_Id,
User_IP = j.User_IP,
Site_Id = j.Site_Id
}).ToList();
 return _Result.ToList();
case DomainMapper.GET_LOCATION_DETAIL_BY_LOCATION_ID:
/* var _Result4 = (from oD in objDataContext.Location_Detail
where oD.Location_ID==Location_ID
orderby oD.Loc_Detail_Id descending
select new POCO.Location_Detail{Loc_Detail_Id = oD.Loc_Detail_Id,
Location_ID = oD.Location_ID,
Downtime = oD.Downtime,
AddressLine1 = oD.AddressLine1,
AddressLine2 = oD.AddressLine2,
City = oD.City,
State = oD.State,
Country = oD.Country,
PostalCode = oD.PostalCode,
FaxNumber = oD.FaxNumber,
PhoneNumber1 = oD.PhoneNumber1,
PhoneNumber2 = oD.PhoneNumber2,
Email = oD.Email,
WebsiteURL = oD.WebsiteURL,
Is_Active = oD.Is_Active,
Created_Date = oD.Created_Date,
Created_By = oD.Created_By,
Modified_Date = oD.Modified_Date,
Modified_By = oD.Modified_By,
Audit_Id = oD.Audit_Id,
User_IP = oD.User_IP,
Site_Id = oD.Site_Id
}).ToList();
return _Result4.ToList();*/
case DomainMapper.GET_LOCATION_DETAIL_BY_ID:
 var _Result1 = (from oD in objDataContext.Location_Detail
where oD.Loc_Detail_Id==Loc_Detail_Id
orderby oD.Loc_Detail_Id descending
select new POCO.Location_Detail{Loc_Detail_Id = oD.Loc_Detail_Id,
Location_ID = oD.Location_ID,
Downtime = oD.Downtime,
AddressLine1 = oD.AddressLine1,
AddressLine2 = oD.AddressLine2,
City = oD.City,
State = oD.State,
Country = oD.Country,
PostalCode = oD.PostalCode,
FaxNumber = oD.FaxNumber,
PhoneNumber1 = oD.PhoneNumber1,
PhoneNumber2 = oD.PhoneNumber2,
Email = oD.Email,
WebsiteURL = oD.WebsiteURL,
Is_Active = oD.Is_Active,
Created_Date = oD.Created_Date,
Created_By = oD.Created_By,
Modified_Date = oD.Modified_Date,
Modified_By = oD.Modified_By,
Audit_Id = oD.Audit_Id,
User_IP = oD.User_IP,
Site_Id = oD.Site_Id
}).ToList();
return _Result1;
case DomainMapper.GET_LOCATION_DETAIL_BY_ID_DATA:
 var _Result3 = from oD in objDataContext.Location_Detail
where oD.Loc_Detail_Id==Loc_Detail_Id
orderby oD.Loc_Detail_Id descending
select new {oD.Loc_Detail_Id,oD.Location_ID,oD.Downtime,oD.AddressLine1,oD.AddressLine2,oD.City,oD.State,oD.Country,oD.PostalCode,oD.FaxNumber,oD.PhoneNumber1,oD.PhoneNumber2,oD.Email,oD.WebsiteURL,oD.Is_Active,oD.Created_Date,oD.Created_By,oD.Modified_Date,oD.Modified_By,oD.Audit_Id,oD.User_IP,oD.Site_Id };
ArrayList objList = new ArrayList();
Location_Detail objLocation_Detail;
foreach (var objLoc1 in _Result3)
 {
objLocation_Detail = new Location_Detail();
objLocation_Detail.Loc_Detail_Id = objLoc1.Loc_Detail_Id;
objLocation_Detail.Location_ID = objLoc1.Location_ID;
objLocation_Detail.Downtime = objLoc1.Downtime;
objLocation_Detail.AddressLine1 = objLoc1.AddressLine1;
objLocation_Detail.AddressLine2 = objLoc1.AddressLine2;
objLocation_Detail.City = objLoc1.City;
objLocation_Detail.State = objLoc1.State;
objLocation_Detail.Country = objLoc1.Country;
objLocation_Detail.PostalCode = objLoc1.PostalCode;
objLocation_Detail.FaxNumber = objLoc1.FaxNumber;
objLocation_Detail.PhoneNumber1 = objLoc1.PhoneNumber1;
objLocation_Detail.PhoneNumber2 = objLoc1.PhoneNumber2;
objLocation_Detail.Email = objLoc1.Email;
objLocation_Detail.WebsiteURL = objLoc1.WebsiteURL;
objLocation_Detail.Is_Active = objLoc1.Is_Active;
objLocation_Detail.Created_Date = objLoc1.Created_Date;
objLocation_Detail.Created_By = objLoc1.Created_By;
objLocation_Detail.Modified_Date = objLoc1.Modified_Date;
objLocation_Detail.Modified_By = objLoc1.Modified_By;
objLocation_Detail.Audit_Id = objLoc1.Audit_Id;
objLocation_Detail.User_IP = objLoc1.User_IP;
objLocation_Detail.Site_Id = objLoc1.Site_Id;
objList.Add(objLocation_Detail);
}
return objList;
default:
return null;
}
}
catch (Exception ex)
{
throw ex;
}
}
void IData.AddChild(IData childEntity)
{
//_ProductDetails.Add((DataLayer.ProductDetail)childEntity);
 throw new NotImplementedException();
}
public void DeleteOnSubmit(DALEntities objDataContext, IData Entity)
{
 //throw new NotImplementedException();
Location_Detail objEntity = Entity.ConvertLocation_Detail();
objDataContext.Location_Detail.Attach(objEntity);
objDataContext.Location_Detail.Remove(objEntity);
}
#endregion
}
}
/*****************************************************************************************************************/

