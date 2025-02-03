using GameStore.DL.Interfaces;
using GameStore.Models.DTO;

namespace GameStore.DL.Repositories
{
    //public class DeveloperStaticRepository : IDeveloperRepository
    //{
    //    public IEnumerable<Developer> GetDevelopersByIds(IEnumerable<int> developersIds)
    //    {
    //        var result = new List<Developer>();

    //        foreach (var developersId in developersIds)
    //        {
    //            foreach (var developer in StaticDB.InMemoryDb.Developers)
    //            {
    //                if (developer.Id == developersId)
    //                {
    //                    result.Add(developer);
    //                }
    //            }
    //        }

    //        return result;

    //    }


    //    public Developer? GetById(int id)
    //    {
    //        return StaticDB.InMemoryDb.Developers.
    //            FirstOrDefault(x => x.Id == id);
    //    }
    //}
}
