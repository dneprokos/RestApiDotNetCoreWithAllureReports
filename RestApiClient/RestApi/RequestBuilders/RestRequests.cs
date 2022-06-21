using RestApiClient.RestApi.RequestBuilders.Users;

namespace RestApiClient.RestApi.RequestBuilders
{
    public class RestRequests
    {
        /// <summary>
        /// Invokes Users V1 builder class 
        /// </summary>
        /// <returns></returns>
        public static UsersRequestBuilderV1 Users() 
            => new UsersRequestBuilderV1();
    }
}
