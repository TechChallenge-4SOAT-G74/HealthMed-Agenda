using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed_Agenda.Application.Core
{
    [ExcludeFromCodeCoverage]
    public class ErrorResultDetail(string code, string? message = null)
    {
        public string Code { get; } = code;
        public string? Message { get; } = message;
        public int? StatusCode { get; set; }
        public List<ErrorResultDetail> Details { get; set; } = [];

        public static readonly ErrorResultDetail INTERNAL_ERROR = new("internal_error") { StatusCode = StatusCodes.Status500InternalServerError };
        public static readonly ErrorResultDetail INVALID_INPUT = new("invalid_input") { StatusCode = StatusCodes.Status400BadRequest };
        public static readonly ErrorResultDetail BAD_REQUEST = new("bad_request") { StatusCode = StatusCodes.Status400BadRequest };
        public static readonly ErrorResultDetail UNAUTHORIZED = new("unauthorized") { StatusCode = StatusCodes.Status401Unauthorized };
        public static readonly ErrorResultDetail FORBIDDEN = new("forbidden") { StatusCode = StatusCodes.Status403Forbidden };
        public static readonly ErrorResultDetail NOT_FOUND = new("not_found") { StatusCode = StatusCodes.Status404NotFound };
        public static readonly ErrorResultDetail BAD_GATEWAY = new("bad_gateway") { StatusCode = StatusCodes.Status502BadGateway };
        public static readonly ErrorResultDetail REQUEST_TIMEOUT = new("request_timeout") { StatusCode = StatusCodes.Status408RequestTimeout };
        public static readonly ErrorResultDetail SERVICE_UNAVAILABLE = new("service_unavailable") { StatusCode = StatusCodes.Status503ServiceUnavailable };
        public static readonly ErrorResultDetail PREDICATE_VALIDATOR = new("PredicateValidator") { StatusCode = StatusCodes.Status506VariantAlsoNegotiates };

        public ErrorResultDetail Format(params object[] valor)
        {
            return new ErrorResultDetail(Code, string.Format(Message, valor));
        }
    }
}
