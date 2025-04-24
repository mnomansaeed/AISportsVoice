using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using DataLayer;
using Utility; 

/// <summary>
/// Summary description for TransactionContext
/// </summary>
namespace TransactionLayer
{

    public class TransactionContext
    {
        protected TransactionHandler _TransactionHandler;

        public IData getEntity
        {
            get
            {
                return _TransactionHandler.getEntity;
            }

        }
        public TransactionContext(TransactionHandler TransHandler)
        {
            this._TransactionHandler = TransHandler;
        }

        public void SubmitChanges(Operations Operation, UseTransaction IsTransaction)
        {
            this._TransactionHandler.SubmitChanges(Operation,IsTransaction); 
        }
        public void AddEntity(IData Entity)
        {
            this._TransactionHandler.AddEntity(Entity);
        }
        public IList Load(IData Entity, string Behaviour)
        {
             return this._TransactionHandler.Load(Entity,Behaviour);
        }
    }
}