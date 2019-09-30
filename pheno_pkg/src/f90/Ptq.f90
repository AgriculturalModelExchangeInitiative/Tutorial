MODULE Ptqmod
    USE list_sub
    IMPLICIT NONE
CONTAINS
    SUBROUTINE model_ptq(tTWindowForPTQ, &
        kl, &
        listTTShootWindowForPTQ, &
        listPARTTWindowForPTQ, &
        listGAITTWindowForPTQ, &
        pAR, &
        deltaTT, &
        ptq)
        REAL, INTENT(IN) :: tTWindowForPTQ
        REAL, INTENT(IN) :: kl
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) ::  &
                listTTShootWindowForPTQ
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(INOUT) ::  &
                listPARTTWindowForPTQ
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: listGAITTWindowForPTQ
        REAL, INTENT(IN) :: pAR
        REAL, INTENT(IN) :: deltaTT
        REAL, INTENT(OUT) :: ptq
        REAL, ALLOCATABLE , DIMENSION(:):: TTList
        REAL, ALLOCATABLE , DIMENSION(:):: PARList
        INTEGER:: i
        INTEGER:: count
        REAL:: SumTT
        REAL:: parInt = 0.0
        REAL:: TTShoot
        !- Description:
    !            * Title: Phyllochron Model
    !            * Author: Pierre Martre
    !            * Reference: Modeling development phase in the 
    !                Wheat Simulation Model SiriusQuality.
    !                See documentation at http://www1.clermont.inra.fr/siriusquality/?page_id=427
    !            * Institution: INRA Montpellier
    !            * Abstract: Calculate Photothermal Quaotient 
        !- inputs:
    !            * name: tTWindowForPTQ
    !                          ** description : Thermal time window in which averages are computed
    !                          ** parametercategory : species
    !                          ** datatype : DOUBLE
    !                          ** min : 0.0
    !                          ** max : 70000.0
    !                          ** default : 70.0
    !                          ** unit : °C d
    !                          ** uri : some url
    !                          ** inputtype : parameter
    !            * name: kl
    !                          ** description : Exctinction Coefficient
    !                          ** parametercategory : species
    !                          ** datatype : DOUBLE
    !                          ** min : 0.0
    !                          ** max : 50.0
    !                          ** default : 0.45
    !                          ** unit : 
    !                          ** uri : some url
    !                          ** inputtype : parameter
    !            * name: listTTShootWindowForPTQ
    !                          ** description : List of Daily Shoot thermal time during TTWindowForPTQ thermal time period
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** min : 
    !                          ** max : 
    !                          ** default : [0.0]
    !                          ** unit : °C d
    !                          ** uri : some url
    !                          ** inputtype : variable
    !            * name: listPARTTWindowForPTQ
    !                          ** description : List of Daily PAR during TTWindowForPTQ thermal time period
    !                          ** variablecategory : state
    !                          ** inputtype : variable
    !                          ** datatype : DOUBLELIST
    !                          ** min : 
    !                          ** max : 
    !                          ** default : [0.0]
    !                          ** unit : MJ m2 d
    !                          ** uri : some url
    !            * name: listGAITTWindowForPTQ
    !                          ** description : List of daily GAI over TTWindowForPTQ thermal time period
    !                          ** variablecategory : state
    !                          ** inputtype : variable
    !                          ** datatype : DOUBLELIST
    !                          ** min : 
    !                          ** max : 
    !                          ** default : [0.0]
    !                          ** unit : m2 m-2
    !                          ** uri : some url
    !            * name: pAR
    !                          ** description : Daily Photosyntetically Active Radiation
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** default : 0.0
    !                          ** min : 0.0
    !                          ** max : 10000.0
    !                          ** unit : MJ m² d
    !                          ** uri : some url
    !                          ** inputtype : variable
    !            * name: deltaTT
    !                          ** description : daily delta TT 
    !                          ** variablecategory : auxiliary
    !                          ** inputtype : variable
    !                          ** datatype : DOUBLE
    !                          ** min : 0.0
    !                          ** max : 100.0
    !                          ** default : 0.0
    !                          ** unit : °C d
    !                          ** uri : some url
        !- outputs:
    !            * name: listPARTTWindowForPTQ
    !                          ** description :  List of Daily PAR during TTWindowForPTQ thermal time period
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** min : 
    !                          ** max : 
    !                          ** unit : MJ m2 d
    !            * name: listTTShootWindowForPTQ
    !                          ** description : List of Daily Shoot thermal time during TTWindowForPTQ thermal time period
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** min : 
    !                          ** max : 
    !                          ** unit : °C d
    !            * name: ptq
    !                          ** description : Photothermal Quotient
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** min : 0
    !                          ** max : 10000
    !                          ** unit : MJ °C-1 d m-2)
        DO i = 1 , SIZE(listTTShootWindowForPTQ)
            call Add(TTList, listTTShootWindowForPTQ(i))
            call Add(PARList, listPARTTWindowForPTQ(i))
        END DO
        call Add(TTList, deltaTT)
        call Add(PARList, pAR)
        SumTT = sum(TTList)
        count = 0
        DO WHILE ( SumTT .GT. tTWindowForPTQ )
            SumTT = SumTT - TTList(count+1)
            count = count + 1
        END DO
        deallocate(listTTShootWindowForPTQ)

        deallocate(listPARTTWindowForPTQ)

        DO i = count + 1  , SIZE(TTList)
            call Add(listTTShootWindowForPTQ, TTList(i))
            call Add(listPARTTWindowForPTQ, PARList(i))
        END DO
        DO i = 1 , SIZE(listTTShootWindowForPTQ)
            parInt = parInt + (listPARTTWindowForPTQ(i) * (1 - EXP((-kl) *  &
                    listGAITTWindowForPTQ(i))))
        END DO
        TTShoot = sum(listTTShootWindowForPTQ)
        ptq = parInt / TTShoot
    END SUBROUTINE model_ptq

END MODULE
