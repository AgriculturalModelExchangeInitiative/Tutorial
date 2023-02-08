import numpy 
from math import *
def model_snowaccumulation(float tsmax=0.0,
                           float tmax=0.0,
                           float trmax=0.0,
                           float precip=0.0):
    """

    Snowfall accumulation  calculation
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
		
    ExtendedDescription: It simulates the snowfall accumulation
    ShortDescription: It simulates the snowfall accumulation

    """
    cdef float Snowaccu
    # Snow accumulation (unit cm)
    cdef float fs=0.0
    if (tmax < tsmax): fs=1.0
    if ((tmax >= tsmax) and (tmax  <= trmax)):
        fs=(trmax-tmax)/(trmax-tsmax)
    Snowaccu=fs*precip 
    return  Snowaccu
