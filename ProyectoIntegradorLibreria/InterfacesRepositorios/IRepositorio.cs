using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLibreria.InterfacesRepositorios
{
    public interface IRepositorio <T>
    {
        IEnumerable<T> FindAll();
        T FindByID(int id);
        void Add(T t);
        void Remove(int id);
        void Update(T t);
    }
}
