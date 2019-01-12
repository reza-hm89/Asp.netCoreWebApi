using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTest.DAL;
using ProjectTest.Data;
using ProjectTest.Models;
using ProjectTest.Models.ViewModels;
using Serilog;

namespace ProjectTest.Controllers
{
    [Produces("application/json")]
    [Route("1.0/school/[Action]")]
    public class SchoolController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public SchoolController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        [HttpGet]
        [ActionName("gets")]
        public IActionResult Gets()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var schools = unitOfWork.School.SelectAll();

                if (schools == null)
                {
                    return NotFound();
                }

                return Ok(schools);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in gets schools api");

                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("{id}")]
        [ActionName("get")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var school = unitOfWork.School.SelectOne(id);

                if (school == null)
                {
                    return NotFound();
                }

                return Ok(school);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in gets schools api");

                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        [ActionName("insert")]
        public IActionResult PostSchool([FromBody] SchoolInsertModel school)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = unitOfWork.School.Insert(school);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in post school api");

                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut]
        [ActionName("update")]
        public IActionResult PutSchool([FromBody] SchoolUpdateModel school)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = unitOfWork.School.UpdateOne(school, school.ID);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in put school api");

                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete("{id}")]
        [ActionName("delete")]
        public IActionResult DeleteSchool([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = unitOfWork.School.DeleteOne(id);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in put school api");

                return StatusCode(500, ex.Message);
            }

        }
    }
}