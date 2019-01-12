using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.DAL;
using ProjectTest.Models.ViewModels;
using Serilog;

namespace ProjectTest.Controllers
{
    [Produces("application/json")]
    [Route("1.0/student/[Action]")]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public StudentController(IUnitOfWork _unitOfWork)
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

                var schools = unitOfWork.Student.SelectAll();

                if (schools == null)
                {
                    return NotFound();
                }

                return Ok(schools);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in gets Student api");

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

                var student = unitOfWork.Student.SelectOne(id);

                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in gets students api");

                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        [ActionName("insert")]
        public IActionResult Post([FromBody] StudentInsertModel student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = unitOfWork.Student.Insert(student);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in post student api");

                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut]
        [ActionName("update")]
        public IActionResult Put([FromBody] StudentUpdateModel student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = unitOfWork.Student.UpdateOne(student, student.ID);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in put student api");

                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete("{id}")]
        [ActionName("delete")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = unitOfWork.Student.DeleteOne(id);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in put student api");

                return StatusCode(500, ex.Message);
            }

        }
    }
}