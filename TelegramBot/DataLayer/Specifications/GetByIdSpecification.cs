using DataLayer.Specifications.Abstract;
using DataLayer.SQLite.Entities.Abstract;
using Telegram.Bot.Types;

namespace DataLayer.Specifications
{
    public class GetByIdSpecification : ISpecification<IUserEntity>
    {
        private readonly long id;

        public GetByIdSpecification(Message massage)
        {
            this.id = massage.Chat.Id;
        }

        public GetByIdSpecification(long id)
        {
            this.id = id;
        }
        public bool IsSatisfiedBy(IUserEntity candidate)
        {
            return candidate.ChatId == id;
        }
    }
}
