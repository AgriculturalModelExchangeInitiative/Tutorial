
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace Snow.DomainClass
{
    public class SnowRate : ICloneable, IDomainClass
    {
        private double _M;
        private double _Snowaccu;
        private double _Mrf;
        private ParametersIO _parametersIO;

        public SnowRate()
        {
            _parametersIO = new ParametersIO(this);
        }

        public SnowRate(SnowRate toCopy, bool copyAll) // copy constructor 
        {
            if (copyAll)
            {
                _M = toCopy._M;
                _Snowaccu = toCopy._Snowaccu;
                _Mrf = toCopy._Mrf;
            }
        }

        public double M
        {
            get { return this._M; }
            set { this._M= value; } 
        }
        public double Snowaccu
        {
            get { return this._Snowaccu; }
            set { this._Snowaccu= value; } 
        }
        public double Mrf
        {
            get { return this._Mrf; }
            set { this._Mrf= value; } 
        }

        public string Description
        {
            get { return "SnowRate of the component";}
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
             _M = default(double);
             _Snowaccu = default(double);
             _Mrf = default(double);
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