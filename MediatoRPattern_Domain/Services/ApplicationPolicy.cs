using MediatoRPattern_Core.ResponseModels;
using Microsoft.Data.SqlClient;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MediatoRPattern_Domain.Services
{
    public class ApplicationPolicy
    {
        public AsyncRetryPolicy ImmediateHttpRetry { get; }

        public AsyncRetryPolicy<HttpResponseMessage> HttpRetry { get; }

        public ApplicationPolicy()
        {
            Console.WriteLine("Retrying");
            ImmediateHttpRetry = Policy.Handle
                <InvalidOperationException>()
                .Or<NotImplementedException>()
                //<SqlException>()
                //.Or<Exception>()
                //.Or<OperationCanceledException>()
                //.Or<ArgumentException>()
                //.OrInner<OperationCanceledException>()
                .RetryAsync(5);

            HttpRetry = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode)
                .RetryAsync(5);

            //HttpRetry = Policy.Handle<HttpRequestException>(ex => ex.StatusCode == HttpStatusCode.BadRequest)
            //    .Or<HttpRequestException>(ex => ex.StatusCode == HttpStatusCode.MethodNotAllowed)
            //    .Or<InvalidOperationException>()
            //    .Or<NotImplementedException>()
            //    .WaitAndRetryAsync(5, times => TimeSpan.FromSeconds(2));

            //HttpRetry = Policy.HandleResult<HttpRequestException>(ex => ex.StatusCode == HttpStatusCode.BadRequest)
            //    //(r => r.StatusCode == HttpStatusCode.InternalServerError)
            //    .RetryAsync(5);

            //HttpRetry = Policy.HandleResult<HttpStatusCode>
            //   ( HttpStatusCode.InternalServerError)
            //   .RetryAsync(5);
        }
    }
}
