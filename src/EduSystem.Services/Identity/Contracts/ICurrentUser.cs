using System;

namespace EduSystem.Services.Identity.Contracts;

public interface ICurrentUser
{
    Guid? UserId { get; }

    bool Exists { get; }
}