using LBG.DataConnector.App.Common.Utilities;
using LBG.DataConnector.Application.Common;
using LBG.DataConnector.Application.Common.Interfaces;
using LBG.DataConnector.Application.Common.Mapping;
using LBG.DataConnector.Application.DecisionMadeData.Queries;
using LBG.DataConnector.Application.Items.Commands.UpdateItem;
using LBG.DataConnector.Application.Items.Queries.GetItems;
using LBG.DataConnector.Application.LivePoliciesData.Queries;
using LBG.DataConnector.Application.ReferredCasesData.Queries;
using LBG.DataConnector.Application.UnsubmittedData.Queries;
using LBG.DataConnector.Domain.Entities;
using LBG.DataConnector.Infrastructure.Data;
using MediatR;
using Serilog;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using LoydsBG = LBG.DataConnector.Application.Common.Results;

var builder = WebApplication.CreateBuilder(args);

//// Configure Serilog
//builder.Host.UseSerilog((context, services, loggerConfiguration) =>
//{
//    loggerConfiguration
//        .ReadFrom.Configuration(context.Configuration)
//        .Enrich.FromLogContext()
//        .Enrich.WithMachineName();  // Esto solo funcionará si tienes el paquete Serilog.Enrichers.Environment
//});




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

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Create logger for use in endpoints
var logger = app.Services.GetRequiredService<ILogger<Program>>();



app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapPut("/UpdateItem", async (ISender sender, ItemDto itemDTO) =>
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

app.MapGet("/GetItems", async (ISender sender) =>
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

app.MapGet("/GetUnsubmittedData", async (ISender sender) =>
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

app.MapGet("/GetDecisionMadeData", async (ISender sender) =>
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

app.MapGet("/GetLivePoliciesData", async (ISender sender) =>
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

app.MapGet("/GetReferredCasesData", async (ISender sender) =>
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
app.MapGet("/GetUnsubmittedDataV2", async (ISender sender) =>
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

app.MapGet("/GetDecisionMadeDataV2", async (ISender sender) =>
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

app.MapGet("/GetLivePoliciesDataV2", async (ISender sender) =>
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

app.MapGet("/GetReferredCasesDataV2", async (ISender sender) =>
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

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

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
