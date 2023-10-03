﻿using CourseHub.API.Helpers.Cookie;
using CourseHub.API.Realtime.Services.Messaging;
using CourseHub.Core.RequestDtos.Social.ChatMessageDtos;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;

namespace CourseHub.API.Realtime.Hubs;

public partial class AppHub
{
    // files -> fileNames
    public async Task SendToConversation(Message message)
    {
        var context = Context.GetHttpContext();
        if (context is null)
            return;

        var clientId = (Guid)context.GetClientId()!;
        Guid conversationId = (Guid)message.ReceiverId!;



        CreateChatMessageDto dto = new()
        {
            Id = Guid.NewGuid(),
            ConversationId = conversationId
        };
        if (message.Type == MessageTypes.CreateTextChatMessage)
            dto.Content = message.Data;
        else if (message.Type == MessageTypes.CreateFileChatMessage)
            dto.Attachments = JsonSerializer.Deserialize<List<string>>(message.Data);
        else
            return;



        var conversation = await _conversationService.Get(conversationId, clientId);
        if (conversation is null)
            return;
        var memberIds = conversation.Data!.Members.Select(_ => _.CreatorId.ToString());



        var result = await _chatMessageService.Create(dto, clientId);
        if (result.IsSuccessful)
        {
#pragma warning disable CS4014
            Clients.Users(memberIds).SendAsync(message.Callback, conversationId, result.Data);
#pragma warning restore CS4014
        }
    }
}
