using System;
using ObjectModel.Dtos;

namespace StoryFront.Services.IServices
{
	public interface IBaseService
	{
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}

