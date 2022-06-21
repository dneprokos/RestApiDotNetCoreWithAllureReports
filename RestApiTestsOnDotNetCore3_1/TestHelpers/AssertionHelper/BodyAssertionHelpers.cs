using FluentAssertions;
using RestApiClient.BasicClient;
using RestApiClient.RestApi.Models._CommonModels;

namespace RestApiTestsOnDotNetCore3_1.TestHelpers.AssertionHelper
{
    public static class BodyAssertionHelpers
    {
        public static SingleResponseModel<T> ShouldNotBeNullAndReturn<T>(this RestResponse<SingleResponseModel<T>> data)
        {
            data.Body.Should().NotBeNull();
            return data.Body;
        }

        public static PagingResponseModel<T> ShouldNotBeNullAndReturn<T>(this RestResponse<PagingResponseModel<T>> data)
        {
            data.Body.Should().NotBeNull();
            return data.Body;
        }

        public static T ShouldNotBeNullAndReturn<T>(this RestResponse<T> data)
        {
            data.Body.Should().NotBeNull();
            return data.Body;
        }
    }
}
