using RestApiClient.BasicClient;
using RestApiClient.RestApi.Endpoints;
using RestApiClient.RestApi.Models._CommonModels;
using RestApiClient.RestApi.Models.Users;
using RestApiClient.RestApi.RequestBuilders._Base;

namespace RestApiClient.RestApi.RequestBuilders.Users
{
    public class UsersRequestBuilderV1 : BaseRequestBuilder
    {
        public UserModelV1 Body;

        public UsersRequestBuilderV1()
        {
            SearchEndpoint = EndpointUrls.Users();
            Body = new UserModelV1();
        }

        #region Body builder

        public UsersRequestBuilderV1 AddBodyLastName(string lastName)
        {
            Body.LastName = lastName;
            return this;
        }

        public UsersRequestBuilderV1 AddBodyFirstName(string firstName)
        {
            Body.FirstName = firstName;
            return this;
        }

        public UsersRequestBuilderV1 AddBodyEmail(string email)
        {
            Body.Email = email;
            return this;
        }

        public UsersRequestBuilderV1 AddBodyAvatar(string avatar)
        {
            Body.Avatar = avatar;
            return this;
        }

        #endregion

        #region Query params builder

        public UsersRequestBuilderV1 WithQueryPageNumber(int pageNumber)
        {
            AddPageNumberAsQueryParam(pageNumber);
            return this;
        }

        public UsersRequestBuilderV1 WithQueryPageSize(int pageSize)
        {
            AddPageSizeAsQueryParam(pageSize);
            return this;
        }

        #endregion

        #region Send requests

        public RestResponse<UserModelV1> SendPostRequest()
        {
            return RestClient.SendPostRequest(EndpointUrls.Users(), Body).Result;
        }

        public RestResponse<T> SendPostRequest<T>(T customBody)
        {
            return RestClient.SendPostRequest(EndpointUrls.Users(), customBody).Result;
        }

        public RestResponse<SingleResponseModel<UserModelV1>> SendGetRequest(int id)
        {
            return RestClient.SendGetRequest<SingleResponseModel<UserModelV1>>(EndpointUrls.Users(id)).Result;
        }

        public RestResponse<PagingResponseModel<PagingResponseModel<UserModelV1>>> SendSearchRequest()
        {
            return RestClient.SendGetRequest<PagingResponseModel<PagingResponseModel<UserModelV1>>>(SearchEndpoint).Result;
        }

        #endregion
    }
}
