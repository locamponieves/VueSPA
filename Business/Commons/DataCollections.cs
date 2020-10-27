using Microsoft.EntityFrameworkCore.Internal;
using System.Collections;
using System.Collections.Generic;

namespace Business.Commons
{
    // Va a ser una clase genérica porque la puede inplementar
    // cualquier modelo
    public class DataCollections<T> where T : class
    {
        // Va a validar si hay registros encontrados o no
        public bool HasItems
        {
            get
            {
                return Items != null && Items.Any();
            }
        }

        // Los registros
        public IEnumerable<T> Items { get; set; }

        // Cantidad de registros encontrados
        public int Total { get; set; }
        
        //Página actual que se está navegando
        public int Page  { get; set; }

        // Cantidad de páginas que se ha detectado
        // Es decir, la cantidad de páginas que se puede páginar
        // la colección
        public int Pages { get; set; }
    }
}