using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Collections; 
using DataLayer;
using Utility;
using System.Transactions;
using System.Data.Entity;

/// <summary>
/// Summary description for EFTransactionHandler
/// </summary>
namespace TransactionLayer
{
    public class EFTransactionHandler : TransactionHandler 
    {
       
        #region Private Members
        
            private void Insert(UseTransaction IsTransaction)
            {
                try
                {
                    for (int iLoop = 0; iLoop < _Entities.Count; iLoop++)
                    {
                        _Entity = _Entities[iLoop].ConvertIData();
                        _Entity.InsertOnSubmit(_DALEntities, _Entity);
                    }

                    if (IsTransaction == UseTransaction.YES)
                    {
                        using (TransactionScope objTransaction = new TransactionScope())
                        {
                        _DALEntities.SaveChanges();

                            objTransaction.Complete();
                        }
                    }
                    else
                    {
                    _DALEntities.SaveChanges();
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
                        _Entity.UpdateOnSubmit(_DALEntities, _Entity);
                        _DALEntities.Entry(_Entity).State= EntityState.Modified;
                }

                if (IsTransaction == UseTransaction.YES)
                    {
                        using (TransactionScope objTransaction = new TransactionScope())
                        {
                        _DALEntities.SaveChanges();

                            objTransaction.Complete();
                        }
                    }
                    else
                    {
                    _DALEntities.SaveChanges();
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
                        _DALEntities.SaveChanges();

                            objTransaction.Complete();
                        }
                    }
                    else
                    {
                    _DALEntities.SaveChanges();
                    }           }
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
                       _Entity.DeleteOnSubmit(_DALEntities, _Entity);
                       
                   }
                   //below line included because of removing changeconflict exception
                  
                    if (IsTransaction == UseTransaction.YES)
                    {
                        using (TransactionScope objTransaction = new TransactionScope())
                        {
                        _DALEntities.SaveChanges();

                            objTransaction.Complete();
                        }
                    }
                    else
                    {

                    _DALEntities.SaveChanges();
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

        # region Public Members
            public EFTransactionHandler()
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
                   return Entity.SelectEntity(_DALEntities,Behaviour);
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