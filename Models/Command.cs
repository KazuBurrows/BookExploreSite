using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookExploreSite.Models
{
    class Command
    {
        private CommandReciever _reciever;
        private string _search_input;


        /// <summary>
        /// "The constructor"
        /// </summary>
        /// <param name="reciever">""</param>
        /// <param name="search_input">""</param>
        public Command(CommandReciever reciever, string search_input)
        {
            this._reciever = reciever;
            this._search_input = search_input;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Query Execute()
        {
            return _reciever.SearchQueryCommand(_search_input);
        }
    }
}