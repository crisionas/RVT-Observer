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
            var data = JsonConvert.SerializeObject(id);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            handler.AllowAutoRedirect = true;
            var client = new HttpClient(handler);
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
                var data_resp =await  response.Result.Content.ReadAsStringAsync();

                regresponse = JsonConvert.DeserializeObject<ResultsResponse>(data_resp);

            }
            catch (AggregateException e)
            {
            }

            return new ResultsResponse()
            {
                Name=regresponse.Name,
                Time = regresponse.Time,
                TotalVotes = regresponse.TotalVotes,
                Votants = regresponse.Votants,
                Population = regresponse.Population,
                Pending = regresponse.Pending,
                GenderStatistics = regresponse.GenderStatistics
            };
        }
        internal async Task<StatisticsResponse> StatisticsAction(string id)
        {
            var data = JsonConvert.SerializeObject(id);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            handler.AllowAutoRedirect = true;
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:44380/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request_api = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://localhost:44380/api/Results/Statistics"),
                Method = HttpMethod.Post,
            };

            var response = client.PostAsync("api/Results/Statistics", content);
            var responseStats = new StatisticsResponse();

            try
            {
                var data_resp = await response.Result.Content.ReadAsStringAsync();

                responseStats = JsonConvert.DeserializeObject<StatisticsResponse>(data_resp);

            }
            catch (AggregateException e)
            {
            }

            return new StatisticsResponse()
            {
                AgeVoters=responseStats.AgeVoters,
                GenderStatistics= responseStats.GenderStatistics,
                Name= responseStats.Name,
                Time= responseStats.Time,
                Population=responseStats.Population,
                Voters= responseStats.Voters
            };
        }
    }
}
