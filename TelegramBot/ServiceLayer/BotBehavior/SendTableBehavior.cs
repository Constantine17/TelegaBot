using DataLayer.Users.Abstract;
using DataLayer.Users.ClientModels;
using ServiceLayer.BotBehavior.Abstract;
using System;

namespace ServiceLayer.BotBehavior
{
    public class SendTableBehavior : IBehavior<IUserChat>
    {
        public IBehavior<IUserChat> NextBehavior { get; }

        private readonly Action<string, IUserChat> communicationMethod;

        private readonly string fileAdress;
        public SendTableBehavior(Action<string, IUserChat> communicationMethod, string fileAdress)
        {
            this.communicationMethod = communicationMethod;
            this.fileAdress = fileAdress;
        }

        public void ExecuteBehavior(IUserChat parameter)
        {
            communicationMethod(fileAdress, parameter);
        }
    }
}
