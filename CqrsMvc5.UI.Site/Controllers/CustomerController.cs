using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CqrsMvc5.App.Cqrs;
using CqrsMvc5.App.Cqrs.Command;
using CqrsMvc5.App.Cqrs.Command.Models;
using CqrsMvc5.App.Cqrs.Query;
using CqrsMvc5.App.Cqrs.Query.Models;
using CqrsMvc5.App.Cqrs.Query.Queries;

namespace CqrsMvc5.UI.Site.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandProcessor _commandProcessor;

        public CustomerController(IQueryProcessor queryProcessor, ICommandProcessor commandProcessor)
        {
            _queryProcessor = queryProcessor;
            _commandProcessor = commandProcessor;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var result = _queryProcessor.Process(new GetCustomers(true));
            return View(result);
        }

        public ActionResult Details(Guid id)
        {
            return View(_queryProcessor.Process(new GetCustomerById(id)));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerModel customer)
        {
            _commandProcessor.Send(new AddCustomer(customer.FirstName, customer.LastName, customer.Email));
            return RedirectToAction("Index");
        }
    }
}