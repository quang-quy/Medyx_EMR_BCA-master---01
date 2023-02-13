using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net;
using System;
using System.Security.RightsManagement;

namespace Medyx_EMR_BCA.ApiAssets.Helpers
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        internal static object GetObjectFromJson<T>(string session)
        {
            return session == null ? default(T) : JsonConvert.DeserializeObject<T>(session);
        }
    }
}
