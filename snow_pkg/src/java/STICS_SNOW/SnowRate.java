import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SnowRate
{
    private double M;
    private double Snowaccu;
    private double Mrf;
    
    public SnowRate() { }
    
    public SnowRate(SnowRate toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.M = toCopy.M;
            this.Snowaccu = toCopy.Snowaccu;
            this.Mrf = toCopy.Mrf;
        }
    }
    public double getM()
    { return M; }

    public void setM(double _M)
    { this.M= _M; } 
    
    public double getSnowaccu()
    { return Snowaccu; }

    public void setSnowaccu(double _Snowaccu)
    { this.Snowaccu= _Snowaccu; } 
    
    public double getMrf()
    { return Mrf; }

    public void setMrf(double _Mrf)
    { this.Mrf= _Mrf; } 
    
}