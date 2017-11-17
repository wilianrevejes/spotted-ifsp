using System;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Spotted {
    class UserFactory: Factory {
        
        public UserFactory(): base() {
          
        }

        public override string create(string content) {
            try {
                string dataString = @"{""content"": """ + content + @"""}";

                byte[] responseBytes = wc.UploadData(new Uri(this.baseAPIUrl + "/users"), "POST", Encoding.UTF8.GetBytes(dataString));

                var response = JObject.Parse(Encoding.UTF8.GetString(responseBytes));

                return response["meta"]["message"].ToString();
            }
            catch (Exception error) {
                throw error;
            }
        }

        public override IList<Publication> getAll<Publication>() {
            try {
                
                byte[] responseBytes = wc.DownloadData(new Uri(this.baseAPIUrl + "/users/list"));

                var responseString = Encoding.UTF8.GetString(responseBytes);
                var responseJSON = JObject.Parse(responseString);

                IList<Publication> responseList = deserializeToList<Publication>(responseJSON["data"]["content"].ToString());

                return responseList;
            }
            catch (Exception error) {
                throw error;
            }
        }
        

    }
}