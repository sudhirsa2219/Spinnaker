using Domain.Enums;
using Newtonsoft.Json;

namespace Application.Dtos;

public record CustomerDto(
    [JsonProperty("id")]
    Guid Id,
    [JsonProperty("name")]
    string Name,
    [JsonProperty("surname")]
    string Surname,
    [JsonProperty("email")]
    string Email,
    [JsonProperty("telephone")]
    string Telephone,
    [JsonProperty("idNumber")]
    string IdNumber,
    [JsonProperty("country")]
    string Country
    );
