using Flurl;
using RestApiClient.BasicClient;

namespace RestApiClient.RestApi.RequestBuilders._Base
{
    public class BaseRequestBuilder
    {
        protected readonly RestClient RestClient;

        protected const string PageNumberQueryParam = "page";
        protected const string PageSizeQueryParam = "per_page";
        protected string SearchEndpoint;

        public BaseRequestBuilder()
        {
            RestClient = new RestClient();
        }

        #region Query params base

        protected void AddPageNumberAsQueryParam(int pageNumber)
        {
            SearchEndpoint = SearchEndpoint.SetQueryParam(PageNumberQueryParam, pageNumber);
        }

        protected void AddPageSizeAsQueryParam(int pageSize)
        {
            SearchEndpoint = SearchEndpoint.SetQueryParam(PageSizeQueryParam, pageSize);
        }

        #endregion
    }
}
