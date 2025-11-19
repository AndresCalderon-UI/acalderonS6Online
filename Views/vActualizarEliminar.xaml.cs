namespace acalderonS6Online.Views;
using acalderonS6Online.Modelos;
using System;
using System.Net;

public partial class vActualizarEliminar : ContentPage
{
	public vActualizarEliminar(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.PutAsync("http://192.168.100.8/wsestudiante/restEstudiantes.php?"+$"codigo={txtCodigo.Text}&nombre={txtNombre.Text}&apellido={txtApellido.Text}&edad={txtEdad.Text}",null);
                DisplayAlert("Alerta", "Actualización exitosa", "OK");
                Navigation.PushAsync(new vEstudiante());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al actualizar estudiante: " + ex.Message);
        }
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        bool confirmacion = await DisplayAlert("Confirmar", "¿Estás seguro de que deseas eliminar este estudiante?", "Sí", "No");
        if (!confirmacion)
            return;

        try
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"http://192.168.100.8/wsestudiante/restEstudiantes.php?codigo={txtCodigo.Text}";
                var response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Éxito", "Estudiante eliminado correctamente", "OK");
                    await Navigation.PushAsync(new vEstudiante());
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo eliminar el estudiante", "OK");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al eliminar estudiante: " + ex.Message);
        }
    }
}