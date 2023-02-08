import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class Snow
{
    private double Tmf;
    public double getTmf()
    { return Tmf; }

    public void setTmf(double _Tmf)
    { this.Tmf= _Tmf; } 
    
    private double SWrf;
    public double getSWrf()
    { return SWrf; }

    public void setSWrf(double _SWrf)
    { this.SWrf= _SWrf; } 
    
    private double tsmax;
    public double gettsmax()
    { return tsmax; }

    public void settsmax(double _tsmax)
    { this.tsmax= _tsmax; } 
    
    private double DKmax;
    public double getDKmax()
    { return DKmax; }

    public void setDKmax(double _DKmax)
    { this.DKmax= _DKmax; } 
    
    private double trmax;
    public double gettrmax()
    { return trmax; }

    public void settrmax(double _trmax)
    { this.trmax= _trmax; } 
    
    private double rho;
    public double getrho()
    { return rho; }

    public void setrho(double _rho)
    { this.rho= _rho; } 
    
    private double Kmin;
    public double getKmin()
    { return Kmin; }

    public void setKmin(double _Kmin)
    { this.Kmin= _Kmin; } 
    
    private double Pns;
    public double getPns()
    { return Pns; }

    public void setPns(double _Pns)
    { this.Pns= _Pns; } 
    
    private double tmaxseuil;
    public double gettmaxseuil()
    { return tmaxseuil; }

    public void settmaxseuil(double _tmaxseuil)
    { this.tmaxseuil= _tmaxseuil; } 
    
    private double tminseuil;
    public double gettminseuil()
    { return tminseuil; }

    public void settminseuil(double _tminseuil)
    { this.tminseuil= _tminseuil; } 
    
    private double prof;
    public double getprof()
    { return prof; }

    public void setprof(double _prof)
    { this.prof= _prof; } 
    
    private double E;
    public double getE()
    { return E; }

    public void setE(double _E)
    { this.E= _E; } 
    
    public Snow() { }
    public void  Calculate_snow(SnowState s, SnowState s1, SnowRate r, SnowAuxiliary a,  SnowExogenous ex)
    {
        //- Name: Snow -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: Snow model
    //            * Author: STICS
    //            * Reference: Snow paper
    //            * Institution: STICS
    //            * Abstract: Snow
        //- inputs:
    //            * name: jul
    //                          ** description : current day of year for the calculation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : INT
    //                          ** default : 0
    //                          ** min : 0
    //                          ** max : 366
    //                          ** unit : d
    //                          ** uri : 
    //            * name: Tmf
    //                          ** description : threshold temperature for snow melting 
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 5000.0
    //                          ** unit : degC
    //                          ** uri : 
    //            * name: SWrf
    //                          ** description : degree-day temperature index for refreezing
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 5000.0
    //                          ** unit : mmW/degC/d
    //                          ** uri : 
    //            * name: tsmax
    //                          ** description : maximum daily air temperature (tmax) below which all precipitation is assumed to be snow
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 1000
    //                          ** unit : degC
    //                          ** uri : 
    //            * name: precip
    //                          ** description : current precipitation
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 5000.0
    //                          ** unit : mmW
    //                          ** uri : 
    //            * name: DKmax
    //                          ** description : difference between the maximum and the minimum melting rates
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 5000.0
    //                          ** unit : mmW/degC/d
    //                          ** uri : 
    //            * name: trmax
    //                          ** description : tmax above which all precipitation is assumed to be rain
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 5000.0
    //                          ** unit : degC
    //                          ** uri : 
    //            * name: tmax
    //                          ** description : current maximum air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 5000.0
    //                          ** unit : degC
    //                          ** uri : 
    //            * name: ps_t1
    //                          ** description : density of snow cover in previous day
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 100.0
    //                          ** unit : kg/m**3
    //                          ** uri : 
    //            * name: Sdepth_t1
    //                          ** description : snow cover depth Calculation in previous day
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 5000.0
    //                          ** unit : m
    //                          ** uri : 
    //            * name: Sdry_t1
    //                          ** description : water in solid state in the snow cover in previous day
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : mmW
    //                          ** uri : 
    //            * name: Swet_t1
    //                          ** description : water in liquid state in the snow cover in previous day
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 100.0
    //                          ** unit : mmW
    //                          ** uri : 
    //            * name: rho
    //                          ** description : The density of the new snow fixed by the user
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 100
    //                          ** min : 
    //                          ** max : 
    //                          ** unit : kg/m**3
    //                          ** uri : 
    //            * name: Kmin
    //                          ** description : minimum melting rate on 21 December
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 5000.0
    //                          ** unit : mmW/degC/d
    //                          ** uri : 
    //            * name: Pns
    //                          ** description : density of the new snow
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 100.0
    //                          ** min : 
    //                          ** max : 
    //                          ** unit : cm/m
    //                          ** uri : 
    //            * name: tmaxseuil
    //                          ** description : maximum temperature when snow cover is higher than prof
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 
    //                          ** max : 
    //                          ** unit : degC
    //                          ** uri : 
    //            * name: tminseuil
    //                          ** description : minimum temperature when snow cover is higher than prof
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 5000.0
    //                          ** unit : degC
    //                          ** uri : 
    //            * name: tmin
    //                          ** description : current minimum air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 100.0
    //                          ** unit : degC
    //                          ** uri : 
    //            * name: prof
    //                          ** description : snow cover threshold for snow insulation 
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 1000
    //                          ** unit : cm
    //                          ** uri : 
    //            * name: E
    //                          ** description : snow compaction parameter
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 
    //                          ** max : 
    //                          ** unit : mm/mm/d
    //                          ** uri : 
        //- outputs:
    //            * name: M
    //                          ** description : snow in the process of melting
    //                          ** variablecategory : rate
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : mmW/d
    //                          ** uri : 
    //            * name: tminrec
    //                          ** description : recalculated minimum temperature
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : degC
    //                          ** uri : 
    //            * name: Sdepth
    //                          ** description : snow cover depth Calculation
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : m
    //                          ** uri : 
    //            * name: Sdry
    //                          ** description : water in solid state in the snow cover
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : mmW
    //                          ** uri : 
    //            * name: Snowaccu
    //                          ** description : snowfall accumulation
    //                          ** variablecategory : rate
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : mmW/d
    //                          ** uri : 
    //            * name: ps
    //                          ** description : density of snow cover
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : kg/m**3
    //                          ** uri : 
    //            * name: Swet
    //                          ** description : water in liquid state in the snow cover
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : mmW
    //                          ** uri : 
    //            * name: tavg
    //                          ** description : mean temperature
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : degC
    //                          ** uri : 
    //            * name: Mrf
    //                          ** description : liquid water in the snow cover in the process of refreezing
    //                          ** variablecategory : rate
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : mmW/d
    //                          ** uri : 
    //            * name: tmaxrec
    //                          ** description : recalculated maximum temperature
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : degC
    //                          ** uri : 
    //            * name: preciprec
    //                          ** description : recalculated precipitation
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : mmW
    //                          ** uri : 
    //            * name: Snowmelt
    //                          ** description : Snow melt
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : m
    //                          ** uri : 
    //            * name: Sdepth_cm
    //                          ** description : snow cover depth in cm
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : cm
    //                          ** uri : 
        int jul = a.getjul();
        double precip = a.getprecip();
        double tmax = a.gettmax();
        double ps_t1 = s1.getps();
        double Sdepth_t1 = s1.getSdepth();
        double Sdry_t1 = s1.getSdry();
        double Swet_t1 = s1.getSwet();
        double tmin = a.gettmin();
        double tavg;
        double M;
        double Mrf;
        double Snowaccu;
        double ps;
        double Snowmelt;
        double Sdepth;
        double Sdepth_cm;
        double Sdry;
        double Swet;
        double tmaxrec;
        double tminrec;
        double preciprec;
        _Snowaccumulation.Calculate_snowaccumulation(s, s1, r, a);
        _Snowdensity.Calculate_snowdensity(s, s1, r, a);
        _Tavg.Calculate_tavg(s, s1, r, a);
        _Melting.Calculate_melting(s, s1, r, a);
        _Refreezing.Calculate_refreezing(s, s1, r, a);
        _Snowmelt.Calculate_snowmelt(s, s1, r, a);
        _Snowdry.Calculate_snowdry(s, s1, r, a);
        _Snowdepth.Calculate_snowdepth(s, s1, r, a);
        _Snowwet.Calculate_snowwet(s, s1, r, a);
        _Snowdepthtrans.Calculate_snowdepthtrans(s, s1, r, a);
        _Preciprec.Calculate_preciprec(s, s1, r, a);
        _Tempmin.Calculate_tempmin(s, s1, r, a);
        _Tempmax.Calculate_tempmax(s, s1, r, a);
        a.settavg(tavg);
        r.setM(M);
        r.setMrf(Mrf);
        r.setSnowaccu(Snowaccu);
        s.setps(ps);
        s.setSnowmelt(Snowmelt);
        s.setSdepth(Sdepth);
        s.setSdepth_cm(Sdepth_cm);
        s.setSdry(Sdry);
        s.setSwet(Swet);
        s.settmaxrec(tmaxrec);
        s.settminrec(tminrec);
        s.setpreciprec(preciprec);
    }
}