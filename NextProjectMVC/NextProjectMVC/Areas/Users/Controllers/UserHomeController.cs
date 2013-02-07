using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextProjectMVC.Core;
using NextProjectMVC.Models.ViewModels;
using PerpetuumSoft.Knockout;

namespace NextProjectMVC.Areas.Users.Controllers
{
    public class UserHomeController : Controller
    {
        //
        // GET: /Users/UserHome/

        private readonly IBus _bus;

        public UserHomeController(IBus bus)
        {
            _bus = bus;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            TestViewModel tvm = new TestViewModel();
            return View(tvm);
        }

        public ActionResult ChnxoTest()
        {
            ChnxoViewModel cvm = new ChnxoViewModel();
            return View(cvm);
        }

        public ActionResult ChnxoSave(ChnxoViewModel cvm)
        {
            MessageArgument<ChnxoViewModel> maCVM = new MessageArgument<ChnxoViewModel>();
            maCVM.Action = MessageAction.Save;
            maCVM.MainParameter = cvm;
            var messageResult = _bus.Send(maCVM);
            if (messageResult.Success)
            {
                return new JSONNetResult(cvm);
            }
            return null;
        }
    }
}