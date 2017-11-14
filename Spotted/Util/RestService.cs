using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class RestService : IRestService {
	
  HttpClient client;

  public RestService() {
    client = new HttpClient ();
    client.MaxResponseContentBufferSize = 256000;
  }

	public async Task<List<TodoItem>> GetDataAsync() {
	  ...
	  // RestUrl = http://developer.xamarin.com:8081/api/todoitems/
	  var uri = new Uri (string.Format (Constants.RestUrl, string.Empty));
	  ...
	  var response = await client.GetAsync (uri);
	  if (response.IsSuccessStatusCode) {
	      var content = await response.Content.ReadAsStringAsync ();
	      Items = JsonConvert.DeserializeObject <List<TodoItem>> (content);
	  }
	  ...
	}

	public async Task CreateAsync (TodoItem item, bool isNewItem = false) {
	  // RestUrl = http://developer.xamarin.com:8081/api/todoitems/
	  var uri = new Uri (string.Format (Constants.RestUrl, string.Empty));

	  ...
	  var json = JsonConvert.SerializeObject (item);
	  var content = new StringContent (json, Encoding.UTF8, "application/json");

	  HttpResponseMessage response = null;
	  if (isNewItem) {
	    response = await client.PostAsync (uri, content);
	  }
	  ...

	  if (response.IsSuccessStatusCode) {
	    Debug.WriteLine (@"TodoItem successfully saved.");

	  }
  	...
	}

	public async Task UpdateAsync (TodoItem item, bool isNewItem = false) {
	  ...
	  response = await client.PutAsync (uri, content);
	  ...
	}

	public async Task DeleteTodoItemAsync (string id) {
	  // RestUrl = http://developer.xamarin.com:8081/api/todoitems/{0}
	  var uri = new Uri (string.Format (Constants.RestUrl, id));
	  ...
	  var response = await client.DeleteAsync (uri);
	  if (response.IsSuccessStatusCode) {
	    Debug.WriteLine (@"TodoItem successfully deleted.");
	  }
	  ...
	}

}
