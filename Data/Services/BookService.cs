using libreria_XGVC.Data.Models;
using libreria_XGVC.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace libreria_XGVC.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }
        //Metodo  que nos permite agregar un nuevo libro en la BD
        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DataRead = book.DataRead,
                Rate = book.Rate,
                Genero = book.Genero,
                Autor = book.Autor,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
        //Metodo  que nos permite obtener una lista de todos los libros de la BD
        public List<Book> GetAllBks() => _context.Books.ToList();
        //Metodo  que nos permite obtener  el libro que estamos pidiendo de la BD
        public Book GetBookId(int bookid) => _context.Books.FirstOrDefault(n => n.id == bookid);

        //Metodo  que nos permite modificar un libro en la BD
        public Book UpdateBookByID(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if (_book != null)
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DataRead = book.DataRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.Autor = book.Autor;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }
        public void DeleteBookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if(_book != null)
            {
                _context.Books.Remove( _book );
                _context.SaveChanges();
            }
        }
    }
}
