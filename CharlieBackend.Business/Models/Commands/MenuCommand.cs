﻿using CharlieBackend.Business.Services.Interfaces;
using CharlieBackend.Core.Entities;
using CharlieBackend.Core.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace CharlieBackend.Business.Models.Commands
{
    public class MenuCommand : Command
    {
        private readonly IAccountService _accountService;
        public override string Name => "menu";

        public MenuCommand(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public override async Task<string> Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            string response = "This is a menu:";
            var account = await _accountService
               .GetAccountByTelegramId(chatId);

            return (await client.SendTextMessageAsync(chatId,
                response, replyToMessageId: messageId, replyMarkup: GetInlineMenu(account))).Text;
        }

        private IReplyMarkup GetInlineMenu(Account account)
        {
            var buttonsList = new List<List<InlineKeyboardButton>>
            {
                new List<InlineKeyboardButton>{ new InlineKeyboardButton { Text = "Personal Info", CallbackData = "/personalinfo" } },
                new List<InlineKeyboardButton>{ new InlineKeyboardButton { Text = "Student Groups", CallbackData = "/studentgroups" } }
            };

            if (account.Role.Is(UserRole.Student))
            {
                buttonsList.AddRange(new List<List<InlineKeyboardButton>>
                {
                    new List<InlineKeyboardButton>{ new InlineKeyboardButton { Text = "Classmates", CallbackData = "/classmates" } },
                    new List<InlineKeyboardButton>{ new InlineKeyboardButton { Text = "Upcoming Homeworks", CallbackData = "/upcominghomeworks" } }
                });
            }

            if (account.Role.Is(UserRole.Mentor))
            {
                buttonsList.AddRange(new List<List<InlineKeyboardButton>>
                {
                    new List<InlineKeyboardButton>{ new InlineKeyboardButton { Text = "Courses", CallbackData = "/courses" } }
                });
            }

            return new InlineKeyboardMarkup(buttonsList);
        }
    }
}