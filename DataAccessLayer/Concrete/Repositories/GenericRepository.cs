using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class  //göndericeğim T değeri bir class olmalı
    {

        Context c = new Context(); //context sınıfından bir nesne oluşturduk
        DbSet<T> _object; //T türünde bir nesne oluşturduk
        public GenericRepository() //GenericRepository sınıfının constructor'ı (T değerine karşılık gelen sınıfı bulmak için)
        {
            _object = c.Set<T>(); //c nesnesinin Set metodunu kullanarak T türünde bir nesne oluşturduk. Artık _object dışardan gelen T değerim
        }
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted; //p nesnesinin durumunu silinmiş olarak ayarla
           // _object.Remove(p); //p nesnesini _object'ten sil
            c.SaveChanges(); //değişiklikleri kaydet
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); //bir dizide veya listede sadece bir tane değer geriye döndürmek için kullanılan ef linq methodudur SingleOrDefault().
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p); //p nesnesini ekleyeceğimiz için Entry metodunu kullanıyoruz
            addedEntity.State = EntityState.Added; //p nesnesinin durumunu eklenmiş olarak ayarla
            //_object.Add(p); //p nesnesini _object'e ekle
            c.SaveChanges(); //değişiklikleri kaydet
        }

        public List<T> List()
        {
            return _object.ToList(); // _object'i listele
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList(); // filterdan gelen değere göre listeleme yapar
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p); //p nesnesini güncelleyeceğimiz için Entry metodunu kullanıyoruz
            updatedEntity.State = EntityState.Modified; //p nesnesinin durumunu güncellenmiş olarak ayarla
            c.SaveChanges(); //değişiklikleri kaydet
        }
    }
}
