using Cupcakes.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cupcakes.Repositories
{
    public interface ICupcakeRepository
    {
        IEnumerable<Cupcake> GetCupcakes();

        Cupcake GetCupcakeById(int id);

        void CreateCupcake(Cupcake cupcake);
        void DeleteCupcake(int id);

        void SaveChanges();

        IQueryable<Bakery> PopulateBakeriesDropDownList();
    }
}
