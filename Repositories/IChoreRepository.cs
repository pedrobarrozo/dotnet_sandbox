using System.Collections.Generic;
using TestApi.Models;


namespace TestApi.Repositories
{
    public interface IChoreRepository
    {
        IEnumerable<ChoreItem> GetAll();
        IEnumerable<ChoreItem> Get(int id);
    }
    
}