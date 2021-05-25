//using SQLite;
//using SQliteDemo1.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;

//namespace SQliteDemo1.Repositories
//{
//    public class CustomerRepository
//    {

//        //Campo para establecer la conexion a nuestro archivo de Base de Datos
//        SQLiteConnection connection;
//        //Propiedad para manejar los mensajes si hay problemas
//        public string StatusMessage { get; set; }

//        //En el constructor configuramos esta conexion
//        public CustomerRepository()
//        {
//            //Pasamos nuestra ruta al archivo de BD y los Flags(Cadena de Conexion)
//            connection =
//                new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
//            //Creamos la tabla si no existe de acuerdo a nuestro modelo
//            connection.CreateTable<Customer>();
//        }

//        //Metodo para agregar o actualizar Customer
//        public void AddOrUpdate(Customer pCustomer)
//        {
//            //Variable para manejar la cantidad de registros afectados
//            int result = 0;
//            //Abrimos un Try para manejar algun error que pudiera existir
//            try
//            {
//                //Si Id es cero es nuevo si no ya existe
//                if(pCustomer.Id==0)
//                { 
//                    //Se manda insertar
//                    result = connection.Insert(pCustomer);
//                    //Si es exitoso le decimos que se insertó
//                    StatusMessage = $"{result} registro(s) agregado(s)";
//                }
//                else
//                {
//                    //Se manda actualizar
//                    result = connection.Update(pCustomer);
//                    //Si es exitoso le decimos que se actualizó
//                    StatusMessage = $"{result} registro(s) actualizado(s)";
//                }
//            }
//            catch (Exception ex)
//            {
//                //Si hubo problemas lo indicamos
//                StatusMessage = $"Error : {ex.Message}";
//            }
//        }

//        //Metodo para devolver todos los Customer existentes
//        public List<Customer> GetAll()
//        {
//            //Variable de retorno
//            List<Customer> ret = null;
//            //Abrimos un Try para manejar algun error que pudiera existir
//            try
//            {
//                //Llenamos la variable con la lista
//                ret = connection.Table<Customer>().ToList();
//            }
//            catch (Exception ex)
//            {
//                //Si hubo problemas lo indicamos
//                StatusMessage = $"Error : {ex.Message}";
//            }
//            //Regresamos la variable
//            return ret;
//        }

//        //Metodo para flexibilizar las consultas con expresiones lambda
//        public List<Customer> Get(Expression<Func<Customer,bool>> predicate)
//        {
//            List<Customer> ret = null;
//            try
//            {
//                ret = connection.Table<Customer>().Where(predicate).ToList();
//            }
//            catch (Exception ex)
//            {
//                //Si hubo problemas lo indicamos
//                StatusMessage = $"Error : {ex.Message}";
//            }
//            //Regresamos la variable
//            return ret;
//        }

//        //Metodo para devolver un Customer en particular
//        public Customer Get(int id)
//        {
//            //variable de retorno
//            Customer ret = null;
//            //Abrimos un Try para manejar algun error que pudiera existir
//            try
//            {
//                ret = connection.Table<Customer>().FirstOrDefault(x => x.Id == id);
//            }
//            catch (Exception ex)
//            {
//                //Si hubo problemas lo indicamos
//                StatusMessage = $"Error : {ex.Message}";
//            }
//            //Regresamos la variable
//            return ret;
//        }

//        //Metodo para devolver una lista a partir de una consulta SQL
//        public List<Customer> GetAll2()
//        {
//            //Creamos la variable para regresar la lista
//            List<Customer> ret = null;
//            //Abrimos un Try para manejar algun error que pudiera existir
//            try
//            {
//                //Almacenamos en la variable el resultado arrojado por la cosulta textual a la BD
//                ret = connection.Query<Customer>("SELECT FROM Customers");
//            }
//            catch (Exception ex)
//            {
//                //Si hubo problemas lo indicamos
//                StatusMessage = $"Error : {ex.Message}";
//            }
//            //Regresamos la variable
//            return ret;
//        }

//        //Metodo para eliminar un registro por id
//        public void Delete(int customerId)
//        {
//            //Abrimos un Try para manejar algun error que pudiera existir
//            try
//            {
//                //Con el id traemos la instancia del cliente
//                var customer = Get(customerId);
//                //Eliminamos la isntancia del cliente
//                connection.Delete(customer);
//            }
//            catch (Exception ex)
//            {
//                //Si hubo problemas lo indicamos
//                StatusMessage = $"Error : {ex.Message}";
//            }
//        }
//    }
//}
