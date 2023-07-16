using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Toy.API.Dtos.Commons;
using Toy.API.Dtos.Notices;
using Toy.Application.Services.Notices;

namespace Toy.API.Controllers;

[ApiController]
[Route("[controller]s")]
public class NoticeController : ControllerBase
{
    private readonly ILogger<NoticeController> _logger;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public NoticeController(
        ILogger<NoticeController> logger,
        IMapper mapper,
        IMediator mediator)
    {
        _logger = logger;
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCollectionAsync(
        [FromQuery] NoticeReadQueryDto queryDto,
        [FromServices] NoticeQueryService service)
    {
        var parameter = _mapper.Map<NoticeQueryParameter>(queryDto);

        var entities = await service.GetPagedCollectionAsync(parameter);
        var totalCount = await service.GetTotalCountAsync(parameter);

        // TODO : (dh) 생성의 대한 책임을 NoticeReadCollectionDto 가 들고가는게 좋을까?
        var response = new NoticeReadCollectionDto
        {
            Notices = entities.Select(entity => _mapper.Map<NoticeSummaryDto>(entity)),
            Pagination = PaginationReadDto.Create(queryDto.PageNumber, queryDto.PageSize, totalCount)
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] NoticeCreateDto request)
    {
        var command = _mapper.Map<AddNoticeCommand>(request);
        var notice = await _mediator.Send(command);
        var dto = _mapper.Map<NoticeDetailDto>(notice);
        return StatusCode((int)HttpStatusCode.Created, dto);
    }
}