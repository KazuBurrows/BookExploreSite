using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookExploreSite.Models
{
    /*
    * Return json string of object
    */
    public static class JsonConverter
    {

        public static Query createQuery(string payload_type, string[] payload)
        {

            Query query = new Query
            {
                //QueryID = queryID,
                PayloadType = payload_type,
                Payload = payload
            };

            return query;
        }



        /// <summary>
        /// "Take 'Query' object and serialize to Json before sending to db."
        /// </summary>
        /// <param name="my_query"></param>
        /// <returns>"Json object."</returns>
        public static string encodeQuery(Query my_query)
        {
            return JsonConvert.SerializeObject(my_query, Formatting.Indented);
        }



        /// <summary>
        /// "Take Json returned by Proxy server and deserialize to 'Query' object."
        /// </summary>
        /// <param name="json_query"></param>
        /// <returns></returns>
        public static Query decodeQuery(string json_query)
        {
            return JsonConvert.DeserializeObject<Query>(json_query);
        }
    }
}