﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPITestProject.support.utils
{
    public static class APIEndpoints
    {
        public const string GetListOfAllObjects= "objects";
        public const string AddObject = "objects";
        public const string GetObjectById = "objects/{id}";
        public const string UpdateObjectById = "objects/{id}";
        public const string DeleteObjectById = "objects/{id}";
    }
}
