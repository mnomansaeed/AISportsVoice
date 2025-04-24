using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using TransactionLayer;
using Utility; 

/// <summary>
/// Summary description for DomainContext
/// </summary>
namespace DomainLayer
{
    public class DomainContext
    {
        
        private IDomain _Domain;
        public DomainContext()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ~DomainContext()
        {
            this._Domain = null;
        }
        public IDomain BusinessObject
        {
            get
            {
                return _Domain;
            }
        }
        public DomainContext(IDomain Domain)
        {
            this._Domain = Domain;
        }
        public void AddField<T, K>(T Key, K Value)
        {
            this._Domain.AddField(Key, Value);
        }
        public void AddDeleteEntity(DataLayer.IData Entity)
        {
            this._Domain.AddDeleteEntity(Entity);
        }
        public void AddRecord(string EntityName)
        {
            this._Domain.AddRecord(EntityName);
        }
        public void AddHASHEntity(string EntityName, Hashtable Entity)
        {
            this._Domain.AddHASHEntity(EntityName, Entity);
        }
        public void AddAJAXEntity(string EntityName, Hashtable Entity)
        {
            this._Domain.AddAJAXEntity(EntityName, Entity);
        }
        public void Submit()
        {
            this._Domain.Submit();
        }
        public void Append()
        {
            this._Domain.Append();
        }

        public void Insert(UseTransaction IsTransaction)
        {
            this._Domain.Insert(IsTransaction);
        }
        public void Update(UseTransaction IsTransaction)
        {
            this._Domain.Update(IsTransaction);
        }
        public void Delete(UseTransaction IsTransaction)
        {
            this._Domain.Delete(IsTransaction);
        }
        public void UpdateCurrentContext(UseTransaction IsTransaction)
        {
            this._Domain.UpdateCurrentContext(IsTransaction);
        }
        public IList Load(string EntityName, string Behaviour)
        {
             return this._Domain.Load(EntityName, Behaviour);
        }
    }
}