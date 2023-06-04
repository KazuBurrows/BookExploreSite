using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookExploreSite.Models
{
    public class CommandHandler
    {
        private CommandReciever _reciever = new CommandReciever();          // This can just be instantiated in the 'Command' 'Execute' function.


        public Query Search(string search_input)
        {
            Command command = new Command(_reciever, search_input);
            Query response = command.Execute();



            //Query a = new Query();
            //a.Payload = new string[] { search_input };

            return response;
            //return a;
        }
    }
}