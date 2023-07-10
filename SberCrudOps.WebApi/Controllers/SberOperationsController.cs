using System.Data;
using System.Net;
using System.Text.Json;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SberCrudOps.Application.SberOperationUseCases.Commands.AddSberCreateOperation;
using SberCrudOps.Application.SberOperationUseCases.Commands.AddSberDeleteOperation;
using SberCrudOps.Application.SberOperationUseCases.Commands.AddSberUpdateOperation;
using SberCrudOps.Application.SberOperationUseCases.Commands.DeleteSberOperation;
using SberCrudOps.Application.SberOperationUseCases.Requests.GetSberOperationById;
using SberCrudOps.Application.Services;
using SberCrudOps.Shared.Abstractions.Commands;
using SberCrudOps.Shared.Abstractions.Queries;
using SberOperationResponseDto = SberCrudOps.Application.DTO.Response.SberOperationResponseDto;

namespace SberCrudOps.WebApi.Controllers;

public class SberOperationsController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public SberOperationsController(ICommandDispatcher commandDispatcher, 
        IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetSberOperationByIdQuery query)
    {
        var operation = await _queryDispatcher.QueryAsync(query);

        return Accepted(new Uri($"/api/SberOperations/{operation.Id}", UriKind.Relative), 
            new {
            operation.Id, 
            operation.IdSource, 
            operation.Added, 
            operation.InformationText,
            operation.TypeWorkCode, 
            operation.Completed});
    }

    
    [HttpPost("/api/SberCreateOperations")]
    public async Task<IActionResult> AddSberCreateOperation([FromBody] AddSberCreateOperationCommand command)
    {
        var result = await _commandDispatcher
            .DispatchAsync<AddSberCreateOperationCommand, Result<SberOperationResponseDto>>(command);

        var id = result.Value.Id;
        var added = result.Value.Added.ToString();
        
        return Accepted(new Uri($"/api/SberOperations/{id}", UriKind.Relative),new {id, added});
    }
    
    [HttpPost("/api/SberUpdateOperations")]
    public async Task<IActionResult> AddSberUpdateOperation([FromBody] AddSberUpdateOperationCommand command)
    {
        Result<SberOperationResponseDto> result = null;
        try
        {
            result = await _commandDispatcher
                .DispatchAsync<AddSberUpdateOperationCommand, Result<SberOperationResponseDto>>(command);
            var id = result.Value.Id;
            var added = result.Value.Added.ToString();
        
            return Accepted(new Uri($"/api/SberOperations/{id}", UriKind.Relative),new {id, added});
        }
        catch (DBConcurrencyException e)
        {
            var conflictResult = result.Value;
            return StatusCode((int)HttpStatusCode.Conflict, 
                new{conflictResult.Id, conflictResult.Added, conflictResult.Completed});
        }
    }
    
    [HttpPost("/api/SberDeleteOperations")]
    public async Task<IActionResult> AddSberDeleteOperation([FromBody] AddSberDeleteOperationCommand command)
    {
        Result<SberOperationResponseDto> result = null;
        try
        {
            result = await _commandDispatcher
                .DispatchAsync<AddSberDeleteOperationCommand, Result<SberOperationResponseDto>>(command);
            
            var id = result.Value.Id;
            var added = result.Value.Added.ToString();
        
            return Accepted(new Uri($"/api/SberOperations/{id}", UriKind.Relative),new {id, added});
        }
        catch (DBConcurrencyException e)
        {
            var conflictResult = result.Value;
            return StatusCode((int)HttpStatusCode.Conflict, 
                new{conflictResult.Id, conflictResult.Added, conflictResult.Completed});
        }
    }
    
    [HttpPost("/api/DeleteSberOperation")]
    public async Task<IActionResult> DeleteSberOperation([FromBody] DeleteSberOperationCommand command)
    {
        Result<SberOperationResponseDto> result = null;
        try
        {
            result = await _commandDispatcher
                .DispatchAsync<DeleteSberOperationCommand, Result<SberOperationResponseDto>>(command);
            
            var id = result.Value.Id;
            var added = result.Value.Added.ToString();
        
            return Accepted(new Uri($"/api/SberOperations/{id}", UriKind.Relative),new {id, added});
        }
        catch (DBConcurrencyException e)
        {
            var conflictResult = result.Value;
            return StatusCode((int)HttpStatusCode.Conflict, 
                new{conflictResult.Id, conflictResult.Added, conflictResult.Completed});
        }
    }
}