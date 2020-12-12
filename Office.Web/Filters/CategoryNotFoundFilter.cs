using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Office.Core.Services;
using Office.Web.DTOs;

namespace Office.API.Filters
{
    public class CategoryNotFoundFilter : ActionFilterAttribute
    {
        // need a connection to the database
        private readonly ICategoryService _categoryService;

        public CategoryNotFoundFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // ** method that take id parameters in product has one value so FirstOrDefault() will work.
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _categoryService.GetByIdAsyn(id);
            if(product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Errors.Add($"CategoryId = {id} was not found in the Database.");
                context.Result = new RedirectToActionResult("Error","Home", errorDto);
            }
        }

    }
}
