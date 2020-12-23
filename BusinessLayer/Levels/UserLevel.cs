
using BusinessLayer.Implementation;
using BusinessLayer.Interfaces;
using RVTLibrary.Models.Observer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Levels
{
    public class UserLevel : UserImplementation, IUser
    {
        public Task<ResultsResponse> ResultsStatus(string id)
        {
            return ResultsAction(id);
        }

        public Task<StatisticsResponse> StatisticsStatus(string id)
        {
            return StatisticsAction(id);
        }
    }
}
