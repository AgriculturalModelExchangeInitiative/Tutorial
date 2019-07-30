using System;
using System.Collections.Generic;
public class Shootnumber
{
    private double _sowingDensity;
    public double sowingDensity
    {
        get
        {
            return this._sowingDensity;
        }
        set
        {
            this._sowingDensity= value;
        } 
    }
    private double _targetFertileShoot;
    public double targetFertileShoot
    {
        get
        {
            return this._targetFertileShoot;
        }
        set
        {
            this._targetFertileShoot= value;
        } 
    }
    public Shootnumber()
    {
           
    }
    
    public void  Calculate_shootnumber(state s, rate r, auxiliary a)
    {
        //- Description:
    //            - Model Name: CalculateShootNumber Model
    //            - Author: Pierre MARTRE
    //            - Reference: Modeling development phase in the 
    //                Wheat Simulation Model SiriusQuality.
    //                See documentation at http://www1.clermont.inra.fr/siriusquality/?page_id=427
    //            - Institution: INRA/LEPSE Montpellier
    //            - Abstract: calculate the shoot number and update the related variables if needed
        //- inputs:
    //            - name: canopyShootNumber
    //                          - description : shoot number for the whole canopy
    //                          - variablecategory : state
    //                          - datatype : DOUBLE
    //                          - min : 0
    //                          - max : 10000
    //                          - default : 288.0
    //                          - unit : shoot m-2
    //                          - inputtype : variable
    //            - name: leafNumber
    //                          - description : Leaf number 
    //                          - variablecategory : state
    //                          - inputtype : variable
    //                          - datatype : DOUBLE
    //                          - min : 0
    //                          - max : 10000
    //                          - default : 0
    //                          - unit : leaf
    //            - name: sowingDensity
    //                          - description : number of plant /m²
    //                          - parametercategory : species
    //                          - datatype : DOUBLE
    //                          - min : 0
    //                          - max : 500
    //                          - default : 288.0
    //                          - unit : plant m-2
    //                          - inputtype : parameter
    //            - name: targetFertileShoot
    //                          - description : max value of shoot number for the canopy
    //                          - parametercategory : species
    //                          - datatype : DOUBLE
    //                          - min : 280
    //                          - max : 1000
    //                          - default : 600.0
    //                          - unit : shoot
    //                          - inputtype : variable
    //            - name: tilleringProfile
    //                          - description :  store the amount of new tiller created at each time a new tiller appears
    //                          - variablecategory : state
    //                          - datatype : DOUBLELIST
    //                          - default : [288.0]
    //                          - unit : 
    //                          - inputtype : variable
    //            - name: leafTillerNumberArray
    //                          - description : store the number of tiller for each leaf layer
    //                          - variablecategory : state
    //                          - datatype : INTLIST
    //                          - unit : leaf
    //                          - default : [1]
    //                          - inputtype : variable
    //            - name: tillerNumber
    //                          - description :  Number of tiller which appears
    //                          - variablecategory : state
    //                          - datatype : INT
    //                          - min : 0
    //                          - max : 10000
    //                          - default : 1
    //                          - unit : 
    //                          - inputtype : variable
        //- outputs:
    //            - name: averageShootNumberPerPlant
    //                          - description : average shoot number per plant in the canopy
    //                          - variablecategory : state
    //                          - datatype : DOUBLE
    //                          - min : 0
    //                          - max : 10000
    //                          - unit : shoot m-2
    //            - name: canopyShootNumber
    //                          - description : shoot number for the whole canopy
    //                          - variablecategory : state
    //                          - datatype : DOUBLE
    //                          - min : 0
    //                          - max : 10000
    //                          - unit : shoot m-2
    //            - name: leafTillerNumberArray
    //                          - description : store the number of tiller for each leaf layer
    //                          - variablecategory : state
    //                          - datatype : INTLIST
    //                          - unit : leaf
    //            - name: tilleringProfile
    //                          - description :  store the amount of new tiller created at each time a new tiller appears
    //                          - variablecategory : state
    //                          - datatype : DOUBLELIST
    //                          - unit : 
    //            - name: tillerNumber
    //                          - description :  store the amount of new tiller created at each time a new tiller appears
    //                          - variablecategory : state
    //                          - datatype : INT
    //                          - min : 0
    //                          - max : 10000
    //                          - unit : 
        double canopyShootNumber = s.canopyShootNumber;
        double leafNumber = s.leafNumber;
        List<double> tilleringProfile = s.tilleringProfile;
        List<int> leafTillerNumberArray = s.leafTillerNumberArray;
        int tillerNumber = s.tillerNumber;
        double averageShootNumberPerPlant;
        double oldCanopyShootNumber;
        int emergedLeaves;
        int shoots;
        int i;
        oldCanopyShootNumber = canopyShootNumber;
        emergedLeaves = (int)(Math.Max(1.0d, Math.Ceiling(leafNumber - 1.0d)));
        shoots = fibonacci(emergedLeaves);
        canopyShootNumber = Math.Min(shoots * sowingDensity, targetFertileShoot);
        averageShootNumberPerPlant = canopyShootNumber / sowingDensity;
        if (canopyShootNumber != oldCanopyShootNumber)
        {
            tilleringProfile.Add(canopyShootNumber - oldCanopyShootNumber);
        }
        tillerNumber = tilleringProfile.Count;
        for (i=leafTillerNumberArray.Count ; i<(int)(Math.Ceiling(leafNumber)) ; i+=1)
        {
            leafTillerNumberArray.Add(tillerNumber);
        }
        s.canopyShootNumber= canopyShootNumber;
        s.tilleringProfile= tilleringProfile;
        s.leafTillerNumberArray= leafTillerNumberArray;
        s.tillerNumber= tillerNumber;
        s.averageShootNumberPerPlant= averageShootNumberPerPlant;
    }
    public static int fibonacci(int n)
    {
        int result = 0;
        int b = 1;
        int i;
        int temp;
        for (i=0 ; i<n ; i+=1)
        {
            temp = result;
            result = b;
            b = temp + b;
        }
        return result;
    }
}