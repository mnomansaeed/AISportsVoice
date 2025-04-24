using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Collections;

namespace Utility
{
    public static class GeneralExtension
    {
        public static Hashtable ConvertHashTable(this object Value)
        {

            return (Hashtable)Value;

        }

        //public static Hashtable ConvertDictionaryToHashTable(this object Value, int count)
        //{
        //    Hashtable objHash = new Hashtable();

        //    for(int iLoop=0;iLoop<=count;iLoop++)
        //    {
        //        objHash.Add(
        //    }


        //    return objHash;

        //}
        public static double ConvertDouble(this object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(Value);
            }
        }
        public static string ConvertString(this object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {
                return "";
            }
            else
            {
                return Convert.ToString(Value);
            }
        }
        public static byte ConvertByte(this object Value)
        {

            return Convert.ToByte(Value);

        }
        public static char ConvertChar(this object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {
                return Convert.ToChar("");
            }
            else
            {
                return Convert.ToChar(Value);
            }
        }
        public static DateTime ConvertDateTime(this object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {

                return Convert.ToDateTime("01/01/1753");
            }
            else
            {
                return Convert.ToDateTime(Value);
            }
        }
        public static Guid ConvertGUID(this object Value)
        {
            return (Guid)Value;
        }
        public static DateTimeOffset ConvertDateTimeOffset(this object Value)
        {

            return (DateTimeOffset)Value;

        }

        public static TimeSpan ConvertTimeSpan(this object Value)
        {

            return (TimeSpan)Value;

        }

        public static decimal ConvertDecimal(this object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(Value);
            }
        }
        public static short ConvertShort(this object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt16(Value);
            }
        }
        public static int ConvertInteger(this object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(Value);
            }
        }
        public static long ConvertLong(this object Value)
        {
            if (Value == null || Value== DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(Value);
            }

        }
        public static bool ConvertBoolean(this object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(Value);
            }
        }
        public static float ConvertFloat(this object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToSingle(Value);
            }
        }
        public static ushort ConvertUShort(this object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToUInt16(Value);
            }
        }
        public static uint ConvertUInteger(this object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToUInt32(Value);
            }
        }
        public static ulong ConvertULong(this object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToUInt64(Value);
            }
        }
    }
}
