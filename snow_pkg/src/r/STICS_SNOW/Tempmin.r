model_tempmin <- function (Sdepth_cm = 0.0,
         prof = 0.0,
         tmin = 0.0,
         tminseuil = 0.0,
         tmaxseuil = 0.0){
    #'- Name: TempMin -Version: 1.0, -Time step: 1
    #'- Description:
    #'            * Title: Minimum temperature  calculation
    #'            * Author: STICS
    #'            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    #'            * Institution: INRA
    #'            * Abstract: recalculation of minimum temperature
    #'- inputs:
    #'            * name: Sdepth_cm
    #'                          ** description : snow depth
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : cm
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
    #'- outputs:
    #'            * name: tminrec
    #'                          ** description : recalculated minimum temperature
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : degC
    #'                          ** uri : 
    tminrec <- tmin
    if (Sdepth_cm > prof)
    {
        if (tmin < tminseuil)
        {
            tminrec <- tminseuil
        }
        else
        {
            if (tmin > tmaxseuil)
            {
                tminrec <- tmaxseuil
            }
        }
    }
    else
    {
        if (Sdepth_cm > 0.0)
        {
            tminrec <- tminseuil - ((1 - (Sdepth_cm / prof)) * (abs(tmin) + tminseuil))
        }
    }
    return (list('tminrec' = tminrec))
}