using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsole.Validators
{
    public class Directory : NonBlankString
    {
        public Directory():this(false,false){
            this.ErrorMessage = MustExist ? "Directory must exist" : "value may not be blank";
        }
        public Directory(bool autoCreate):this(autoCreate,false) { }
        public Directory(bool autoCreate, bool mustExist) { this.AutoCreate = autoCreate; this.MustExist = mustExist; }
        public bool AutoCreate { get; set; }

        public bool MustExist { get; set; }

        public override bool Validate(string val)
        {
            return base.Validate(val) && AutoCreate ? System.IO.Directory.CreateDirectory(Value) != null : MustExist ? System.IO.Directory.Exists(Value) : true;
        }
    }
}
