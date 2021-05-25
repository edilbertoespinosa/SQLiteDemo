using SQLite;
using SQliteDemo1.Abstractions;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SQliteDemo1.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {

        //Campo para establecer la conexion a nuestro archivo de Base de Datos
        SQLiteConnection connection;
        //Propiedad para manejar los mensajes si hay problemas
        public string StatusMessage { get; set; }

        //En el constructor configuramos esta conexion
        public BaseRepository()
        {
            //Pasamos nuestra ruta al archivo de BD y los Flags(Cadena de Conexion)
            connection =
                new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            //Creamos la tabla si no existe de acuerdo a nuestro modelo
            connection.CreateTable<T>();
        }

        //Metodo para eliminar un registro por id
        public void DeleteItem(T item)
        {
            //Abrimos un Try para manejar algun error que pudiera existir
            try
            {
                //Eliminamos el registro
                connection.Delete(item, true);
            }
            catch (Exception ex)
            {
                //Si hubo problemas lo indicamos
                StatusMessage = $"Error : {ex.Message}";
            }
        }

        //Cuando desocupamos la coneccion, la mandamos al GarbageCollector
        public void Dispose()
        {
            connection.Close();
        }

        //Metodo para devolver un registro en particular por Id
        public T GetItem(int Id)
        {
            //variable de retorno
            T ret = null;
            //Abrimos un Try para manejar algun error que pudiera existir
            try
            {
                ret = connection.Table<T>().FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                //Si hubo problemas lo indicamos
                StatusMessage = $"Error : {ex.Message}";
            }
            //Regresamos la variable
            return ret;
        }

        //Metodo para flexibilizar la consulta de un registro con expresiones lambda
        public T GetItem(Expression<Func<T, bool>> predicate)
        {
            T ret = null;
            try
            {
                ret = connection.Table<T>().Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //Si hubo problemas lo indicamos
                StatusMessage = $"Error : {ex.Message}";
            }
            //Regresamos la variable
            return ret;
        }

        //Metodo para devolver todos los Registros existentes
        public List<T> GetItems()
        {
            //Variable de retorno
            List<T> ret = null;
            //Abrimos un Try para manejar algun error que pudiera existir
            try
            {
                //Llenamos la variable con la lista
                ret = connection.Table<T>().ToList();
            }
            catch (Exception ex)
            {
                //Si hubo problemas lo indicamos
                StatusMessage = $"Error : {ex.Message}";
            }
            //Regresamos la variable
            return ret;
        }

        //Metodo para flexibilizar las consultas de registros con expresiones lambda
        public List<T> GetItems(Expression<Func<T, bool>> predicate)
        {
            List<T> ret = null;
            try
            {
                ret = connection.Table<T>().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                //Si hubo problemas lo indicamos
                StatusMessage = $"Error : {ex.Message}";
            }
            //Regresamos la variable
            return ret;
        }

        //Metodo para agregar o actualizar un registro
        public void SaveItem(T item)
        {
            //Variable para manejar la cantidad de registros afectados
            int result = 0;
            //Abrimos un Try para manejar algun error que pudiera existir
            try
            {
                //Si Id es cero es nuevo si no ya existe
                if (item.Id == 0)
                {
                    //Se manda insertar
                    result = connection.Insert(item);
                    //Si es exitoso le decimos que se insertó
                    StatusMessage = $"{result} registro(s) agregado(s)";
                }
                else
                {
                    //Se manda actualizar
                    result = connection.Update(item);
                    //Si es exitoso le decimos que se actualizó
                    StatusMessage = $"{result} registro(s) actualizado(s)";
                }
            }
            catch (Exception ex)
            {
                //Si hubo problemas lo indicamos
                StatusMessage = $"Error : {ex.Message}";
            }
        }

        //Metodo para grabar las relaciones
        public void SaveItemWithChildren(T item, bool recursive = false)
        {
            //Grabamos el item con sus relaciones
            connection.InsertWithChildren(item, recursive);
        }

        //Metodo para leer las relaciones
        public List<T> GetItemsWithChildren()
        {
            //Variable de retorno
            List<T> ret = null;
            //Abrimos un Try para manejar algun error que pudiera existir
            try
            {
                //Llenamos la variable con la lista
                ret = connection.GetAllWithChildren<T>().ToList();
            }
            catch (Exception ex)
            {
                //Si hubo problemas lo indicamos
                StatusMessage = $"Error : {ex.Message}";
            }
            //Regresamos la variable
            return ret;
        }
    }
}
