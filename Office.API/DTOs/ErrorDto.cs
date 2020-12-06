using System;
using System.Collections.Generic;

namespace Office.API.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }

        // list should be alwasy newed in ctor to fill or it will fire a null exception
        public List<string> Errors { get; set; }
        public int Status { get; set; }
    }
}
