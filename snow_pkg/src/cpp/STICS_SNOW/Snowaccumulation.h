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
class Snowaccumulation
{
    private:
        double tsmax;
        double trmax;
    public:
        Snowaccumulation();
        void  Calculate_Model(SnowState& s, SnowState& s1, SnowRate& r, SnowAuxiliary& a, SnowExogenous& ex);
        double gettsmax();
        void settsmax(double _tsmax);
        double gettrmax();
        void settrmax(double _trmax);

};