using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Business.Services;
using Tutorial.Domain.Services;

namespace Tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependancyInjectionTestController : ControllerBase
    {

        private readonly CallerService callerService;
        private readonly ScopedService scopedService;
        private readonly SingletonService singletonService;
        private readonly TransientService transientService;

        public DependancyInjectionTestController(CallerService callerService, ScopedService scopedService, SingletonService singletonService, TransientService transientService)
        {
            this.callerService = callerService;
            this.scopedService = scopedService;
            this.singletonService = singletonService;
            this.transientService = transientService;
        }


        [HttpGet("getmyid")]
        public IActionResult GetMyId()
        {

            var businessResult = this.callerService.GetMyId();


            businessResult.Add("singletonController", this.singletonService.Id);
            businessResult.Add("scopedController", this.scopedService.Id);
            businessResult.Add("transientController", this.transientService.Id);


            return new JsonResult(businessResult);


        }
    }
}
