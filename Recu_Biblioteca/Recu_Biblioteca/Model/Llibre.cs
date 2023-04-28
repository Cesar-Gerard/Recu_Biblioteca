using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recu_Biblioteca.Model
{
    public class Llibre : INotifyPropertyChanged
    {
        private int id;
        private String titol;
        private ObservableCollection<Categoria> categories; 
        
        public static ObservableCollection<Llibre> llibres_creats= new ObservableCollection<Llibre>();

        public event PropertyChangedEventHandler PropertyChanged;

        public Llibre(int id, string titol, ObservableCollection<Categoria> categories) 
        {
            Id = id;
            Titol = titol;
            Categories = categories;
        }

        public int Id { get => id; set => id = value; }
        public string Titol { get => titol; 
            
            set
            {
                if (correctName(value))
                {
                    titol = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(("Titol")));
                }

            }
        }

        public ObservableCollection<Categoria> Categories { get => categories; set => categories = value; }

        public static void inserirLlibre(Llibre entrada)
        {         
            llibres_creats.Add(entrada);           
           
        } 



        //Retorna el íd del últim llibre inserit
        public static int getLastId()
        {
            if (llibres_creats.Count==0)
            {
                return 1;
            }
            else
            {
                int resultat = llibres_creats.Last().Id;
                return resultat+1;
            }
   
        }


        //Comprova que el nom dels Llibres compleixin amb les condicions
        public static bool correctName(String entrada)
        {
            if (entrada.Length >= 2 && entrada != "")
            {

                if (llibres_creats.Count > 0)
                {
                    string min = entrada.ToLower();
                    string final = min.Replace(" ", "");

                    for(int i =0; i<llibres_creats.Count; i++)
                    {
                        string min2 = llibres_creats[i].Titol.ToLower();
                        string final2 = min2.Replace(" ", "");

                        if (final.Equals(final2))
                        {
                            return false;
                        }
                    }
                    return true;

                }
                else
                {
                    return true;
                }
              

            }
            else
            {
                return false;
            }
        }


        
    }
}
