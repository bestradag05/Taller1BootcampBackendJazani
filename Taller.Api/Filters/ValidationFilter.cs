using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Taller.Api.Exceptions;

namespace Taller.Api.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsModelState = context.ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage))
                .ToList();

                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.Message = "Ingrese todos los campos requeridos";
                errorResponse.Errors = new List<ErrorValidationModel>();

                Console.WriteLine("Los errores son : ", errorResponse);

                errorsModelState.ForEach(error =>
                {
                    foreach (var message in error.Value)
                    {
                        errorResponse.Errors.Add(new()
                        {
                            FieldName = error.Key,
                            Message = message
                        });
                    }
                });

                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }


            await next();
        }
    }
    
}
