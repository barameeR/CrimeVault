using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MapsterMapper;
using CrimeVault.Domain.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace CrimeVault.WebAPI.Controllers;
[ApiController]
[Authorize]
public class ApiController : ControllerBase
{
    private const int DefaultStatusCode = (int)HttpStatusCode.BadRequest;
    protected readonly ISender _sender;
    protected readonly IMapper _mapper;

    protected ApiController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates an <see cref="IActionResult"/> that represents a problem response based on the provided list of errors.
    /// </summary>
    /// <param name="errors">The list of errors to process.</param>
    /// <returns>An <see cref="IActionResult"/> representing the problem response.</returns>
    protected IActionResult Problem(List<Error>? errors)
    {
        switch (errors?.Count)
        {
            case 0:
                return Problem(statusCode: (int)HttpStatusCode.InternalServerError, title: "An unexpected error occurred.");
            // Handle a single error
            case 1:
                return CreateProblemResponse(errors[0]);
            default:
                {
                    // Handle multiple errors
                    var errorDetails = errors?.Select(GetErrorDetails).ToList();
                    return StatusCode((int)HttpStatusCode.MultiStatus, errorDetails); // 207 Multi-Status (for multiple errors)
                }
        }
    }

    /// <summary>
    /// Extracts error details from the provided <see cref="Error"/> instance.
    /// </summary>
    /// <param name="error">The error to extract details from.</param>
    /// <returns>An object containing the error details.</returns>
    private static object GetErrorDetails(Error error)
    {
        var statusCode = GetStatusCode(error);

        return new
        {
            status = statusCode,
            title = error.Message,
            detail = error.Message,
        };
    }

    /// <summary>
    /// Creates an <see cref="IActionResult"/> that represents a problem response based on the provided error.
    /// </summary>
    /// <param name="error">The error to process.</param>
    /// <returns>An <see cref="IActionResult"/> representing the problem response.</returns>
    private IActionResult CreateProblemResponse(Error error)
    {
        var statusCode = GetStatusCode(error);
        return Problem(statusCode: statusCode, title: error.Message);
    }

    /// <summary>
    /// Retrieves the status code from the metadata of the provided <see cref="Error"/> instance.
    /// </summary>
    /// <param name="error">The error to extract the status code from.</param>
    /// <returns>The status code extracted from the error metadata, or a default status code if not present.</returns>
    private static int GetStatusCode(Error error)
    {
        return int.TryParse(error.Code, out var stautsCode) ? stautsCode : DefaultStatusCode;
    }
}


