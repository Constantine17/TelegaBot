using DataLayer.ClientModels;
using ServiceLayer.BotBehavior.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.BotBehavior
{
    public class SendTableBehavior: IBehavior<IClientChat>
    {
        public IBehavior<IClientChat> NextBehavior { get; }

        private readonly Action<string, IClientChat> communicationMethod;

        private readonly string fileAdress;
        public SendTableBehavior(Action<string, IClientChat> communicationMethod, string fileAdress)
        {
            this.communicationMethod = communicationMethod;
            this.fileAdress = fileAdress;
        }

        public void ExecuteBehavior(IClientChat parameter)
        {
            communicationMethod(fileAdress, parameter);
        }
    }
}
