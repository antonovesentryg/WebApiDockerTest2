using MediatR;

namespace WebApiDockerTest2.Handlers
{
    public class TestRequest : IRequest<int> { public int Value { get; set; } }

    public class TestRequestHandler : IRequestHandler<TestRequest, int>
    {
        public TestRequestHandler() { }

        public async Task<int> Handle(TestRequest request, CancellationToken cancellationToken)
        {
            return request.Value;
        }
    }
}
