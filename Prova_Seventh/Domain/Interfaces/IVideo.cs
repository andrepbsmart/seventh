﻿using System;
using Prova.Domain.Entities;

namespace Prova.Domain.Interfaces
{
    public interface IVideo
    {
        Task SaveAsync(Video video);
        Task DeleteAsync(string idserver, string idvideo);
        
        Task<Video> FindById(string idvideo);
        Task<string> FindBinaryById(string idvideo);
        Task<IList<Video>> ListAllVideos(string idsever);
    }
}
