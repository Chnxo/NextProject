using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcContrib.CommandProcessor;
using MvcContrib.CommandProcessor.Commands;
using NextProjectMVC.Core;
using NextProjectMVC.Models.ViewModels;

namespace NextProjectMVC.Models.MessageHandlers
{
    public class TestMessageHandler : Command<MessageArgument<TestViewModel>>
    {
        protected override ReturnValue Execute(MessageArgument<TestViewModel> commandMessage)
        {
            switch (commandMessage.Action)
            {
                case MessageAction.Save:
                    break;

                case MessageAction.Get:
                    break;

                case MessageAction.GetAll:
                    break;

                case MessageAction.Edit:
                    break;

                case MessageAction.Delete:
                    break;

                case MessageAction.Custom:
                    break;

                default:
                    break;
            }
            return new Result().SetValue(false);
        }
    }
}