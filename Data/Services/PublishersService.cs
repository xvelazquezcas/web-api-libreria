﻿using libreria_XGVC.Data.Models;
using libreria_XGVC.Data.ViewModels;
using libreria_XGVC.Exceptions;
using System;
using System.Linq;
using System.Text.RegularExpressions;

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

        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStartsWithNumber(publisher.Name)) throw new PublisherNameException("El nombre empieza con un numero",
                publisher.Name);
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher); 
            _context.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherByID(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);

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
            else
            {
                throw new Exception($"La editora con el id: {id} no existe!");
            }
        }
        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d^"));
    }
}
