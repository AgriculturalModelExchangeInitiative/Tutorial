model_refreezing <- function (tavg = 0.0,
         Tmf = 0.0,
         SWrf = 0.0){
    #'- Name: Refreezing -Version: 1.0, -Time step: 1
    #'- Description:
    #'            * Title: snowfall accumulation  calculation
    #'            * Author: STICS
    #'            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    #'            * Institution: INRA
    #'            * Abstract: It simulates the depth of snow cover and recalculate weather data
    #'- inputs:
    #'            * name: tavg
    #'                          ** description : average temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : auxiliary
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 100.0
    #'                          ** unit : degC
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
    #'- outputs:
    #'            * name: Mrf
    #'                          ** description : liquid water in the snow cover in the process of refreezing
    #'                          ** variablecategory : rate
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : mmW/d
    #'                          ** uri : 
    Mrf <- 0.0
    if (tavg < Tmf)
    {
        Mrf <- SWrf * (Tmf - tavg)
    }
    return (list('Mrf' = Mrf))
}