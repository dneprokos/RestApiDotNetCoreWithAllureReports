using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using RestApiClient.RestApi.RequestBuilders;
using RestApiTestsOnDotNetCore3_1.RestApiTests._TestBaseClasses;
using RestApiTestsOnDotNetCore3_1.TestHelpers.AssertionHelper;
using RestApiTestsOnDotNetCore3_1.TestHelpers.TestDataHelper;

namespace RestApiTestsOnDotNetCore3_1.RestApiTests.Users
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    [AllureSuite("Users")]
    [AllureSubSuite("GET /users")]
    public class SearchUsersApiTests : RestTestsBase
    {
        [TestCase]
        public void SearchUsers_WithPageNumberAndSize_ShouldReturnFilteredResults()
        {
            //Arrange
            const int pageNumber = 2;
            const int pageSize = 2;

            //Act
            var searchResponse = RestRequests
                .Users()
                .WithQueryPageNumber(pageNumber)
                .WithQueryPageSize(pageSize)
                .SendSearchRequest();

            //Assert
            searchResponse.ShouldHaveOkStatusCode();
            var body = searchResponse.ShouldNotBeNullAndReturn();
            using (new AssertionScope())
            {
                body.Support.Should().BeEquivalentTo(CommonDataHelper.GetDefaultSupportModel);
                body.Page.Should().Be(pageNumber);
                body.PerPage.Should().Be(pageSize);

                body.Data.Count.Should().Be(pageSize);
            }
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        public void SearchUsers_WithPageSize_OutOfBoundary_ShouldBeBadRequest(int pageSize)
        {
            //Act
            var searchResponse = RestRequests
                .Users()
                .WithQueryPageSize(pageSize)
                .SendSearchRequest();

            //Assert
            searchResponse.ShouldHaveBadRequestStatusCode();
        }
    }
}
