#ifndef _SNOWWET_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include <numeric>
#include <algorithm>
#include <array>
#include <map>
#include <tuple>
#include "Snowwet.h"
using namespace std;

Snowwet::Snowwet() { }
void Snowwet::Calculate_Model(SnowState& s, SnowState& s1, SnowRate& r, SnowAuxiliary& a, SnowExogenous& ex)
{
    //- Name: SnowWet -Version: 1.0, -Time step: 1
    //- Description:
    //            * Title: The Snow wet Model
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
    //            * ExtendedDescription: It estimates the water in liquid state in the snow cover
    //            * ShortDescription: It estimates the water in liquid state in the snow cover
    //- inputs:
    //            * name: Swet_t1
    //                          ** description : water in liquid state in the snow cover in previous day
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 100.0
    //                          ** unit : mmW
    //                          ** uri : 
    //            * name: precip
    //                          ** description : current precipitation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 5000.0
    //                          ** unit : mmW
    //                          ** uri : 
    //            * name: Snowaccu
    //                          ** description :  snowfall accumulation
    //                          ** inputtype : variable
    //                          ** variablecategory : rate
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 
    //                          ** max : 
    //                          ** unit : mmW/d
    //                          ** uri : 
    //            * name: Mrf
    //                          ** description : liquid water in the snow cover in the process of refreezing
    //                          ** inputtype : variable
    //                          ** variablecategory : rate
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 
    //                          ** max : 
    //                          ** unit : mmW/d
    //                          ** uri : 
    //            * name: M
    //                          ** description : snow in the process of melting
    //                          ** inputtype : variable
    //                          ** variablecategory : rate
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 
    //                          ** max : 
    //                          ** unit : mmW/d
    //                          ** uri : 
    //            * name: Sdry
    //                          ** description : water in solid state in the snow cover
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : mmW
    //                          ** uri : 
    //- outputs:
    //            * name: Swet
    //                          ** description : water in liquid state in the snow cover
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : mmW
    //                          ** uri : 
    double Swet_t1 = s1.getSwet();
    double precip = a.getprecip();
    double Snowaccu = r.getSnowaccu();
    double Mrf = r.getMrf();
    double M = r.getM();
    double Sdry = s.getSdry();
    double Swet;
    double frac_sdry;
    double tmp_swet;
    Swet = 0.0;
    if (Mrf <= Swet_t1)
    {
        tmp_swet = Swet_t1 + precip - Snowaccu + M - Mrf;
        frac_sdry = 0.1 * Sdry;
        if (tmp_swet < frac_sdry)
        {
            Swet = tmp_swet;
        }
        else
        {
            Swet = frac_sdry;
        }
    }
    s.setSwet(Swet);
}
#endif