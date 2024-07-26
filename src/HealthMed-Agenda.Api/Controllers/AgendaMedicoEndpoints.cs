using HealthMed_Agenda.Application.UseCases.AgendaMedico.Dtos;
using HealthMed_Agenda.Application.UseCases.AgendaMedico.Interfaces;
using HealthMed_Agenda.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed_Agenda.Api.Controllers;

[ExcludeFromCodeCoverage]
public static class AgendaMedicoEndpoints
{
    public static void MapAgendaMedicoEndpoints(this IEndpointRouteBuilder routes, [StringSyntax("Route")] string pattern)
    {
        var group = routes.MapGroup(pattern).WithTags(nameof(AgendaMedico));


        group.MapGet("consultaragendamedico/{nomeOrCrmOrEspecialidade}", async ([FromServices] IAgendaMedicoObterUseCase useCase, string nomeOrCrmOrEspecialidade) =>
        {
            return Results.Ok(await useCase.ConsultarAgendaMedico(nomeOrCrmOrEspecialidade));
        })
        .WithName("ConsultarAgendaMedico")
        .WithOpenApi();

        group.MapGet("consultarlistaagendamedico", async ([FromServices] IAgendaMedicoObterUseCase useCase) =>
        {
            return Results.Ok(await useCase.ConsultarListaAgendaMedicos());
        })
        .WithName("ConsultarListaAgendaMedico")
        .WithOpenApi();

        group.MapPut("atualizaragendamedico/{id}", async ([FromServices] IAgendaMedicoAtualizarUseCase useCase, string id, [FromBody] Calendario calendario) =>
        {
            return Results.Ok(await useCase.AtualizarCalendario(id, calendario));
        })
        .WithName("AtualizarAgendaMedico")
        .WithOpenApi();

        group.MapPut("confirmaorcancelaagendamedico/{id}", async ([FromServices] IAgendaMedicoAtualizarUseCase useCase, string id) =>
        {
            return Results.Ok(await useCase.ConfirmaCancelaAgendamento(id));
        })
        .WithName("ConfirmaAgendaMedico")
        .WithOpenApi();

        group.MapPost("criaragendamedico/", async ([FromServices] IAgendaMedicoCriarUseCase useCase, [FromBody] AgendaMedicoDto dto) =>
        {
            return Results.Ok(await useCase.CriarAgendaMedico(dto));
        })
        .WithName("CriarAgendaMedico")
        .WithOpenApi();

        group.MapDelete("cancelaragendamedico/{id}", async ([FromServices] IAgendaMedicoExcluirUseCase useCase, string id) =>
        {
            return Results.Ok(await useCase.CancelarAgendaMedico(id));
        })
        .WithName("CancelarAgendaMedico")
        .WithOpenApi();
    }
}
