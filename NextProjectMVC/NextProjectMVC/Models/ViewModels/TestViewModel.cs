using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NextProjectMVC.Models.ViewModels
{
    public class TestViewModel
    {
        public TestViewModel()
        {
            number = 0;
            text = string.Empty;
        }

        public int number { get; set; }

        public string text { get; set; }
    }
}