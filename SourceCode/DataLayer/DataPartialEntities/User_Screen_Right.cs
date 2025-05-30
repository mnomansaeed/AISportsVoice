/*****************************************************************************************************************
Author: Code generated by Shinersoft Code Plumber 2008.
Date: Thursday, April 24, 2025
Time: 10:42:00 AM
TableName: User_Screen_Right
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
public partial class User_Screen_Right: DataBase,IData
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
UserRightsId=Entity[EntityMapper.User_Screen_Right.USERRIGHTSID].ConvertInteger();
UserGroupId=Entity[EntityMapper.User_Screen_Right.USERGROUPID].ConvertInteger();
ScreenId=Entity[EntityMapper.User_Screen_Right.SCREENID].ConvertInteger();
ViewRights=Entity[EntityMapper.User_Screen_Right.VIEWRIGHTS].ConvertBoolean();
AddRights=Entity[EntityMapper.User_Screen_Right.ADDRIGHTS].ConvertBoolean();
EditRights=Entity[EntityMapper.User_Screen_Right.EDITRIGHTS].ConvertBoolean();
DeleteRights=Entity[EntityMapper.User_Screen_Right.DELETERIGHTS].ConvertBoolean();
ReportRights=Entity[EntityMapper.User_Screen_Right.REPORTRIGHTS].ConvertBoolean();
Is_Active=Entity[EntityMapper.User_Screen_Right.IS_ACTIVE].ConvertBoolean();
Created_Date=Entity[EntityMapper.User_Screen_Right.CREATED_DATE].ConvertDateTime();
Created_By=Entity[EntityMapper.User_Screen_Right.CREATED_BY].ConvertInteger();
Modified_Date=Entity[EntityMapper.User_Screen_Right.MODIFIED_DATE].ConvertDateTime();
Modified_By=Entity[EntityMapper.User_Screen_Right.MODIFIED_BY].ConvertInteger();
Audit_Id=Entity[EntityMapper.User_Screen_Right.AUDIT_ID].ConvertInteger();
User_IP=Entity[EntityMapper.User_Screen_Right.USER_IP].ConvertString();
Site_Id=Entity[EntityMapper.User_Screen_Right.SITE_ID].ConvertInteger();
}
void IData.InsertOnSubmit(DALEntities objDataContext, IData Entity)
{
objDataContext.User_Screen_Right.Add(Entity.ConvertUser_Screen_Right());
}
void IData.UpdateOnSubmit(DALEntities objDataContext, IData Entity)
{
User_Screen_Right objEntity = Entity.ConvertUser_Screen_Right();
objDataContext.User_Screen_Right.Attach(objEntity);
}
public IList SelectEntity(DALEntities objDataContext, string Behaviour)
{
try
 {
switch(Behaviour.ToString())
 {
 case DomainMapper.GET_USER_SCREEN_RIGHTS_DATA:
  var _Result2 = objDataContext.User_Screen_Right.Select(j =>
new {UserRightsId = j.UserRightsId,
UserGroupId = j.UserGroupId,
ScreenId = j.ScreenId,
ViewRights = j.ViewRights,
AddRights = j.AddRights,
EditRights = j.EditRights,
DeleteRights = j.DeleteRights,
ReportRights = j.ReportRights,
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
 case DomainMapper.GET_USER_SCREEN_RIGHTS:
  var _Result = objDataContext.User_Screen_Right.Select(j =>
new POCO.User_Screen_Right{UserRightsId = j.UserRightsId,
UserGroupId = j.UserGroupId,
ScreenId = j.ScreenId,
ViewRights = j.ViewRights,
AddRights = j.AddRights,
EditRights = j.EditRights,
DeleteRights = j.DeleteRights,
ReportRights = j.ReportRights,
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
case DomainMapper.GET_USER_SCREEN_RIGHT_BY_LOCATION_ID:
/* var _Result4 = (from oD in objDataContext.User_Screen_Right
where oD.Location_ID==Location_ID
orderby oD.UserRightsId descending
select new POCO.User_Screen_Right{UserRightsId = oD.UserRightsId,
UserGroupId = oD.UserGroupId,
ScreenId = oD.ScreenId,
ViewRights = oD.ViewRights,
AddRights = oD.AddRights,
EditRights = oD.EditRights,
DeleteRights = oD.DeleteRights,
ReportRights = oD.ReportRights,
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
case DomainMapper.GET_USER_SCREEN_RIGHT_BY_ID:
 var _Result1 = (from oD in objDataContext.User_Screen_Right
where oD.UserRightsId==UserRightsId
orderby oD.UserRightsId descending
select new POCO.User_Screen_Right{UserRightsId = oD.UserRightsId,
UserGroupId = oD.UserGroupId,
ScreenId = oD.ScreenId,
ViewRights = oD.ViewRights,
AddRights = oD.AddRights,
EditRights = oD.EditRights,
DeleteRights = oD.DeleteRights,
ReportRights = oD.ReportRights,
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
case DomainMapper.GET_USER_SCREEN_RIGHT_BY_ID_DATA:
 var _Result3 = from oD in objDataContext.User_Screen_Right
where oD.UserRightsId==UserRightsId
orderby oD.UserRightsId descending
select new {oD.UserRightsId,oD.UserGroupId,oD.ScreenId,oD.ViewRights,oD.AddRights,oD.EditRights,oD.DeleteRights,oD.ReportRights,oD.Is_Active,oD.Created_Date,oD.Created_By,oD.Modified_Date,oD.Modified_By,oD.Audit_Id,oD.User_IP,oD.Site_Id };
ArrayList objList = new ArrayList();
User_Screen_Right objUser_Screen_Right;
foreach (var objUse1 in _Result3)
 {
objUser_Screen_Right = new User_Screen_Right();
objUser_Screen_Right.UserRightsId = objUse1.UserRightsId;
objUser_Screen_Right.UserGroupId = objUse1.UserGroupId;
objUser_Screen_Right.ScreenId = objUse1.ScreenId;
objUser_Screen_Right.ViewRights = objUse1.ViewRights;
objUser_Screen_Right.AddRights = objUse1.AddRights;
objUser_Screen_Right.EditRights = objUse1.EditRights;
objUser_Screen_Right.DeleteRights = objUse1.DeleteRights;
objUser_Screen_Right.ReportRights = objUse1.ReportRights;
objUser_Screen_Right.Is_Active = objUse1.Is_Active;
objUser_Screen_Right.Created_Date = objUse1.Created_Date;
objUser_Screen_Right.Created_By = objUse1.Created_By;
objUser_Screen_Right.Modified_Date = objUse1.Modified_Date;
objUser_Screen_Right.Modified_By = objUse1.Modified_By;
objUser_Screen_Right.Audit_Id = objUse1.Audit_Id;
objUser_Screen_Right.User_IP = objUse1.User_IP;
objUser_Screen_Right.Site_Id = objUse1.Site_Id;
objList.Add(objUser_Screen_Right);
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
User_Screen_Right objEntity = Entity.ConvertUser_Screen_Right();
objDataContext.User_Screen_Right.Attach(objEntity);
objDataContext.User_Screen_Right.Remove(objEntity);
}
#endregion
}
}
/*****************************************************************************************************************/

