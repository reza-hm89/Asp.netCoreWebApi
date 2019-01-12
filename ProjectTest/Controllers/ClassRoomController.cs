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
    [Route("1.0/classRoom/[Action]")]
    public class ClassRoomController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ClassRoomController(IUnitOfWork _unitOfWork)
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

                var result = unitOfWork.ClassRoom.SelectAll();

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in gets classRoom api");

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

                var result = unitOfWork.ClassRoom.SelectOne(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in gets classRoom api");

                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        [ActionName("insert")]
        public IActionResult Post([FromBody] ClassInsertModel classRoom)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = unitOfWork.ClassRoom.Insert(classRoom);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in post classRoom api");

                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut]
        [ActionName("update")]
        public IActionResult Put([FromBody] ClassUpdateModel classRoom)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = unitOfWork.ClassRoom.UpdateOne(classRoom, classRoom.ID);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in put classRoom api");

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

                var result = unitOfWork.ClassRoom.DeleteOne(id);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in put classRoom api");

                return StatusCode(500, ex.Message);
            }

        }
    }
}