# coding: utf8
import numpy
from math import *

def model_updateleafflag(cumulTT = 741.510096671757,
         leafNumber = 8.919453833361189,
         calendarMoments = ["Sowing"],
         calendarDates = ["21/3/2007"],
         calendarCumuls = [0.0],
         currentdate = "29/4/2007",
         finalLeafNumber = 8.797582013199484,
         hasFlagLeafLiguleAppeared = 1,
         phase = 1.0):
    #- Description:
    #            - Model Name: UpdateLeafFlag Model
    #            - Author: Pierre MARTRE
    #            - Reference: Modeling development phase in the 
    #                Wheat Simulation Model SiriusQuality.
    #                See documentation at http://www1.clermont.inra.fr/siriusquality/?page_id=427
    #            - Institution: INRA Montpellier
    #            - Abstract: tells if flag leaf has appeared and update the calendar if so
    #    	
    #- inputs:
    #            - name: cumulTT
    #                          - description : cumul thermal times at current date
    #                          - variablecategory : auxiliary
    #                          - datatype : DOUBLE
    #                          - min : -200
    #                          - max : 10000
    #                          - default : 741.510096671757
    #                          - unit : °C d
    #                          - uri : some url
    #                          - inputtype : variable
    #            - name: leafNumber
    #                          - description : Actual number of phytomers
    #                          - variablecategory : state
    #                          - datatype : DOUBLE
    #                          - min : 0
    #                          - max : 25
    #                          - default : 8.919453833361189
    #                          - unit : leaf
    #                          - uri : some url
    #                          - inputtype : variable
    #            - name: calendarMoments
    #                          - description : List containing apparition of each stage
    #                          - variablecategory : state
    #                          - datatype : STRINGLIST
    #                          - default : ['Sowing']
    #                          - unit : 
    #                          - inputtype : variable
    #            - name: calendarDates
    #                          - description : List containing  the dates of the wheat developmental phases
    #                          - variablecategory : state
    #                          - datatype : DATELIST
    #                          - default : ['21/3/2007']
    #                          - unit : 
    #                          - inputtype : variable
    #            - name: calendarCumuls
    #                          - description : list containing for each stage occured its cumulated thermal times
    #                          - variablecategory : state
    #                          - datatype : DOUBLELIST
    #                          - default : [0.0]
    #                          - unit : °C d
    #                          - inputtype : variable
    #            - name: currentdate
    #                          - description :  current date
    #                          - variablecategory : auxiliary
    #                          - datatype : DATE
    #                          - default : 29/4/2007
    #                          - unit : 
    #                          - uri : some url
    #                          - inputtype : variable
    #            - name: finalLeafNumber
    #                          - description : final leaf number
    #                          - variablecategory : state
    #                          - datatype : DOUBLE
    #                          - min : 0
    #                          - max : 10000
    #                          - default : 8.797582013199484
    #                          - unit : leaf
    #                          - uri : some url
    #                          - inputtype : variable
    #            - name: hasFlagLeafLiguleAppeared
    #                          - description : true if flag leaf has appeared (leafnumber reached finalLeafNumber)
    #                          - variablecategory : state
    #                          - datatype : INT
    #                          - min : 0
    #                          - max : 1
    #                          - default : 1
    #                          - unit : 
    #                          - uri : some url
    #                          - inputtype : variable
    #            - name: phase
    #                          - description :  the name of the phase
    #                          - variablecategory : state
    #                          - datatype : DOUBLE
    #                          - min : 0
    #                          - max : 7
    #                          - default : 1
    #                          - unit : 
    #                          - uri : some url
    #                          - inputtype : variable
    #- outputs:
    #            - name: hasFlagLeafLiguleAppeared
    #                          - description : true if flag leaf has appeared (leafnumber reached finalLeafNumber)
    #                          - variablecategory : state
    #                          - datatype : INT
    #                          - min : 0
    #                          - max : 1
    #                          - unit : 
    #                          - uri : some url
    #            - name: calendarMoments
    #                          - description :  List containing apparition of each stage
    #                          - variablecategory : state
    #                          - datatype : STRINGLIST
    #                          - unit : 
    #            - name: calendarDates
    #                          - description :  List containing  the dates of the wheat developmental phases
    #                          - variablecategory : state
    #                          - datatype : DATELIST
    #                          - unit : 
    #            - name: calendarCumuls
    #                          - description :  list containing for each stage occured its cumulated thermal times
    #                          - variablecategory : state
    #                          - datatype : DOUBLELIST
    #                          - unit : °C d
    if phase >= 1.0 and phase < 4.0:
        if leafNumber > 0.0:
            if hasFlagLeafLiguleAppeared == 0 and (finalLeafNumber > 0.0 and leafNumber >= finalLeafNumber):
                hasFlagLeafLiguleAppeared = 1
                if "FlagLeafLiguleJustVisible" not in calendarMoments:
                    calendarMoments.append("FlagLeafLiguleJustVisible")
                    calendarCumuls.append(cumulTT)
                    calendarDates.append(currentdate)
        else:
            hasFlagLeafLiguleAppeared = 0
    return (hasFlagLeafLiguleAppeared, calendarMoments, calendarDates, calendarCumuls)