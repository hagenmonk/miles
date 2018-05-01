

using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using System.IO;

public class Miles
{

    private Dictionary<String, int> mileStorage;
    private int currentMaxUnit;  //最大單位
    private int currentMaxValue; //最大單位數值

    public Miles()
    {
        mileStorage = new Dictionary<string, int>();
        currentMaxUnit = 0;
        currentMaxValue = 0;
    }

    //取得總路程
    public Dictionary<string, int> getAll
    {
        get
        {
            return mileStorage;
        }
    }

    //取得最大單位
    public int getMaxUnit
    {
        get
        {
            return currentMaxUnit;
        }
    }

    //取得最大單位內的數值
    public int getMaxValue
    {
        get
        {
            return currentMaxValue;
        }
    }

    //修改特定單位數值
    public void addValueByKey(string key, int value)
    {
        if(mileStorage.ContainsKey(key))
        {
            mileStorage[key] = value;
        }
    }

    //藉由key找出該單位路程數
    public int getValueByKey(string key)
    {
        int result = 0;
        if(mileStorage.ContainsKey(key))
        {
            result = mileStorage[key];
        }

        return result;
    }

    /**
     *<summary> 轉單位為key </summary>
     */
    public string convertUnitToKey(int unit)
    {
        switch(unit)
        {
            case 0:
                return "";
            case 1:
                return "K";
            case 2:
                return "M";
            case 3:
                return "G";
            case 4:
                return "T";
            case 5:
                return "P";
            case 6:
                return "E";
            case 7:
                return "Z";
            case 8:
                return "Y";
            default:
                return null;
        }
    }


    public static Miles operator + (Miles a , Miles b)
    {
        Miles result = new Miles();

        if (Miles.compare(a, b))
        {
            Dictionary<string, int> addend = b.getAll;
            foreach(var mile in a.getAll)
            {
                result.addValueByKey(mile.Key, mile.Value + addend[mile.Key]);
            }
        }
        else
        {
            Dictionary<string, int> addend = a.getAll;
            foreach (var mile in b.getAll)
            {
                result.addValueByKey(mile.Key, mile.Value + addend[mile.Key]);
            }
        }

        return result;
    }

    //比較a跟b,如果a大於b回傳true
    public static Boolean compare (Miles a, Miles b)
    {
        if(a.getMaxUnit > b.getMaxUnit)
        {
            return true;
        }
        else if(a.getMaxUnit == b.getMaxUnit)
        {
            if(a.getMaxValue > b.getMaxValue )
            {
                return true;
            }
        }

        return false;
    }
}