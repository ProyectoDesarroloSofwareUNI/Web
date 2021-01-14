using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;
namespace PMatriculaService.App_Start
{
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
  public class MyCorsPolicyAttribute : Attribute, ICorsPolicyProvider
  {
    private CorsPolicy _policy;

    public MyCorsPolicyAttribute()
    {
      // Create a CORS policy.
      _policy = new CorsPolicy
      {
        AllowAnyMethod = true,
        AllowAnyHeader = true
      };
      string varURl = ConfigurationManager.AppSettings["corsWEb"];
      // Add allowed origins.
      _policy.Origins.Add(varURl);

    }



    public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      return Task.FromResult(_policy);
    }
  }
}
