using Recu_Biblioteca.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Recu_Biblioteca
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Carregue les categories existents en el seu ListView
            
            lsvCategories.ItemsSource = Categoria.crearCategories();

        }

        //Guardem un nou llibre y les sevs categories 
        private void btnDesar_Click(object sender, RoutedEventArgs e)
        {
            //Mirem si es un cas de actualitzacio o de creacio;

            if (lsvLlibres.SelectedItem == null)
            {
                //Agafem al informació del txbName
                String nom = txbName.Text;

                
                    Llibre nou = null;

                    //Rebem el id que li toca
                    int id = Llibre.getLastId();


                    //Comprovem si hi han categories seleccionades del seu ListView

                    ObservableCollection<Categoria> categories_llibre = new ObservableCollection<Categoria>();

                    foreach (Categoria cat in lsvCategories.SelectedItems)
                    {
                        categories_llibre.Add(cat);
                    }

                    nou = new Llibre(id, nom, categories_llibre);
                    Llibre.inserirLlibre(nou);

                
            }
            else
            {
                Llibre actu = (Llibre)lsvLlibres.SelectedItem;


                ObservableCollection<Categoria> categories_llibre = new ObservableCollection<Categoria>();

                foreach (Categoria cat in lsvCategories.SelectedItems)
                {
                    categories_llibre.Add(cat);
                }


                
                    actu.Titol = txbName.Text;
                actu.Categories = categories_llibre;
                
            }
            //Recarreguem el ListView dels Llibres
            carregarListLlibres();
            btnDesar.IsEnabled = false;
        }


        //Recarrega el contingut de la ListVoew dels Llibres
        public void carregarListLlibres()
        {
            lsvLlibres.ItemsSource = Llibre.llibres_creats;
            NetejarCamps();
        }

        //Comportament a l'hora de cabiar el llibre seleccionat
        private void lsvLlibres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //Netejem els categories seleccioandes
            lsvCategories.SelectedItems.Clear();

            //Activem el buto de Desar
            btnDesar.IsEnabled = true;
            
            if (lsvLlibres.SelectedItem != null)
            {

                //Agafem el nom del Llibre y el possem en el TextBlock
                Llibre select = (Llibre)lsvLlibres.SelectedItem;
                txbName.Text = select.Titol;

                //Carreguem les seves categories al ListVoew de les Categories

                for (int i = 0; i < select.Categories.Count; i++)
                {
                    lsvCategories.SelectedItems.Add(select.Categories[i]);
                }

            }
            
        }

        //Crida el metode que neteja els camps
        private void btnNou_Click(object sender, RoutedEventArgs e)
        {
            NetejarCamps();

        }
        //NEteja els camps
        private void NetejarCamps()
        {
            //Netejem els camps
            lsvLlibres.SelectedItem = null;
            lsvCategories.SelectedItems.Clear();
            txbName.Text = "";
            txbName.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void txbName_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            

            if (!Llibre.correctName(txbName.Text))
            {
                txbName.Background= new SolidColorBrush(Colors.Red);
                btnDesar.IsEnabled = false;
            }
            else
            {
                txbName.Background = new SolidColorBrush(Colors.Transparent);
                btnDesar.IsEnabled = true;
            }
        }
    }
}
