﻿using System;

namespace libreria_XGVC.Data.Models
{
    public class Book
    { 
        public int id {  get; set; }    
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool IsRead  { get; set; }
        public DateTime? DataRead { get; set; }
        public int? Rate { get; set; }
        public string Genero { get; set; }
        public string Autor {  get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
