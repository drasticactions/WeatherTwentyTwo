namespace WeatherTwentyTwo;

public partial class HomePage : BasePage
{
    private HomeViewModel vm;

    public HomePage(IServiceProvider services)
        : base(services)
    {
        this.InitializeComponent();
        this.BindingContext = this.vm = services.ResolveWith<HomeViewModel>();
    }
}