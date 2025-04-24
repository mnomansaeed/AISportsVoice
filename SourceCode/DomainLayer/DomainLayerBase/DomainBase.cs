using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Collections;
using Utility;
using TransactionLayer;
using DataLayer;

/// <summary>
/// Summary description for DomainBase
/// </summary>

namespace DomainLayer
{

    public class DomainBase
    {
        #region Private Members
        private IData CreateSelectEntity(string className)
        {
            try
            {


                Creator objCreate = new DataFactory();

                return objCreate.CreateDataLayerObject(className);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected IData CreateEntity(string className)
        {
            try
            {
                IData _tempData;

                Creator objCreate = new DataFactory();

                _tempData = objCreate.CreateDataLayerObject(className);

                _tempData.Fill(_Record);

                return _tempData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Protected Members
        protected Int32 _ID;
        protected string _StringID;
        protected Hashtable _Record;
        protected TransactionContext _TransactionContext;
        protected IData _TempEntity = null;
        protected IQueryable _TempQueryObject = null;
        protected IList _Result = null;
        protected Stack _EntityStack = null;
        protected static Int64 _Count = 0;


        protected void Field<T, K>(T Key, K Value)
        {
            try
            {
                _Record.Add(Key, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void AddEntity(IData Entity)
        {
            try
            {
                if (_EntityStack.Count <= 0)
                {
                    _EntityStack.Push(Entity);
                }
                else
                {
                    _TempEntity = Entity;
                    _EntityStack.Peek().ConvertIData().AddChild(_TempEntity);
                    _EntityStack.Push(_TempEntity);
                }

                _Record = new Hashtable();
                _Count = _Count + 1;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void AddEntity(string EntityName)
        {
            try
            {
                if (_EntityStack.Count <= 0)
                {
                    _EntityStack.Push(CreateEntity(EntityName));
                }
                else
                {
                    _TempEntity = CreateEntity(EntityName);
                    _EntityStack.Peek().ConvertIData().AddChild(_TempEntity);
                    _EntityStack.Push(_TempEntity);
                }

                _Record = new Hashtable();
                _Count = _Count + 1;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void AddDelEntity(IData Entity)
        {
            try
            {
                _TransactionContext.AddEntity(Entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void AddAJAXRecord(string EntityName, Hashtable Entity)
        {
            try
            {
                try
                {
                    if (_EntityStack.Count <= 0)
                    {
                        IData _TempEntity1 = CreateSelectEntity(EntityName);
                        _TempEntity1.Fill(Entity);
                        _EntityStack.Push(_TempEntity1);
                    }
                    else
                    {
                        _TempEntity = CreateSelectEntity(EntityName);
                        _TempEntity.Fill(Entity);
                        _EntityStack.Peek().ConvertIData().AddChild(_TempEntity);
                        _EntityStack.Push(_TempEntity);
                    }

                    _Record = new Hashtable();
                    _Count = _Count + 1;

                }
                catch (Exception ex)
                {
                    throw ex;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void AddHASHRecord(string EntityName, Hashtable Entity)
        {
            try
            {
                try
                {
                    if (_EntityStack.Count <= 0)
                    {
                        IData _TempEntity1 = CreateSelectEntity(EntityName);
                        _TempEntity1.Fill(Entity);
                        _EntityStack.Push(_TempEntity1);
                    }
                    else
                    {
                        _TempEntity = CreateSelectEntity(EntityName);
                        _TempEntity.Fill(Entity);
                        _EntityStack.Peek().ConvertIData().AddChild(_TempEntity);
                        _EntityStack.Push(_TempEntity);
                    }

                    _Record = new Hashtable();
                    _Count = _Count + 1;

                }
                catch (Exception ex)
                {
                    throw ex;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void SubmitRecord()
        {
            try
            {
                _TransactionContext.AddEntity(_EntityStack.Pop().ConvertIData());
                _EntityStack.Clear();

                _TempEntity = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void AppendRecord()
        {
            try
            {
                _EntityStack.Pop();

                _TempEntity = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected IData GetEntity(string EntityName)
        {
            try
            {
                _TempEntity = CreateSelectEntity(EntityName);
                return _TempEntity;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        protected void RemoveTransaction()
        {
            try
            {
                _TransactionContext = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void SetTransaction(TransactionType TType)
        {
            try
            {
                switch (TType)
                {
                    case TransactionType.QUERY:
                        //  _TransactionContext = new TransactionContext(new INLINETransactionHandler());
                        break;
                    case TransactionType.STOREDPROCEDURE:
                        // _TransactionContext = new TransactionContext(new SPTransactionHandler());
                        break;
                    case TransactionType.LINQ:
                        _TransactionContext = new TransactionContext(new LINQTransactionHandler());
                        break;
                    case TransactionType.EF:
                        _TransactionContext = new TransactionContext(new EFTransactionHandler());
                        break;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        public int ID
        {
            get
            {
                return _ID;
            }
        }
        public string StringID
        {
            get
            {
                return _StringID;
            }
        }


        public DomainBase()
        {
            _Record = new Hashtable();
            _EntityStack = new Stack();
            _Count = 0;

        }
        ~DomainBase()
        {
            _Record = null;
            _TransactionContext = null;
            _Count = 0;
            _EntityStack = null;
            _TempEntity = null;
            _TempQueryObject = null;
            _Result = null;


        }
    }
}