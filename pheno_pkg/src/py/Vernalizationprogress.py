# coding: utf8
import numpy
from math import *
from datetime import datetime

def model_vernalizationprogress(dayLength = 12.3037621834005,
         deltaTT = 20.3429985011972,
         cumulTT = 112.330110409888,
         leafNumber = 0.0,
         calendarMoments = ["Sowing"],
         calendarDates = [datetime(2007, 3, 21)],
         calendarCumuls = [0.0],
         minTvern = 0.0,
         intTvern = 11.0,
         vAI = 0.015,
         vBEE = 0.01,
         minDL = 8.0,
         maxDL = 15.0,
         maxTvern = 23.0,
         pNini = 4.0,
         aMXLFNO = 24.0,
         vernaprog = 0.5517254187376879,
         currentdate = (2007, 3, 27),
         isVernalizable = 1,
         minFinalNumber = 5.5):
    #- Description:
    #            * Title: VernalizationProgress Model
    #            * Author: Pierre MARTRE
    #            * Reference: Modeling development phase in the 
    #                Wheat Simulation Model SiriusQuality.
    #                See documentation at http://www1.clermont.inra.fr/siriusquality/?page_id=427
    #            * Institution: INRA Montpellier
    #            * Abstract: Calculate progress (VernaProg) towards vernalization, but there 
    #        			is no vernalization below minTvern 
    #        			and above maxTvern . The maximum value of VernaProg is 1.
    #        			Progress towards full vernalization is a linear function of shoot 
    #        			temperature (soil temperature until leaf # reach MaxLeafSoil and then
    #        			 canopy temperature)
    #    	
    #- inputs:
    #            * name: dayLength
    #                          ** description : day length
    #                          ** variablecategory : auxiliary
    #                          ** datatype : DOUBLE
    #                          ** min : 0
    #                          ** max : 10000
    #                          ** default : 12.3037621834005
    #                          ** unit : mm2 m-2
    #                          ** inputtype : variable
    #            * name: deltaTT
    #                          ** description : difference cumul TT between j and j-1 day 
    #                          ** variablecategory : auxiliary
    #                          ** inputtype : variable
    #                          ** datatype : DOUBLE
    #                          ** min : -20
    #                          ** max : 100
    #                          ** default : 20.3429985011972
    #                          ** unit : °C d
    #            * name: cumulTT
    #                          ** description : cumul thermal times at currentdate
    #                          ** variablecategory : auxiliary
    #                          ** datatype : DOUBLE
    #                          ** min : -200
    #                          ** max : 10000
    #                          ** default : 112.330110409888
    #                          ** unit : °C d
    #                          ** inputtype : variable
    #            * name: leafNumber
    #                          ** description : Actual number of phytomers
    #                          ** variablecategory : state
    #                          ** datatype : DOUBLE
    #                          ** min : 0
    #                          ** max : 25
    #                          ** default : 0
    #                          ** unit : leaf
    #                          ** inputtype : variable
    #            * name: calendarMoments
    #                          ** description : List containing appearance of each stage
    #                          ** variablecategory : state
    #                          ** datatype : STRINGLIST
    #                          ** default : ['Sowing']
    #                          ** unit : 
    #                          ** inputtype : variable
    #            * name: calendarDates
    #                          ** description : List containing  the dates of the wheat developmental phases
    #                          ** variablecategory : state
    #                          ** datatype : DATELIST
    #                          ** default : ['2007/3/21']
    #                          ** unit : 
    #                          ** inputtype : variable
    #            * name: calendarCumuls
    #                          ** description : list containing for each stage occured its cumulated thermal times
    #                          ** variablecategory : state
    #                          ** datatype : DOUBLELIST
    #                          ** default : [0.0]
    #                          ** unit : 
    #                          ** inputtype : variable
    #            * name: minTvern
    #                          ** description : Minimum temperature for vernalization to occur
    #                          ** parametercategory : species
    #                          ** datatype : DOUBLE
    #                          ** min : -20
    #                          ** max : 60
    #                          ** default : 0.0
    #                          ** unit : °C
    #                          ** inputtype : parameter
    #            * name: intTvern
    #                          ** description : Intermediate temperature for vernalization to occur
    #                          ** parametercategory : species
    #                          ** datatype : DOUBLE
    #                          ** min : -20
    #                          ** max : 60
    #                          ** default :  11.0
    #                          ** unit : °C
    #                          ** inputtype : parameter
    #            * name: vAI
    #                          ** description : Response of vernalization rate to temperature
    #                          ** parametercategory : species
    #                          ** datatype : DOUBLE
    #                          ** min : 0
    #                          ** max : 1
    #                          ** default :  0.015
    #                          ** unit : d-1 °C-1
    #                          ** inputtype : parameter
    #            * name: vBEE
    #                          ** description : Vernalization rate at 0°C
    #                          ** parametercategory : species
    #                          ** datatype : DOUBLE
    #                          ** min : 0
    #                          ** max : 1
    #                          ** default : 0.01
    #                          ** unit : d-1
    #                          ** inputtype : parameter
    #            * name: minDL
    #                          ** description : Threshold daylength below which it does influence vernalization rate
    #                          ** parametercategory : species
    #                          ** datatype : DOUBLE
    #                          ** min : 12
    #                          ** max : 24
    #                          ** default : 8.0
    #                          ** unit : h
    #                          ** inputtype : parameter
    #            * name: maxDL
    #                          ** description : Saturating photoperiod above which final leaf number is not influenced by daylength
    #                          ** parametercategory : species
    #                          ** datatype : DOUBLE
    #                          ** min : 0
    #                          ** max : 24
    #                          ** default : 15.0
    #                          ** unit : h
    #                          ** inputtype : parameter
    #            * name: maxTvern
    #                          ** description : Maximum temperature for vernalization to occur
    #                          ** parametercategory : species
    #                          ** datatype : DOUBLE
    #                          ** min : -20
    #                          ** max : 60
    #                          ** default :  23.0
    #                          ** unit : °C
    #                          ** inputtype : parameter
    #            * name: pNini
    #                          ** description : Number of primorida in the apex at emergence
    #                          ** parametercategory : species
    #                          ** datatype : DOUBLE
    #                          ** min : 0
    #                          ** max : 24
    #                          ** default : 4.0
    #                          ** unit : primordia
    #                          ** inputtype : parameter
    #            * name: aMXLFNO
    #                          ** description : Absolute maximum leaf number
    #                          ** parametercategory : species
    #                          ** datatype : DOUBLE
    #                          ** min : 0
    #                          ** max : 25
    #                          ** default : 24.0
    #                          ** unit : leaf
    #                          ** inputtype : parameter
    #            * name: vernaprog
    #                          ** description : progression on a 0  to 1 scale of the vernalization
    #                          ** variablecategory : state
    #                          ** datatype : DOUBLE
    #                          ** min : 0
    #                          ** max : 1
    #                          ** default :  0.5517254187376879
    #                          ** unit : 
    #                          ** inputtype : variable
    #            * name: currentdate
    #                          ** description : current date 
    #                          ** variablecategory : auxiliary
    #                          ** datatype : DATE
    #                          ** default : 2007/3/27
    #                          ** inputtype : variable
    #                          ** unit : 
    #            * name: isVernalizable
    #                          ** description : true if the plant is vernalizable
    #                          ** parametercategory : species
    #                          ** datatype : INT
    #                          ** min : 0
    #                          ** max : 1
    #                          ** default : 1
    #                          ** unit : 
    #                          ** inputtype : parameter
    #            * name: minFinalNumber
    #                          ** description : minimum final leaf number
    #                          ** datatype : DOUBLE
    #                          ** min : 0
    #                          ** max : 25
    #                          ** default : 5.5
    #                          ** unit : leaf
    #                          ** inputtype : variable
    #                          ** variablecategory : state
    #- outputs:
    #            * name: vernaprog
    #                          ** description : progression on a 0  to 1 scale of the vernalization
    #                          ** variablecategory : state
    #                          ** datatype : DOUBLE
    #                          ** min : 0
    #                          ** max : 10000
    #                          ** unit : 
    #            * name: minFinalNumber
    #                          ** description : minimum final leaf number
    #                          ** variablecategory : state
    #                          ** datatype : DOUBLE
    #                          ** min : 0
    #                          ** max : 10000
    #                          ** unit : leaf
    #            * name: calendarMoments
    #                          ** description : List containing appearance of each stage
    #                          ** variablecategory : state
    #                          ** datatype : STRINGLIST
    #                          ** unit : 
    #            * name: calendarDates
    #                          ** description : List containing  the dates of the wheat developmental phases
    #                          ** variablecategory : state
    #                          ** datatype : DATELIST
    #                          ** unit : 
    #            * name: calendarCumuls
    #                          ** description : list containing for each stage occured its cumulated thermal times
    #                          ** variablecategory : state
    #                          ** datatype : DOUBLELIST
    #                          ** unit : 
    if isVernalizable == 1 and vernaprog < 1.0:
        tt = deltaTT
        if tt >= minTvern and tt <= intTvern:
            vernaprog = vernaprog + (vAI * tt) + vBEE
        if tt > intTvern:
            maxVernaProg = vAI * intTvern + vBEE
            dLverna = max(minDL, min(maxDL, dayLength))
            vernaprog = vernaprog + max(0.0, maxVernaProg * (1.0 + ((intTvern - tt) / (maxTvern - intTvern) * ((dLverna - minDL) / (maxDL - minDL)))))
        primordno = 2.0 * leafNumber + pNini
        minLeafNumber = minFinalNumber
        if vernaprog >= 1.0 or primordno >= aMXLFNO:
            minFinalNumber = max(primordno, minFinalNumber)
            calendarMoments.append("EndVernalisation")
            calendarCumuls.append(cumulTT)
            calendarDates.append(currentdate)
            vernaprog = max(1.0, vernaprog)
        else:
            potlfno = aMXLFNO - ((aMXLFNO - minLeafNumber) * vernaprog)
            if primordno >= potlfno:
                minFinalNumber = max((potlfno + primordno) / 2.0, minFinalNumber)
                vernaprog = max(1.0, vernaprog)
                calendarMoments.append("EndVernalisation")
                calendarCumuls.append(cumulTT)
                calendarDates.append(currentdate)
    return (vernaprog, minFinalNumber, calendarMoments, calendarDates, calendarCumuls)