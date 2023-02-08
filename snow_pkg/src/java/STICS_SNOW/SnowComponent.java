public class SnowComponent
{
    
    public SnowComponent() { }

    Melting _Melting = new Melting();
    Refreezing _Refreezing = new Refreezing();
    Snowaccumulation _Snowaccumulation = new Snowaccumulation();
    Snowdensity _Snowdensity = new Snowdensity();
    Snowdepth _Snowdepth = new Snowdepth();
    Snowdepthtrans _Snowdepthtrans = new Snowdepthtrans();
    Snowdry _Snowdry = new Snowdry();
    Snowmelt _Snowmelt = new Snowmelt();
    Snowwet _Snowwet = new Snowwet();
    Tavg _Tavg = new Tavg();
    Tempmax _Tempmax = new Tempmax();
    Tempmin _Tempmin = new Tempmin();
    Preciprec _Preciprec = new Preciprec();

    public double getTmf()
    { return _Refreezing.getTmf(); }
    public void setTmf(double Tmf)
    { _Refreezing.setTmf(Tmf);
        _Melting.setTmf(Tmf); } 

    public double getSWrf()
    { return _Refreezing.getSWrf(); }
    public void setSWrf(double SWrf)
    { _Refreezing.setSWrf(SWrf); } 

    public double gettsmax()
    { return _Snowaccumulation.gettsmax(); }
    public void settsmax(double tsmax)
    { _Snowaccumulation.settsmax(tsmax); } 

    public double getDKmax()
    { return _Melting.getDKmax(); }
    public void setDKmax(double DKmax)
    { _Melting.setDKmax(DKmax); } 

    public double gettrmax()
    { return _Snowaccumulation.gettrmax(); }
    public void settrmax(double trmax)
    { _Snowaccumulation.settrmax(trmax); } 

    public double getrho()
    { return _Preciprec.getrho(); }
    public void setrho(double rho)
    { _Preciprec.setrho(rho);
        _Snowdepth.setrho(rho); } 

    public double getKmin()
    { return _Melting.getKmin(); }
    public void setKmin(double Kmin)
    { _Melting.setKmin(Kmin); } 

    public double getPns()
    { return _Snowdepthtrans.getPns(); }
    public void setPns(double Pns)
    { _Snowdepthtrans.setPns(Pns); } 

    public double gettmaxseuil()
    { return _Tempmin.gettmaxseuil(); }
    public void settmaxseuil(double tmaxseuil)
    { _Tempmin.settmaxseuil(tmaxseuil);
        _Tempmax.settmaxseuil(tmaxseuil); } 

    public double gettminseuil()
    { return _Tempmin.gettminseuil(); }
    public void settminseuil(double tminseuil)
    { _Tempmin.settminseuil(tminseuil);
        _Tempmax.settminseuil(tminseuil); } 

    public double getprof()
    { return _Tempmin.getprof(); }
    public void setprof(double prof)
    { _Tempmin.setprof(prof);
        _Tempmax.setprof(prof); } 

    public double getE()
    { return _Snowdepth.getE(); }
    public void setE(double E)
    { _Snowdepth.setE(E); } 
    public void  Calculate_snow(SnowState s, SnowState s1, SnowRate r, SnowAuxiliary a, SnowExogenous ex)
    {
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
    }
    private double Tmf;
    private double SWrf;
    private double tsmax;
    private double DKmax;
    private double trmax;
    private double rho;
    private double Kmin;
    private double Pns;
    private double tmaxseuil;
    private double tminseuil;
    private double prof;
    private double E;
    public SnowComponent(SnowComponent toCopy) // copy constructor 
    {
        this.Tmf = toCopy.getTmf();
        this.SWrf = toCopy.getSWrf();
        this.tsmax = toCopy.gettsmax();
        this.DKmax = toCopy.getDKmax();
        this.trmax = toCopy.gettrmax();
        this.rho = toCopy.getrho();
        this.Kmin = toCopy.getKmin();
        this.Pns = toCopy.getPns();
        this.tmaxseuil = toCopy.gettmaxseuil();
        this.tminseuil = toCopy.gettminseuil();
        this.prof = toCopy.getprof();
        this.E = toCopy.getE();

    }
}