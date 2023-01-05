using MediatoRPattern.Modules.Interfaces;
using MediatoRPattern_Domain.Queries;
using MediatoRPattern_Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatoRPattern.Modules.EndpointModules
{
    public class Endpoint : IModule
    {
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet(
                "api/v1/student/getAllStudents",
                async ([FromServices] IMediator mediator, IHttpClientFactory _httpClientFactory, ApplicationPolicy policy) =>
                {
                   var client = _httpClientFactory.CreateClient("weather");
                    //var result = await policy.ImmediateHttpRetry.ExecuteAsync(
                    //    () => mediator.Send(new GetStudentListQuery()));
                    var apiUrl = "https://localhost:7142/WeatherForecast";
                    client.BaseAddress = new Uri("https://localhost:7142/WeatherForecast");
                    //var result = await policy.HttpRetry.ExecuteAsync(() => client.GetAsync(apiUrl));
                    var result = await client.GetStringAsync("https://localhost:7142/WeatherForecast");
                    //if(result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    //{
                    //    var count = 0;
                    //    for(var i = false ; count <= 5; count ++)
                    //    {
                    //       result = await policy.HttpRetry.ExecuteAsync(() => client.GetAsync(apiUrl));
                    //        if(result.IsSuccessStatusCode)
                    //        {
                    //            i= true;
                    //        }
                    //    }

                    //}
                    return result;
                });

            return endpoints;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder)
        {
            builder.AddSingleton<ApplicationPolicy>(new ApplicationPolicy());
            builder.AddMediatR(typeof(StudentRepository).Assembly);
            return builder;
        }
    }
}
