using Domain.Enums;

namespace Application.Dtos;

public record CustomerDto(
    Guid Id,
    string Name,
    string Surname,
    string Email,
    string Telephone,
    string IdNumber,
    string Country
    );
