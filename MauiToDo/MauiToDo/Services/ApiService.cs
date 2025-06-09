//using System.Net.Http.Headers;
//using System.Text;
//using System.Text.Json;
//using MauiToDo.Models; // MAUI tarafýnda ToDoItem modelini burada tanýmlayacaðýz

//namespace MauiToDo.Services
//{
//	public class ApiService
//	{
//		private readonly HttpClient _http;
//		private readonly string _baseUrl = "https://10.0.2.2:7160/api"; // Android için localhost yerine 10.0.2.2

//		public string Token { get; set; }

//		public ApiService()
//		{
//			_http = new HttpClient();
//		}

//		private void SetAuthHeader()
//		{
//			if (!string.IsNullOrEmpty(Token))
//				_http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
//		}

//		public async Task<List<ToDoItem>> GetToDosAsync()
//		{
//			SetAuthHeader();

//			var response = await _http.GetAsync($"{_baseUrl}/todo");

//			if (!response.IsSuccessStatusCode)
//				return new List<ToDoItem>();

//			var json = await response.Content.ReadAsStringAsync();
//			return JsonSerializer.Deserialize<List<ToDoItem>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
//		}
//		public async Task<HttpResponseMessage> PostAsync(string endpoint, HttpContent content)
//		{
//			SetAuthHeader();
//			return await _http.PostAsync($"{_baseUrl}/{endpoint}", content);
//		}

//	}
//}
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using MauiToDo.Models;

namespace MauiToDo.Services
{
	public class ApiService
	{
		private readonly HttpClient _http;
        private readonly string _baseUrl = "http://localhost:5130/api"; 


        public string Token { get; set; }

		public ApiService()
		{
			_http = new HttpClient();
		}

		private void SetAuthHeader()
		{
			if (!string.IsNullOrEmpty(Token))
				_http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
		}

		public async Task<List<ToDoItem>> GetToDosAsync()
		{
			SetAuthHeader();

			var response = await _http.GetAsync($"{_baseUrl}/todo");

			if (!response.IsSuccessStatusCode)
				return new List<ToDoItem>();

			var json = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<List<ToDoItem>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
		}

		public async Task<HttpResponseMessage> PostAsync(string endpoint, HttpContent content)
		{
			SetAuthHeader();
			return await _http.PostAsync($"{_baseUrl}/{endpoint}", content);
		}

		public async Task<HttpResponseMessage> PutAsync(string endpoint, HttpContent content)
		{
			SetAuthHeader();
			return await _http.PutAsync($"{_baseUrl}/{endpoint}", content);
		}

		public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
		{
			SetAuthHeader();
			return await _http.DeleteAsync($"{_baseUrl}/{endpoint}");
		}
	}
}
