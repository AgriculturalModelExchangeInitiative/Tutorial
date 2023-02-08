import numpy 
from math import *
def model_tempmax(float Sdepth_cm=0.0,
                  float prof=0.0,
                  float tmax=0.0,
                  float tminseuil=0.0,
                  float tmaxseuil=0.0):
    """

    Model of Maximum temperature recalculation
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
		
    ExtendedDescription: It estimates the new maximum temperature
    ShortDescription: It estimates the new maximum temperature

    """
    cdef float tmaxrec
    tmaxrec=tmax
    if (Sdepth_cm  > prof):
        if(tmax  < tminseuil):
            tmaxrec=tminseuil
        else:
            if (tmax  > tmaxseuil):
                tmaxrec=tmaxseuil
    else:
        if (Sdepth_cm  > 0.0):
            if (tmax  <= 0.0):
                tmaxrec=tmaxseuil-(1-(Sdepth_cm/prof))*(-tmax)
            else:
                tmaxrec=0.0
    return  tmaxrec
