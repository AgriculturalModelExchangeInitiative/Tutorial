
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
    public class SnowDensity : IStrategySnow
    {
        public SnowDensity()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd1.PropertyName = "ps";
            pd1.PropertyType = (Snow.DomainClass.SnowStateVarInfo.ps).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.ps);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd2.PropertyName = "Sdepth";
            pd2.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Sdepth).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Sdepth);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd3.PropertyName = "Sdry";
            pd3.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Sdry).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Sdry);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd4.PropertyName = "Swet";
            pd4.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Swet).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Swet);
            _inputs0_0.Add(pd4);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd5.PropertyName = "ps";
            pd5.PropertyType = (Snow.DomainClass.SnowStateVarInfo.ps).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.ps);
            _outputs0_0.Add(pd5);
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
            get { return "density of snow cover" ;}
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


        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {
        }

        public string TestPostConditions(Snow.DomainClass.SnowState s,Snow.DomainClass.SnowState s1,Snow.DomainClass.SnowRate r,Snow.DomainClass.SnowAuxiliary a,Snow.DomainClass.SnowExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                Snow.DomainClass.SnowStateVarInfo.ps.CurrentValue=s.ps;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r5 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.ps);
                if(r5.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.ps.ValueType)){prc.AddCondition(r5);}
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
                Snow.DomainClass.SnowStateVarInfo.ps.CurrentValue=s.ps;
                Snow.DomainClass.SnowStateVarInfo.Sdepth.CurrentValue=s.Sdepth;
                Snow.DomainClass.SnowStateVarInfo.Sdry.CurrentValue=s.Sdry;
                Snow.DomainClass.SnowStateVarInfo.Swet.CurrentValue=s.Swet;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.ps);
                if(r1.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.ps.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Sdepth);
                if(r2.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Sdepth.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Sdry);
                if(r3.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Sdry.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Swet);
                if(r4.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Swet.ValueType)){prc.AddCondition(r4);}
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
            double ps_t1 = s1.ps;
            double Sdepth_t1 = s1.Sdepth;
            double Sdry_t1 = s1.Sdry;
            double Swet_t1 = s1.Swet;
            double ps;
            ps = 0.0d;
            if (Math.Abs(Sdepth_t1) > 0.0d)
            {
                if (Math.Abs(Sdry_t1 + Swet_t1) > 0.0d)
                {
                    ps = (Sdry_t1 + Swet_t1) / Sdepth_t1;
                }
                else
                {
                    ps = ps_t1;
                }
            }
            s.ps= ps;
        }

    }
}