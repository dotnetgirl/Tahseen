﻿using Microsoft.AspNetCore.Mvc;
using Tahseen.Api.Models;
using Tahseen.Service.DTOs.SchoolAndEducations;
using Tahseen.Service.Interfaces.ISchoolAndEducation;
using Tahseen.Service.Services.SchoolAndEducations;

namespace Tahseen.Api.Controllers.SchoolAndEducationsControllers;


[ApiController]
[Route("api/[controller]/[action]")]
public class PupilsControllers : ControllerBase
{
    private readonly IPupilService _pupilService;

    public PupilsControllers(IPupilService pupilService)
    {
        this._pupilService = pupilService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = _pupilService.RetrieveAll()
        };
        return Ok(response);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long Id)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _pupilService.RetrieveByIdAsync(Id)
        };
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> PostAsync(PupilForCreationDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _pupilService.AddAsync(dto)
        };
        return Ok(response);
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _pupilService.RemoveAsync(id)
        };
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(long id, PupilForUpdateDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _pupilService.ModifyAsync(id, dto)
        };
        return Ok(response);
    }
}