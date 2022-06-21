using RestApiClient.RestApi.Models._CommonModels;

namespace RestApiTestsOnDotNetCore3_1.TestHelpers.TestDataHelper
{
    public class CommonDataHelper
    {
        public static SupportModel GetDefaultSupportModel => new SupportModel
        {
            Text = "To keep ReqRes free, contributions towards server costs are appreciated!",
            Url = "https://reqres.in/#support-heading"
        };
    }
}
