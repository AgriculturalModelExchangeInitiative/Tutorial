
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using CRA.ModelLayer.MetadataTypes;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;
using System.Reflection;
using VarInfo=CRA.ModelLayer.Core.VarInfo;
using Preconditions=CRA.ModelLayer.Core.Preconditions;
using CRA.AgroManagement;       
using Snow.DomainClass;
namespace Snow.Strategies
{
    public class SnowDepth : IStrategySnow
    {
        public SnowDepth()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 0.0;
            v1.Description = "snow compaction parameter";
            v1.Id = 0;
            v1.MaxValue = ;
            v1.MinValue = ;
            v1.Name = "E";
            v1.Size = 1;
            v1.Units = "mm/mm/d";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = 100;
            v2.Description = "The density of the new snow fixed by the user";
            v2.Id = 0;
            v2.MaxValue = ;
            v2.MinValue = ;
            v2.Name = "rho";
            v2.Size = 1;
            v2.Units = "kg/m**3";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v2);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd1.PropertyName = "Snowmelt";
            pd1.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Snowmelt).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Snowmelt);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd2.PropertyName = "Sdepth";
            pd2.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Sdepth).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Sdepth);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(Snow.DomainClass.SnowRate);
            pd3.PropertyName = "Snowaccu";
            pd3.PropertyType = (Snow.DomainClass.SnowRateVarInfo.Snowaccu).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(Snow.DomainClass.SnowRateVarInfo.Snowaccu);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd4.PropertyName = "Sdepth";
            pd4.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Sdepth).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Sdepth);
            _outputs0_0.Add(pd4);
            mo0_0.Outputs=_outputs0_0;
            //Associated strategies
            List<string> lAssStrat0_0 = new List<string>();
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            //Adding the modeling options to the modeling options manager
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);
            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();

        }

        public string Description
        {
            get { return "snow cover depth Calculation" ;}
        }

        public string URL
        {
            get { return "" ;}
        }

        public string Domain
        {
            get { return "";}
        }

        public string ModelType
        {
            get { return "";}
        }

        public bool IsContext
        {
            get { return false;}
        }

        public IList<int> TimeStep
        {
            get
            {
                IList<int> ts = new List<int>();
                return ts;
            }
        }

        private  PublisherData _pd;
        public PublisherData PublisherData
        {
            get { return _pd;} 
        }

        private  void SetPublisherData()
        {
            _pd = new CRA.ModelLayer.MetadataTypes.PublisherData();
            _pd.Add("Creator", "STICS");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "INRA");
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(Snow.DomainClass.SnowState),  typeof(Snow.DomainClass.SnowState), typeof(Snow.DomainClass.SnowRate), typeof(Snow.DomainClass.SnowAuxiliary), typeof(Snow.DomainClass.SnowExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double E
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("E");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'E' not found (or found null) in strategy 'SnowDepth'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("E");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'E' not found in strategy 'SnowDepth'");
            }
        }
        public double rho
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("rho");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'rho' not found (or found null) in strategy 'SnowDepth'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("rho");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'rho' not found in strategy 'SnowDepth'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            EVarInfo.Name = "E";
            EVarInfo.Description = "snow compaction parameter";
            EVarInfo.MaxValue = ;
            EVarInfo.MinValue = ;
            EVarInfo.DefaultValue = 0.0;
            EVarInfo.Units = "mm/mm/d";
            EVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            rhoVarInfo.Name = "rho";
            rhoVarInfo.Description = "The density of the new snow fixed by the user";
            rhoVarInfo.MaxValue = ;
            rhoVarInfo.MinValue = ;
            rhoVarInfo.DefaultValue = 100;
            rhoVarInfo.Units = "kg/m**3";
            rhoVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _EVarInfo = new VarInfo();
        public static VarInfo EVarInfo
        {
            get { return _EVarInfo;} 
        }

        private static VarInfo _rhoVarInfo = new VarInfo();
        public static VarInfo rhoVarInfo
        {
            get { return _rhoVarInfo;} 
        }

        public string TestPostConditions(Snow.DomainClass.SnowState s,Snow.DomainClass.SnowState s1,Snow.DomainClass.SnowRate r,Snow.DomainClass.SnowAuxiliary a,Snow.DomainClass.SnowExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                Snow.DomainClass.SnowStateVarInfo.Sdepth.CurrentValue=s.Sdepth;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r6 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Sdepth);
                if(r6.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Sdepth.ValueType)){prc.AddCondition(r6);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".Snow, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(Snow.DomainClass.SnowState s,Snow.DomainClass.SnowState s1,Snow.DomainClass.SnowRate r,Snow.DomainClass.SnowAuxiliary a,Snow.DomainClass.SnowExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                Snow.DomainClass.SnowStateVarInfo.Snowmelt.CurrentValue=s.Snowmelt;
                Snow.DomainClass.SnowStateVarInfo.Sdepth.CurrentValue=s.Sdepth;
                Snow.DomainClass.SnowRateVarInfo.Snowaccu.CurrentValue=r.Snowaccu;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Snowmelt);
                if(r1.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Snowmelt.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Sdepth);
                if(r2.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Sdepth.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(Snow.DomainClass.SnowRateVarInfo.Snowaccu);
                if(r3.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowRateVarInfo.Snowaccu.ValueType)){prc.AddCondition(r3);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("E")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("rho")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".Snow, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(Snow.DomainClass.SnowState s,Snow.DomainClass.SnowState s1,Snow.DomainClass.SnowRate r,Snow.DomainClass.SnowAuxiliary a,Snow.DomainClass.SnowExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component Snow, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(Snow.DomainClass.SnowState s, Snow.DomainClass.SnowState s1, Snow.DomainClass.SnowRate r, Snow.DomainClass.SnowAuxiliary a, Snow.DomainClass.SnowExogenous ex)
        {
            double Snowmelt = s.Snowmelt;
            double Sdepth_t1 = s1.Sdepth;
            double Snowaccu = r.Snowaccu;
            double Sdepth;
            Sdepth = 0.0d;
            if (Snowmelt <= Sdepth_t1 + (Snowaccu / rho))
            {
                Sdepth = Snowaccu / rho + Sdepth_t1 - Snowmelt - (Sdepth_t1 * E);
            }
            s.Sdepth= Sdepth;
        }

    }
}