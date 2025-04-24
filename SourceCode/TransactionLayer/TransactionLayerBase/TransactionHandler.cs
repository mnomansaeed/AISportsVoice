using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using DataLayer;
using Utility; 

/// <summary>
/// Summary description for ITransaction
/// </summary>

namespace TransactionLayer
{
    public abstract class TransactionHandler
    {

        protected ArrayList _Entities;
        protected IData _Entity;
        protected IDbCommand _Command;
      //  protected DALDataContext _DALDataContext;
        protected DALEntities _DALEntities;
        public IData getEntity
        {
            get
            {
                return _Entity;
            }
          
        }
        public TransactionHandler()
        {
            _Entities = new ArrayList();
           // _DALDataContext = new DALDataContext();
            _DALEntities = new DALEntities();

        }
        ~TransactionHandler()
        {
            _Entities = null;
           // _DALDataContext = null;
            _DALEntities = null;
        }

        public abstract void AddEntity(IData Entity);

        public abstract IList Load(IData Entity, string Behaviour);
        
        public abstract void SubmitChanges(Operations Operation, UseTransaction IsTransaction);


      
    }
}