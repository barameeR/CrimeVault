using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeVault.Domain.Abstractions;
public interface IResult
{
    bool IsSuccess { get; }
    List<Error> Errors { get; }
}



public class Result : IResult
{
    public List<Error> Errors { get; protected set; }
    public bool IsSuccess => Errors == null || !Errors.Any();
    public static Result Success() => new();
    public static Result Failure(Error error) => new() { Errors = new() { error } };
    public static Result Failure(List<Error> errors) => new() { Errors = errors };
}
public class Result<T> : Result
{
    public Result(T value) => Value = value;
    public Result(Error error) => Errors = [error];
    public Result(List<Error> errors) => Errors = errors;
    public T Value { get; }
    public List<Error> Errors { get; }
    public bool IsSuccess => Errors == null || !Errors.Any();
    public bool IsFailure => !IsSuccess;
    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(Error error) => new(error);
    public static Result<T> Failure(List<Error> errors) => new(errors);
    public TResult Map<TResult>(Func<T, TResult> onSuccess, Func<List<Error>, TResult> onFailure) => IsSuccess ? onSuccess(Value) : onFailure(Errors);

}

