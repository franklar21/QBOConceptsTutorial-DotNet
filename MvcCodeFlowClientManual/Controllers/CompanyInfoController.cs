﻿

using Intuit.Ipp.Core;
using Intuit.Ipp.Data;
using Intuit.Ipp.QueryFilter;
using Intuit.Ipp.Security;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net;
using System.Net.Http.Headers;
using Intuit.Ipp.DataService;

namespace MvcCodeFlowClientManual.Controllers
{
    public class CompanyInfoController : AppController
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CompanyInfo()
        {
            //Make QBO api calls using .Net SDK
            if (Session["realmId"] != null)
            {
                string realmId = Session["realmId"].ToString();

                try
                {

                    //Initialize OAuth2RequestValidator and ServiceContext
                    ServiceContext serviceContext = base.IntializeContext(realmId);
                    DataService dataService = new DataService(serviceContext);


                    //Query/Read CompanyInfo
                    QueryService<CompanyInfo> querySvc = new QueryService<CompanyInfo>(serviceContext);//CompanyInfo call
                    CompanyInfo companyInfo = querySvc.ExecuteIdsQuery("SELECT * FROM CompanyInfo").FirstOrDefault();



                    return View("Index", (object)("QBO API calls Success!"));
                }
                catch (Exception ex)
                {
                    return View("Index", (object)"QBO API calls Failed!");
                }

            }
            else
                return View("Index", (object)"QBO API call Failed!");
        }
    }
}