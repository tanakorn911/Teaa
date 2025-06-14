using System.Text;
using System.Text.Json;
using Tea.Shared.Models;
using Microsoft.Extensions.Configuration;

namespace Tea.Shared.Services
{
    public class PaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _publicKey;
        private readonly string _secretKey;
        private const string OMISE_API_BASE = "https://api.omise.co";

        public PaymentService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _publicKey = configuration["Omise:TestPublicKey"] ?? "";
            _secretKey = configuration["Omise:TestSecretKey"] ?? "";
        }

        public async Task<OmiseSource?> CreatePromptPaySourceAsync(decimal amount)
        {
            try
            {
                var amountInSubunits = (int)(amount * 100); // Convert to subunits (satang)

                var formData = new List<KeyValuePair<string, string>>
                {
                    new("amount", amountInSubunits.ToString()),
                    new("currency", "THB"),
                    new("type", "promptpay")
                };

                var formContent = new FormUrlEncodedContent(formData);

                // Use public key for creating source
                var authValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_publicKey}:"));
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authValue);

                var response = await _httpClient.PostAsync($"{OMISE_API_BASE}/sources", formContent);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var source = JsonSerializer.Deserialize<OmiseSource>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
                    });
                    return source;
                }
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error creating PromptPay source: {ex.Message}");
            }

            return null;
        }

        public async Task<OmiseCharge?> CreateChargeAsync(string sourceId, decimal amount, string description = "")
        {
            try
            {
                var amountInSubunits = (int)(amount * 100);

                var formData = new List<KeyValuePair<string, string>>
                {
                    new("amount", amountInSubunits.ToString()),
                    new("currency", "THB"),
                    new("source", sourceId)
                };

                if (!string.IsNullOrEmpty(description))
                {
                    formData.Add(new("description", description));
                }

                var formContent = new FormUrlEncodedContent(formData);

                // Use secret key for creating charge
                var authValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_secretKey}:"));
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authValue);

                var response = await _httpClient.PostAsync($"{OMISE_API_BASE}/charges", formContent);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var charge = JsonSerializer.Deserialize<OmiseCharge>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
                    });
                    return charge;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating charge: {ex.Message}");
            }

            return null;
        }

        public async Task<OmiseCharge?> GetChargeStatusAsync(string chargeId)
        {
            try
            {
                var authValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_secretKey}:"));
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authValue);

                var response = await _httpClient.GetAsync($"{OMISE_API_BASE}/charges/{chargeId}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var charge = JsonSerializer.Deserialize<OmiseCharge>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
                    });
                    return charge;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting charge status: {ex.Message}");
            }

            return null;
        }

        public async Task<OmiseCharge?> CreatePromptPayChargeAsync(decimal amount, string description = "")
        {
            try
            {
                var amountInSubunits = (int)(amount * 100);

                var formData = new List<KeyValuePair<string, string>>
                {
                    new("amount", amountInSubunits.ToString()),
                    new("currency", "THB"),
                    new("source[type]", "promptpay")
                };

                if (!string.IsNullOrEmpty(description))
                {
                    formData.Add(new("description", description));
                }

                var formContent = new FormUrlEncodedContent(formData);

                // Use secret key for creating charge directly
                var authValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_secretKey}:"));
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authValue);

                var response = await _httpClient.PostAsync($"{OMISE_API_BASE}/charges", formContent);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var charge = JsonSerializer.Deserialize<OmiseCharge>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
                    });
                    return charge;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating PromptPay charge: {ex.Message}");
            }

            return null;
        }
    }
}