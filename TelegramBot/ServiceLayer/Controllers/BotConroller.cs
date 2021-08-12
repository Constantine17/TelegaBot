using DataLayer;
using DataLayer.Client;
using DataLayer.Client.Enams;
using DataLayer.Repository;
using DataLayer.Repository.Abstract;
using DataLayer.Specifications;
using ServiceLayer.BotBehavior;
using ServiceLayer.BotBehavior.Abstract;
using ServiceLayer.Massages;
using ServiceLayer.Services;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace ServiceLayer.Controllers
{
    public class BotConroller
    {
        private readonly IRepository<IClientChat> repository;
        private readonly IBotService botService;
        private readonly Dictionary<string, IBehavior<IClientChat>> actionFromComand;
        public BotConroller(IBotService botService)
        {
            this.repository = new ClientChatRepository();
            this.botService = botService;

            actionFromComand = new()
            {
                { "/info", new InfoBehavior(botService.SayAsync, repository) },
                { "/start", new StartBehavior(botService.SayAsync, botService) },
                { "/registration", new StartBehavior(botService.SayAsync, botService) },
            };
        }

        public void StartBot()
        {
            botService.StartReceiving();
            botService.OnMassage += BotService_OnMassage;
        }

        private void BotService_OnMassage(object sender, MessageEventArgs arg)
        {
            var message = arg.Message;

            if (message != null)
            {
                IClientChat chat = GetChat(message);

                if (message.Entities != null && message.Entities.Any())
                {
                    foreach (var entity in message.Entities)
                    {
                        switch (entity.Type)
                        {
                            case MessageEntityType.BotCommand:
                                TryGetCommand(message.Text, chat);
                                break;

                            default:
                                botService.SayAsync(new UnknownСommandMassage(), chat);
                                break;
                        }
                    }
                }
                else if (chat.State != ClientState.Registered) new RegistrationService(botService, chat).Register(message.Text);

                else botService.SayAsync(new UnknownСommandMassage(), chat);
            }
        }

        private IClientChat GetChat(Telegram.Bot.Types.Message message)
        {
            var chat = repository.Get(new ConditionalSpecification<IClientChat>(s => s.Chat.Id == message.Chat.Id)).FirstOrDefault();
            
            if (chat is null)
            {
                var newChat = new ClientChat(message.Chat);

                repository.Create(newChat);

                chat = repository.Get(new ConditionalSpecification<IClientChat>(s => s.Chat.Id == message.Chat.Id)).FirstOrDefault();
            }

            return chat;
        }

        private void TryGetCommand(string text, IClientChat chat)
        {
            IBehavior<IClientChat> behavior;
            var isFound = actionFromComand.TryGetValue(text, out behavior);

            if (isFound)
            {
                behavior.ExecuteBehavior(chat);
            }
            else
            {
                botService.SayAsync(new UnknownСommandMassage(), chat);
            }
        }
    }
}
