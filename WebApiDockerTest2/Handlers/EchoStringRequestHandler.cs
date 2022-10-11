using MediatR;
using System.Diagnostics;

namespace WebApiDockerTest2.Handlers
{
    public class EchoStringRequest : IRequest<string>
    {
        public string Value { get; set; }
    }
    public class EchoStringRequestHandler : IRequestHandler<EchoStringRequest, string>
    {
        public EchoStringRequestHandler() { }

        public async Task<string> Handle(EchoStringRequest request, CancellationToken cancellationToken)
        {
            Debug.WriteLine(request.Value);

            await Task.Delay(100); // some async behaviour ¯\_(ツ)_/¯
            
            return request.Value;
        }
    }
}
