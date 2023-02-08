# coding: utf8
from copy import copy
from array import array
from math import *

import numpy
from math import *

def model_snowdepthtrans(Sdepth = 0.0,
         Pns = 100.0):
    """
     - Name: SnowDepthTrans -Version: 1.0, -Time step: 1
     - Description:
                 * Title: snow cover depth conversion
                 * Author: STICS
                 * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
                 * Institution: INRA
                 * Abstract: snow cover depth in cm
     - inputs:
                 * name: Sdepth
                               ** description : snow cover depth Calculation
                               ** inputtype : variable
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** default : 0.0
                               ** min : 0.0
                               ** max : 500.0
                               ** unit : m
                               ** uri : 
                 * name: Pns
                               ** description : density of the new snow
                               ** inputtype : parameter
                               ** parametercategory : constant
                               ** datatype : DOUBLE
                               ** default : 100.0
                               ** min : 
                               ** max : 
                               ** unit : cm/m
                               ** uri : 
     - outputs:
                 * name: Sdepth_cm
                               ** description : snow cover depth in cm
                               ** variablecategory : state
                               ** datatype : DOUBLE
                               ** min : 0.0
                               ** max : 500.0
                               ** unit : cm
                               ** uri : 
    """

    Sdepth_cm = Sdepth * Pns
    return Sdepth_cm