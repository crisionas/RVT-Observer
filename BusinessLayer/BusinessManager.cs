﻿
using BusinessLayer.Interfaces;
using BusinessLayer.Levels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class BusinessManager
    {
        public IResults GetResults()
        {
            return new ResultsLevel() ;
        }
    }
}