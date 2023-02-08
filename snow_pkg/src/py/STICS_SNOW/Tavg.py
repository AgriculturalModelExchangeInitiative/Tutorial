# coding: utf8
from copy import copy
from array import array
from math import *

import numpy
from math import *

def model_tavg(tmin = 0.0,
         tmax = 0.0):
    """
     - Name: Tavg -Version: 1.0, -Time step: 1
     - Description:
                 * Title: Mean temperature  calculation
                 * Author: STICS
                 * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
                 * Institution: INRA
                 * Abstract: It simulates the depth of snow cover and recalculate weather data
     - inputs:
                 * name: tmin
                               ** description : current minimum air temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** default : 0.0
                               ** min : 0.0
                               ** max : 500.0
                               ** unit : degC
                               ** uri : 
                 * name: tmax
                               ** description : current maximum air temperature
                               ** inputtype : variable
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** default : 0.0
                               ** min : 0.0
                               ** max : 100.0
                               ** unit : degC
                               ** uri : 
     - outputs:
                 * name: tavg
                               ** description : mean temperature
                               ** variablecategory : auxiliary
                               ** datatype : DOUBLE
                               ** min : 0.0
                               ** max : 500.0
                               ** unit : degC
                               ** uri : 
    """

    tavg = (tmin + tmax) / 2
    return tavg