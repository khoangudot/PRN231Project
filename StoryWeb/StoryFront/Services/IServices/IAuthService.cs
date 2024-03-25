using System;
using ObjectModel.Dtos;

namespace StoryFront.Services.IServices
{
	public interface IAuthService
    {
        Task<T> Login<T>(string email, string password);
    }
}

