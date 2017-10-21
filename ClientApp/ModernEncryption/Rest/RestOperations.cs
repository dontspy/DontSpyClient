﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModernEncryption.Model;
using Newtonsoft.Json;

namespace ModernEncryption.Rest
{
    internal class RestOperations
    {
        private readonly HttpClient _client;

        public RestOperations()
        {
            _client = new HttpClient { MaxResponseContentBufferSize = 256000 };
        }

        public async Task<User> GetUserBy(string eMail)
        {
            var uri = new Uri(string.Format(Constants.RestUrlGetUser, eMail));
            var response = await _client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(content);
            }
            Debug.WriteLine("Server antwortet nicht"); // TODO: Improve error management
            return null;
        }

        public async Task<bool> SendMessage(Message message)
        {
            try
            {
                var uri = new Uri(string.Format(Constants.RestUrlSendMessage));
                var json = JsonConvert.SerializeObject(message);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);
                return true;
            }
            catch // TODO: Improve error management
            {
                Debug.WriteLine("Server antwortet nicht");
                return false;
            }
        }
    }
}
