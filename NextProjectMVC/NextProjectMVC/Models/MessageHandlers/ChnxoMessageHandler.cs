using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcContrib.CommandProcessor.Commands;
using NextProjectMVC.Core;
using NextProjectMVC.Models.ViewModels;

namespace NextProjectMVC.Models.MessageHandlers
{
    public class ChnxoMessageHandler : Command<MessageArgument<ChnxoViewModel>>
    {
        protected override MvcContrib.CommandProcessor.ReturnValue Execute(MessageArgument<ChnxoViewModel> commandMessage)
        {
            switch (commandMessage.Action)
            {
                case MessageAction.Save:
                    if (commandMessage.MainParameter != null)
                    {
                        Result result = new Result(false);
                        commandMessage.MainParameter.Guild = "OldSchool";
                        result.Success = true;
                        return result;
                    }
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
            throw new NotImplementedException();
        }
    }
}