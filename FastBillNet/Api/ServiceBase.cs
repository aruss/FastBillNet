#region License

/* Copyright (c) 2013 Russlan Akiev
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy 
 * of this software and associated documentation files (the "Software"), to 
 * deal in the Software without restriction, including without limitation the 
 * rights to use, copy, modify, merge, publish, distribute, sublicense, and/or 
 * sell copies of the Software, and to permit persons to whom the Software is 
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software. 
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 * THE SOFTWARE.
 */

#endregion

using System.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace FastBillNet
{
    public abstract class ServiceBase
    {
        public virtual string UserName
        {
            get { return ConfigurationManager.AppSettings["FastBill:UserName"]; }
        }

        public virtual string Password
        {
            get { return ConfigurationManager.AppSettings["FastBill:Password"]; }
        }

        public virtual string BaseAddress
        {
            get { return ConfigurationManager.AppSettings["FastBill:BaseAddress"]; }
        }

        public virtual ApiResponse<TResponse> Send<TResponse>(object request)
            where TResponse : ResponseBase
        {
            using (var c = new HttpClient())
            {
                c.BaseAddress = new Uri(this.BaseAddress);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", 
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(String.Format("{0}:{1}", this.UserName, this.Password))));

                var req = new HttpRequestMessage(HttpMethod.Post, string.Empty)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(request,
                        Formatting.None,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        }),
                        Encoding.UTF8, "application/json")
                };

                var result = c.SendAsync(req).Result;
                var stringContent = result.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<ApiResponse<TResponse>>(stringContent);
            }
        }
    }
}