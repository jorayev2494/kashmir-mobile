using System;
using System.Collections.Generic;
using System.Text;

namespace Kashmir.Exceptions
{
    public class ValidationException
    {

        public List<Errors> errors { get; set; }

    }

    public class Errors
    {
        public string[] error { get; set; }
    }
}
