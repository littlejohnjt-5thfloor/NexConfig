using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace Infrastructure.Services
{
    public class NexudusService : INexudusService
    {
        private IConfiguration _configuration { get; set; }

        private ITokenRepository _tokenRepository { get; set; }

        private HttpClient _httpClient { get; set; }

        private ILogger _logger { get; set; }

        private AccessToken token { get; set; }

        public class QueryResults<T>
        {
            public IReadOnlyList<T> Records { get; set; }
            public int CurrentPageSize { get; set; }
            public int CurrentPage { get; set; }
            public string CurrentOrderField { get; set; }
            public int CurrentSortDirection { get; set; }
            public int FirstItem { get; set; }
            public bool HasNextPage { get; set; }
            public bool HasPreviousPage { get; set; }
            public int LastItem { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public int TotalItems { get; set; }
            public int TotalPages { get; set; }
        }

        public NexudusService(IConfiguration configuration,
            ITokenRepository tokenRepository,
            HttpClient httpClient,
            ILogger<NexudusService> logger)
        {
            _configuration = configuration;
            _tokenRepository = tokenRepository;
            _httpClient = httpClient;
            _logger = logger;
        }

        private async Task RetrieveToken()
        {
            // Get the access token
            token
                = await _tokenRepository
                .GetByClientIdAsync(NexudusConstants.CLIENT_ID);
        }

        public async Task<IReadOnlyList<Plan>> GetAllPlans()
        {
            IReadOnlyList<Plan> results = null;

            await RetrieveToken();

            if (token == null) await AuthenticateAsync();

            try
            {
                HttpResponseMessage response;

                do
                {
                    using var request = new HttpRequestMessage(
                        HttpMethod.Get, NexudusConstants.BILLING_PLANS_URL);
                    request.Headers.Authorization
                        = new AuthenticationHeaderValue("Bearer",
                        token.Token);

                    response
                        = await _httpClient.SendAsync(request,
                        HttpCompletionOption.ResponseHeadersRead);

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                        await ReauthenticateAsync();

                } while (response.StatusCode == HttpStatusCode.Unauthorized);

                response.EnsureSuccessStatusCode();

                var responseContent
                    = await response.Content.ReadAsStringAsync();

                var queryResults
                    = JsonSerializer.Deserialize<QueryResults<Plan>>(
                        responseContent);

                results = queryResults.Records;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception encountered reading plan information from the Nexudus platform",
                    ex.Message);
            }

            return results;
        }

        public async Task<IReadOnlyList<Plan>> GetActivePlans()
        {
            IReadOnlyList<Plan> results = null;

            await RetrieveToken();

            if (token == null) await AuthenticateAsync();

            try
            {
                HttpResponseMessage response;

                do
                {
                    var queryParameters = new Dictionary<string, string>
                    {
                        { "Tariff_Archived", "false" }
                    };

                    // Add the query parameters
                    var requestUrl 
                        = QueryHelpers.AddQueryString(
                            NexudusConstants.BILLING_PLANS_URL, 
                            queryParameters);

                    using var request = new HttpRequestMessage(
                        HttpMethod.Get, requestUrl);
                    request.Headers.Authorization
                        = new AuthenticationHeaderValue("Bearer",
                        token.Token);

                    response
                        = await _httpClient.SendAsync(request,
                        HttpCompletionOption.ResponseHeadersRead);

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                        await ReauthenticateAsync();

                } while (response.StatusCode == HttpStatusCode.Unauthorized);

                response.EnsureSuccessStatusCode();

                var responseContent
                    = await response.Content.ReadAsStringAsync();

                var queryResults
                    = JsonSerializer.Deserialize<QueryResults<Plan>>(
                        responseContent);

                results = queryResults.Records;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception encountered reading plan information from the Nexudus platform",
                    ex.Message);
            }

            return results;
        }

        public async Task<IReadOnlyList<Resource>> GetAllResources()
        {
            IReadOnlyList<Resource> results = null;

            await RetrieveToken();

            if (token == null) await AuthenticateAsync();

            try
            {
                HttpResponseMessage response;

                do
                {
                    using var request = new HttpRequestMessage(
                        HttpMethod.Get, NexudusConstants.SPACES_RESOURCES_URL);
                    request.Headers.Authorization
                        = new AuthenticationHeaderValue("Bearer",
                        token.Token);

                    response
                        = await _httpClient.SendAsync(request,
                        HttpCompletionOption.ResponseHeadersRead);

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                        await ReauthenticateAsync();

                } while (response.StatusCode == HttpStatusCode.Unauthorized);

                response.EnsureSuccessStatusCode();

                var responseContent
                    = await response.Content.ReadAsStringAsync();

                var queryResults
                    = JsonSerializer.Deserialize<QueryResults<Resource>>(
                        responseContent);

                results = queryResults.Records;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception encountered reading resource information from the Nexudus platform",
                    ex.Message);
            }

            return results;
        }

        public async Task<IReadOnlyList<Resource>> GetActiveResources()
        {
            IReadOnlyList<Resource> results = null;

            await RetrieveToken();

            if (token == null) await AuthenticateAsync();

            try
            {
                HttpResponseMessage response;

                do
                {
                    var queryParameters = new Dictionary<string, string>
                    {
                        { "Resource_Archived", "false" }
                    };

                    // Add the query parameters
                    var requestUrl
                        = QueryHelpers.AddQueryString(
                            NexudusConstants.SPACES_RESOURCES_URL,
                            queryParameters);

                    using var request = new HttpRequestMessage(
                        HttpMethod.Get, requestUrl);
                    request.Headers.Authorization
                        = new AuthenticationHeaderValue("Bearer",
                        token.Token);

                    response
                        = await _httpClient.SendAsync(request,
                        HttpCompletionOption.ResponseHeadersRead);

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                        await ReauthenticateAsync();

                } while (response.StatusCode == HttpStatusCode.Unauthorized);

                response.EnsureSuccessStatusCode();

                var responseContent
                    = await response.Content.ReadAsStringAsync();

                var queryResults
                    = JsonSerializer.Deserialize<QueryResults<Resource>>(
                        responseContent);

                results = queryResults.Records;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception encountered reading resource information from the Nexudus platform",
                    ex.Message);
            }

            return results;
        }

        public async Task<IReadOnlyList<Pass>> GetAllPasses()
        {
            IReadOnlyList<Pass> results = null;

            await RetrieveToken();

            if (token == null) await AuthenticateAsync();

            try
            {
                HttpResponseMessage response;

                do
                {
                    using var request = new HttpRequestMessage(
                        HttpMethod.Get, NexudusConstants.BILLING_TIMEPASSES_URL);
                    request.Headers.Authorization
                        = new AuthenticationHeaderValue("Bearer",
                        token.Token);

                    response
                        = await _httpClient.SendAsync(request,
                        HttpCompletionOption.ResponseHeadersRead);

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                        await ReauthenticateAsync();

                } while (response.StatusCode == HttpStatusCode.Unauthorized);

                response.EnsureSuccessStatusCode();

                var responseContent
                    = await response.Content.ReadAsStringAsync();

                var queryResults
                    = JsonSerializer.Deserialize<QueryResults<Pass>>(
                        responseContent);

                results = queryResults.Records;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception encountered reading time pass information from the Nexudus platform",
                    ex.Message);
            }

            return results;
        }

        public async Task<IReadOnlyList<Pass>> GetActivePasses()
        {
            IReadOnlyList<Pass> results = null;

            await RetrieveToken();

            if (token == null) await AuthenticateAsync();

            try
            {
                HttpResponseMessage response;

                do
                {
                    var queryParameters = new Dictionary<string, string>
                    {
                        { "TimePass_Archived", "false" }
                    };

                    // Add the query parameters
                    var requestUrl
                        = QueryHelpers.AddQueryString(
                            NexudusConstants.BILLING_TIMEPASSES_URL,
                            queryParameters);

                    using var request = new HttpRequestMessage(
                        HttpMethod.Get, requestUrl);
                    request.Headers.Authorization
                        = new AuthenticationHeaderValue("Bearer",
                        token.Token);

                    response
                        = await _httpClient.SendAsync(request,
                        HttpCompletionOption.ResponseHeadersRead);

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                        await ReauthenticateAsync();

                } while (response.StatusCode == HttpStatusCode.Unauthorized);

                response.EnsureSuccessStatusCode();

                var responseContent
                    = await response.Content.ReadAsStringAsync();

                var queryResults
                    = JsonSerializer.Deserialize<QueryResults<Pass>>(
                        responseContent);

                results = queryResults.Records;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception encountered reading time pass information from the Nexudus platform",
                    ex.Message);
            }

            return results;
        }

        public async Task<IReadOnlyList<Product>> GetAllProducts()
        {
            IReadOnlyList<Product> results = null;

            await RetrieveToken();

            if (token == null) await AuthenticateAsync();

            try
            {
                HttpResponseMessage response;

                do
                {
                    using var request = new HttpRequestMessage(
                        HttpMethod.Get, NexudusConstants.BILLING_PRODUCTS_URL);
                    request.Headers.Authorization
                        = new AuthenticationHeaderValue("Bearer",
                        token.Token);

                    response
                        = await _httpClient.SendAsync(request,
                        HttpCompletionOption.ResponseHeadersRead);

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                        await ReauthenticateAsync();

                } while (response.StatusCode == HttpStatusCode.Unauthorized);

                response.EnsureSuccessStatusCode();

                var responseContent
                    = await response.Content.ReadAsStringAsync();

                var queryResults
                    = JsonSerializer.Deserialize<QueryResults<Product>>(
                        responseContent);

                results = queryResults.Records;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception encountered reading product information from the Nexudus platform",
                    ex.Message);
            }

            return results;
        }

        public async Task<IReadOnlyList<Product>> GetActiveProducts()
        {
            IReadOnlyList<Product> results = null;

            await RetrieveToken();

            if (token == null) await AuthenticateAsync();

            try
            {
                HttpResponseMessage response;

                do
                {
                    var queryParameters = new Dictionary<string, string>
                    {
                        { "Product_Archived", "false" }
                    };

                    // Add the query parameters
                    var requestUrl
                        = QueryHelpers.AddQueryString(
                            NexudusConstants.BILLING_PRODUCTS_URL,
                            queryParameters);

                    using var request = new HttpRequestMessage(
                        HttpMethod.Get, requestUrl);
                    request.Headers.Authorization
                        = new AuthenticationHeaderValue("Bearer",
                        token.Token);

                    response
                        = await _httpClient.SendAsync(request,
                        HttpCompletionOption.ResponseHeadersRead);

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                        await ReauthenticateAsync();

                } while (response.StatusCode == HttpStatusCode.Unauthorized);

                response.EnsureSuccessStatusCode();

                var responseContent
                    = await response.Content.ReadAsStringAsync();

                var queryResults
                    = JsonSerializer.Deserialize<QueryResults<Product>>(
                        responseContent);

                results = queryResults.Records;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception encountered reading product information from the Nexudus platform",
                    ex.Message);
            }

            return results;
        }

        public async Task<IReadOnlyList<FinancialAccount>> GetAllFinancialAccounts()
        {
            IReadOnlyList<FinancialAccount> results = null;

            await RetrieveToken();

            if (token == null) await AuthenticateAsync();

            try
            {
                HttpResponseMessage response;

                do
                {
                    using var request = new HttpRequestMessage(
                        HttpMethod.Get, NexudusConstants.BILLING_FINANCIALACCOUNTS_URL);
                    request.Headers.Authorization
                        = new AuthenticationHeaderValue("Bearer",
                        token.Token);

                    response
                        = await _httpClient.SendAsync(request,
                        HttpCompletionOption.ResponseHeadersRead);

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                        await ReauthenticateAsync();

                } while (response.StatusCode == HttpStatusCode.Unauthorized);

                response.EnsureSuccessStatusCode();

                var responseContent
                    = await response.Content.ReadAsStringAsync();

                var queryResults
                    = JsonSerializer.Deserialize<QueryResults<FinancialAccount>>(
                        responseContent);

                results = queryResults.Records;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception encountered reading financial account information from the Nexudus platform",
                    ex.Message);
            }

            return results;
        }

        private async Task AuthenticateAsync()
        {
            var authContent
                = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", _configuration["NexudusCredentials:Username"]),
                    new KeyValuePair<string, string>("password", _configuration["NexudusCredentials:Password"])
                };

            try
            {
                using var request = new HttpRequestMessage(
                    HttpMethod.Post, NexudusConstants.AUTHENTICATION_URL);
                request.Headers.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("client_id",
                    NexudusConstants.CLIENT_ID);
                request.Content
                    = new FormUrlEncodedContent(authContent);

                var response
                    = await _httpClient.SendAsync(request,
                    HttpCompletionOption.ResponseHeadersRead);

                response.EnsureSuccessStatusCode();

                var responseContent
                    = await response.Content.ReadAsStringAsync();

                token
                    = JsonSerializer.Deserialize<AccessToken>(
                        responseContent);

                await _tokenRepository.AddAsync(token);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception encountered authenticating with the Nexudus platform",
                    ex.Message);
            }
        }

        private async Task ReauthenticateAsync()
        {
            var authContent
                = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("refresh_token", token.RefreshToken),
                };

            try
            {
                using var request = new HttpRequestMessage(
                    HttpMethod.Post, NexudusConstants.AUTHENTICATION_URL);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(
                    "application/json"));
                request.Headers.Add("client_id",
                    NexudusConstants.CLIENT_ID);
                request.Content
                    = new FormUrlEncodedContent(authContent);

                var response
                    = await _httpClient.SendAsync(request,
                    HttpCompletionOption.ResponseHeadersRead);

                response.EnsureSuccessStatusCode();

                var responseContent
                    = await response.Content.ReadAsStringAsync();

                token
                    = JsonSerializer.Deserialize<AccessToken>(
                        responseContent);

                await _tokenRepository.AddAsync(token);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception encountered re-authenticating with the Nexudus platform",
                    ex.Message);
            }
        }
    }
}
