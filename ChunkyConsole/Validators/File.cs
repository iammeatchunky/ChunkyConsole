using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsole.Validators
{
    public class File:NonBlankString
    {
        public File():this(false){}
        public File(bool mustExist) { this.MustExist = mustExist; }
        public bool MustExist { get; set; }
        public override bool Validate(string val)
        {
            return base.Validate(val) && MustExist ? System.IO.File.Exists(Value) : true;
        }
    }
}
