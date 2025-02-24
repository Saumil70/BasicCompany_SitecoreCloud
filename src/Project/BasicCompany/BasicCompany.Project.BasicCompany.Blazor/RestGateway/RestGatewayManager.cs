using Newtonsoft.Json;
using System.Net;

namespace BasicCompany.Blazor.RestGateway
{
    /// <summary>
    /// Rest request manager
    /// </summary>
    public class RestGatewayManager : IRestGatewayManager
    {

        private HttpClient Client;
        private const string AUTHTYPE_BEARER = "Basic ";

        public RestGatewayManager()
        {
            var httpClientHandler = new HttpClientHandler();
            Client = new HttpClient(httpClientHandler);
            Client.BaseAddress = new Uri("http://localhost:5000");
            Client.Timeout = new TimeSpan(0, 10, 0);
        }

        public RestResponse<T> Get<T>(string endpoint, Dictionary<string, string> queryParameter, RestEndPointManager.RestEndpoint type = RestEndPointManager.RestEndpoint.CE, string authtoken = "")
        {
            using (var objResponse = new RestResponse<T>())
            {
                try
                {
                    using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, GetQueryString(endpoint, queryParameter)))
                    {
                        string language = "en";
                        requestMessage.Headers.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue(language));

                        var response = GetEndPoint(type).SendAsync(requestMessage).GetAwaiter().GetResult();
                        string result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                        objResponse.StatusCode = response.StatusCode;

                        if (response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.BadRequest)
                        {
                            objResponse.ResultData = JsonConvert.DeserializeObject<T>(result, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                            objResponse.IsSuccessful = true;
                        }
                        else if (!string.IsNullOrWhiteSpace(result) && objResponse.StatusCode == HttpStatusCode.BadRequest)
                        {
                            try
                            {
                                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(result);
                                objResponse.ErrorMessage = string.Join(", ", errorResponse.Errors);
                                SetErrorResponse(objResponse, response);
                            }
                            catch (Exception ex)
                            {
                                objResponse.ResultData = default;
                                SetErrorResponse(objResponse, response);
                            }
                        }
                        else
                        {
                            objResponse.ErrorMessage = result;
                            objResponse.ResultData = default;
                            SetErrorResponse(objResponse, response);
                        }
                        response.Content?.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    objResponse.IsSuccessful = false;
                    objResponse.Error = ex;
                    objResponse.ErrorMessage = ex.Message;
                    objResponse.StatusCode = HttpStatusCode.ExpectationFailed;
                }
                return objResponse;
            }
        }

        public async Task<RestResponse<T>> GetAsync<T>(string endpoint, Dictionary<string, string> queryParameter, RestEndPointManager.RestEndpoint type = RestEndPointManager.RestEndpoint.CE, string authtoken = "")
        {
            using (var objResponse = new RestResponse<T>())
            {
                try
                {
                    using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, GetQueryString(endpoint, queryParameter)))
                    {
                        string language = "en";
                        requestMessage.Headers.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue(language));

                        var response = await GetEndPoint(type).SendAsync(requestMessage);
                        string result = response.Content.ReadAsStringAsync().Result;

                        objResponse.StatusCode = response.StatusCode;

                        JsonSerializerSettings settings = new JsonSerializerSettings()
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            MissingMemberHandling = MissingMemberHandling.Ignore,
                        };

                        if (response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.BadRequest)
                        {
                            objResponse.ResultData = JsonConvert.DeserializeObject<T>(result, settings);
                            objResponse.IsSuccessful = true;
                        }
                        else
                        {
                            objResponse.ErrorMessage = result;
                            objResponse.ResultData = default;
                            SetErrorResponse(objResponse, response);
                        }
                        response.Content?.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    objResponse.IsSuccessful = false;
                    objResponse.Error = ex;
                    objResponse.ErrorMessage = ex.Message;
                    objResponse.StatusCode = HttpStatusCode.ExpectationFailed;
                }
                return objResponse;
            }
        }

        private static string GetQueryString(string endpoint, Dictionary<string, string> QueryParameter = null)
        {
            var querystring = "";

            if (QueryParameter != null)
            {
                foreach (var pair in QueryParameter)
                {
                    querystring += querystring != "" ? "&" : "";
                    querystring += pair.Key + "=" + pair.Value;
                }
            }

            return querystring != "" ? endpoint + "?" + querystring : endpoint;
        }

        private static void SetErrorResponse<T>(RestResponse<T> objResponse, HttpResponseMessage response)
        {
            objResponse.IsSuccessful = false;

            //TODO : Return error based on the status code

            switch (response.StatusCode)
            {
                case HttpStatusCode.Continue:
                    break;
                case HttpStatusCode.SwitchingProtocols:
                    break;
                case HttpStatusCode.Created:
                    break;
                case HttpStatusCode.Accepted:
                    break;
                case HttpStatusCode.NonAuthoritativeInformation:
                    break;
                case HttpStatusCode.NoContent:
                    break;
                case HttpStatusCode.ResetContent:
                    break;
                case HttpStatusCode.PartialContent:
                    break;
                case HttpStatusCode.MultipleChoices:
                    break;
                case HttpStatusCode.MovedPermanently:
                    break;
                case HttpStatusCode.Found:
                    break;
                case HttpStatusCode.SeeOther:
                    break;
                case HttpStatusCode.NotModified:
                    break;
                case HttpStatusCode.UseProxy:
                    break;
                case HttpStatusCode.Unused:
                    break;
                case HttpStatusCode.TemporaryRedirect:
                    break;
                case HttpStatusCode.BadRequest:
                    objResponse.IsSuccessful = true;
                    break;
                case HttpStatusCode.Unauthorized:
                    break;
                case HttpStatusCode.PaymentRequired:
                    break;
                case HttpStatusCode.Forbidden:
                    break;
                case HttpStatusCode.NotFound:
                    objResponse.IsSuccessful = true;
                    break;
                case HttpStatusCode.MethodNotAllowed:
                    break;
                case HttpStatusCode.NotAcceptable:
                    break;
                case HttpStatusCode.ProxyAuthenticationRequired:
                    break;
                case HttpStatusCode.RequestTimeout:
                    break;
                case HttpStatusCode.Conflict:
                    break;
                case HttpStatusCode.Gone:
                    break;
                case HttpStatusCode.LengthRequired:
                    break;
                case HttpStatusCode.PreconditionFailed:
                    break;
                case HttpStatusCode.RequestEntityTooLarge:
                    break;
                case HttpStatusCode.RequestUriTooLong:
                    break;
                case HttpStatusCode.UnsupportedMediaType:
                    break;
                case HttpStatusCode.RequestedRangeNotSatisfiable:
                    break;
                case HttpStatusCode.ExpectationFailed:
                    break;
                case HttpStatusCode.UpgradeRequired:
                    break;
                case HttpStatusCode.InternalServerError:
                    break;
                case HttpStatusCode.NotImplemented:
                    break;
                case HttpStatusCode.BadGateway:
                    break;
                case HttpStatusCode.ServiceUnavailable:
                    break;
                case HttpStatusCode.GatewayTimeout:
                    break;
                case HttpStatusCode.HttpVersionNotSupported:
                    break;
                default:
                    break;
            }
        }
        private HttpClient GetEndPoint(RestEndPointManager.RestEndpoint type)
        {
            switch (type)
            {
                case RestEndPointManager.RestEndpoint.CE:
                    return Client;
                default:
                    return Client;
            }
        }
    }
}

