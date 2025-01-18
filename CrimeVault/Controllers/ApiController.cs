using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CrimeVault.WebAPI.Controllers;
[ApiController]
public class ApiController : ControllerBase
{
    private const string StatusCodeKey = "StatusCode";
    private const string DetailKey = "Detail";
    private const int DefaultStatusCode = (int)HttpStatusCode.BadRequest;
    protected readonly ISender _sender;

    protected ApiController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Creates an <see cref="IActionResult"/> that represents a problem response based on the provided list of errors.
    /// </summary>
    /// <param name="errors">The list of errors to process.</param>
    /// <returns>An <see cref="IActionResult"/> representing the problem response.</returns>
    protected IActionResult Problem(List<IError> errors)
    {
        if (errors == null || errors.Count == 0)
        {
            return Problem(statusCode: (int)HttpStatusCode.InternalServerError, title: "An unexpected error occurred.");
        }

        // Handle a single error
        if (errors.Count == 1)
        {
            return CreateProblemResponse(errors[0]);
        }

        // Handle multiple errors
        var errorDetails = errors.Select(GetErrorDetails).ToList();
        return StatusCode((int)HttpStatusCode.MultiStatus, errorDetails); // 207 Multi-Status (for multiple errors)
    }

    /// <summary>
    /// Extracts error details from the provided <see cref="IError"/> instance.
    /// </summary>
    /// <param name="error">The error to extract details from.</param>
    /// <returns>An object containing the error details.</returns>
    private object GetErrorDetails(IError error)
    {
        var statusCode = error.Metadata.TryGetValue(StatusCodeKey, out object? value)
            ? (int)value : (int)HttpStatusCode.BadRequest;

        return new
        {
            status = statusCode,
            title = error.Message,
            detail = error.Metadata.ContainsKey(DetailKey) ? error.Metadata[DetailKey] : null
        };
    }

    /// <summary>
    /// Creates an <see cref="IActionResult"/> that represents a problem response based on the provided error.
    /// </summary>
    /// <param name="error">The error to process.</param>
    /// <returns>An <see cref="IActionResult"/> representing the problem response.</returns>
    private IActionResult CreateProblemResponse(IError error)
    {
        var statusCode = GetStatusCodeFromMetadata(error);
        return Problem(statusCode: statusCode, title: error.Message);
    }

    /// <summary>
    /// Retrieves the status code from the metadata of the provided <see cref="IError"/> instance.
    /// </summary>
    /// <param name="error">The error to extract the status code from.</param>
    /// <returns>The status code extracted from the error metadata, or a default status code if not present.</returns>
    private static int GetStatusCodeFromMetadata(IError error)
    {
        return error.Metadata.ContainsKey(StatusCodeKey)
            ? (int)error.Metadata[StatusCodeKey]
            : DefaultStatusCode;
    }
}


