#ifndef _NETRADIATION_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include <numeric>
#include <algorithm>
#include <array>
#include <map>
#include <tuple>
#include "Netradiation.h"
using namespace std;

Netradiation::Netradiation() { }
double Netradiation::getalbedoCoefficient() {return this-> albedoCoefficient; }
double Netradiation::getstefanBoltzman() {return this-> stefanBoltzman; }
double Netradiation::getelevation() {return this-> elevation; }
void Netradiation::setalbedoCoefficient(double _albedoCoefficient) { this->albedoCoefficient = _albedoCoefficient; }
void Netradiation::setstefanBoltzman(double _stefanBoltzman) { this->stefanBoltzman = _stefanBoltzman; }
void Netradiation::setelevation(double _elevation) { this->elevation = _elevation; }
void Netradiation::Calculate_Model(EnergybalanceState& s, EnergybalanceState& s1, EnergybalanceRate& r, EnergybalanceAuxiliary& a, EnergybalanceExogenous& ex)
{
    //- Name: NetRadiation -Version: 1.0, -Time step: 1
    //- Description:
    //            * Title: NetRadiation Model
    //            * Author: Pierre Martre
    //            * Reference: Modelling energy balance in the wheat crop model SiriusQuality2:
    //            Evapotranspiration and canopy and soil temperature calculations
    //            * Institution: INRA Montpellier
    //            * ExtendedDescription: It is calculated at the surface of the canopy and is givenby the difference between incoming and outgoing radiation of both short
    //                     and long wavelength radiation 
    //            * ShortDescription: It refers as difference between incoming and outgoing radiation of both short
    //            and long wavelength radiation 
    //- inputs:
    //            * name: minTair
    //                          ** description : minimum air temperature
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** min : -30
    //                          ** max : 45
    //                          ** default : 0.7
    //                          ** unit : °C
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    //                          ** inputtype : variable
    //            * name: maxTair
    //                          ** description : maximum air Temperature
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** min : -30
    //                          ** max : 45
    //                          ** default : 7.2
    //                          ** unit : °C
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    //                          ** inputtype : variable
    //            * name: albedoCoefficient
    //                          ** description : albedo Coefficient
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 0.23
    //                          ** min : 0
    //                          ** max : 1
    //                          ** unit : 
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    //                          ** inputtype : parameter
    //            * name: stefanBoltzman
    //                          ** description : stefan Boltzman constant
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 4.903E-09
    //                          ** min : 0
    //                          ** max : 1
    //                          ** unit : 
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    //                          ** inputtype : parameter
    //            * name: elevation
    //                          ** description : elevation
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 0
    //                          ** min : -500
    //                          ** max : 10000
    //                          ** unit : m
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    //                          ** inputtype : parameter
    //            * name: solarRadiation
    //                          ** description : solar Radiation
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** default : 3
    //                          ** min : 0
    //                          ** max : 1000
    //                          ** unit : MJ m-2 d-1
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    //                          ** inputtype : variable
    //            * name: vaporPressure
    //                          ** description : vapor Pressure
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** default : 6.1
    //                          ** min : 0
    //                          ** max : 1000
    //                          ** unit : hPa
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    //                          ** inputtype : variable
    //            * name: extraSolarRadiation
    //                          ** description : extra Solar Radiation
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** default : 11.7
    //                          ** min : 0
    //                          ** max : 1000
    //                          ** unit : MJ m2 d-1
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    //                          ** inputtype : variable
    //- outputs:
    //            * name: netRadiation
    //                          ** description :  net radiation 
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** min : 0
    //                          ** max : 5000
    //                          ** unit : MJ m-2 d-1
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    //            * name: netOutGoingLongWaveRadiation
    //                          ** description : net OutGoing Long Wave Radiation 
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** min : 0
    //                          ** max : 5000
    //                          ** unit : g m-2 d-1
    //                          ** uri : http://www1.clermont.inra.fr/siriusquality/?page_id=547
    double minTair = a.getminTair();
    double maxTair = a.getmaxTair();
    double solarRadiation = a.getsolarRadiation();
    double vaporPressure = a.getvaporPressure();
    double extraSolarRadiation = a.getextraSolarRadiation();
    double netRadiation;
    double netOutGoingLongWaveRadiation;
    double Nsr;
    double clearSkySolarRadiation;
    double averageT;
    double surfaceEmissivity;
    double cloudCoverFactor;
    double Nolr;
    Nsr = (1.0 - albedoCoefficient) * solarRadiation;
    clearSkySolarRadiation = (0.75 + (2 * pow(10.0, -5) * elevation)) * extraSolarRadiation;
    averageT = (pow(maxTair + 273.16, 4) + pow(minTair + 273.16, 4)) / 2.0;
    surfaceEmissivity = 0.34 - (0.14 * sqrt(vaporPressure / 10.0));
    cloudCoverFactor = 1.35 * (solarRadiation / clearSkySolarRadiation) - 0.35;
    Nolr = stefanBoltzman * averageT * surfaceEmissivity * cloudCoverFactor;
    netRadiation = Nsr - Nolr;
    netOutGoingLongWaveRadiation = Nolr;
    a.setnetRadiation(netRadiation);
    a.setnetOutGoingLongWaveRadiation(netOutGoingLongWaveRadiation);
}
#endif