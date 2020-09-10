using System;
using System.Collections.Generic;
using System.Text;
using Tutorial.Domain.Services;

namespace Tutorial.Business.Services
{
    public class CallerService
    {
        private readonly SingletonService singletonService;
        private readonly ScopedService scopedService;
        private readonly TransientService transientService;

        public CallerService(SingletonService singletonService, ScopedService scopedService, TransientService transientService)
        {
            this.singletonService = singletonService;
            this.scopedService = scopedService;
            this.transientService = transientService;
        }


        public Dictionary<string,Guid> GetMyId()
        {
            var dictionary = new Dictionary<string, Guid>();

            dictionary.Add("singleton", this.singletonService.Id);
            dictionary.Add("scoped", this.scopedService.Id);
            dictionary.Add("transient", this.transientService.Id);


            return dictionary;
        }
    }
}