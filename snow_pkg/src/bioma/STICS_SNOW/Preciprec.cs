
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
    public class Preciprec : IStrategySnow
    {
        public Preciprec()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 100;
            v1.Description = "The density of the new snow fixed by the user";
            v1.Id = 0;
            v1.MaxValue = ;
            v1.MinValue = ;
            v1.Name = "rho";
            v1.Size = 1;
            v1.Units = "kg/m**3";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd1.PropertyName = "Sdry";
            pd1.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Sdry).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Sdry);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd2.PropertyName = "Sdry";
            pd2.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Sdry).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Sdry);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd3.PropertyName = "Swet";
            pd3.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Swet).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Swet);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd4.PropertyName = "Swet";
            pd4.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Swet).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Swet);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd5.PropertyName = "Sdepth";
            pd5.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Sdepth).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Sdepth);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd6.PropertyName = "Sdepth";
            pd6.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Sdepth).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Sdepth);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(Snow.DomainClass.SnowRate);
            pd7.PropertyName = "Mrf";
            pd7.PropertyType = (Snow.DomainClass.SnowRateVarInfo.Mrf).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(Snow.DomainClass.SnowRateVarInfo.Mrf);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(Snow.DomainClass.SnowAuxiliary);
            pd8.PropertyName = "precip";
            pd8.PropertyType = (Snow.DomainClass.SnowAuxiliaryVarInfo.precip).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(Snow.DomainClass.SnowAuxiliaryVarInfo.precip);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(Snow.DomainClass.SnowRate);
            pd9.PropertyName = "Snowaccu";
            pd9.PropertyType = (Snow.DomainClass.SnowRateVarInfo.Snowaccu).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(Snow.DomainClass.SnowRateVarInfo.Snowaccu);
            _inputs0_0.Add(pd9);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd10.PropertyName = "preciprec";
            pd10.PropertyType = (Snow.DomainClass.SnowStateVarInfo.preciprec).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.preciprec);
            _outputs0_0.Add(pd10);
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
            get { return "recalculation of precipitation" ;}
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

        public double rho
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("rho");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'rho' not found (or found null) in strategy 'Preciprec'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("rho");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'rho' not found in strategy 'Preciprec'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            rhoVarInfo.Name = "rho";
            rhoVarInfo.Description = "The density of the new snow fixed by the user";
            rhoVarInfo.MaxValue = ;
            rhoVarInfo.MinValue = ;
            rhoVarInfo.DefaultValue = 100;
            rhoVarInfo.Units = "kg/m**3";
            rhoVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
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
                Snow.DomainClass.SnowStateVarInfo.preciprec.CurrentValue=s.preciprec;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r11 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.preciprec);
                if(r11.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.preciprec.ValueType)){prc.AddCondition(r11);}
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
                Snow.DomainClass.SnowStateVarInfo.Sdry.CurrentValue=s.Sdry;
                Snow.DomainClass.SnowStateVarInfo.Sdry.CurrentValue=s.Sdry;
                Snow.DomainClass.SnowStateVarInfo.Swet.CurrentValue=s.Swet;
                Snow.DomainClass.SnowStateVarInfo.Swet.CurrentValue=s.Swet;
                Snow.DomainClass.SnowStateVarInfo.Sdepth.CurrentValue=s.Sdepth;
                Snow.DomainClass.SnowStateVarInfo.Sdepth.CurrentValue=s.Sdepth;
                Snow.DomainClass.SnowRateVarInfo.Mrf.CurrentValue=r.Mrf;
                Snow.DomainClass.SnowAuxiliaryVarInfo.precip.CurrentValue=a.precip;
                Snow.DomainClass.SnowRateVarInfo.Snowaccu.CurrentValue=r.Snowaccu;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Sdry);
                if(r1.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Sdry.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Sdry);
                if(r2.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Sdry.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Swet);
                if(r3.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Swet.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Swet);
                if(r4.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Swet.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Sdepth);
                if(r5.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Sdepth.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Sdepth);
                if(r6.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Sdepth.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(Snow.DomainClass.SnowRateVarInfo.Mrf);
                if(r7.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowRateVarInfo.Mrf.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(Snow.DomainClass.SnowAuxiliaryVarInfo.precip);
                if(r8.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowAuxiliaryVarInfo.precip.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(Snow.DomainClass.SnowRateVarInfo.Snowaccu);
                if(r9.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowRateVarInfo.Snowaccu.ValueType)){prc.AddCondition(r9);}
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
            double Sdry_t1 = s1.Sdry;
            double Sdry = s.Sdry;
            double Swet = s.Swet;
            double Swet_t1 = s1.Swet;
            double Sdepth_t1 = s1.Sdepth;
            double Sdepth = s.Sdepth;
            double Mrf = r.Mrf;
            double precip = a.precip;
            double Snowaccu = r.Snowaccu;
            double preciprec;
            preciprec = precip;
            if (Sdry + Swet < Sdry_t1 + Swet_t1)
            {
                preciprec = preciprec + ((Sdepth_t1 - Sdepth) * rho) - Mrf;
            }
            preciprec = preciprec - Snowaccu;
            s.preciprec= preciprec;
        }

    }
}