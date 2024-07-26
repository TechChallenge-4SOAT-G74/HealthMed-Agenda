using HealthMed_Agenda.Application.UseCases.Agenda.Dtos;
using HealthMed_Agenda.Application.UseCases.Agenda.Interfaces;
using HealthMed_Agenda.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed_Agenda.Api.Controllers;

[ExcludeFromCodeCoverage]
public static class AgendaEndpoints
{
    public static void MapAgendaEndpoints(this IEndpointRouteBuilder routes, [StringSyntax("Route")] string pattern)
    {
        var group = routes.MapGroup(pattern).WithTags(nameof(Agenda));

        group.MapGet("consultaragendamentocliente/{nomeOrEmail}", async ([FromServices] IAgendaObterUseCase useCase, string nomeOrEmail) =>
        {
            return Results.Ok(await useCase.ConsultarAgendamentoCliente(nomeOrEmail));
        })
        .WithName("ConsultarAgendamentoCliente")
        .WithOpenApi();

        group.MapGet("consultaagendamentomedico/{nomeOrCrmOrEspecialidade}", async ([FromServices] IAgendaObterUseCase useCase, string nomeOrCrmOrEspecialidade) =>
        {
            return Results.Ok(await useCase.ConsultarAgendaMedico(nomeOrCrmOrEspecialidade));
        })
        .WithName("ConsultarAgendamentoMedico")
        .WithOpenApi();

        group.MapGet("consultaagendamentomedicopordistancia/{localidadePaciente}", async ([FromServices] IAgendaObterUseCase useCase, string localidadePaciente) =>
        {
            return Results.Ok(await useCase.ConsultarAgendaMedicoPorDistancia(localidadePaciente));
        })
        .WithName("ConsultarAgendaMedicoPorDistancia")
        .WithOpenApi();

        group.MapGet("consultaragendamentos", async ([FromServices] IAgendaObterUseCase useCase) =>
        {
            return Results.Ok(await useCase.ConsultarAgendamentos());
        })
       .WithName("ConsultarAgendamentos")
       .WithOpenApi();

        group.MapPut("atualizaragendamento/{id}", async ([FromServices] IAgendaAtualizarUseCase useCase, string id, [FromBody] AgendamentoDto dto) =>
        {
            return Results.Ok(await useCase.AtualizarAgendamento(id, dto));
        })
        .WithName("AtualizarAgendamento")
        .WithOpenApi();

        group.MapPost("criaragendamento", async ([FromServices] IAgendaCriarUseCase useCase, [FromBody] AgendamentoDto dto) =>
        {
            return Results.Ok(await useCase.CriarAgendamento(dto));
        })
        .WithName("criaragendamento")
        .WithOpenApi();

        group.MapDelete("CancelarAgendamento/{codigoAgendaMedico}", async ([FromServices] IAgendaExcluirUseCase useCase, string codigoAgendaMedico) =>
        {
            return Results.Ok(await useCase.CancelarAgendamento(codigoAgendaMedico));
        })
        .WithName("CancelarAgendamento")
        .WithOpenApi();
    }
}
