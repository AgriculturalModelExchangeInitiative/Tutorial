# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *

import numpy

#%%CyML Model Begin%%
def model_conductance(vonKarman:float,
         heightWeatherMeasurements:float,
         zm:float,
         zh:float,
         d:float,
         plantHeight:float,
         wind:float):
    """
     - Name: Conductance -Version: 1.0, -Time step: 1
     - Description:
                 * Title: Conductance Model
                 * Authors: Peter D. Jamieson, Glen S. Francis, Derick R. Wilson, Robert J. Martin
                 * Reference:  https://doi.org/10.1016/0168-1923(94)02214-5
             
                 * Institution: New Zealand Institute for Crop and Food Research Ltd.,
                 New Zealand Institute for Crop and Food Research Ltd.,
                 New Zealand Institute for Crop and Food Research Ltd.,
                 New Zealand Institute for Crop and Food Research Ltd.
             
                 * ExtendedDescription: The boundary layer conductance is expressed as the wind speed profile above the
                 canopy and the canopy structure. The approach does not take into account buoyancy
                 effects. 
             
                 * ShortDescription: The boundary layer conductance is expressed as the wind speed profile above the
                 canopy and the canopy structure. The approach does not take into account buoyancy
                 effects.
             
     - inputs:
                 * name: vonKarman
                               ** description : von Karman constant
                               ** datatype : DOUBLE
                               ** min : 0
                               ** max : 1
                               ** default : 0.42
                               ** unit : dimensionless
                               ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
                               ** inputtype : parameter
                               ** parametercategory : constant
                 * name: heightWeatherMeasurements
                               ** description : reference height of wind and humidity measurements
                               ** parametercategory : soil
                               ** datatype : DOUBLE
                               ** min : 0
                               ** max : 10
                               ** default : 2
                               ** unit : m
                               ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
                               ** inputtype : parameter
                 * name: zm
                               ** description : roughness length governing momentum transfer, FAO
                               ** parametercategory : constant
                               ** inputtype : parameter
                               ** datatype : DOUBLE
                               ** min : 0
                               ** max : 1
                               ** default : 0.13
                               ** unit : m
                               ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
                 * name: zh
                               ** description : roughness length governing transfer of heat and vapour, FAO
                               ** parametercategory : constant
                               ** inputtype : parameter
                               ** datatype : DOUBLE
                               ** min : 0
                               ** max : 1
                               ** default : 0.013
                               ** unit : m
                               ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
                 * name: d
                               ** description : corresponding to 2/3. This is multiplied to the crop heigth for calculating the zero plane displacement height, FAO
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** default : 0.67
                               ** min : 0
                               ** max : 1
                               ** unit : dimensionless
                               ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547rl
                 * name: plantHeight
                               ** description : plant Height
                               ** datatype : DOUBLE
                               ** default : 0
                               ** min : 0
                               ** max : 1000
                               ** unit : mm
                               ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                 * name: wind
                               ** description : wind
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** default : 124000
                               ** min : 0
                               ** max : 1000000
                               ** unit : m/d
                               ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
                               ** inputtype : variable
     - outputs:
                 * name: conductance
                               ** description : the boundary layer conductance
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** min : 0
                               ** max : 10000
                               ** unit : m/d
                               ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    """

    conductance:float
    h:float
    h = max(10.0, plantHeight) / 100.0
    conductance = wind * pow(vonKarman, 2) / (log((heightWeatherMeasurements - (d * h)) / (zm * h)) * log((heightWeatherMeasurements - (d * h)) / (zh * h)))
    return conductance
#%%CyML Model End%%