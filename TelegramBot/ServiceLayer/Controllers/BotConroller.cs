using DataLayer.Repository;
using DataLayer.Repository.Abstract;
using DataLayer.Specifications;
using DataLayer.Users.Abstract;
using DataLayer.Users.AdminModels.Abstract;
using DataLayer.Users.ClientModels;
using DataLayer.Users.ClientModels.Enams;
using ServiceLayer.BotBehavior;
using ServiceLayer.BotBehavior.Abstract;
using ServiceLayer.Massages;
using ServiceLayer.Services;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Args;

namespace ServiceLayer.Controllers
{
    public class BotConroller
    {
        private readonly IRepository<IClientChat> сlientRepository;
        private readonly IRepository<IAdminChat> adminRepository;
        private readonly IBotService botService;
        public BotConroller(IBotService botService)
        {
            this.adminRepository = new AdminChatRepository();
            this.сlientRepository = new ClientChatRepository();
            this.botService = botService;

            
        }

        public void StartBot()
        {
            botService.StartReceiving();
            botService.OnMassage += BotService_OnMassage;
        }

        private void BotService_OnMassage(object sender, MessageEventArgs arg)
        {
            var message = arg.Message;

            var chat = GetChat(message);

            if (chat != null)
            {
                chat.LastMessage = message;
                GetCommand(message.Text, chat);
            }
            else botService.SayAsync(new UnknownСommandMassage(), chat);

        }

        private IUserChat GetChat(Telegram.Bot.Types.Message message)
        {
            var chat = сlientRepository.Get(new ConditionalSpecification<IClientChat>(s => s.Chat.Id == message.Chat.Id)).FirstOrDefault();

            if (chat is null)
            {
                var newChat = new ClientChat(message.Chat);

                repository.Create(newChat);

                chat = repository.Get(new ConditionalSpecification<IClientChat>(s => s.Chat.Id == message.Chat.Id)).FirstOrDefault();
            }

            return chat;
        }

        private void GetCommand(string text, IClientChat chat)
        {
            var isFound = actionFromCommand.TryGetValue(text, out var behavior);

            if (isFound)
            {
                behavior.ExecuteBehavior(chat);
            }

            else if (chat.State != ClientState.Registered) new RegistrationService(botService, chat).Register();

            else
            {
                botService.SayAsync(new UnknownСommandMassage(), chat);
            }
        }
    }
}
