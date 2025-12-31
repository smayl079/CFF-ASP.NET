using FiorelloClone.Data;

namespace FiorelloClone.Services;

public class LayoutService
{
    private readonly AppDbContext _context;
    public LayoutService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Dictionary<string, string>> GetAllSetting()
    {
        Dictionary<string, string> settings = await Task.FromResult(_context.Settings.Where(m => !m.IsDeleted).ToDictionary(m => m.Key, m => m.Value));

        return settings;
    }
}
