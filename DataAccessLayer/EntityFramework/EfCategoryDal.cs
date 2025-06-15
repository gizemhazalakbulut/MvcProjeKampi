using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>,ICategoryDal
    {
        // böylece katmanları, katmanlar içindeki sınıfları birbirleriyle haberleştirerek her katmanın ya da her sınıfın veya her metodun içindeki komut sadece kendisine ait işlemleri gerçekleştirsin istiyorum 

        // Artık EfCategoryDal, GenericRepository içerisindeki Category sınıfımda yer alan komutu kullanacak.

        // Burda EfCategoryDal kullanarak GenericRepository e ulaştım. GenericRepository e göndereceğim T değerini burda gönderiyorum.
    }
}
