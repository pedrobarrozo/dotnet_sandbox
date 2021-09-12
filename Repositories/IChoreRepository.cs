using System.Collections.Generic;
using TestApi.Models;
using System.Text.Json;

namespace TestApi.Repositories
{
    public interface IChoreRepository
    {
        IEnumerable<ChoreItem> GetAll();
        IEnumerable<ChoreItem> Get(int id);
        ChoreItem Create(ChoreItem chore);
        IEnumerable<ChoreItem> Update(int id,ChoreItem chore);
        void Delete(int id);
    }
    
}