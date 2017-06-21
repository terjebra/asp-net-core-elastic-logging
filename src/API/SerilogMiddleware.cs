using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;

namespace API {
  public class SerilogMiddleware {
    private readonly RequestDelegate _next;
    private static readonly ILogger Logger = Serilog.Log.ForContext<SerilogMiddleware> ();
    private const string MessageTemplate = "{StatusCode} {RequestMethod} {RequestPath} incoming from {IP}";

    public SerilogMiddleware (RequestDelegate next) {
      _next = next;
    }

    public async Task Invoke (HttpContext context) {
     var currentContext = context;

      try {
        await  _next (context);
        Logger.Information("{@logEntry}", CreateLogEntry(currentContext));
      }
      catch(Exception e){
        Log.Error("{@logEntry}", CreateLogEntry(currentContext, e.ToString()));
      }
    }

    private object CreateLogEntry(HttpContext context, string error = ""){
      var host = context.Request.Host.ToUriComponent();
      var baseUrl = $"{context.Request.Scheme}://{host}";
      var fullPath = $"{baseUrl}{context.Request.Path}";

      return new {
          Path =  fullPath,
          StatusCode = context.Response?.StatusCode,  
          QueryString = context.Request.QueryString.Value,
          RequestMethod = context.Request.Method,
          ConnectionFrom= context.Connection.RemoteIpAddress.ToString(),
          User = "anonymous",
          Error = error
      };
    }
  }
}