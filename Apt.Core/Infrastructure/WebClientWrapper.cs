using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;
 

namespace Apt.Core.Infrastructure
{
    public abstract class WebClientWrapperBase : IDisposable
    {
        private readonly string _baseUrl;
        private Lazy<WebClient> _lazyClient;

        protected WebClientWrapperBase(string baseUrl)
        {
            _baseUrl = baseUrl.Trim('/');
            _lazyClient = new Lazy<WebClient>(() => new WebClient());
        }

        protected WebClient Client()
        {
            if (_lazyClient == null)
            {
                throw new ObjectDisposedException("WebClient has been disposed");
            }

            return _lazyClient.Value;
        }

        protected T Execute<T>(string urlSegment)
        {
            return JsonConvert.DeserializeObject<T>(Client().DownloadString(_baseUrl + '/' + urlSegment.TrimStart('/')));
        }

        protected List<T> GetAll<T>(string urlSegment)
        {
            return JsonConvert.DeserializeObject<List<T>>(Client().DownloadString(_baseUrl + '/' + urlSegment.TrimStart('/')));
        }

        protected void Del<T>(string urlSegment)
        {
            JsonConvert.DeserializeObject<T>(Client().DownloadString(_baseUrl + '/' + urlSegment.TrimStart('/')));
        }

        protected void PostValues<T>(string urlSegment, T item)
        {
            //JsonConvert.DeserializeObject<T>(Client().DownloadString(_baseUrl + '/' + urlSegment.TrimStart('/')));

            //var bytes = Encoding.Default.GetBytes(item);

            //Client().UploadData(Client().DownloadString(_baseUrl + '/' + urlSegment.TrimStart('/')), item);

            MemoryStream ms = new MemoryStream();
            var serializer = new DataContractJsonSerializer(typeof(T));
            serializer.WriteObject(ms, item);

            Client().Headers.Add(HttpRequestHeader.Accept, "application/json");
            Client().Headers.Add(HttpRequestHeader.ContentType, "application/json");

            Client().UploadData(Client().DownloadString(_baseUrl + '/' + urlSegment.TrimStart('/')), "POST", ms.ToArray());

            //NameValueCollection nc = new NameValueCollection();
            //nc.Add("FirstName", "Rajendra");
            //nc.Add("LastName", "Kumar");

            //Client().UploadValues(Client().DownloadString(_baseUrl + '/' + urlSegment.TrimStart('/')), nc);      

        }


        ~WebClientWrapperBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_lazyClient != null)
            {
                if (disposing)
                {
                    if (_lazyClient.IsValueCreated)
                    {
                        _lazyClient.Value.Dispose();
                        _lazyClient = null;
                    }
                }

                // There are no unmanaged resources to release, but
                // if we add them, they need to be released here.
            }
        }
    }
}

public static class JsonHelper
{
    public static string ToJson<T>(T instance)
    {

        var serializer = new  DataContractJsonSerializer(typeof(T)); 
        using (var tempStream = new MemoryStream())
        {
            serializer.WriteObject(tempStream, instance);
            return Encoding.Default.GetString(tempStream.ToArray());
        }
    }

    public static T FromJson<T>(string json)
    {
   
        
        var serializer = new DataContractJsonSerializer(typeof(T));
        using (var tempStream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
        {
            return (T)serializer.ReadObject(tempStream);
        }
    }
}