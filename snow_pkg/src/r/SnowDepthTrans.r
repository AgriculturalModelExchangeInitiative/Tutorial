model_SnowDepthTrans <- function (Sdepth = 0.0,
         Pns = 100.0){
    #'- Name: SnowDepthTrans -Version: 1.0, -Time step: 1
    #'- Description:
    #'            * Title: snow cover depth conversion
    #'            * Author: STICS
    #'            * Reference: -
    #'            * Institution: INRA
    #'            * Abstract: -
    #'- inputs:
    #'            * name: Sdepth
    #'                          ** description : snow cover depth Calculation
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** default : 0.0
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : m
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
    #'- outputs:
    #'            * name: Sdepth_cm
    #'                          ** description : snow cover depth in cm
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** min : 0.0
    #'                          ** max : 500.0
    #'                          ** unit : cm
    #'                          ** uri : 
    Sdepth_cm <- Sdepth * Pns
    return (list('Sdepth_cm' = Sdepth_cm))
}