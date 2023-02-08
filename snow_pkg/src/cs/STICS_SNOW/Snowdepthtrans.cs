using System;
using System.Collections.Generic;
using System.Linq;
public class SnowDepthTrans
{
    private double _Pns;
    public double Pns
        {
            get { return this._Pns; }
            set { this._Pns= value; } 
        }
    public SnowDepthTrans() { }
    
    public void  CalculateModel(SnowState s, SnowState s1, SnowRate r, SnowAuxiliary a, SnowExogenous ex)
    {
        //- Name: SnowDepthTrans -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: Snow cover depth conversion
    //            * Author: Guillaume Jégo,
    //            Martin Chantigny,
    //            Elizabeth Pattey,
    //            Gilles Bélanger,
    //            Philippe Rochette,
    //            Anne Vanasse,
    //            Claudia Goyer
    //		
    //            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    //            * Institution: Agriculture and Agri-Food Canada,
    //				Agriculture and Agri-Food Canada,
    //				Agriculture and Agri-Food Canada,
    //				Agriculture and Agri-Food Canada,
    //				Agriculture and Agri-Food Canada,
    //				CanadaLaval University,
    //				Agriculture and Agri-Food Canada
    //		
    //            * ExtendedDescription: It converts the snow cover depth in cm
    //            * ShortDescription: It converts the snow cover depth in cm
        //- inputs:
    //            * name: Sdepth
    //                          ** description : snow cover depth Calculation
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : m
    //                          ** uri : 
    //            * name: Pns
    //                          ** description : density of the new snow
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 100.0
    //                          ** min : 
    //                          ** max : 
    //                          ** unit : cm/m
    //                          ** uri : 
        //- outputs:
    //            * name: Sdepth_cm
    //                          ** description : snow cover depth in cm
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : cm
    //                          ** uri : 
        double Sdepth = s.Sdepth;
        double Sdepth_cm;
        Sdepth_cm = Sdepth * Pns;
        s.Sdepth_cm= Sdepth_cm;
    }
}