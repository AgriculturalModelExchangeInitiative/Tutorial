import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SnowAuxiliary
{
    private int jul;
    private double precip;
    private double tmax;
    private double tmin;
    private double tavg;
    
    public SnowAuxiliary() { }
    
    public SnowAuxiliary(SnowAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.jul = toCopy.jul;
            this.precip = toCopy.precip;
            this.tmax = toCopy.tmax;
            this.tmin = toCopy.tmin;
            this.tavg = toCopy.tavg;
        }
    }
    public int getjul()
    { return jul; }

    public void setjul(int _jul)
    { this.jul= _jul; } 
    
    public double getprecip()
    { return precip; }

    public void setprecip(double _precip)
    { this.precip= _precip; } 
    
    public double gettmax()
    { return tmax; }

    public void settmax(double _tmax)
    { this.tmax= _tmax; } 
    
    public double gettmin()
    { return tmin; }

    public void settmin(double _tmin)
    { this.tmin= _tmin; } 
    
    public double gettavg()
    { return tavg; }

    public void settavg(double _tavg)
    { this.tavg= _tavg; } 
    
}