using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsole.Validators
{
    public class NonBlankString:BaseValidator<string>
    {
        public NonBlankString():this("value may not be blank"){}
        public NonBlankString(string errorMessage) : base(errorMessage) { }
        public override bool Validate(string val)
        {
            if (!String.IsNullOrEmpty(val))
            {
                Assignment(val);
                return true;
            }
            //Value = val;
            return false;
        }
    }
}
