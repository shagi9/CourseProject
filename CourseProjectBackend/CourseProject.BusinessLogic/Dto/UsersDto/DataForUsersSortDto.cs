﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.BusinessLogic.Dto.UsersDto
{
    public class DataForUsersSortDto
    {
        public string SearchString { get; set; }
        public string Field { get; set; }
        public int Current { get; set; }
        public int PageSize { get; set; }
    }
}