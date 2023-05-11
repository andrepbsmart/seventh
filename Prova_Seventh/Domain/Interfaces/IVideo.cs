using System;
using Prova.Domain.Entities;

namespace Prova.Domain.Interfaces
{
    public interface IVideo
    {
        Task SaveAsync(Video video);
        Task DeleteAsync(string dserver, string idvideo);
        Task Recycle(int days);

        Task<Server> FindById(string idserver, string idvideo);
        Task<Server> FindBinaryById(string idserver, string idvideo);
        Task<IList<Video>> ListAllVideos(string idsever);
    }
}
