﻿using DataLayer;
using DataLayer.Client;
using DataLayer.Client.Enams;
using ServiceLayer.Massages;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ServiceLayer.Controllers
{
    public class BotConroller
    {
        private readonly ICommandService commandService;
        private IClientChat chat;
        private readonly IBotService botService;
        private readonly IRegistrationService registrationService;
        public BotConroller(IBotService botService, IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
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

            if (chat == null)
            {
                chat = new ClientChat(message.Chat);
            }

            if (message != null)
            {
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
                else if (chat.State != ClientState.Registered) registrationService.StartRegistration(chat, message.Text);

                else botService.SayAsync(new UnknownСommandMassage(), chat);
            }
        }

        private void TryGetCommand(string text, IClientChat chat)
        {
            switch (text)
            {
                case "/start":
                    botService.SayAsync(new WelcomeMessage(), chat);
                    break;

                case "/registration":
                    chat.State = ClientState.NotRegistered;
                    registrationService.StartRegistration(chat, text);
                    break;

                case "/info":
                    if (chat.State == ClientState.Registered)
                    {
                        foreach (var item in chat.Client)
                        {
                            botService.SayAsync(new Massage(item), chat);
                        }
                    }
                    else
                    {
                        botService.SayAsync(new Massage("Ви ще не зарегіструвалися"), chat);
                    }
                    break;

                default:
                    botService.SayAsync(new UnknownСommandMassage(), chat);
                    break;
            }
        }
    }
}