using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>  
    {
        //CRUD operasyonları
        List<T> List();      // listeleme işlemi

        void Insert(T p);   //ekleme işlemi

        T Get(Expression<Func<T, bool>> filter); // bu id 5 olanı getirir sadece

        void Update(T p);  // güncelleme işlemi

        void Delete(T p);    // silme işlemi

        List<T> List(Expression<Func<T, bool>> filter);  //şartlı listeleme yapar bu adı ali olan tüm yazarları listeler 


    }
}
