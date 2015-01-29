﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;

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
