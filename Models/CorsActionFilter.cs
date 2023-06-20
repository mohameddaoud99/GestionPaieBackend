using System.Web.Http.Filters;

public class CorsActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000/");
        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");

        base.OnActionExecuted(actionExecutedContext);
    }
}