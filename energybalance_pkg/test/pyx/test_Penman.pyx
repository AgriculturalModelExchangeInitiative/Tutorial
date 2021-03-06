#'Test generation'

from Penman import *
from math import *
import numpy 



def test_test1():
    params= Penman(
    evapoTranspirationPriestlyTaylor = 449.367,
    Alpha = 1.5,
    lambdaV = 2.454,
    hslope = 0.584,
    VPDair = 2.19,
     )
    evapoTranspirationPenman_estimated = round(params, 3)
    evapoTranspirationPenman_computed = 830.958
    assert (evapoTranspirationPenman_estimated == evapoTranspirationPenman_computed)