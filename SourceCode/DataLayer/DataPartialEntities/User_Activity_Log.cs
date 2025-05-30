/*****************************************************************************************************************
Author: Code generated by Shinersoft Code Plumber 2008.
Date: Thursday, April 24, 2025
Time: 10:42:00 AM
TableName: User_Activity_Log
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
public partial class User_Activity_Log: DataBase,IData
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
Log_Id=Entity[EntityMapper.User_Activity_Log.LOG_ID].ConvertLong();
Location_ID=Entity[EntityMapper.User_Activity_Log.LOCATION_ID].ConvertInteger();
User_Id=Entity[EntityMapper.User_Activity_Log.USER_ID].ConvertInteger();
Activity_Type=Entity[EntityMapper.User_Activity_Log.ACTIVITY_TYPE].ConvertString();
Activity_Timestamp=Entity[EntityMapper.User_Activity_Log.ACTIVITY_TIMESTAMP].ConvertDateTime();
Additional_Data=Entity[EntityMapper.User_Activity_Log.ADDITIONAL_DATA].ConvertString();
Notes=Entity[EntityMapper.User_Activity_Log.NOTES].ConvertString();
Is_Active=Entity[EntityMapper.User_Activity_Log.IS_ACTIVE].ConvertByte();
Created_Date=Entity[EntityMapper.User_Activity_Log.CREATED_DATE].ConvertDateTime();
Created_By=Entity[EntityMapper.User_Activity_Log.CREATED_BY].ConvertInteger();
Modified_Date=Entity[EntityMapper.User_Activity_Log.MODIFIED_DATE].ConvertDateTime();
Modified_By=Entity[EntityMapper.User_Activity_Log.MODIFIED_BY].ConvertInteger();
Audit_Id=Entity[EntityMapper.User_Activity_Log.AUDIT_ID].ConvertLong();
User_IP=Entity[EntityMapper.User_Activity_Log.USER_IP].ConvertString();
Site_Id=Entity[EntityMapper.User_Activity_Log.SITE_ID].ConvertInteger();
}
void IData.InsertOnSubmit(DALEntities objDataContext, IData Entity)
{
objDataContext.User_Activity_Log.Add(Entity.ConvertUser_Activity_Log());
}
void IData.UpdateOnSubmit(DALEntities objDataContext, IData Entity)
{
User_Activity_Log objEntity = Entity.ConvertUser_Activity_Log();
objDataContext.User_Activity_Log.Attach(objEntity);
}
public IList SelectEntity(DALEntities objDataContext, string Behaviour)
{
try
 {
switch(Behaviour.ToString())
 {
 case DomainMapper.GET_USER_ACTIVITY_LOGS_DATA:
  var _Result2 = objDataContext.User_Activity_Log.Select(j =>
new {Log_Id = j.Log_Id,
Location_ID = j.Location_ID,
User_Id = j.User_Id,
Activity_Type = j.Activity_Type,
Activity_Timestamp = j.Activity_Timestamp,
Additional_Data = j.Additional_Data,
Notes = j.Notes,
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
 case DomainMapper.GET_USER_ACTIVITY_LOGS:
  var _Result = objDataContext.User_Activity_Log.Select(j =>
new POCO.User_Activity_Log{Log_Id = j.Log_Id,
Location_ID = j.Location_ID,
User_Id = j.User_Id,
Activity_Type = j.Activity_Type,
Activity_Timestamp = j.Activity_Timestamp,
Additional_Data = j.Additional_Data,
Notes = j.Notes,
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
case DomainMapper.GET_USER_ACTIVITY_LOG_BY_LOCATION_ID:
/* var _Result4 = (from oD in objDataContext.User_Activity_Log
where oD.Location_ID==Location_ID
orderby oD.Log_Id descending
select new POCO.User_Activity_Log{Log_Id = oD.Log_Id,
Location_ID = oD.Location_ID,
User_Id = oD.User_Id,
Activity_Type = oD.Activity_Type,
Activity_Timestamp = oD.Activity_Timestamp,
Additional_Data = oD.Additional_Data,
Notes = oD.Notes,
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
case DomainMapper.GET_USER_ACTIVITY_LOG_BY_ID:
 var _Result1 = (from oD in objDataContext.User_Activity_Log
where oD.Log_Id==Log_Id
orderby oD.Log_Id descending
select new POCO.User_Activity_Log{Log_Id = oD.Log_Id,
Location_ID = oD.Location_ID,
User_Id = oD.User_Id,
Activity_Type = oD.Activity_Type,
Activity_Timestamp = oD.Activity_Timestamp,
Additional_Data = oD.Additional_Data,
Notes = oD.Notes,
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
case DomainMapper.GET_USER_ACTIVITY_LOG_BY_ID_DATA:
 var _Result3 = from oD in objDataContext.User_Activity_Log
where oD.Log_Id==Log_Id
orderby oD.Log_Id descending
select new {oD.Log_Id,oD.Location_ID,oD.User_Id,oD.Activity_Type,oD.Activity_Timestamp,oD.Additional_Data,oD.Notes,oD.Is_Active,oD.Created_Date,oD.Created_By,oD.Modified_Date,oD.Modified_By,oD.Audit_Id,oD.User_IP,oD.Site_Id };
ArrayList objList = new ArrayList();
User_Activity_Log objUser_Activity_Log;
foreach (var objUse1 in _Result3)
 {
objUser_Activity_Log = new User_Activity_Log();
objUser_Activity_Log.Log_Id = objUse1.Log_Id;
objUser_Activity_Log.Location_ID = objUse1.Location_ID;
objUser_Activity_Log.User_Id = objUse1.User_Id;
objUser_Activity_Log.Activity_Type = objUse1.Activity_Type;
objUser_Activity_Log.Activity_Timestamp = objUse1.Activity_Timestamp;
objUser_Activity_Log.Additional_Data = objUse1.Additional_Data;
objUser_Activity_Log.Notes = objUse1.Notes;
objUser_Activity_Log.Is_Active = objUse1.Is_Active;
objUser_Activity_Log.Created_Date = objUse1.Created_Date;
objUser_Activity_Log.Created_By = objUse1.Created_By;
objUser_Activity_Log.Modified_Date = objUse1.Modified_Date;
objUser_Activity_Log.Modified_By = objUse1.Modified_By;
objUser_Activity_Log.Audit_Id = objUse1.Audit_Id;
objUser_Activity_Log.User_IP = objUse1.User_IP;
objUser_Activity_Log.Site_Id = objUse1.Site_Id;
objList.Add(objUser_Activity_Log);
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
User_Activity_Log objEntity = Entity.ConvertUser_Activity_Log();
objDataContext.User_Activity_Log.Attach(objEntity);
objDataContext.User_Activity_Log.Remove(objEntity);
}
#endregion
}
}
/*****************************************************************************************************************/

