import numpy 
from math import *
def model_tavg(float tmin=0.0,
               float tmax=0.0):
    """

    Mean temperature calculation
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
		
    ExtendedDescription: Calculate the daily mean temperature
    ShortDescription: Calculate the daily mean temperature

    """
    cdef float tavg
    tavg = (tmin + tmax)/2
    return  tavg
