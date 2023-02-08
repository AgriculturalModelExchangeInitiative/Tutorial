SUBROUTINE model_ptsoil(evapoTranspirationPriestlyTaylor, &
        Alpha, &
        tau, &
        tauAlpha, &
        energyLimitedEvaporation)
    IMPLICIT NONE
    REAL, INTENT(IN) :: evapoTranspirationPriestlyTaylor
    REAL, INTENT(IN) :: Alpha
    REAL, INTENT(IN) :: tau
    REAL, INTENT(IN) :: tauAlpha
    REAL, INTENT(OUT) :: energyLimitedEvaporation
    REAL:: AlphaE
    !- Name: PtSoil -Version: 1.0, -Time step: 1
    !- Description:
    !            * Title: PtSoil EnergyLimitedEvaporation Model
    !            * Author: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
    !            * Reference: https://doi.org/10.1016/0168-1923(94)02214-5
    !            * Institution: New Zealand Institute for Crop and Food Research Ltd.,
    !            New Zealand Institute for Crop and Food Research Ltd.,
    !            New Zealand Institute for Crop and Food Research Ltd.,
    !            New Zealand Institute for Crop and Food Research Ltd.
    !        
    !            * ExtendedDescription: Evaporation from the soil in the energy-limited stage 
    !            * ShortDescription: Evaporation from the soil in the energy-limited stage
    !- inputs:
    !            * name: evapoTranspirationPriestlyTaylor
    !                          ** description : evapoTranspiration Priestly Taylor
    !                          ** variablecategory : rate
    !                          ** datatype : DOUBLE
    !                          ** default : 120
    !                          ** min : 0
    !                          ** max : 1000
    !                          ** unit : g m-2 d-1
    !                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    !                          ** inputtype : variable
    !            * name: Alpha
    !                          ** description : Priestley-Taylor evapotranspiration proportionality constant
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** default : 1.5
    !                          ** min : 0
    !                          ** max : 100
    !                          ** unit : 
    !                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    !                          ** inputtype : parameter
    !            * name: tau
    !                          ** description : plant cover factor
    !                          ** parametercategory : species
    !                          ** datatype : DOUBLE
    !                          ** default : 0.9983
    !                          ** min : 0
    !                          ** max : 100
    !                          ** unit : 
    !                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    !                          ** inputtype : parameter
    !            * name: tauAlpha
    !                          ** description : Fraction of the total net radiation exchanged at the soil surface when AlpaE = 1
    !                          ** parametercategory : soil
    !                          ** datatype : DOUBLE
    !                          ** default : 0.3
    !                          ** min : 0
    !                          ** max : 1
    !                          ** unit : 
    !                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    !                          ** inputtype : parameter
    !- outputs:
    !            * name: energyLimitedEvaporation
    !                          ** description : energy Limited Evaporation 
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** min : 0
    !                          ** max : 5000
    !                          ** unit : g m-2 d-1
    !                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    IF(tau .LT. tauAlpha) THEN
        AlphaE = 1.0
    ELSE
        AlphaE = Alpha - ((Alpha - 1.0) * (1.0 - tau) / (1.0 - tauAlpha))
    END IF
    energyLimitedEvaporation = evapoTranspirationPriestlyTaylor / Alpha *  &
            AlphaE * tau
END SUBROUTINE model_ptsoil