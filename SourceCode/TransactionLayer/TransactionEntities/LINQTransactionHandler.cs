using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using DataLayer;
using Utility;
using System.Transactions;
/// <summary>
/// Summary description for LINQTransactionHandler
/// </summary>
namespace TransactionLayer
{
    public class LINQTransactionHandler : TransactionHandler
    {

        #region Private Members

        private void Insert(UseTransaction IsTransaction)
        {
            try
            {
                for (int iLoop = 0; iLoop < _Entities.Count; iLoop++)
                {
                    _Entity = _Entities[iLoop].ConvertIData();
                  //  _Entity.InsertOnSubmit(_DALDataContext, _Entity);
                }

                if (IsTransaction == UseTransaction.YES)
                {
                    using (TransactionScope objTransaction = new TransactionScope())
                    {
                     //   _DALDataContext.SubmitChanges();

                        objTransaction.Complete();
                    }
                }
                else
                {
                   // _DALDataContext.SubmitChanges();
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                _Entities.Clear();
            }
        }
        private void Update(UseTransaction IsTransaction)
        {
            try
            {
                for (int iLoop = 0; iLoop < _Entities.Count; iLoop++)
                {
                    _Entity = _Entities[iLoop].ConvertIData();
                  //  _Entity.UpdateOnSubmit(_DALDataContext, _Entity);
                   // _DALDataContext.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, _Entity);
                }

                if (IsTransaction == UseTransaction.YES)
                {
                    using (TransactionScope objTransaction = new TransactionScope())
                    {
                       // _DALDataContext.SubmitChanges();

                        objTransaction.Complete();
                    }
                }
                else
                {
                    //_DALDataContext.SubmitChanges();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                _Entities.Clear();
            }

        }

        private void UpdateCurrentContext(UseTransaction IsTransaction)
        {
            try
            {
                //_DALDataContext.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, _Entity);


                if (IsTransaction == UseTransaction.YES)
                {
                    using (TransactionScope objTransaction = new TransactionScope())
                    {
                       // _DALDataContext.SubmitChanges();

                        objTransaction.Complete();
                    }
                }
                else
                {
                   // _DALDataContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {


            }

        }
        private void Delete(UseTransaction IsTransaction)
        {
            try
            {
                for (int iLoop = 0; iLoop < _Entities.Count; iLoop++)
                {
                    _Entity = _Entities[iLoop].ConvertIData();
                  //  _Entity.DeleteOnSubmit(_DALDataContext, _Entity);

                }
                //below line included because of removing changeconflict exception
               // _DALDataContext.Refresh(System.Data.Linq.RefreshMode.KeepChanges, _Entities);
                if (IsTransaction == UseTransaction.YES)
                {
                    using (TransactionScope objTransaction = new TransactionScope())
                    {
                       // _DALDataContext.SubmitChanges();

                        objTransaction.Complete();
                    }
                }
                else
                {

                    //_DALDataContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                _Entities.Clear();
            }
        }
        #endregion

        #region Public Members
        public LINQTransactionHandler()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public override void SubmitChanges(Operations Operation, UseTransaction IsTransaction)
        {
            switch (Operation)
            {
                case Operations.INSERT:
                    Insert(IsTransaction);
                    break;
                case Operations.UPDATE:
                    Update(IsTransaction);
                    break;
                case Operations.UPDATE_CURRENT_CONTEXT:
                    UpdateCurrentContext(IsTransaction);
                    break;
                case Operations.DELETE:
                    Delete(IsTransaction);
                    break;
            }

        }

        public override void AddEntity(IData Entity)
        {
            _Entities.Add(Entity);
        }

        public override IList Load(IData Entity, string Behaviour)
        {
            try
            {
                // return Entity.SelectEntity(_DALDataContext, Behaviour);
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _Entities.Clear();
            }
        }
        #endregion


    }
}