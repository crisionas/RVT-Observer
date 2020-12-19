
using BusinessLayer.Implementation;
using BusinessLayer.Interfaces;
using RVTLibrary.Models.Observer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Levels
{
    public class ResultsLevel : ResultsImplementation, IResults
    {
        public Task<ResultsResponse> ResultsStatus(string id)
        {
            return ResultsAction(id);
        }
    }
}
