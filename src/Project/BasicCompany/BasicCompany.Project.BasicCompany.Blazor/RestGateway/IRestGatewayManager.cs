namespace BasicCompany.Blazor.RestGateway
{
    /// <summary>
    /// RestGateway Interface
    /// </summary>
    public interface IRestGatewayManager
    {
        RestResponse<T> Get<T>(string endpoint, Dictionary<string, string> queryParameter, RestEndPointManager.RestEndpoint type = RestEndPointManager.RestEndpoint.CE, string authtoken = "");
        Task<RestResponse<T>> GetAsync<T>(string endpoint, Dictionary<string, string> queryParameter, RestEndPointManager.RestEndpoint type = RestEndPointManager.RestEndpoint.CE, string authtoken = "");
    }
}

