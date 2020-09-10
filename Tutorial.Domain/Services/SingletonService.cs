using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial.Domain.Services
{
    public class SingletonService
    {
        public Guid Id { get; set; }

        public SingletonService()
        {
            this.Id = Guid.NewGuid();
        }

    }
}
