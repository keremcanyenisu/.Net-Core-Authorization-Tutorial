using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial.Domain.Services
{
    public class ScopedService
    {
        public Guid Id { get; set; }

        public ScopedService()
        {
            this.Id = Guid.NewGuid();
        }


    }
}
