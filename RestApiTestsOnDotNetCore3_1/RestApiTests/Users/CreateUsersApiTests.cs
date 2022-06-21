using System;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using RestApiClient.Extensions;
using RestApiClient.RestApi.RequestBuilders;
using RestApiTestsOnDotNetCore3_1.RestApiTests._TestBaseClasses;
using RestApiTestsOnDotNetCore3_1.TestHelpers.AssertionHelper;
using RestApiTestsOnDotNetCore3_1.TestHelpers.TestDataHelper;

namespace RestApiTestsOnDotNetCore3_1.RestApiTests.Users
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    [AllureSuite("Users")]
    [AllureSubSuite("POST /users")]
    public class CreateUsersApiTests : RestTestsBase
    {
        [TestCase]
        public void CreateUser_ShouldBeCreatedWithAllFields()
        {
            //Arrange
            var firstName = StringGenerator.GenerateRandomString(10, true);
            var lastName = StringGenerator.GenerateRandomString(12);
            var email = $"{firstName}.{lastName[0]}@test.com";

            //Act
            var baseRequest = RestRequests
                .Users()
                .AddBodyFirstName(firstName)
                .AddBodyLastName(lastName)
                .AddBodyEmail(email)
                .AddBodyAvatar("Some avatar");

            var postResponse = baseRequest.SendPostRequest();
            var expectedTime = DateTime.UtcNow.TruncateMilliseconds().ToAzoresStandardTime();

            //Assert
            postResponse.ShouldHaveCreatedStatusCode();
            var body = postResponse.ShouldNotBeNullAndReturn();
            using (new AssertionScope())
            {
                body.Should().BeEquivalentTo(baseRequest.Body, c => c
                    .Excluding(u => u.Id)
                    .Excluding(u => u.CreatedAt));

                body.Id.Should().NotBeNull().And.NotBe(0);
                body.CreatedAt
                    .TruncateMilliseconds()
                    .Should()
                    .BeCloseTo(expectedTime, TimeSpan.FromSeconds(3));
            }

        }
    }
}
