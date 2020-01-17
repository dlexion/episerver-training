using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EpiserverSite.Business.CreatePage;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Business
{
    public abstract class CreatePageService<T> : ICreatePageService<T> where T : BasePage
    {
        public abstract bool TryCreate(string pageName, ContentReference parent, out T newPage);
    }
}