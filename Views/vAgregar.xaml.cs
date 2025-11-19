using System.Net;

namespace acalderonS6Online.Views;

public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues("http://192.168.100.8/wsestudiante/restEstudiantes.php", "POST", parametros);
			DisplayAlert("Alerta", "Ingreso exitoso", "OK");
			Navigation.PushAsync(new vEstudiante());
        }
		catch (Exception ex)
		{

			Console.WriteLine("Error al agregar estudiante " + ex.Message);
		}

    }
}