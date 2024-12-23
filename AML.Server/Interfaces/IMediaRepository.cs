﻿using AML.Server.DTOs;
using AML.Server.Models;

namespace AML.Server.Interfaces
{
    public interface IMediaRepository
    {
        Task BorrowMedia(BorrowMediaRequest request);
        Task<List<Media>> GetMedia(SearchMediaRequest? request);
    }
}
