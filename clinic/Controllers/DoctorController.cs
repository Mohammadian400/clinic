﻿using Domain.ViewModel;
using Logic.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace clinic.Controllers
{
    public class DoctorController : BaseApiController
    {
        private readonly IDoctorRepository _repository;

        public DoctorController(IDoctorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<DoctorViewModel>> GetDoctors()
        {
            var doctors = _repository.GetAll();
            return Ok(doctors);
        }
    }

}








































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































