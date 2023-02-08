import numpy 
from math import *
def model_snowdepth(float Snowmelt=0.0,
                    float Sdepth_t1=0.0,
                    float Snowaccu=0.0,
                    float E=0.0,
                    float rho=100.0):
    """

    Snow cover depth Calculation
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
		
    ExtendedDescription: It calculates the snow cover depth Calculation
    ShortDescription: It calculates the snow cover depth Calculation

    """
    cdef float Sdepth
    # Snow depth calculation
    Sdepth=0.0
    if(Snowmelt  <= (Sdepth_t1+Snowaccu/rho)): 
        Sdepth=(Snowaccu/rho+Sdepth_t1-Snowmelt-(Sdepth_t1*E))
    return  Sdepth
