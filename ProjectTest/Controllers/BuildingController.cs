using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.DAL;
using ProjectTest.Models;
using ProjectTest.Models.ViewModels;
using Serilog;

namespace ProjectTest.Controllers
{
    [Produces("application/json")]
    [Route("1.0/building/[Action]")]
    public class BuildingController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public BuildingController(IUnitOfWork _unitOfWork)
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

                var result = unitOfWork.Building.SelectAll();

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in gets Building api");

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

                var result = unitOfWork.Building.SelectOne(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in gets Building api");

                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        [ActionName("insert")]
        public IActionResult Post([FromBody] BuildingInsertModel building)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = unitOfWork.Building.Insert(building);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in post building api");

                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut]
        [ActionName("update")]
        public IActionResult Put([FromBody] BuildingUpdateModel building)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = unitOfWork.Building.UpdateOne(building, building.ID);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in put building api");

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

                var result = unitOfWork.Building.DeleteOne(id);

                return Ok(new { result });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exceptions occurred in put building api");

                return StatusCode(500, ex.Message);
            }

        }
    }
}