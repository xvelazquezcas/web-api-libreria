﻿using System.Collections.Generic;

namespace libreria_XGVC.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AuthorWithBookVM
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
