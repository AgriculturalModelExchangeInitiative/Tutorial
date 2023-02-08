import numpy 
from math import *
def model_snowdepthtrans(float Sdepth=0.0,
                         float Pns=100.0):
    """

    Snow cover depth conversion
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
		
    ExtendedDescription: It converts the snow cover depth in cm
    ShortDescription: It converts the snow cover depth in cm

    """
    cdef float Sdepth_cm
    Sdepth_cm=Sdepth*Pns
    return  Sdepth_cm
