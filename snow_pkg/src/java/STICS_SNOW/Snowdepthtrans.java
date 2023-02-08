import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class Snowdepthtrans
{
    private double Pns;
    public double getPns()
    { return Pns; }

    public void setPns(double _Pns)
    { this.Pns= _Pns; } 
    
    public Snowdepthtrans() { }
    public void  Calculate_snowdepthtrans(SnowState s, SnowState s1, SnowRate r, SnowAuxiliary a,  SnowExogenous ex)
    {
        //- Name: SnowDepthTrans -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: snow cover depth conversion
    //            * Author: STICS
    //            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    //            * Institution: INRA
    //            * Abstract: snow cover depth in cm
        //- inputs:
    //            * name: Sdepth
    //                          ** description : snow cover depth Calculation
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** default : 0.0
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : m
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
        //- outputs:
    //            * name: Sdepth_cm
    //                          ** description : snow cover depth in cm
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** min : 0.0
    //                          ** max : 500.0
    //                          ** unit : cm
    //                          ** uri : 
        double Sdepth = s.getSdepth();
        double Sdepth_cm;
        Sdepth_cm = Sdepth * Pns;
        s.setSdepth_cm(Sdepth_cm);
    }
}