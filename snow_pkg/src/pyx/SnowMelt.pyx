import numpy 
from math import *
def model_snowmelt(float ps=0.0,
                   float M=0.0):
    """

    Snow Melt Model
    Author: Guillaume Jégo,
            Martin Chantigny,
            Elizabeth Pattey,
            Gilles Bélanger,
            Philippe Rochette,
            Anne Vanasse,
            Claudia Goyer
		
    Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    Institution: Agriculture and Agri-Food Canada,
				Agriculture and Agri-Food Canada,
				Agriculture and Agri-Food Canada,
				Agriculture and Agri-Food Canada,
				Agriculture and Agri-Food Canada,
				CanadaLaval University,
				Agriculture and Agri-Food Canada
		
    ExtendedDescription: It estimates the Snow melt
    ShortDescription: It estimates the Snow melt

    """
    cdef float Snowmelt
    # Snow melt calculation
    Snowmelt=0.0
    if( ps  > 1e-8 ):
        Snowmelt = M / ps
    return  Snowmelt
