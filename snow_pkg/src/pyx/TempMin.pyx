import numpy 
from math import *
def model_tempmin(float Sdepth_cm=0.0,
                  float prof=0.0,
                  float tmin=0.0,
                  float tminseuil=0.0,
                  float tmaxseuil=0.0):
    """

    Model of Minimum temperature recalculation
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
		
    ExtendedDescription: It estimates the minimum temperature
    ShortDescription: It estimates the new minimum temperature

    """
    cdef float tminrec
    tminrec=tmin
    if (Sdepth_cm  > prof):
        if(tmin  < tminseuil):
            tminrec=tminseuil
        else:
            if (tmin  > tmaxseuil):
                tminrec=tmaxseuil
    else:
        if (Sdepth_cm  > 0.0) :
            tminrec=tminseuil-(1-(Sdepth_cm/prof))*(abs(tmin)+tminseuil)
    return  tminrec
