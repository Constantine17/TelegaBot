using DataLayer.Users.ClientModels;
using ServiceLayer.BotBehavior.Abstract;
using System;

namespace ServiceLayer.BotBehavior
{
    public class SendTableBehavior : IBehavior<IClientChat>
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
