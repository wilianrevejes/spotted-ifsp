using System;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Spotted {
    class InstituicaoEnsinoFactory {

        WebClient wc;
        string baseAPIUrl = "http://192.168.9.8:8080";
        public static List<string> InvalidJsonElements;


        public InstituicaoEnsinoFactory() {
            wc = new WebClient();
        }
        
        public IList<SelectItem> toSelect() {
            try {

                string csrfToken = "JWT eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpZCI6IjU5NWE0N2Y4YWEwNDhmMDQ0YzNkMzZhOCJ9.bsPsloXOOQ_Q1Zix_zU2dFFPrlC7I3DgLWrV2JEe0P8";

                wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                wc.Headers.Add(HttpRequestHeader.Accept, "application/json");
                wc.Headers.Add("Authorization", csrfToken);
                wc.Headers.Add("x-spotted-userid", "595a47f8aa048f044c3d36a8");
                wc.Headers.Add("X-Requested-With", "XMLHttpRequest");


                byte[] responseBytes = wc.DownloadData(new Uri(this.baseAPIUrl + "/instituicoes-ensino/select"));

                var responseString = Encoding.UTF8.GetString(responseBytes);
                var responseJSON = JObject.Parse(responseString);

                IList<SelectItem> responseList = DeserializeToList<SelectItem>(responseJSON["data"].ToString());

                return responseList;
            }
            catch (Exception error) {
                throw error;
            }
        }

        public static IList<T> DeserializeToList<T>(string jsonString) {
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