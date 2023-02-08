library (gsubfn) 
setwd('/src/r')
source('Melting.r')
source('Refreezing.r')
source('Snowaccumulation.r')
source('Snowdensity.r')
source('Snowdepth.r')
source('Snowdepthtrans.r')
source('Snowdry.r')
source('Snowmelt.r')
source('Snowwet.r')
source('Tavg.r')
source('Tempmax.r')
source('Tempmin.r')
source('Preciprec.r')

model_snow <- function (jul = 0,
         Tmf = 0.0,
         SWrf = 0.0,
         tsmax = 0.0,
         precip = 0.0,
         DKmax = 0.0,
         trmax = 0.0,
         tmax = 0.0,
         ps_t1 = 0.0,
         Sdepth_t1 = 0.0,
         Sdry_t1 = 0.0,
         Swet_t1 = 0.0,
         rho = 100.0,
         Kmin = 0.0,
         Pns = 100.0,
         tmaxseuil = 0.0,
         tminseuil = 0.0,
         tmin = 0.0,
         prof = 0.0,
         E = 0.0){
    #'- Name: Snow -Version: 1.0, -Time step: 1
    #'- Description:
    #'            * Title: Snow model
    #'            * Author: STICS
    #'            * Reference: Snow paper
    #'            * Institution: STICS
    #'            * Abstract: Snow
    #'- inputs:
    #'            * name: jul
    #'                          ** description : current day of year for the calculation
    #'                          ** inputtype : variable
    #'                          ** variablecategory : auxiliary
    #'                          ** datatype : INT
    #'                          ** default : 0
    #'                          ** min : 0
    #'                          ** max : 366
    #'                          ** unit : d
    #'                          ** uri : 
    #'            * name: Tmf
    #'                          ** description : threshold temperature for snow melting 
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 5000.0
    #'                          ** unit : degC
    #'                          ** uri : 
    #'            * name: SWrf
    #'                          ** description : degree-day temperature index for refreezing
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 5000.0
    #'                          ** unit : mmW/degC/d
    #'                          ** uri : 
    #'            * name: tsmax
    #'                          ** description : maximum daily air temperature (tmax) below which all precipitation is assumed to be snow
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 1000
    #'                          ** unit : degC
    #'                          ** uri : 
    #'            * name: precip
    #'                          ** description : current precipitation
    #'                          ** inputtype : variable
    #'                          ** variablecategory : auxiliary
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 5000.0
    #'                          ** unit : mmW
    #'                          ** uri : 
    #'            * name: DKmax
    #'                          ** description : difference between the maximum and the minimum melting rates
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 5000.0
    #'                          ** unit : mmW/degC/d
    #'                          ** uri : 
    #'            * name: trmax
    #'                          ** description : tmax above which all precipitation is assumed to be rain
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 5000.0
    #'                          ** unit : degC
    #'                          ** uri : 
    #'            * name: tmax
    #'                          ** description : current maximum air temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : auxiliary
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 5000.0
    #'                          ** unit : degC
    #'                          ** uri : 
    #'            * name: ps_t1
    #'                          ** description : density of snow cover in previous day
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 100.0
    #'                          ** unit : kg/m**3
    #'                          ** uri : 
    #'            * name: Sdepth_t1
    #'                          ** description : snow cover depth Calculation in previous day
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 5000.0
    #'                          ** unit : m
    #'                          ** uri : 
    #'            * name: Sdry_t1
    #'                          ** description : water in solid state in the snow cover in previous day
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : mmW
    #'                          ** uri : 
    #'            * name: Swet_t1
    #'                          ** description : water in liquid state in the snow cover in previous day
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 100.0
    #'                          ** unit : mmW
    #'                          ** uri : 
    #'            * name: rho
    #'                          ** description : The density of the new snow fixed by the user
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** default : 100
    #'                          ** min : 
    #'                          ** max : 
    #'                          ** unit : kg/m**3
    #'                          ** uri : 
    #'            * name: Kmin
    #'                          ** description : minimum melting rate on 21 December
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 5000.0
    #'                          ** unit : mmW/degC/d
    #'                          ** uri : 
    #'            * name: Pns
    #'                          ** description : density of the new snow
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** default : 100.0
    #'                          ** min : 
    #'                          ** max : 
    #'                          ** unit : cm/m
    #'                          ** uri : 
    #'            * name: tmaxseuil
    #'                          ** description : maximum temperature when snow cover is higher than prof
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 
    #'                          ** max : 
    #'                          ** unit : degC
    #'                          ** uri : 
    #'            * name: tminseuil
    #'                          ** description : minimum temperature when snow cover is higher than prof
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 5000.0
    #'                          ** unit : degC
    #'                          ** uri : 
    #'            * name: tmin
    #'                          ** description : current minimum air temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : auxiliary
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 100.0
    #'                          ** unit : degC
    #'                          ** uri : 
    #'            * name: prof
    #'                          ** description : snow cover threshold for snow insulation 
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 1000
    #'                          ** unit : cm
    #'                          ** uri : 
    #'            * name: E
    #'                          ** description : snow compaction parameter
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 
    #'                          ** max : 
    #'                          ** unit : mm/mm/d
    #'                          ** uri : 
    #'- outputs:
    #'            * name: M
    #'                          ** description : snow in the process of melting
    #'                          ** variablecategory : rate
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : mmW/d
    #'                          ** uri : 
    #'            * name: tminrec
    #'                          ** description : recalculated minimum temperature
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : degC
    #'                          ** uri : 
    #'            * name: Sdepth
    #'                          ** description : snow cover depth Calculation
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : m
    #'                          ** uri : 
    #'            * name: Sdry
    #'                          ** description : water in solid state in the snow cover
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : mmW
    #'                          ** uri : 
    #'            * name: Snowaccu
    #'                          ** description : snowfall accumulation
    #'                          ** variablecategory : rate
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : mmW/d
    #'                          ** uri : 
    #'            * name: ps
    #'                          ** description : density of snow cover
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : kg/m**3
    #'                          ** uri : 
    #'            * name: Swet
    #'                          ** description : water in liquid state in the snow cover
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : mmW
    #'                          ** uri : 
    #'            * name: tavg
    #'                          ** description : mean temperature
    #'                          ** variablecategory : auxiliary
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : degC
    #'                          ** uri : 
    #'            * name: Mrf
    #'                          ** description : liquid water in the snow cover in the process of refreezing
    #'                          ** variablecategory : rate
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : mmW/d
    #'                          ** uri : 
    #'            * name: tmaxrec
    #'                          ** description : recalculated maximum temperature
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : degC
    #'                          ** uri : 
    #'            * name: preciprec
    #'                          ** description : recalculated precipitation
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : mmW
    #'                          ** uri : 
    #'            * name: Snowmelt
    #'                          ** description : Snow melt
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : m
    #'                          ** uri : 
    #'            * name: Sdepth_cm
    #'                          ** description : snow cover depth in cm
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : cm
    #'                          ** uri : 
    Snowaccu <- model_snowaccumulation(tsmax, tmax, trmax, precip)
    ps <- model_snowdensity(ps_t1, Sdepth_t1, Sdry_t1, Swet_t1)
    tavg <- model_tavg(tmin, tmax)
    M <- model_melting(jul, Tmf, DKmax, Kmin, tavg)
    Mrf <- model_refreezing(tavg, Tmf, SWrf)
    Snowmelt <- model_snowmelt(ps, M)
    Sdry <- model_snowdry(Sdry_t1, Snowaccu, Mrf, M)
    Sdepth <- model_snowdepth(Snowmelt, Sdepth_t1, Snowaccu, E, rho)
    Swet <- model_snowwet(Swet_t1, precip, Snowaccu, Mrf, M, Sdry)
    Sdepth_cm <- model_snowdepthtrans(Sdepth, Pns)
    preciprec <- model_preciprec(Sdry_t1, Sdry, Swet, Swet_t1, Sdepth_t1, Sdepth, Mrf, precip, Snowaccu, rho)
    tminrec <- model_tempmin(Sdepth_cm, prof, tmin, tminseuil, tmaxseuil)
    tmaxrec <- model_tempmax(Sdepth_cm, prof, tmax, tminseuil, tmaxseuil)
    return (list ("M" = M,"tminrec" = tminrec,"Sdepth" = Sdepth,"Sdry" = Sdry,"Snowaccu" = Snowaccu,"ps" = ps,"Swet" = Swet,"tavg" = tavg,"Mrf" = Mrf,"tmaxrec" = tmaxrec,"preciprec" = preciprec,"Snowmelt" = Snowmelt,"Sdepth_cm" = Sdepth_cm))
}