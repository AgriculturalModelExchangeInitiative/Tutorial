import numpy 
from math import *
def model_melting(int jul=0,
                  float Tmf=0.5,
                  float DKmax=0.0,
                  float Kmin=0.0,
                  float tavg=0.0):
    """

    Snow melting Model
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
		
    ExtendedDescription: It simulates the snow in the process of melting
    ShortDescription: It simulates the snow in the process of melting

    """
    cdef float M
    # M calculation
    cdef float K
    M = 0.0
    K=(DKmax/2.0)*(-sin((2.0*pi*float(jul)/366.0)+(9.0/16.0)*pi)) +Kmin+(DKmax/2.0)
    if ( tavg  > Tmf ): 
        M = K * ( tavg - Tmf )
    return  M
