using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomObjectSI
/// </summary>
public class CustomObjectSI
{
    int integerValue;
    String stringValue;

    public CustomObjectSI(int IntegerValue)
    {
        integerValue = IntegerValue;
    }
    public CustomObjectSI(String StringValue)
    {
        stringValue = StringValue;
    }
    public CustomObjectSI(int IntegerValue, String StringValue)
    {
        integerValue = IntegerValue;
        stringValue = StringValue;
    }
    public override String ToString()
    {
        if (stringValue != null)
            return stringValue;
        else
            return integerValue.ToString();
    }
    public CustomObjectSI()
    {

    }
}