﻿using ProbOauthApi.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProbOauthApi.Models.Response
{
    public class ServiceResponse : EntityResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceForTransaction { get; set; }
    }
}