using BookExploreSite.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookExploreSite.Models
{
    public class CommandReciever
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search_input"></param>
        /// <returns></returns>
        public Query SearchQueryCommand(string search_input)
        {
            string query_type = "Search";
            string[] payload = { search_input };
            Query client_query = JsonConverter.createQuery(query_type, payload);                    // Create Query object

            string json_query = JsonConverter.encodeQuery(client_query);                            // Convert Query object to json
            string responseMsg = AsynchronousClient.StartClient(json_query);                        // Send to server and wait for return
            Console.WriteLine("Here is the json response from the server: " + responseMsg);

            Query server_query = JsonConverter.decodeQuery(responseMsg);


            return server_query;



            //Query a = new Query();
            //a.Payload = new string[] { search_input };

            //return a;

        }
    }
}