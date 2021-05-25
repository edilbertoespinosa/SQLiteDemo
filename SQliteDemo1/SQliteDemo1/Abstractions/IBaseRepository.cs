using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SQliteDemo1.Abstractions
{
    public interface IBaseRepository<T> : IDisposable
        where T : TableData, new()
    {
        void SaveItem(T item);
        T GetItem(int Id);
        T GetItem(Expression<Func<T, bool>> predicate);
        void DeleteItem(T item);
        List<T> GetItems();
        List<T> GetItems(Expression<Func<T, bool>> predicate);
        void SaveItemWithChildren(T item, bool recursive = false);
        List<T> GetItemsWithChildren();
    }
}
