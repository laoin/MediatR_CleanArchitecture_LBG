using LBG.DataConnector.Application.Common.Interfaces;
using LBG.DataConnector.Application.Items.Queries.GetItems;
using LBG.DataConnector.Application.UnsubmittedData.Queries;
using LBG.DataConnector.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace LBG.DataConnector.Infrastructure.Data
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly IConfiguration _configuration;

        public DatabaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public Task<bool> UpdateItem(int itemId, decimal newPrice, string title)
        {
            return Task.FromResult(true);
        }

        public Task<ItemDto> GetItemById(int id)
        {
            return Task.FromResult(new ItemDto(id, 12, "Title String"));
        }

        public Task<List<ItemDto>> GetItems()
        {
            return Task.FromResult(new List<ItemDto>{
                new ItemDto(new Random().Next(), new decimal(new Random().Next()), "New Title_" + new Random().Next()),
                new ItemDto(new Random().Next(), new decimal(new Random().Next()), "New Title_" + new Random().Next()),
                new ItemDto(new Random().Next(), new decimal(new Random().Next()), "New Title_" + new Random().Next()),
                new ItemDto(new Random().Next(), new decimal(new Random().Next()), "New Title_" + new Random().Next()),
                new ItemDto(new Random().Next(), new decimal(new Random().Next()), "New Title_" + new Random().Next()),
                new ItemDto(new Random().Next(), new decimal(new Random().Next()), "New Title_" + new Random().Next()),
            });
        }

        public async Task<IEnumerable<UnsubmittedDataDto>> GetUnsubmittedData()
        {
            IEnumerable<UnsubmittedDataDto> result = null;

            var connection = CreateConnection();

            try
            {
                connection.Open();

                result = await connection.QueryAsync<UnsubmittedDataDto>(
                        "SELECT " +
                        "ClientName," +
                        "ReferenceNumber," +
                        "Product," +
                        "ProductCategory," +
                        "Premium," +
                        "Stage," +
                        "StageName," +
                        "DateCreated," +
                        "CurrentStep," +
                        "ExpiresIn," +
                        "ContinueStep " +
                        "FROM " +
                        "UnsubmittedData");

            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }

            return await Task.FromResult(result);

        }

        public async Task<IEnumerable<DecisionMadeDataDto>> GetDecisionMadeData()
        {
            IEnumerable<DecisionMadeDataDto> result = null;

            var connection = CreateConnection();

            try
            {
                connection.Open();

                result = await connection.QueryAsync<DecisionMadeDataDto>(
                        "SELECT " +
                        "ClientName," +
                        "Policy," +
                        "Product," +
                        "ProductCategory," +
                        "Premium," +
                        "LastUpdated," +
                        "ExpiresIn," +
                        "Decision," +
                        "NeedAttention " +
                        "FROM " +
                        "DecisionMadeData");

            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<LivePoliciesDataDto>> GetLivePoliciesData()
        {
            IEnumerable<LivePoliciesDataDto> result = null;

            var connection = CreateConnection();

            try
            {
                connection.Open();
                
                result = await connection.QueryAsync<LivePoliciesDataDto>(
                        "SELECT " +
                        "ClientName," +
                        "Policy," +
                        "Product," +
                        "ProductCategory," +
                        "Premium," +
                        "StartDate," +
                        "LastUpdated," +
                        "SummaryIssue," +
                        "NeedAttention " +
                        "FROM " +
                        "LivePoliciesData");

            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<ReferredCasesDataDto>> GetReferredCasesData()
        {
            const string spName = "GetReferredCasesData";

            using (IDbConnection dbConnection = CreateConnection())
            {
                dbConnection.Open();

                var referredCasesData =
                    await dbConnection.QueryAsync<ReferredCasesDataDto>(
                        spName,
                        commandType: CommandType.StoredProcedure
                );

                return referredCasesData;
            }
        }
    }
}
