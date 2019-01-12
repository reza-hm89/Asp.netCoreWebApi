using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProjectTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.DAL
{
    public class HttpUnitOfWork : UnitOfWork
    {
        public HttpUnitOfWork(ApplicationDbContext context ,IHttpContextAccessor httpAccessor)
            : base(context)
        {
        }
    }
}
