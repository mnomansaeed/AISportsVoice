using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Reflection; 

/// <summary>
/// Summary description for DomainFactory
/// </summary>
namespace DomainLayer
{
    public class DomainFactory:Creator 
    {
        public DomainFactory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

      

        public override IDomain CreateDomainLayerObject(string className)
        {
            try
            {
                base.LoadClass(className, "DomainAssembly");

                IDomain targetObject = (IDomain)_ConstructorInfo.Invoke(null);
                if (targetObject == null)
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
