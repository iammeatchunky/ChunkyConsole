using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsole.Validators
{
    public abstract class BaseValidator<T>:IValidator,IValue<T>
    {
        public Action<object> Assignment { get; set; }
        

        public BaseValidator(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.Assignment = (t => Value = (T)t);
        }
        
        public T Value { get; set; }
        public abstract bool Validate(string val);
        public string ErrorMessage { get; set; }

        public static IValidator InstanceByType(object source, string propertyName)
        {
            var prop = source.GetType().GetProperty(propertyName);
            if (prop != null)
            {
                return InstanceByType(source.GetType().GetProperty(propertyName).PropertyType);
            }
            else
                return new Validators.AnyString();

        }
        public static IValidator InstanceByType(Type ptype)
        {
            if (ptype.Equals(typeof(int)))
                return new Validators.Int();
            else if (ptype.Equals(typeof(decimal)))
                return new Validators.Decimal();
            else if (ptype.Equals(typeof(double)))
                return new Validators.Double();
            else if (ptype.Equals(typeof(float)))
                return new Validators.Float();
            else if (ptype.Equals(typeof(long)))
                return new Validators.Long();
            else if (ptype.Equals(typeof(string)))
                return new Validators.NonBlankString();
            else if (ptype.Equals(typeof(System.Boolean)))
                return new Validators.Bool();
            else if (ptype.Equals(typeof(System.DateTime)))
                return new Validators.DateTime();

            else
                return new Validators.AnyString();
        }
    }
}
