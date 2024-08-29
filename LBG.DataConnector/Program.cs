using LBG.DataConnector.Application.Common;
using LBG.DataConnector.Application.Common.Interfaces;
using LBG.DataConnector.Application.Common.Mapping;
using LBG.DataConnector.Application.DecisionMadeData.Queries;
using LBG.DataConnector.Application.Items.Commands.UpdateItem;
using LBG.DataConnector.Application.Items.Queries.GetItems;
using LBG.DataConnector.Application.LivePoliciesData.Queries;
using LBG.DataConnector.Application.ReferredCasesData.Queries;
using LBG.DataConnector.Application.UnsubmittedData.Queries;
using LBG.DataConnector.Common.Utilities;
using LBG.DataConnector.Domain.Entities;
using LBG.DataConnector.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Text.Json;
using System.Text.Json.Serialization;
using LoydsBG = LBG.DataConnector.Application.Common.Results;

var APPName = "DataConnector";

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .Enrich.WithMachineName();
});

// Configure JSON serializer options
builder.Services.AddScoped<JsonSerializerOptions>(sp =>
{
    var options = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
    };
    options.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
    return options;
});

// Configure services
builder.Services.AddScoped<IDatabaseRepository, DatabaseRepository>();

// AutoMapper Registry
builder.Services.AddAutoMapper(typeof(MappingProfile));

// MediatR registration
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(AssemblyMarker).Assembly);
});

// Configuring Kestrel for HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5001, listenOptions =>
    {
        listenOptions.UseHttps(); // Enable HTTPS on port 5001
    });
});

// Configure logging
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddConfiguration(builder.Configuration.GetSection("Logging"));
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

builder.Services.AddDefaultHealthChecks();

// Add InHub Endpoints
builder.Services.AddInHubEndpoints(builder.Configuration);

// Add Swagger
builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.AddSwaggerUIEndpoint();
}

app.UseInHubBaseEndpoints();

// Base route for actions
var actionsApi = app.MapGroup("/api");

// Create logger for use in endpoints
var logger = app.Services.GetRequiredService<ILogger<Program>>();

actionsApi.MapPut("/UpdateItem", async (ISender sender, ItemDto itemDTO) =>
{
    var command = new UpdateItemCommand
    {
        Id = itemDTO.Id,
        Price = itemDTO.Price,
        Title = itemDTO.Title
    };

    var result = await sender.Send(command);

    if (result)
    {
        return Results.Ok(new { Success = true });
    }
    else
    {
        return Results.BadRequest(new { Success = false });
    }
})
.WithName("UpdateItem")
.WithOpenApi();

actionsApi.MapGet("/GetItems", async (ISender sender) =>
{
    var query = new GetItemsQuery();
    var result = await sender.Send(query);

    if (result.Count() > 0)
    {
        return Results.Ok(result);
    }
    else
    {
        return Results.BadRequest(new { Success = false });
    }
})
.WithName("GetItems")
.WithOpenApi();

actionsApi.MapGet("/GetUnsubmittedData", async (ISender sender) =>
{
    var query = new GetUnsubmittedDataQuery();
    var result = await sender.Send(query);

    if (result?.Count() > 0)
    {
        var response = new ResponseData<IEnumerable<UnsubmittedDataBriefDto>>(result, null);
        return Results.Ok(response);
    }
    else
    {
        return Results.BadRequest(new { Success = false });
    }
})
.WithName("GetUnsubmittedData")
.WithOpenApi();

actionsApi.MapGet("/GetDecisionMadeData", async (ISender sender) =>
{
    var query = new GetDecisionMadeDataQuery();
    var result = await sender.Send(query);

    if (result?.Count() > 0)
    {
        var response = new ResponseData<IEnumerable<DecisionMadeDataBriefDto>>(result, null);
        return Results.Ok(response);
    }
    else
    {
        return Results.BadRequest(new { Success = false });
    }
})
.WithName("GetDecisionMadeData")
.WithOpenApi();

actionsApi.MapGet("/GetLivePoliciesData", async (ISender sender) =>
{
    var query = new GetLivePoliciesDataQuery();
    var result = await sender.Send(query);

    if (result?.Count() > 0)
    {
        var response = new ResponseData<IEnumerable<LivePoliciesDataBriefDto>>(result, null);
        return Results.Ok(response);
    }
    else
    {
        return Results.BadRequest(new { Success = false });
    }
})
.WithName("GetLivePoliciesData")
.WithOpenApi();

actionsApi.MapGet("/GetReferredCasesData", async (ISender sender) =>
{
    var query = new GetReferredCasesDataQuery();
    var result = await sender.Send(query);

    if (result?.Count() > 0)
    {
        var response = new ResponseData<IEnumerable<ReferredCasesDataBriefDto>>(result, null);
        return Results.Ok(response);
    }
    else
    {
        return Results.BadRequest(new { Success = false });
    }
})
.WithName("GetReferredCasesData")
.WithOpenApi();

// V2 Endpoints with SafeExecutionExtensions
actionsApi.MapGet("/GetUnsubmittedDataV2", async (ISender sender) =>
{
    return await SafeExecutionExtensions.Execute(async () =>
    {
        var query = new GetUnsubmittedDataQuery();
        var result = await sender.Send(query);
        var response = new LoydsBG.ValueResult<IEnumerable<UnsubmittedDataBriefDto>>
        {
            Data = result
        };

        return Results.Ok(response);
    }, logger);
})
.WithName("GetUnsubmittedDataV2")
.WithOpenApi();

actionsApi.MapGet("/GetDecisionMadeDataV2", async (ISender sender) =>
{
    return await SafeExecutionExtensions.Execute(async () =>
    {
        var query = new GetDecisionMadeDataQuery();
        var result = await sender.Send(query);

        var response = new LoydsBG.ValueResult<IEnumerable<DecisionMadeDataBriefDto>>
        {
            Data = result
        };

        return Results.Ok(response);
    }, logger);
})
.WithName("GetDecisionMadeDataV2")
.WithOpenApi();

actionsApi.MapGet("/GetLivePoliciesDataV2", async (ISender sender) =>
{
    return await SafeExecutionExtensions.Execute(async () =>
    {
        var query = new GetLivePoliciesDataQuery();
        var result = await sender.Send(query);

        var response = new LoydsBG.ValueResult<IEnumerable<LivePoliciesDataBriefDto>>
        {
            Data = result
        };

        return Results.Ok(response);
    }, logger);
})
.WithName("GetLivePoliciesDataV2")
.WithOpenApi();

actionsApi.MapGet("/GetReferredCasesDataV2", async (ISender sender) =>
{
    return await SafeExecutionExtensions.Execute(async () =>
    {
        var query = new GetReferredCasesDataQuery();
        var result = await sender.Send(query);

        var response = new LoydsBG.ValueResult<IEnumerable<ReferredCasesDataBriefDto>>
        {
            Data = result
        };

        return Results.Ok(response);
    }, logger);
})
.WithName("GetReferredCasesDataV2")
.WithOpenApi();

app.Run();

public record ResponseData<T>(
    T Data,
    object? Errors
);

[JsonSerializable(typeof(ResponseData<IEnumerable<UnsubmittedDataBriefDto>>))]
[JsonSerializable(typeof(ResponseData<IEnumerable<DecisionMadeDataBriefDto>>))]
[JsonSerializable(typeof(ResponseData<IEnumerable<LivePoliciesDataBriefDto>>))]
[JsonSerializable(typeof(ResponseData<IEnumerable<ReferredCasesDataBriefDto>>))]

[JsonSerializable(typeof(LoydsBG.ValueResult<IEnumerable<UnsubmittedDataBriefDto>>))]
[JsonSerializable(typeof(LoydsBG.ValueResult<IEnumerable<DecisionMadeDataBriefDto>>))]
[JsonSerializable(typeof(LoydsBG.ValueResult<IEnumerable<LivePoliciesDataBriefDto>>))]
[JsonSerializable(typeof(LoydsBG.ValueResult<IEnumerable<ReferredCasesDataBriefDto>>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}
