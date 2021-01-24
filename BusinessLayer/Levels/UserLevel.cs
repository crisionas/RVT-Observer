
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
        public async Task<ResultsResponse> ResultsStatus(string id)
        {
            return await ResultsAction(id);
        }

        public async Task<StatisticsResponse> StatisticsStatus(string id)
        {
            return await StatisticsAction(id);
        }
    }
}
