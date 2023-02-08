
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
    public class SnowDepthTrans : IStrategySnow
    {
        public SnowDepthTrans()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 100.0;
            v1.Description = "density of the new snow";
            v1.Id = 0;
            v1.MaxValue = ;
            v1.MinValue = ;
            v1.Name = "Pns";
            v1.Size = 1;
            v1.Units = "cm/m";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd1.PropertyName = "Sdepth";
            pd1.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Sdepth).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Sdepth);
            _inputs0_0.Add(pd1);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd2.PropertyName = "Sdepth_cm";
            pd2.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Sdepth_cm).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Sdepth_cm);
            _outputs0_0.Add(pd2);
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
            get { return "snow cover depth in cm" ;}
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

        public double Pns
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("Pns");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'Pns' not found (or found null) in strategy 'SnowDepthTrans'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("Pns");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'Pns' not found in strategy 'SnowDepthTrans'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            PnsVarInfo.Name = "Pns";
            PnsVarInfo.Description = "density of the new snow";
            PnsVarInfo.MaxValue = ;
            PnsVarInfo.MinValue = ;
            PnsVarInfo.DefaultValue = 100.0;
            PnsVarInfo.Units = "cm/m";
            PnsVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _PnsVarInfo = new VarInfo();
        public static VarInfo PnsVarInfo
        {
            get { return _PnsVarInfo;} 
        }

        public string TestPostConditions(Snow.DomainClass.SnowState s,Snow.DomainClass.SnowState s1,Snow.DomainClass.SnowRate r,Snow.DomainClass.SnowAuxiliary a,Snow.DomainClass.SnowExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                Snow.DomainClass.SnowStateVarInfo.Sdepth_cm.CurrentValue=s.Sdepth_cm;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r3 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Sdepth_cm);
                if(r3.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Sdepth_cm.ValueType)){prc.AddCondition(r3);}
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
                Snow.DomainClass.SnowStateVarInfo.Sdepth.CurrentValue=s.Sdepth;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Sdepth);
                if(r1.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Sdepth.ValueType)){prc.AddCondition(r1);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Pns")));
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
            double Sdepth = s.Sdepth;
            double Sdepth_cm;
            Sdepth_cm = Sdepth * Pns;
            s.Sdepth_cm= Sdepth_cm;
        }

    }
}