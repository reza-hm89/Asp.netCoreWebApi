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
    [Route("1.0/grade/[Action]")]
    public class GradeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public GradeController(IUnitOfWork _unitOfWork)
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

                var result = unitOfWork.Grade.SelectAll();

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in gets grades api");

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

                var result = unitOfWork.Grade.SelectOne(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in gets grade api");

                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        [ActionName("insert")]
        public IActionResult Post([FromBody] GradeInsertModel grade)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = unitOfWork.Grade.Insert(grade);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in post grade api");

                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut]
        [ActionName("update")]
        public IActionResult Put([FromBody] GradeUpdateModel grade)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = unitOfWork.Grade.UpdateOne(grade, grade.ID);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in put grade api");

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

                var result = unitOfWork.Grade.DeleteOne(id);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in put grade api");

                return StatusCode(500, ex.Message);
            }

        }
    }
}