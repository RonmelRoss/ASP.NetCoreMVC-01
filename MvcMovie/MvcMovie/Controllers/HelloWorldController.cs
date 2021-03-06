﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        //public string Index()
        //{
        //    return "This is my default action...";
        //}
        public IActionResult Index()
        {
            //If you don't explicitly specify the name of the view template file, 
            //MVC defaulted to using the Index.cshtml view file in the /Views/HelloWorld folder
            return View();
        }

        // GET: /HelloWorld/Welcome/ 
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        // GET: /HelloWorld/Welcome1/
        // Requires using System.Text.Encodings.Web;
        //Modify the code to pass some parameter information from the URL to the controller.
        //For example, /HelloWorld/Welcome? name = Rick & numtimes = 4
        //Code below uses the C# optional-parameter feature to indicate that the numTimes parameter defaults to 1
        //and name parameter defaults to USER if no value is passed for these parameters.
        public string Welcome1(string name = "USER", int numTimes = 1)
        {
            //UsesHtmlEncoder.Default.Encode to protect the app from malicious input(namely JavaScript).
            //Uses Interpolated Strings in $"Hello {name}, NumTimes is: {numTimes}".
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }

        // GET: /HelloWorld/Welcome2/
        //Run the app and enter the following URL: 
        // https://localhost:xxx/HelloWorld/Welcome2/3?name=Rick
        //The Welcome method contains a parameter id that matched the URL template in the MapRoute method.
        //The trailing ? (in id?) indicates the id parameter is optional.
        public string Welcome2(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }

        public IActionResult Welcome3(string name, int numTimes = 1)
        {
            //Data is taken from the URL and passed to the controller using the MVC model binder . 
            //The controller packages the data into a ViewData dictionary and passes that object to the view. 
            //The view then renders the data as HTML to the browser.

            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}