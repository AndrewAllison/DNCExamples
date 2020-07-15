using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNCExamples.Api.MiddleWare
{
    /// <summary>
    /// Deals with logging requests
    /// </summary>
    public class WebRequestLogger
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// Elem
        /// </summary>
        private ILogger<WebRequestLogger> Logger { get; }

        /// <summary>
        /// Initialise class to log requests
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public WebRequestLogger(RequestDelegate next, ILogger<WebRequestLogger> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            Logger = logger;
        }

        /// <summary>
        /// Invokde request method.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));
            httpContext.Request.EnableBuffering();
            Stream body = httpContext.Request.Body;
            byte[] buffer = new byte[Convert.ToInt32(httpContext.Request.ContentLength)];
            await httpContext.Request.Body.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
            // Getting the request body is a little tricky because it's a stream
            // So, we need to read the stream and then rewind it back to the beginning
            string requestBody = Encoding.UTF8.GetString(buffer);
            body.Seek(0, SeekOrigin.Begin);
            httpContext.Request.Body = body;

            //Log.ForContext("RequestHeaders", httpContext.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()), destructureObjects: true)
            //   .ForContext("RequestBody", requestBody)
            //   .Debug("Request information {RequestMethod} {RequestPath} information", httpContext.Request.Method, httpContext.Request.Path);

            var requestHeaders = httpContext.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());
            Logger.LogDebug("Request information {requestMethod} {@requestBody} {@requestHeaders}", httpContext.Request.Method, requestBody, requestHeaders);

            // The reponse body is also a stream so we need to:
            // - hold a reference to the original response body stream
            // - re-point the response body to a new memory stream
            // - read the response body after the request is handled into our memory stream
            // - copy the response in the memory stream out to the original response stream
            using var responseBodyMemoryStream = new MemoryStream();
            var originalResponseBodyReference = httpContext.Response.Body;
            httpContext.Response.Body = responseBodyMemoryStream;

            await _next(httpContext).ConfigureAwait(false);

            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(httpContext.Response.Body).ReadToEndAsync().ConfigureAwait(false);
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            Logger.LogDebug("Response information {requestMethod} {statusCode} {@responseBody}", httpContext.Request.Method, httpContext.Response.StatusCode, requestBody);

            await responseBodyMemoryStream.CopyToAsync(originalResponseBodyReference).ConfigureAwait(false);
        }
    }
}
