﻿using AutoMapper;
using BussinessObjects.Dtos;
using DataAccess.DbContexts;
using DataAccess.Entities;
using DataAccess.Repository.Irepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            IEnumerable<User> users = await _context.Users
                                                    .Where(x => x.RoleId == 2)
                                                    .OrderByDescending(x => x.UserId)
                                                    .ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            User user = await _context.Users
                .FirstOrDefaultAsync(x => x.RoleId == 2 && x.UserId == userId);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByEmailAndPassword(string email, string password)
        {
            User user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()) && x.Password == password && x.IsActive == true);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.RoleId == 2 && x.Email.ToLower().Equals(email.ToLower()));
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> CreateUser(UserDTO userDto)
        {
            User user = _mapper.Map<UserDTO, User>(userDto);
            user.RoleId = 2;
            user.IsActive = true;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDto)
        {
            User oldUser = await _context.Users
                .FirstOrDefaultAsync(x => x.RoleId == 2 && x.UserId == userDto.UserId);
            oldUser.FullName = userDto.FullName;
            oldUser.UserName = userDto.UserName;
            if (userDto.File != null)
            {
                oldUser.ImageUser = userDto.ImageUser;
            }
            if (!string.IsNullOrEmpty(userDto.Email))
            {
                oldUser.Email = userDto.Email;
            }
            //oldUser.Email = userDto.Email;
            //oldUser.Password = userDto.Password;
            oldUser.IsMale = userDto.IsMale;
            oldUser.IsActive = userDto.IsActive;
            _context.Users.Update(oldUser);
            await _context.SaveChangesAsync();
            return _mapper.Map<User, UserDTO>(oldUser);
        }

        public async Task<UserDTO> UpdatePassword(UserDTO userDto)
        {
            User oldUser = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userDto.UserId);
            oldUser.Password = userDto.Password;
            _context.Users.Update(oldUser);
            await _context.SaveChangesAsync();
            return _mapper.Map<User, UserDTO>(oldUser);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user == null)
            {
                return false;
            }
            user.IsActive = false;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckDuplicate(string email, string userName)
        {
            var user = await _context.Users.Where(x => x.Email.ToLower() == email.ToLower()
            || x.UserName.ToLower() == userName.ToLower()).FirstOrDefaultAsync();
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}
