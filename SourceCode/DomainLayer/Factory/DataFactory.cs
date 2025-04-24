using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Reflection;
using DataLayer; 

/// <summary>
/// Summary description for DataFactory
/// </summary>
namespace DomainLayer
{
    public class DataFactory : Creator
    {
        public DataFactory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public override IData CreateDataLayerObject(string className)
        {
            try
            {
                base.LoadClass(className, "DataLayer"); 
                IData targetObject = (IData)_ConstructorInfo.Invoke(null);
                if( targetObject == null )
                throw new ArgumentException("Can't instantiate type " + className);

                return targetObject;
               

            }
            
            catch (Exception ex)
            {
                throw ex;
            }
            

            
        }

      
    }
}