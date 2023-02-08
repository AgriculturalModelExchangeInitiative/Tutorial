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
class Snowdepthtrans
{
    private:
        double Pns;
    public:
        Snowdepthtrans();
        void  Calculate_Model(SnowState& s, SnowState& s1, SnowRate& r, SnowAuxiliary& a, SnowExogenous& ex);
        double getPns();
        void setPns(double _Pns);

};