using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChunkyConsole.Utils;
namespace ChunkyConsole.Validators
{
    public class Numeric<K>:BaseValidator<K> where K: struct, IConvertible, IComparable<K>
    {
        public Numeric():this("Input must be numeric"){}
        public Numeric(string errorMessage):base(errorMessage){}
        public override bool Validate(string val)
        {
            K k = default(K);
            if (k is Int64 && new Int64().ParseNullable(val).HasValue)
            {
                Assignment((K)Convert.ChangeType(new Int64().ParseNullable(val).Value, typeof(K)));
            }
            else if (k is Int32 && new Int32().ParseNullable(val).HasValue)
            {
                Assignment((K)Convert.ChangeType(new Int32().ParseNullable(val).Value, typeof(K)));
            }
            else if (k is double && new double().ParseNullable(val).HasValue)
            {
                Assignment((K)Convert.ChangeType(new double().ParseNullable(val).Value, typeof(K)));
            }
            else if (k is decimal && new decimal().ParseNullable(val).HasValue)
            {
                Assignment((K)Convert.ChangeType(new decimal().ParseNullable(val).Value, typeof(K)));
            }
            else if (k is double && new double().ParseNullable(val).HasValue)
            {
                Assignment((K)Convert.ChangeType(new double().ParseNullable(val).Value, typeof(K)));
            }
            else
                return false;

            return true;
        }        
    }

    public class Int:Numeric<int>{}
    public class Double : Numeric<int> { }
    public class Long : Numeric<long> { }
    public class Decimal : Numeric<decimal> { }
    public class Float : Numeric<float> { }

}
