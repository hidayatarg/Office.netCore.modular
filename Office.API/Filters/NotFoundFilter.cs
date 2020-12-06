using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Office.API.DTOs;
using Office.Core.Services;

namespace Office.API.Filters
{
    public class ProductNotFoundFilter : ActionFilterAttribute
    {
        // need a connection to the database
        private readonly IProductService _productService;

        public ProductNotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // ** method that take id parameters in product has one value so FirstOrDefault() will work.
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetByIdAsyn(id);
            if(product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"ProductId = {id} was not found in the Database.");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }

    }
}
