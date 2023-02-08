from datetime import datetime
from math import *
from STICS_SNOW.Melting import model_melting
from STICS_SNOW.Refreezing import model_refreezing
from STICS_SNOW.Snowaccumulation import model_snowaccumulation
from STICS_SNOW.Snowdensity import model_snowdensity
from STICS_SNOW.Snowdepth import model_snowdepth
from STICS_SNOW.Snowdepthtrans import model_snowdepthtrans
from STICS_SNOW.Snowdry import model_snowdry
from STICS_SNOW.Snowmelt import model_snowmelt
from STICS_SNOW.Snowwet import model_snowwet
from STICS_SNOW.Tavg import model_tavg
from STICS_SNOW.Tempmax import model_tempmax
from STICS_SNOW.Tempmin import model_tempmin
from STICS_SNOW.Preciprec import model_preciprec
def model_snow(int jul=0,
      float tmaxseuil=0.0,
      float tminseuil=0.0,
      float prof=0.0,
      float tmin=0.0,
      float tmax=0.0,
      float precip=0.0,
      float Sdry_t1=0.0,
      float E=0.0,
      float rho=100.0,
      float Sdepth_t1=0.0,
      float Pns=100.0,
      float Swet_t1=0.0,
      float Kmin=0.0,
      float Tmf=0.0,
      float SWrf=0.0,
      float tsmax=0.0,
      float DKmax=0.0,
      float trmax=0.0,
      float ps_t1=0.0):
    cdef float tavg
    cdef float M
    cdef float Mrf
    cdef float Snowaccu
    cdef float ps
    cdef float Snowmelt
    cdef float Sdepth
    cdef float Sdepth_cm
    cdef float Sdry
    cdef float Swet
    cdef float tmaxrec
    cdef float tminrec
    cdef float preciprec
    Snowaccu = model_snowaccumulation( tsmax,tmax,trmax,precip)
    ps = model_snowdensity( ps_t1,Sdepth_t1,Sdry_t1,Swet_t1)
    tavg = model_tavg( tmin,tmax)
    M = model_melting( jul,Tmf,DKmax,Kmin,tavg)
    Mrf = model_refreezing( tavg,Tmf,SWrf)
    Snowmelt = model_snowmelt( ps,M)
    Sdry = model_snowdry( Sdry_t1,Snowaccu,Mrf,M)
    Sdepth = model_snowdepth( Snowmelt,Sdepth_t1,Snowaccu,E,rho)
    Swet = model_snowwet( Swet_t1,precip,Snowaccu,Mrf,M,Sdry)
    Sdepth_cm = model_snowdepthtrans( Sdepth,Pns)
    preciprec = model_preciprec( Sdry_t1,Sdry,Swet,Swet_t1,Sdepth_t1,Sdepth,Mrf,precip,Snowaccu,rho)
    tminrec = model_tempmin( Sdepth_cm,prof,tmin,tminseuil,tmaxseuil)
    tmaxrec = model_tempmax( Sdepth_cm,prof,tmax,tminseuil,tmaxseuil)
    return tmaxrec, ps, Mrf, tavg, Swet, Snowmelt, Snowaccu, Sdry, Sdepth, tminrec, M, preciprec, Sdepth_cm

def init_snow(int jul=0,
                float tmaxseuil=0.0,
                float tminseuil=0.0,
                float prof=0.0,
                float tmin=0.0,
                float tmax=0.0,
                float precip=0.0,
                float E=0.0,
                float rho=100.0,
                float Pns=100.0,
                float Kmin=0.0,
                float Tmf=0.0,
                float SWrf=0.0,
                float tsmax=0.0,
                float DKmax=0.0,
                float trmax=0.0):

    cdef float Sdry_t1 = 0.0
    cdef float Sdepth_t1 = 0.0
    cdef float Swet_t1 = 0.0
    cdef float ps_t1 = 0.0
    Sdry_t1 = 0.0
    Sdepth_t1 = 0.0
    Swet_t1 = 0.0
    ps_t1 = 0.0
    return  Sdry_t1, Sdepth_t1, Swet_t1, ps_t1
