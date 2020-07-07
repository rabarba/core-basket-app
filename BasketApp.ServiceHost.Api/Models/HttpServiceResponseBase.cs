using System.Net;

namespace BasketApp.ServiceHost.Api.Models
{
    public class HttpServiceResponseBase
    {
        public ErrorModel Error { get; set; }
    }

    public class HttpServiceResponseBase<TData>
    {
        public TData Data { get; set; }
    }

    public class ErrorModel
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
