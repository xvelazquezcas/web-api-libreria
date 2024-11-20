using libreria_XGVC.Data.Models;
using libreria_XGVC.Data.ViewModels;
using System;
using System.Linq;

namespace libreria_XGVC.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        //Metodo  que nos permite  agregar  una nueva Editora  en la BD

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher); 
            _context.SaveChanges();
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Book.Select(n => new BookAuthorVM()
                    { 
                       BookName = n.Titulo,
                       BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                    }).ToList() 
                }).FirstOrDefault();
            return _publisherData;
        }

        internal void DeletePublisherId(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if(_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}
