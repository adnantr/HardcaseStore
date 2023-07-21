using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace AlkutayUI.ViewComponents
{
    public class _MessagePartial : ViewComponent
    {
        private readonly IMessageService _messageService;

        public _MessagePartial(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IViewComponentResult Invoke(Message p)
        {
            string hostName = Dns.GetHostName();
            IPAddress[] localIPs = Dns.GetHostAddresses(hostName);
            foreach (IPAddress address in localIPs)
            {
                TempData["IpAddress"] = address.ToString(); 
            }
            return View();
        }
    }
}
