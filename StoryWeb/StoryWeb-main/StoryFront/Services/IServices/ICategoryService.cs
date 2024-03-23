﻿using System;
namespace StoryFront.Services.IServices
{
	public interface ICategoryService
	{
        Task<T> GetAllCategoriesAsync<T>(string token);
        Task<T> GetCategoryByIdAsync<T>(int id, string token);
    }
}

