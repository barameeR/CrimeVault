﻿public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId,string email);
}

