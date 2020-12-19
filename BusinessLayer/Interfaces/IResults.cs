
using RVTLibrary.Models.Observer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IResults
    {
        public Task<ResultsResponse> ResultsStatus(string id);
    }
}
