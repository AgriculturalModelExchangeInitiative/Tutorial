using System;
using System.Collections.Generic;
using System.Linq;
public class PriestlyTaylor
{
    private double _psychrometricConstant;
    public double psychrometricConstant
        {
            get { return this._psychrometricConstant; }
            set { this._psychrometricConstant= value; } 
        }
    private double _Alpha;
    public double Alpha
        {
            get { return this._Alpha; }
            set { this._Alpha= value; } 
        }
    public PriestlyTaylor() { }
    
    public void  CalculateModel(EnergyBalanceState s, EnergyBalanceState s1, EnergyBalanceRate r, EnergyBalanceAuxiliary a, EnergyBalanceExogenous ex)
    {
        //- Name: PriestlyTaylor -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: evapoTranspirationPriestlyTaylor  Model
    //            * Author: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    //            * Reference:  https://doi.org/10.1016/0168-1923(94)02214-5
    //            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    //            New Zealand Institute for Crop and Food Research Ltd.,
    //            New Zealand Institute for Crop and Food Research Ltd.,
    //            New Zealand Institute for Crop and Food Research Ltd.
    //        
    //            * ExtendedDescription: Calculate Energy Balance 
    //            * ShortDescription: It uses Priestly-Taylor method
        //- inputs:
    //            * name: netRadiationEquivalentEvaporation
    //                          ** description : net Radiation in Equivalent Evaporation
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** default : 638.142
    //                          ** min : 0
    //                          ** max : 5000
    //                          ** unit : g m-2 d-1
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    //                          ** inputtype : variable
    //            * name: hslope
    //                          ** description : the slope of saturated vapor pressure temperature curve at a given temperature 
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** default : 0.584
    //                          ** min : 0
    //                          ** max : 1000
    //                          ** unit : hPa °C-1
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    //                          ** inputtype : variable
    //            * name: psychrometricConstant
    //                          ** description : psychrometric constant
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 0.66
    //                          ** min : 0
    //                          ** max : 1
    //                          ** unit : 
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    //                          ** inputtype : parameter
    //            * name: Alpha
    //                          ** description : Priestley-Taylor evapotranspiration proportionality constant
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 1.5
    //                          ** min : 0
    //                          ** max : 100
    //                          ** unit : 
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    //                          ** inputtype : parameter
        //- outputs:
    //            * name: evapoTranspirationPriestlyTaylor
    //                          ** description : evapoTranspiration of Priestly Taylor 
    //                          ** variablecategory : rate
    //                          ** datatype : DOUBLE
    //                          ** min : 0
    //                          ** max : 10000
    //                          ** unit : g m-2 d-1
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
        double netRadiationEquivalentEvaporation = s.netRadiationEquivalentEvaporation;
        double hslope = a.hslope;
        double evapoTranspirationPriestlyTaylor;
        evapoTranspirationPriestlyTaylor = Math.Max(Alpha * hslope * netRadiationEquivalentEvaporation / (hslope + psychrometricConstant), 0.0d);
        r.evapoTranspirationPriestlyTaylor = evapoTranspirationPriestlyTaylor;
    }
}