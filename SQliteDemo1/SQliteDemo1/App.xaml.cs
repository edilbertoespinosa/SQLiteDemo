using SQliteDemo1.Models;
using SQliteDemo1.Repositories;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQliteDemo1
{
    public partial class App : Application
    {

        //Creamos un campo estatico del repository donde tendremos la coneccion
        private static BaseRepository<Customer> _customerRepository;

        //Llenamos el campo estico del repository mediante patron Singleton
        public static BaseRepository<Customer> CustomerRepository 
        { 
            get
            {
                if(_customerRepository==null)
                {
                    _customerRepository = new BaseRepository<Customer>();
                }
                return _customerRepository;
            }
        }

        //Creamos un campo estatico del repository donde tendremos la coneccion
        private static BaseRepository<Order> _orderRepository;

        //Llenamos el campo estico del repository mediante patron Singleton
        public static BaseRepository<Order> OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new BaseRepository<Order>();
                }
                return _orderRepository;
            }
        }

        //Creamos un campo estatico del repository donde tendremos la coneccion
        private static BaseRepository<Passport> _passportRepository;

        //Llenamos el campo estico del repository mediante patron Singleton
        public static BaseRepository<Passport> PassportRepository
        {
            get
            {
                if (_passportRepository == null)
                {
                    _passportRepository = new BaseRepository<Passport>();
                }
                return _passportRepository;
            }
        }

        //Creamos un campo estatico del repository donde tendremos la coneccion
        private static BaseRepository<CreditCard> _creditCardRepository;

        //Llenamos el campo estico del repository mediante patron Singleton
        public static BaseRepository<CreditCard> CreditCardRepository
        {
            get
            {
                if (_creditCardRepository == null)
                {
                    _creditCardRepository = new BaseRepository<CreditCard>();
                }
                return _creditCardRepository;
            }
        }

        //Creamos un campo estatico del repository donde tendremos la coneccion
        private static BaseRepository<Asistencia> _asistenciaRepository;

        //Llenamos el campo estico del repository mediante patron Singleton
        public static BaseRepository<Asistencia> AsistenciaRepository
        {
            get
            {
                if (_asistenciaRepository == null)
                {
                    _asistenciaRepository = new BaseRepository<Asistencia>();
                }
                return _asistenciaRepository;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
