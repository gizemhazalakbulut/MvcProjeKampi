using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{

    // Her methodun tek tek görevini tanımladık
    public class CategoryRepository : ICategoryDal  // ICategoryDal interface'ini implement ettik
    {

        Context c = new Context(); // context sınıfından bir nesne oluşturduk
        DbSet<Category> _object;
        public void Delete(Category p)
        {
            _object.Remove(p);
            c.SaveChanges(); // değişiklikleri kaydet

        }

        public void Delete(int id)
        {
            var value = _object.Find(id); // id'ye göre silinecek nesneyi bul
            _object.Remove(value); // nesneyi sil
            c.SaveChanges(); // değişiklikleri kaydet

        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category p)
        {
            _object.Add(p); // parametre olarak gelen p nesnesini _object'e ekle
            c.SaveChanges(); // değişiklikleri kaydet
        }

        public List<Category> List()
        {
            return _object.ToList();
            
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            c.SaveChanges(); // değişiklikleri kaydet

        }
    }
}
