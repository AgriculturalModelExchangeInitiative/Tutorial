
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace Snow.DomainClass
{
    public class SnowExogenous : ICloneable, IDomainClass
    {
        private ParametersIO _parametersIO;

        public SnowExogenous()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SnowExogenous(SnowExogenous toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
            }
        }

        public string Description
        {
            get { return "SnowExogenous of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public virtual IDictionary<string, PropertyInfo> PropertiesDescription
        {
            get { return _parametersIO.GetCachedProperties(typeof(IDomainClass));}
        }

        public virtual Boolean ClearValues()
        {
            return true;
        }

        public virtual Object Clone()
        {
            IDomainClass myclass = (IDomainClass) this.MemberwiseClone();
            _parametersIO.PopulateClonedCopy(myclass);
            return myclass;
        }
    }
}