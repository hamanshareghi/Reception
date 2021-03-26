using Data.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class VideoService : IVideo
    {

        private DataContext _context;

        public VideoService(DataContext context)
        {
            _context = context;
        }

        public void Add(Video video)
        {
            _context.Videos.Add(video);
            _context.SaveChanges();
        }

        public void Delete(Video video)
        {
            video.IsDelete = true;
            _context.Videos.Update(video);
        }

        public bool Exist(int id)
        {
            return _context.Videos.Any(s => s.VideoId == id);
        }

        public Task<List<Video>> GetAll()
        {
            return _context.Videos.ToListAsync();
        }

        public Task<Video> GetById(int id)
        {
            return _context.Videos.FirstOrDefaultAsync(s => s.VideoId == id);
        }

        public void Update(Video video)
        {
            _context.Videos.Update(video);
            _context.SaveChanges();
        }
    }
}
