using DataLayer.Specifications.Abstract;
using DataLayer.Users.Abstract;
using System;
using Telegram.Bot.Types;

namespace DataLayer.Specifications
{
    public class GetByIdSpecification : ISpecification<IUserChat>
    {
        private readonly Message massage;

        public GetByIdSpecification(Message massage)
        {
            this.massage = massage;
        }
        public bool IsSatisfiedBy(IUserChat candidate)
        {
           return candidate.Chat.Id == massage.Chat.Id;
        }
    }
}
