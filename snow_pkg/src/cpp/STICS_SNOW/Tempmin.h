#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SnowState.h"
#include "SnowRate.h"
#include "SnowAuxiliary.h"
#include "SnowExogenous.h"
using namespace std;
class Tempmin
{
    private:
        double prof;
        double tminseuil;
        double tmaxseuil;
    public:
        Tempmin();
        void  Calculate_Model(SnowState& s, SnowState& s1, SnowRate& r, SnowAuxiliary& a, SnowExogenous& ex);
        double getprof();
        void setprof(double _prof);
        double gettminseuil();
        void settminseuil(double _tminseuil);
        double gettmaxseuil();
        void settmaxseuil(double _tmaxseuil);

};