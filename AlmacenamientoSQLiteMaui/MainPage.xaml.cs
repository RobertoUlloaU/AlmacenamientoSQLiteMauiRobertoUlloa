using AlmacenamientoSQLiteMaui.Models;

namespace AlmacenamientoSQLiteMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    // Evento al presionar "Guardar Nota"
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var note = new Note
        {
            Text = textEntry.Text,
            Date = DateTime.Now
        };

        await App.Database.SaveNoteAsync(note);
        textEntry.Text = string.Empty;
        await LoadNotes();
    }

    // Carga las notas al ListView
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadNotes();
    }

    private async Task LoadNotes()
    {
        notesListView.ItemsSource = await App.Database.GetNotesAsync();
    }

    // Muestra un mensaje al seleccionar una nota
    private async void OnNoteSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Note note)
        {
            await DisplayAlert("Nota seleccionada", note.Text, "OK");
            ((ListView)sender).SelectedItem = null; // Deselecciona el item
        }
    }
}
