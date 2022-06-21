using System;
using RestApiClient.Managers;

namespace RestApiClient.RestApi.Endpoints
{
    public class EndpointUrls
    {
        private static readonly string BaseUrl = TestSettingsManager.RestApiUrl == null ? 
            throw new Exception("coreApiUrl cannot be null. Please make sure it was specified in .runsettings file") :
            TestSettingsManager.RestApiUrl;

        #region Users

        public static string Users(int id)
            => $"{BaseUrl}/users/{id}";

        public static string Users()
            => $"{BaseUrl}/users";

        #endregion
    }
}
