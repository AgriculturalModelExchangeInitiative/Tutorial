import numpy 
from math import *
def model_refreezing(float tavg=0.0,
                     float Tmf=0.0,
                     float SWrf=0.0):
    """

    Snowfall refreezing  Model
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
		
    ExtendedDescription: It simulates the snow in the process of refreezing
    ShortDescription: It simulates the snow in the process of refreezing

    """
    cdef float Mrf
    # Mrf calculation
    Mrf=0.0
    if ( tavg  < Tmf ): 
        Mrf = SWrf * ( Tmf - tavg )
    return  Mrf
