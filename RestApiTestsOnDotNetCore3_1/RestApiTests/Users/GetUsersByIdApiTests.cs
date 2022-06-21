using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using RestApiClient.RestApi.Models._CommonModels;
using RestApiClient.RestApi.Models.Users;
using RestApiClient.RestApi.RequestBuilders;
using RestApiTestsOnDotNetCore3_1.RestApiTests._TestBaseClasses;
using RestApiTestsOnDotNetCore3_1.TestHelpers.AssertionHelper;
using RestApiTestsOnDotNetCore3_1.TestHelpers.TestDataHelper;

namespace RestApiTestsOnDotNetCore3_1.RestApiTests.Users
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    [AllureSuite("Users")]
    [AllureSubSuite("GET /users/{Id}")]
    public class GetUsersByIdApiTests : RestTestsBase
    {
        [TestCase]
        public void GetUserById_IdExists_ShouldBeOkAndReturned()
        {
            //Arrange
            const int userId = 1;
            var expectedUserData = new SingleResponseModel<UserModelV1>
            {
                Support = CommonDataHelper.GetDefaultSupportModel,
                Data = new UserModelV1
                {
                    Id = userId,
                    Email = "george.bluth@reqres.in",
                    FirstName = "George",
                    LastName = "Bluth",
                    Avatar = "https://reqres.in/img/faces/1-image.jpg"
                }
            };

            //Act
            var getResponse = RestRequests
                .Users()
                .SendGetRequest(userId);

            //Assert
            getResponse.ShouldHaveOkStatusCode();
            var actualBody = getResponse.ShouldNotBeNullAndReturn();
            actualBody.Should().BeEquivalentTo(expectedUserData);
        }

        [TestCase]
        public void GetUserById_IdDoesNotExist_ShouldBeNotFound()
        {
            //Arrange
            const int userId = int.MaxValue;

            //Act
            var getResponse = RestRequests
                .Users()
                .SendGetRequest(userId);

            //Assert
            getResponse.ShouldHaveNotFoundStatusCode();
            getResponse.Body.Should().BeNull();
        }
    }
}
