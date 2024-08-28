﻿using sneaker_collectors_backend.Models.Database;

namespace sneaker_collectors_backend.Services
{
    public interface ISneakerOverviewService
    {
        public Task<List<SneakerSample>> GetAsync(string pageId);
    }
}
