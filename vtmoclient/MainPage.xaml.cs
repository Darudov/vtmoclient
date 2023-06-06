using System.Net.Http.Json;
using Resource = Microsoft.Maui.Controls;

namespace vtmoclient;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    record class User(int id, string name, string password, bool canBeGm);
    private static HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("http://localhost:8080"),
    };
    private async void OnCounterClicked(object sender, EventArgs e)
    {
    
        // count++;
        //
        // if (count == 1)
        //     CounterBtn.Text = $"Clicked {count} time";
        // else
        //     CounterBtn.Text = $"Clicked {count} times";
        var user = await sharedClient.GetFromJsonAsync<User>("/user/1");
        CounterBtn.Text = user.name;
        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}