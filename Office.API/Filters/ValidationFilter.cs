using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Office.API.DTOs;

namespace Office.API.Filters
{
    public class ValidationFilter: ActionFilterAttribute
    {
        // When Request Comes
        // while come to action
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 400;

                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(v => v.Errors);

                // fill the Error DTO list of Errors
                modelErrors.ToList().ForEach(x =>
                {
                    // filling only Error Message
                    // Exception can be also filled here
                    errorDto.Errors.Add(x.ErrorMessage);
                });

                context.Result = new BadRequestObjectResult(errorDto); 
            }
        }
    }
}
