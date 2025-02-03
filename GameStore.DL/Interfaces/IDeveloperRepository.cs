using GameStore.Models.DTO;

namespace GameStore.DL.Interfaces
{
    public interface IDeveloperRepository
    {
        void AddDeveloper(Developer developer);
        IEnumerable<Developer> GetDevelopersByIds(IEnumerable<string> developersIds);
        Developer? GetById(string id);
    }
}
