using Api.Data.Uow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Text.Json.Serialization;

namespace TyTManagementSystem
{
  public static class ServicesExtensions
  {
    public static void ConfigureCors(this IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddDefaultPolicy(policy => { 
          policy
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
        });
      });
    }

    public static void ConfigureDataService(this IServiceCollection services)
    {
      services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void ConfigureJSONSerialization(this IServiceCollection services)
    {
      services.AddControllers().AddJsonOptions(option => 
        option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
    }

    public static void ConfigureDefaultModelResponse(this IServiceCollection services)
    {
      services.AddControllers().ConfigureApiBehaviorOptions(options =>
      {
        options.InvalidModelStateResponseFactory = context =>
        {
          var responseObj = new
          {
            path = context.HttpContext.Request.Path.ToString(),
            method = context.HttpContext.Request.Method,
            controller = (context.ActionDescriptor as ControllerActionDescriptor)?.ControllerName,
            action = (context.ActionDescriptor as ControllerActionDescriptor)?.ActionName,
            errors = context.ModelState.Keys.Select(key =>
            {
              return new
              {
                field = key,
                messages = context.ModelState[key]?.Errors.Select(e => e.ErrorMessage)
              };
            })
          };

          return new BadRequestObjectResult(responseObj);
        };
      });
    }
  }
}
