﻿using MRI.OpenApi.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRI.OpenApi.Models.Response
{
    public class InspectionResponse : EntityResponse
    {
        public int PatientId { get; set; }
        public DateTime InspectionDate { get; set; }
        // Id МРТ-снимка
        public int MriId { get; set; }
    }
}