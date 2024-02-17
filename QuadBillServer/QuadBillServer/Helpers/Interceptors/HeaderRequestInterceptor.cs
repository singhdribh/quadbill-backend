using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using System.Security.Claims;

namespace QuadBillServer.Helpers.Interceptors
{
    public class HeaderRequestInterceptor : DefaultHttpRequestInterceptor
    {
        public override ValueTask OnCreateAsync(HttpContext context, IRequestExecutor requestExecutor, IQueryRequestBuilder requestBuilder, CancellationToken cancellationToken)
        {
            var headers = context.Request.Headers.Select(x => new { key = x.Key, value = x.Value.FirstOrDefault() }).ToList();
            var identity = new ClaimsIdentity();
            headers.ForEach(x =>
            {
                identity.AddClaim(new Claim(x.key, x.value ?? string.Empty));
            });
            context.User.AddIdentity(identity);
            return base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
        }
    }
}
