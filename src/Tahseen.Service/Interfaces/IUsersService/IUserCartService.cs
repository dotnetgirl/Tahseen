﻿using Tahseen.Service.DTOs.Users.UserCart;

namespace Tahseen.Service.Interfaces.IUsersService
{
    public interface IUserCartService
    {
        public Task<UserCartForResultDto> AddAsync(UserCartForCreationDto dto);
        public Task<UserCartForResultDto> ModifyAsync(long Id, UserCartForUpdateDto dto);
        public Task<bool> RemoveAsync(long Id);
        public Task<UserCartForResultDto> RetrieveByIdAsync(long Id);
        public ICollection<UserCartForResultDto> RetrieveAll();
    }
}
