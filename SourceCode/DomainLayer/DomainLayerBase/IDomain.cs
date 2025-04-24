using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TransactionLayer;
using Utility;
/// <summary>
/// Summary description for IDomain
/// </summary>
namespace DomainLayer
{
    public interface IDomain
    {

        void AddField<T, K>(T Key, K Value);

        void AddRecord(string EntityName);

        void AddDeleteEntity(DataLayer.IData Entity);
        
        void AddAJAXEntity(string EntityName, Hashtable Entity);


        void AddHASHEntity(string EntityName, Hashtable Entity);
            
        void Append();

        void Submit();

        void Insert(UseTransaction IsTransaction);

        void Update(UseTransaction IsTransaction);

        void Delete(UseTransaction IsTransaction);

        void UpdateCurrentContext(UseTransaction IsTransaction);

       // void UpdateQuery(UseTransaction IsTransaction);

        IList Load(string EntityName, string Behaviour);

        IList DataList
        {
            get;
        }


    }

}