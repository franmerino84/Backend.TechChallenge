﻿using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.Gifters
{
    public interface IUserCreationGifter
    {
        void ApplyGift(User user);
    }

}