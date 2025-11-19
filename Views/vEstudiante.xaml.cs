using acalderonS6Online.Modelos;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace acalderonS6Online.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "http://192.168.100.8/wsestudiante/restEstudiantes.php";
	private readonly HttpClient client = new HttpClient();
	private ObservableCollection<Estudiante> _estudiante;

	public async void Mostrar() 
	{ 
		var content = await client.GetStringAsync(Url);
		List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		_estudiante = new ObservableCollection<Estudiante>(mostrarEst);
		listaEstudiantes.ItemsSource = _estudiante;
    }

    public vEstudiante()
	{
		InitializeComponent();
		Mostrar();
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new vAgregar());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objetoEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new vActualizarEliminar(objetoEstudiante));
    }
}