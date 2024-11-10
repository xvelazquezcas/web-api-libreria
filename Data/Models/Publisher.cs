using System.Collections.Generic;

namespace libreria_XGVC.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Propiedades de navegacion
        public List<Book> Book { get; set; }
    }
}
