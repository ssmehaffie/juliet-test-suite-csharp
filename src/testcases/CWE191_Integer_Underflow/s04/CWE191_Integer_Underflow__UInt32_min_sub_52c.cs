/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE191_Integer_Underflow__UInt32_min_sub_52c.cs
Label Definition File: CWE191_Integer_Underflow.label.xml
Template File: sources-sinks-52c.tmpl.cs
*/
/*
 * @description
 * CWE: 191 Integer Underflow
 * BadSource: min Set data to the min value for uint
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: sub
 *    GoodSink: Ensure there will not be an underflow before subtracting 1 from data
 *    BadSink : Subtract 1 from data, which can cause an Underflow
 * Flow Variant: 52 Data flow: data passed as an argument from one method to another to another in three different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE191_Integer_Underflow
{
class CWE191_Integer_Underflow__UInt32_min_sub_52c
{
#if (!OMITBAD)
    public static void BadSink(uint data )
    {
        /* POTENTIAL FLAW: if data == uint.MinValue, this will overflow */
        uint result = (uint)(data - 1);
        IO.WriteLine("result: " + result);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(uint data )
    {
        /* POTENTIAL FLAW: if data == uint.MinValue, this will overflow */
        uint result = (uint)(data - 1);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(uint data )
    {
        /* FIX: Add a check to prevent an overflow from occurring */
        if (data > uint.MinValue)
        {
            uint result = (uint)(data - 1);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too small to perform subtraction.");
        }
    }
#endif
}
}