using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Reflection;
using DataLayer;
/// <summary>
/// Summary description for Creator
/// </summary>
namespace DomainLayer

{
    public abstract class Creator
    {
        #region Protected Members
            protected Assembly _assembly;
            protected Type _targetType;
            protected Type[] _types;

            protected void LoadClass(string className,string AssemblyName)
            {
                try
                {
                    _assembly=Assembly.Load(AssemblyName);
                    _targetType = _assembly.GetType(className, false, false);

                    if (_targetType == null)
                        throw new ArgumentException("Can't instantiate type " + className);
                    // get the default constructor and instantiate
                    _types = new Type[0];

                    _ConstructorInfo = _targetType.GetConstructor(_types);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                

            }
        #endregion
        
        protected ConstructorInfo _ConstructorInfo; 
        public virtual IDomain CreateDomainLayerObject(string className) { return null; }
        public virtual IData CreateDataLayerObject(string className) { return null; }
    }
}