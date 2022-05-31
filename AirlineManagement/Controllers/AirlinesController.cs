﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AirlineManagement.Models;
using AirlineManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlinesController : ControllerBase
    {
        private readonly IAirlineRepository _airlineRepository;
        public AirlinesController(IAirlineRepository repos)
        {
            this._airlineRepository = repos;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Airline>> GetAirlines()
        {
            try
            {
                IEnumerable<Airline> airlines = _airlineRepository.GetAirlines();
                if (airlines != null)
                {
                    return Ok(airlines.ToList());
                }
                else
                {
                    string msg = $"No Airlines available in the database.";
                    return NotFound(GenerateResponseData(false, null, msg));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }
        
        [HttpGet("{id}")]
        public ActionResult<Airline> GetAirlineById(int id)
        {
            try
            {
                Airline airline = _airlineRepository.GetAirlineById(id);
                if (airline != null)
                {
                    return Ok(GenerateResponseData(true, airline, "Airline Found"));
                }
                else
                {
                    string msg = $"Airline {id} not found.";
                    return NotFound(GenerateResponseData(false, null, msg));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult AddAirline([FromBody] Airline obj)
        {
            try
            {
                _airlineRepository.AddAirline(obj);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] bool value)
        {
            try
            {
                Airline airline = _airlineRepository.UpdateAirlineStatus(id, value);
                if (airline != null)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    string msg = $"Airline not found. Unable to Update Airline ID: {id}";
                    //return StatusCode(StatusCodes.Status404NotFound, GenerateResponseData(false, null, msg));
                    return NotFound(GenerateResponseData(false, null, msg));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAirline(int id)
        {
            try
            {
                Airline airline = _airlineRepository.DeleteAirline(id);
                if (airline != null)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    string msg = $"Airline not found. Unable to delete Airline ID: {id}";
                    return NotFound(GenerateResponseData(false, null, msg));
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }            
        }

        private object GenerateResponseData(bool isSuccess, Airline airline, string msg)
        {
            var obj = new { isSuccess = isSuccess, data = airline, message = msg };
            return obj;
        }
    }
}
