using DataLayer.ClientModels;
using DataLayer.ClientModels.Enams;
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

namespace ServiceLayer.Controllers
{
    public class BotConroller
    {
        private readonly IRepository<IClientChat> repository;
        private readonly IBotService botService;
        private readonly Dictionary<string, IBehavior<IClientChat>> actionFromCommand;
        public BotConroller(IBotService botService)
        {
            this.repository = new ClientChatRepository();
            this.botService = botService;

            actionFromCommand = new()
            {
                { "/info", new InfoBehavior(botService.SayAsync, new ClientEntityRepository(), new SendTableBehavior(botService.SendFileAsync, @".\ClientTable.csv")) },
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

            var chat = GetChat(message);

            if (chat != null)
            {
                chat.LastMessage = message;
                GetCommand(message.Text, chat);
            }
            else botService.SayAsync(new UnknownСommandMassage(), chat);

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
