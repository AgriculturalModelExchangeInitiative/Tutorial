
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
    public class SnowMelt : IStrategySnow
    {
        public SnowMelt()
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
            pd2.DomainClassType = typeof(Snow.DomainClass.SnowRate);
            pd2.PropertyName = "M";
            pd2.PropertyType = (Snow.DomainClass.SnowRateVarInfo.M).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(Snow.DomainClass.SnowRateVarInfo.M);
            _inputs0_0.Add(pd2);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(Snow.DomainClass.SnowState);
            pd3.PropertyName = "Snowmelt";
            pd3.PropertyType = (Snow.DomainClass.SnowStateVarInfo.Snowmelt).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(Snow.DomainClass.SnowStateVarInfo.Snowmelt);
            _outputs0_0.Add(pd3);
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
            get { return "Snow melt" ;}
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
                Snow.DomainClass.SnowStateVarInfo.Snowmelt.CurrentValue=s.Snowmelt;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r3 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.Snowmelt);
                if(r3.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.Snowmelt.ValueType)){prc.AddCondition(r3);}
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
                Snow.DomainClass.SnowRateVarInfo.M.CurrentValue=r.M;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(Snow.DomainClass.SnowStateVarInfo.ps);
                if(r1.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowStateVarInfo.ps.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(Snow.DomainClass.SnowRateVarInfo.M);
                if(r2.ApplicableVarInfoValueTypes.Contains( Snow.DomainClass.SnowRateVarInfo.M.ValueType)){prc.AddCondition(r2);}
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
            double ps = s.ps;
            double M = r.M;
            double Snowmelt;
            Snowmelt = 0.0d;
            if (ps > 1e-8d)
            {
                Snowmelt = M / ps;
            }
            s.Snowmelt= Snowmelt;
        }

    }
}