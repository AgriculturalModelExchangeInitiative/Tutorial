from . import SnowComponent
import pandas as pd
import os

def simulation(datafile, vardata, params, init):
    rep = os.path.dirname(datafile)
    out = os.path.join(rep, 'output.csv')
    df = pd.read_csv(datafile, sep = ";")

    # inputs values
    t_jul = df[vardata.loc[vardata["Variables"]=="jul","Data columns"].iloc[0]].to_list()
    t_precip = df[vardata.loc[vardata["Variables"]=="precip","Data columns"].iloc[0]].to_list()
    t_tmax = df[vardata.loc[vardata["Variables"]=="tmax","Data columns"].iloc[0]].to_list()
    t_tmin = df[vardata.loc[vardata["Variables"]=="tmin","Data columns"].iloc[0]].to_list()

    #parameters
    Tmf = params.loc[params["name"]=="Tmf", "value"].iloc[0]
    SWrf = params.loc[params["name"]=="SWrf", "value"].iloc[0]
    tsmax = params.loc[params["name"]=="tsmax", "value"].iloc[0]
    DKmax = params.loc[params["name"]=="DKmax", "value"].iloc[0]
    trmax = params.loc[params["name"]=="trmax", "value"].iloc[0]
    rho = params.loc[params["name"]=="rho", "value"].iloc[0]
    Kmin = params.loc[params["name"]=="Kmin", "value"].iloc[0]
    Pns = params.loc[params["name"]=="Pns", "value"].iloc[0]
    tmaxseuil = params.loc[params["name"]=="tmaxseuil", "value"].iloc[0]
    tminseuil = params.loc[params["name"]=="tminseuil", "value"].iloc[0]
    prof = params.loc[params["name"]=="prof", "value"].iloc[0]
    E = params.loc[params["name"]=="E", "value"].iloc[0]

    #initialization
    ps_t1 = init.loc[init["name"]=="ps_t1", "value"].iloc[0]
    Sdepth_t1 = init.loc[init["name"]=="Sdepth_t1", "value"].iloc[0]
    Sdry_t1 = init.loc[init["name"]=="Sdry_t1", "value"].iloc[0]
    Swet_t1 = init.loc[init["name"]=="Swet_t1", "value"].iloc[0]

    #outputs
    output_names = ["M","tminrec","Sdepth","Sdry","Snowaccu","ps","Swet","tavg","Mrf","tmaxrec","preciprec","Snowmelt","Sdepth_cm"]

    df_out = pd.DataFrame(columns = output_names)
    for i in range(0,len(df.index)-1):
        jul = t_jul[i]
        precip = t_precip[i]
        tmax = t_tmax[i]
        tmin = t_tmin[i]
        M,tminrec,Sdepth,Sdry,Snowaccu,ps,Swet,tavg,Mrf,tmaxrec,preciprec,Snowmelt,Sdepth_cm= SnowComponent.model_snow(jul,Tmf,SWrf,tsmax,precip,DKmax,trmax,tmax,ps_t1,Sdepth_t1,Sdry_t1,Swet_t1,rho,Kmin,Pns,tmaxseuil,tminseuil,tmin,prof,E)

        ps_t1 = ps
        Sdepth_t1 = Sdepth
        Sdry_t1 = Sdry
        Swet_t1 = Swet
        df_out.loc[i] = [M,tminrec,Sdepth,Sdry,Snowaccu,ps,Swet,tavg,Mrf,tmaxrec,preciprec,Snowmelt,Sdepth_cm]
    df_out.insert(0, 'date', pd.to_datetime(df.year*10000 + df.month*100 + df.day, format='%Y%m%d'), True)
    df_out.set_index("date", inplace=True)
    df_out.to_csv(out, sep=";")
    return df_out