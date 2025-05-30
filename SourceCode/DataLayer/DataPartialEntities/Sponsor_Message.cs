/*****************************************************************************************************************
Author: Code generated by Shinersoft Code Plumber 2008.
Date: Thursday, April 24, 2025
Time: 10:42:00 AM
TableName: Sponsor_Message
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
public partial class Sponsor_Message: DataBase,IData
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
Message_Id=Entity[EntityMapper.Sponsor_Message.MESSAGE_ID].ConvertInteger();
Location_ID=Entity[EntityMapper.Sponsor_Message.LOCATION_ID].ConvertInteger();
Sponsor_Name=Entity[EntityMapper.Sponsor_Message.SPONSOR_NAME].ConvertString();
Language_Code=Entity[EntityMapper.Sponsor_Message.LANGUAGE_CODE].ConvertString();
Message_Text=Entity[EntityMapper.Sponsor_Message.MESSAGE_TEXT].ConvertString();
Placement_Context=Entity[EntityMapper.Sponsor_Message.PLACEMENT_CONTEXT].ConvertString();
Notes=Entity[EntityMapper.Sponsor_Message.NOTES].ConvertString();
Is_Active=Entity[EntityMapper.Sponsor_Message.IS_ACTIVE].ConvertByte();
Created_Date=Entity[EntityMapper.Sponsor_Message.CREATED_DATE].ConvertDateTime();
Created_By=Entity[EntityMapper.Sponsor_Message.CREATED_BY].ConvertInteger();
Modified_Date=Entity[EntityMapper.Sponsor_Message.MODIFIED_DATE].ConvertDateTime();
Modified_By=Entity[EntityMapper.Sponsor_Message.MODIFIED_BY].ConvertInteger();
Audit_Id=Entity[EntityMapper.Sponsor_Message.AUDIT_ID].ConvertLong();
User_IP=Entity[EntityMapper.Sponsor_Message.USER_IP].ConvertString();
Site_Id=Entity[EntityMapper.Sponsor_Message.SITE_ID].ConvertInteger();
}
void IData.InsertOnSubmit(DALEntities objDataContext, IData Entity)
{
objDataContext.Sponsor_Message.Add(Entity.ConvertSponsor_Message());
}
void IData.UpdateOnSubmit(DALEntities objDataContext, IData Entity)
{
Sponsor_Message objEntity = Entity.ConvertSponsor_Message();
objDataContext.Sponsor_Message.Attach(objEntity);
}
public IList SelectEntity(DALEntities objDataContext, string Behaviour)
{
try
 {
switch(Behaviour.ToString())
 {
 case DomainMapper.GET_SPONSOR_MESSAGES_DATA:
  var _Result2 = objDataContext.Sponsor_Message.Select(j =>
new {Message_Id = j.Message_Id,
Location_ID = j.Location_ID,
Sponsor_Name = j.Sponsor_Name,
Language_Code = j.Language_Code,
Message_Text = j.Message_Text,
Placement_Context = j.Placement_Context,
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
 case DomainMapper.GET_SPONSOR_MESSAGES:
  var _Result = objDataContext.Sponsor_Message.Select(j =>
new POCO.Sponsor_Message{Message_Id = j.Message_Id,
Location_ID = j.Location_ID,
Sponsor_Name = j.Sponsor_Name,
Language_Code = j.Language_Code,
Message_Text = j.Message_Text,
Placement_Context = j.Placement_Context,
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
case DomainMapper.GET_SPONSOR_MESSAGE_BY_LOCATION_ID:
/* var _Result4 = (from oD in objDataContext.Sponsor_Message
where oD.Location_ID==Location_ID
orderby oD.Message_Id descending
select new POCO.Sponsor_Message{Message_Id = oD.Message_Id,
Location_ID = oD.Location_ID,
Sponsor_Name = oD.Sponsor_Name,
Language_Code = oD.Language_Code,
Message_Text = oD.Message_Text,
Placement_Context = oD.Placement_Context,
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
case DomainMapper.GET_SPONSOR_MESSAGE_BY_ID:
 var _Result1 = (from oD in objDataContext.Sponsor_Message
where oD.Message_Id==Message_Id
orderby oD.Message_Id descending
select new POCO.Sponsor_Message{Message_Id = oD.Message_Id,
Location_ID = oD.Location_ID,
Sponsor_Name = oD.Sponsor_Name,
Language_Code = oD.Language_Code,
Message_Text = oD.Message_Text,
Placement_Context = oD.Placement_Context,
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
case DomainMapper.GET_SPONSOR_MESSAGE_BY_ID_DATA:
 var _Result3 = from oD in objDataContext.Sponsor_Message
where oD.Message_Id==Message_Id
orderby oD.Message_Id descending
select new {oD.Message_Id,oD.Location_ID,oD.Sponsor_Name,oD.Language_Code,oD.Message_Text,oD.Placement_Context,oD.Notes,oD.Is_Active,oD.Created_Date,oD.Created_By,oD.Modified_Date,oD.Modified_By,oD.Audit_Id,oD.User_IP,oD.Site_Id };
ArrayList objList = new ArrayList();
Sponsor_Message objSponsor_Message;
foreach (var objSpo1 in _Result3)
 {
objSponsor_Message = new Sponsor_Message();
objSponsor_Message.Message_Id = objSpo1.Message_Id;
objSponsor_Message.Location_ID = objSpo1.Location_ID;
objSponsor_Message.Sponsor_Name = objSpo1.Sponsor_Name;
objSponsor_Message.Language_Code = objSpo1.Language_Code;
objSponsor_Message.Message_Text = objSpo1.Message_Text;
objSponsor_Message.Placement_Context = objSpo1.Placement_Context;
objSponsor_Message.Notes = objSpo1.Notes;
objSponsor_Message.Is_Active = objSpo1.Is_Active;
objSponsor_Message.Created_Date = objSpo1.Created_Date;
objSponsor_Message.Created_By = objSpo1.Created_By;
objSponsor_Message.Modified_Date = objSpo1.Modified_Date;
objSponsor_Message.Modified_By = objSpo1.Modified_By;
objSponsor_Message.Audit_Id = objSpo1.Audit_Id;
objSponsor_Message.User_IP = objSpo1.User_IP;
objSponsor_Message.Site_Id = objSpo1.Site_Id;
objList.Add(objSponsor_Message);
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
Sponsor_Message objEntity = Entity.ConvertSponsor_Message();
objDataContext.Sponsor_Message.Attach(objEntity);
objDataContext.Sponsor_Message.Remove(objEntity);
}
#endregion
}
}
/*****************************************************************************************************************/

