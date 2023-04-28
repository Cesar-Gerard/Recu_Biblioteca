using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recu_Biblioteca.Model
{
   public class Categoria
    {
        private int id;
        private String nom;

        public static ObservableCollection<Categoria> categories_creades = null;

        public Categoria(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }


        public static ObservableCollection<Categoria> crearCategories()
        {
            if (categories_creades == null)
            {
                categories_creades = new ObservableCollection<Categoria>();

                categories_creades.Add(new Categoria(1, "Narrativa"));
                categories_creades.Add(new Categoria(2, "Poesia"));
                categories_creades.Add(new Categoria(3, "Teatre"));
                categories_creades.Add(new Categoria(4, "Història"));
                categories_creades.Add(new Categoria(5, "Ciència Ficció"));
                categories_creades.Add(new Categoria(6, "Novel·la Històrica"));
                categories_creades.Add(new Categoria(7, "Ficció"));
                categories_creades.Add(new Categoria(8, "Assaig"));
                categories_creades.Add(new Categoria(9, "Biografies"));

                return categories_creades;
            }
            else
            {
                return null;
            }
            

        }
    }
}
