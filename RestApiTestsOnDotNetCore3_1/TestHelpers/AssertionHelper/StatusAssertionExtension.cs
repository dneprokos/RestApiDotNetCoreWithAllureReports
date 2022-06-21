using System.Net;
using FluentAssertions;
using RestApiClient.BasicClient;

namespace RestApiTestsOnDotNetCore3_1.TestHelpers.AssertionHelper
{
    public static class StatusAssertionExtension
    {
        public static void ShouldHaveOkStatusCode<T>(this RestResponse<T> response)
        {
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK, BuildErrorMessage(response));
        }

        public static void ShouldHaveCreatedStatusCode<T>(this RestResponse<T> response)
        {
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.Created, BuildErrorMessage(response));
        }

        public static void ShouldHaveNotFoundStatusCode<T>(this RestResponse<T> response, string expectedMessage = null)
        {
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            VerifyExpectedMessage(response, expectedMessage);
        }

        public static void ShouldHaveBadRequestStatusCode<T>(this RestResponse<T> response, string expectedMessage = null)
        {
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            VerifyExpectedMessage(response, expectedMessage);
        }

        #region Private methods

        private static void VerifyExpectedMessage<T>(RestResponse<T> response, string expectedMessage)
        {
            if (expectedMessage != null)
                response.FullException.Should().Contain(expectedMessage);
        }

        private static string BuildErrorMessage<T>(RestResponse<T> response)
        {
            return $"Exception: {response.FullException} " +
                $"\nRequestUrl: {response.HttpMethod} {response.RequestEndpoint}";
        }

        #endregion
    }
}
