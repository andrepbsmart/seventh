using System;

using Microsoft.EntityFrameworkCore;

using Prova.Domain.Core;
using Prova.Domain.Entities;
using Prova.Domain.Interfaces;

using Prova.Data.Context;

namespace Prova.Data.Repositorys
{
    public class VideoRepository : IVideo
    {
        private readonly PostgreContext _context;

        public VideoRepository(PostgreContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Video video)
        {
            _context.Entry(video).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string idvideo, string idserver)
        {
            var video = _context.Videos.Where(x => x.idVideo == idvideo && x.idServer == idserver).FirstOrDefault();
            if (video == null)
            {
                throw new BusinessException("Servidor não encontrado");
            }
            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();
        }

        public Task Recycle(int days)
        {
            throw new NotImplementedException();
        }

        public Video FindById(string idserver, string idvideo)
        {
            var video = _context.Videos.Where(x => x.idVideo == idvideo && x.idServer == idserver).FirstOrDefault();
            if (video == null)
            {
                throw new BusinessException("Servidor não encontrado");
            }

            return video;
        }

        public async Task<string> FindBinaryById(string idserver, string idvideo)
        {
            var video = await Task.FromResult(_context.Videos.Where(x => x.idVideo == idvideo && x.idServer == idserver).FirstOrDefault());
            if (video == null)
            {
                throw new BusinessException("Servidor não encontrado");
            }

            return video.Content;
        }

        public async Task<IList<Video>> ListAllVideos(string idsever)
        {
            return await _context.Videos.Where(x => x.idServer == idsever).ToListAsync();
        }
    }
}
