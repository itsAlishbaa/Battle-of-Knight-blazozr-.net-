using System.Text.Json;
using blazor_final_pro.Models; // Ensure this matches your namespace

namespace blazor_final_pro.Services;

public class UserService
{
    private List<UserAccount> _users = new();
    private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "users.json");

    // CurrentUser ko nullable rakhna zaroori hai taaki jab koi logged in na ho, yeh null ho sake
    public UserAccount? CurrentUser { get; set; }

    public UserService()
    {
        LoadData();
    }

    public bool Register(UserAccount user)
    {
        if (user == null || string.IsNullOrEmpty(user.Email)) return false;

        if (_users.Any(u => u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase))) return false;

        _users.Add(user);
        SaveData();
        return true;
    }

    public bool Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) return false;

        var user = _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Password == password);
        if (user != null)
        {
            CurrentUser = user;
            return true;
        }
        return false;
    }

    public void Logout()
    {
        CurrentUser = null;
    }

    private void SaveData()
    {
        try
        {
            var dir = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllText(_filePath, JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true }));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }

    private void LoadData()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _users = JsonSerializer.Deserialize<List<UserAccount>>(json) ?? new();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
            _users = new();
        }
    }
}