using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using DataLayer;

/// <summary>
/// Summary description for IData
/// </summary>
namespace DataLayer
{
    public interface IData
    {

        string InsertQuery();

        string UpdateQuery();

        string DeleteQuery();

        string SelectQuery();

        string SelectAllQuery();

        IDbCommand InsertSP();

        IDbCommand UpdateSP();

        IDbCommand DeleteSP();

        IDbCommand SelectSP();

        IDbCommand SelectAllSP();

        void Fill(Hashtable Entity);

        void AddChild(IData childEntity);

        //void DeleteOnSubmit(DALDataContext objDataContext, IData Entity);

        //void InsertOnSubmit(DALDataContext objDataContext, IData Entity);

        //void UpdateOnSubmit(DALDataContext objDataContext, IData Entity);

        //IList SelectEntity(DALDataContext objDataContext, string Behaviour);

        void DeleteOnSubmit(DALEntities objDataContext, IData Entity);

        void InsertOnSubmit(DALEntities objDataContext, IData Entity);

        void UpdateOnSubmit(DALEntities objDataContext, IData Entity);

        IList SelectEntity(DALEntities objDataContext, string Behaviour);


    }

}
