﻿using Microsoft.AspNetCore.Http;

namespace DigiBite_Core.IRepos
{
    public interface IMediaRepos
    {
        Task<int> UploadFiles(IFormFileCollection files, string UploadedBy);
    }
}
