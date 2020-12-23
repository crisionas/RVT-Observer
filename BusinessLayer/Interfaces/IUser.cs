
using RVTLibrary.Models.Observer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUser
    {
        public Task<ResultsResponse> ResultsStatus(string id);
        public Task<StatisticsResponse> StatisticsStatus(string id);
    }
}
