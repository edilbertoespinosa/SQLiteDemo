using Bogus;
using PropertyChanged;
using SQliteDemo1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQliteDemo1.ViewModels
{
    //Se agrega el atributo para indicar que debe cambiar las propiedades
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        //Creamos una propiedad con lista de Customer
        public List<Customer> Customers { get; set; }

        //Creamos una propiedad con el boton
        public ICommand AddCommand { get; set; }

        //Creamos una propiedad con el eliminar
        public ICommand DeleteCommand { get; set; }

        //Creamos una propiedad con valor de un customer
        public Customer NewCustomer { get; set; }

        //Creamos un metodo para crear un Customer
        private void GenerateNewCustomer()
        {
            NewCustomer = new Faker<Customer>()
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.Address, f => f.Person.Address.Street)
                .Generate();

            NewCustomer.Passport = new Passport
            {
                ExpirationDate = DateTime.Now.AddDays(30)
            };

            NewCustomer.CreditCards = new List<CreditCard>
            {
                new CreditCard { ExpirationDate = DateTime.Now.AddDays(30)},
                new CreditCard { ExpirationDate = DateTime.Now.AddDays(60)},
                new CreditCard { ExpirationDate = DateTime.Now.AddDays(90)}
            };

            NewCustomer.Asistencias = new List<Asistencia>
            {
                new Asistencia { MyDate = DateTime.Now.AddDays(30)},
                new Asistencia { MyDate = DateTime.Now.AddDays(60)},
                new Asistencia { MyDate = DateTime.Now.AddDays(90)}
            };
        }

        //Creamos un constructor 
        public MainPageViewModel()
        {
            //Creamos una nueva variable 
            var orders = App.OrderRepository.GetItems();

            //Actualizamos la lista de Customer
            Refresh();

            //Mandamos generar un fake de Customer
            GenerateNewCustomer();
            
            //Le indicamos lo que hará el botón Grabar
            AddCommand = new Command(async () =>
            {
                //Disparamos el método Grabar
                App.CustomerRepository.SaveItemWithChildren(NewCustomer);
                //Desplegamos el resultado
                Console.WriteLine(App.CustomerRepository.StatusMessage);
                //Mandamos generar un nuevo fake de Customer
                GenerateNewCustomer();
                //Actualizamos la lista de Customer
                Refresh();
            });

            //Le indicamos lo que hará el Swipe
            DeleteCommand = new Command(async (customer) =>
            {
                App.CustomerRepository.DeleteItem((Customer)customer);
                Refresh();
            });
        }

        //Creamos el metodo para actualizar la lista
        private void Refresh()
        {
            Customers = App.CustomerRepository.GetItemsWithChildren();
            //Asi podmeos flexibilizar la recuperacion de informacion
            //Customers = App.CustomerRepository.Get(x => x.Name.StartsWith("a"));
            var passport = App.PassportRepository.GetItems();
            var creditCards = App.CreditCardRepository.GetItems();
            var asistencias = App.AsistenciaRepository.GetItems();
            var a = 1;
        }
    }
}
