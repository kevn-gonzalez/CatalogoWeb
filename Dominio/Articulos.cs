using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesArt
{
    public class Articulos
    {
        public int Id { get; set; }
        [DisplayName("Cod. de artículo")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; }
        [DisplayName("Marca")]
        public Marca IdMarca { get; set; } = new Marca();
        [DisplayName("Categoria")]
        public Categoria IdCategoria { get; set; } = new Categoria();
    } 
}
