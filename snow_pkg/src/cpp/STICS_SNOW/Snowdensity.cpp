#ifndef _SNOWDENSITY_
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
#include "Snowdensity.h"
using namespace std;

Snowdensity::Snowdensity() { }
void Snowdensity::Calculate_Model(SnowState& s, SnowState& s1, SnowRate& r, SnowAuxiliary& a, SnowExogenous& ex)
{
    //- Name: SnowDensity -Version: 1.0, -Time step: 1
    //- Description:
    //            * Title: Density of snow cover calculation
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
    //            * ExtendedDescription: It calculates the density of snow cover
    //            * ShortDescription: It calculates the density of snow cover
    //- inputs:
    //            * name: ps_t1
    //                          ** description : density of snow cover in previous day
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 100.0
    //                          ** unit : kg/m**3
    //                          ** uri : 
    //            * name: Sdepth_t1
    //                          ** description : snow cover depth Calculation in previous day
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 5000.0
    //                          ** unit : m
    //                          ** uri : 
    //            * name: Sdry_t1
    //                          ** description : water in solid state in the snow cover in previous day
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : mmW
    //                          ** uri : 
    //            * name: Swet_t1
    //                          ** description : water in liquid state in the snow cover
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 100.0
    //                          ** unit : mmW
    //                          ** uri : 
    //- outputs:
    //            * name: ps
    //                          ** description : density of snow cover
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : kg/m**3
    //                          ** uri : 
    double ps_t1 = s1.getps();
    double Sdepth_t1 = s1.getSdepth();
    double Sdry_t1 = s1.getSdry();
    double Swet_t1 = s1.getSwet();
    double ps;
    ps = 0.0;
    if (abs(Sdepth_t1) > 0.0)
    {
        if (abs(Sdry_t1 + Swet_t1) > 0.0)
        {
            ps = (Sdry_t1 + Swet_t1) / Sdepth_t1;
        }
        else
        {
            ps = ps_t1;
        }
    }
    s.setps(ps);
}
#endif