import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class SnowState
{
    private double tminrec;
    private double Sdepth;
    private double Sdry;
    private double ps;
    private double Swet;
    private double tmaxrec;
    private double preciprec;
    private double Snowmelt;
    private double Sdepth_cm;
    
    public SnowState() { }
    
    public SnowState(SnowState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.tminrec = toCopy.tminrec;
            this.Sdepth = toCopy.Sdepth;
            this.Sdry = toCopy.Sdry;
            this.ps = toCopy.ps;
            this.Swet = toCopy.Swet;
            this.tmaxrec = toCopy.tmaxrec;
            this.preciprec = toCopy.preciprec;
            this.Snowmelt = toCopy.Snowmelt;
            this.Sdepth_cm = toCopy.Sdepth_cm;
        }
    }
    public double gettminrec()
    { return tminrec; }

    public void settminrec(double _tminrec)
    { this.tminrec= _tminrec; } 
    
    public double getSdepth()
    { return Sdepth; }

    public void setSdepth(double _Sdepth)
    { this.Sdepth= _Sdepth; } 
    
    public double getSdry()
    { return Sdry; }

    public void setSdry(double _Sdry)
    { this.Sdry= _Sdry; } 
    
    public double getps()
    { return ps; }

    public void setps(double _ps)
    { this.ps= _ps; } 
    
    public double getSwet()
    { return Swet; }

    public void setSwet(double _Swet)
    { this.Swet= _Swet; } 
    
    public double gettmaxrec()
    { return tmaxrec; }

    public void settmaxrec(double _tmaxrec)
    { this.tmaxrec= _tmaxrec; } 
    
    public double getpreciprec()
    { return preciprec; }

    public void setpreciprec(double _preciprec)
    { this.preciprec= _preciprec; } 
    
    public double getSnowmelt()
    { return Snowmelt; }

    public void setSnowmelt(double _Snowmelt)
    { this.Snowmelt= _Snowmelt; } 
    
    public double getSdepth_cm()
    { return Sdepth_cm; }

    public void setSdepth_cm(double _Sdepth_cm)
    { this.Sdepth_cm= _Sdepth_cm; } 
    
}