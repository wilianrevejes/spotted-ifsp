using System;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Spotted.Factory {
    class PublicationFactory {

        WebClient wc;
        string baseAPIUrl = "http://192.168.1.101:8080";
        public static List<string> InvalidJsonElements;


        public PublicationFactory() {
            wc = new WebClient();
        }

        public string create(string content) {
            try {

                string csrfToken = "JWT eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpZCI6IjU5NWE0N2Y4YWEwNDhmMDQ0YzNkMzZhOCJ9.bsPsloXOOQ_Q1Zix_zU2dFFPrlC7I3DgLWrV2JEe0P8";
                Console.WriteLine("CSRF Token: {0}", csrfToken);

                wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                wc.Headers.Add(HttpRequestHeader.Accept, "application/json");
                wc.Headers.Add("Authorization", csrfToken);
                wc.Headers.Add("x-spotted-userid", "595a47f8aa048f044c3d36a8");
                wc.Headers.Add("X-Requested-With", "XMLHttpRequest");


                string dataString = @"{""content"": """ + content + @"""}";

                byte[] responseBytes = wc.UploadData(new Uri(this.baseAPIUrl + "/publications"), "POST", Encoding.UTF8.GetBytes(dataString));
               
                var response = JObject.Parse(Encoding.UTF8.GetString(responseBytes));
                
                return response["meta"]["message"].ToString();
            }
            catch(Exception error) {
                throw error;
            }
        }

        public IList<Publication> getAll() {
            try {

                string csrfToken = "JWT eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpZCI6IjU5NWE0N2Y4YWEwNDhmMDQ0YzNkMzZhOCJ9.bsPsloXOOQ_Q1Zix_zU2dFFPrlC7I3DgLWrV2JEe0P8";

                wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                wc.Headers.Add(HttpRequestHeader.Accept, "application/json");
                wc.Headers.Add("Authorization", csrfToken);
                wc.Headers.Add("x-spotted-userid", "595a47f8aa048f044c3d36a8");
                wc.Headers.Add("X-Requested-With", "XMLHttpRequest");


                byte[] responseBytes = wc.DownloadData(new Uri(this.baseAPIUrl + "/publications/list"));

                var responseString = Encoding.UTF8.GetString(responseBytes);
                var responseJSON = JObject.Parse(responseString);

                IList<Publication> responseList = DeserializeToList<Publication>(responseJSON["data"]["content"].ToString());

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
                    InvalidJsonElements = InvalidJsonElements ?? new List<string>();
                    InvalidJsonElements.Add(item.ToString());
                }
            }

            return objectsList;
        }

    }
}