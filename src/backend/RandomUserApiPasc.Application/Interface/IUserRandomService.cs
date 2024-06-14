﻿using RandomUserApiPasc.Domain.Models;
using RandomUserApiPasc.Infra.DTO;

namespace RandomUserApiPasc.Application.Interface
{
    public interface IUserRandomService
    {
        Task<Results> GenerateNewUser();
        Task<IEnumerable<UserDataDTO>> GetAllUsers();
    }
}
