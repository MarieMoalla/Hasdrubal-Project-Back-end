using Hasdrubal__Project.DBConnection;
using Hasdrubal__Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hasdrubal__Project.Services
{
    public interface IImagesService
    {
        Task<List<string>> GetImagesnameByOeuvreAsync(int id);
    }
    public class ImagesService : IImagesService
    {

        private readonly AppDBContext _context;
        public ImagesService(AppDBContext context)
        {
            _context = context;
        }
        public async Task<List<string>> GetImagesnameByOeuvreAsync(int id)
        {
            try
            {
                var list = new List<string>();
                foreach(var image in _context.Images.Where(i => i.OeuvreId == id).ToList())
                {
                    list.Add(image.name);
                }
                return list;
            }
            catch(Exception e ) { return null; }
        }
    }
}
