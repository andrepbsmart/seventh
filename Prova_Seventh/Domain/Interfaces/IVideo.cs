using System;
using Prova.Domain.Entities;

namespace Prova.Domain.Interfaces
{
    public interface IVideo
    {
        Task SaveAsync(Video video);
        Task DeleteAsync(string idserver, string idvideo);
        Task Recycle(int days);

        Video FindById(string idserver, string idvideo);
        string FindBinaryById(string idserver, string idvideo);
        Task<IList<Video>> ListAllVideos(string idsever);
    }
}
