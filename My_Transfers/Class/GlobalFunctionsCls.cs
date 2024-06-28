using Microsoft.IdentityModel.Tokens;
using System;
using System.Globalization;

namespace TestRecordset.Global;
public static class GlobalFunctionsCls
{
    public static decimal GetDecimalValue(object oVar)
    {
        if (oVar == null)
        {
            return 0;
        }
        else if (oVar == "")
        {
            return 0;
        }
        else if (!oVar.ToString().All(char.IsNumber))
        {
            return 0;
        }
        else
        {
            return decimal.Parse(oVar.ToString());
        }
    }
    public static int GetIntValue(object oVar)
    {
        if (oVar == null)    return 0;
        else if (oVar == "")   return 0;
        else if (!oVar.ToString().All(char.IsNumber))   return 0;
        else   return int.Parse(oVar.ToString());
        
    }
    public static bool GetBooleanValue(object oVar)
    {
        if (oVar == null)    return false;
        else if (oVar == "")   return false;
        else if (oVar.ToString() == "0" || oVar.ToString() == "0.0")   return false;
        else if (oVar.ToString() == "1" || oVar.ToString() == "1.0")   return true;
        else   return bool.Parse(oVar.ToString());
         
    }
    public static DateTime GetDateTimeValue(object oVar)
    {
        if (oVar == null || string.IsNullOrEmpty(oVar.ToString()) || string.IsNullOrWhiteSpace(oVar.ToString())) return DateTime.Parse("01/01/1900");
        else return DateTime.Parse(oVar.ToString(), new CultureInfo("ar-EG"));
    }
    public static string GetStringValue(object oVar)
    {
        if (oVar == null || string.IsNullOrEmpty(oVar.ToString()) || string.IsNullOrWhiteSpace(oVar.ToString()))
        {
            return "";
        }
        else
        {
            return oVar.ToString();
        }

    }
}
