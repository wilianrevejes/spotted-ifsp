using System;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Spotted {
    abstract class Factory {

        protected WebClient wc;
        protected string baseAPIUrl = "http://187.49.247.78:8080";
        protected static List<string> InvalidJsonElements;
        protected string csrfToken;

        public Factory() {
            wc = new WebClient();
            csrfToken = "JWT eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpZCI6IjU5NWE0N2Y4YWEwNDhmMDQ0YzNkMzZhOCJ9.bsPsloXOOQ_Q1Zix_zU2dFFPrlC7I3DgLWrV2JEe0P8";

            wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
            wc.Headers.Add(HttpRequestHeader.Accept, "application/json");
            wc.Headers.Add("Authorization", csrfToken);
            wc.Headers.Add("x-spotted-userid", "595a47f8aa048f044c3d36a8");
            wc.Headers.Add("X-Requested-With", "XMLHttpRequest");

        }

        public abstract string create(string content);
         
        public abstract IList<T> getAll<T>();

        public static IList<T> deserializeToList<T>(string jsonString) {
            InvalidJsonElements = null;
            var array = JArray.Parse(jsonString);
            IList<T> objectsList = new List<T>();

            foreach (var item in array) {
                try {
                    // CorrectElements
                    objectsList.Add(item.ToObject<T>());
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    InvalidJsonElements = InvalidJsonElements ?? new List<string>();
                    InvalidJsonElements.Add(item.ToString());
                }
            }

            return objectsList;
        }

    }
}