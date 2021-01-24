using Newtonsoft.Json;
using RVTLibrary.Models.Observer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class UserImplementation
    {
        internal async Task<ResultsResponse> ResultsAction(string id)
        {
            return await Task.Run(() =>
            {

                var data = JsonConvert.SerializeObject(id);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                handler.AllowAutoRedirect = true;
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri("https://localhost:44380/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var request_api = new HttpRequestMessage()
                    {
                        RequestUri = new Uri("https://localhost:44380/api/Results/Results"),
                        Method = HttpMethod.Post,
                    };

                    var response = client.PostAsync("api/Results/Results", content);
                    var regresponse = new ResultsResponse();

                    try
                    {
                        var data_resp = response.Result.Content.ReadAsStringAsync().Result;

                        regresponse = JsonConvert.DeserializeObject<ResultsResponse>(data_resp);

                    }
                    catch
                    {
                    }

                    return regresponse;
                }
            });
        }
        internal async Task<StatisticsResponse> StatisticsAction(string id)
        {
            return await Task.Run(() =>
            {
                var data = JsonConvert.SerializeObject(id);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                handler.AllowAutoRedirect = true;
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri("https://localhost:44380/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var request_api = new HttpRequestMessage()
                    {
                        RequestUri = new Uri("https://localhost:44380/api/Results/Statistics"),
                        Method = HttpMethod.Post,
                    };

                    var response =  client.PostAsync("api/Results/Statistics", content);
                    var responseStats = new StatisticsResponse();

                    try
                    {
                        var data_resp = response.Result.Content.ReadAsStringAsync().Result;

                        responseStats = JsonConvert.DeserializeObject<StatisticsResponse>(data_resp);

                    }
                    catch (AggregateException e)
                    {
                    }

                    return responseStats;
                }
            });
        }
    }
}
