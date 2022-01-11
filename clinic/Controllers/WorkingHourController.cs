using Logic;
using Logic.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinic.Controllers
{
    public class WorkingHourController : BaseApiController
    {
        private readonly IWorkingHourRepository _repository;
        public WorkingHourController(IWorkingHourRepository repository)
        {
            _repository = repository;
        }
        //public ActionResult FreeTime()
        //{
        //}
    }
}
