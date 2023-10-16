using Microsoft.AspNetCore.Mvc;
using Tahseen.Api.Models;
using Tahseen.Service.DTOs.Feedbacks.UserMessages;
using Tahseen.Service.Interfaces.IFeedbackService;

namespace Tahseen.Api.Controllers.FeedbackControllers;

[ApiController]
[Route("api[controller]")]
public class UserMessageController : ControllerBase
{
    private readonly IUserMessageService _userMessageService;

    public UserMessageController(IUserMessageService userMessageService)
    {
        _userMessageService = userMessageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = _userMessageService.RetrieveAll()
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
            Data = await _userMessageService.RetrieveByIdAsync(Id)
        };
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(UserMessageForCreationDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _userMessageService.AddAsync(dto)
        };
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _userMessageService.RemoveAsync(Id)
        };
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(long Id, UserMessageForUpdateDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _userMessageService.ModifyAsync(Id, dto)
        };
        return Ok(response);
    }
}