using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial.Domain.Services
{
    public class TransientService
    {
        public Guid Id { get; set; }

        public TransientService()
        {

            this.Id = Guid.NewGuid();


        }

    }
}
