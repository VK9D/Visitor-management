﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using visitor_management_api.Data;
using visitor_management_api.Dtos;
using visitor_management_api.Models;

namespace visitor_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitRepo _repository;
        private readonly IMapper _mapper;

        public VisitsController(IVisitRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VisitReadDto>> GetAllVisits()
        {
            var visitItems = _repository.GetAllVisits();

            if (visitItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<VisitReadDto>>(visitItems));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}", Name = "GetVisitById")]
        public ActionResult<VisitReadDto> GetVisitById(int id)
        {
            var visitItem = _repository.GetVisitById(id);

            if (visitItem != null)
            {
                return Ok(_mapper.Map<VisitReadDto>(visitItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<VisitReadDto> CreateVisit(VisitCreateDto visitCreateDto)
        {
            var visitModel = _mapper.Map<Visit>(visitCreateDto);
            _repository.CreateVisit(visitModel);
            _repository.SaveChanges();

            var visitReadDto = _mapper.Map<VisitReadDto>(visitModel);

            return CreatedAtRoute(nameof(GetVisitById), new { Id = visitReadDto.Id }, visitReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateVisit(int id, VisitUpdateDto visitUpdateDto)
        {
            var visitModelFromRepo = _repository.GetVisitById(id);
            if (visitModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(visitUpdateDto, visitModelFromRepo);

            _repository.UpdateVisit(visitModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialVisitUpdate(int id, JsonPatchDocument<VisitUpdateDto> patchDocument)
        {
            var visitModelFromRepo = _repository.GetVisitById(id);
            if (visitModelFromRepo == null)
            {
                return NotFound();
            }

            var visitToPatch = _mapper.Map<VisitUpdateDto>(visitModelFromRepo);

            patchDocument.ApplyTo(visitToPatch, ModelState);

            if (!TryValidateModel(visitToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(visitToPatch, visitModelFromRepo);

            _repository.UpdateVisit(visitModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteVisit(int id)
        {
            var visitModelFromRepo = _repository.GetVisitById(id);
            if (visitModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteVisit(visitModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}