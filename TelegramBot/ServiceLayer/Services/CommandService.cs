using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ServiceLayer.Services
{
    public class CommandService:ICommandService
    {
        private readonly Dictionary<string, Action> CommandFromAction;

        public CommandService(Dictionary<string, Action> commandFromAction)
        {
            
        }

        public bool TryGetCommand(string command)
        {
            Action action;
            
            var actionFound = CommandFromAction.TryGetValue(command, out action);

            if (actionFound)
            {
                action();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
