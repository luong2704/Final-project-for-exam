using Campus.Models;

namespace Campus.Services;

public class CampusService
{
    public List<CampusModel> GetCampuses()
    {
        return new List<CampusModel>
        {
            new CampusModel { Id = 1, Name = "Cơ sở 1", Address = "Hà Nội" },
            new CampusModel { Id = 2, Name = "Cơ sở 2", Address = "TP.HCM" }
        };
    }
}