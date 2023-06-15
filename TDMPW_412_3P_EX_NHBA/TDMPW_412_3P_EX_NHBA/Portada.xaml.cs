//using Android.Media;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System.Threading.Tasks;


namespace TDMPW_412_3P_EX_NHBA;

public partial class Portada : TabbedPage
{
    private readonly Random random = new Random();
    private readonly Timer timer;
    private GradientBrush gradientBrush;

    List<Musica> musica = new List<Musica>();
    int i = 0;
    public Portada()
	{
		InitializeComponent();

        musica.Add(new Musica("una_vez.mp4", "Una vez", "Bad Bunny"));
        musica.Add(new Musica("rompe.mp4", "Rompe", "Daddy Yankee"));
        musica.Add(new Musica("otra_noche_en_miami.mp4", "Otra noche en Miami", "Bad Bunny"));
        musica.Add(new Musica("feliz_cumpleanos.mp4", "Feliz cumpleaños", "Feid"));

        timer = new Timer(ChangeBackgroundColor, null, 0, 1500);

    }

    private void ChangeBackgroundColor(object state)
    {
        var starColor = System.Drawing.Color.FromArgb(
            random.Next(0, 256),
            random.Next(0, 256),
            random.Next(0, 256)
            );

        var endColor = System.Drawing.Color.FromArgb(
            random.Next(0, 256),
            random.Next(0, 256),
            random.Next(0, 256)
            );

        var colors = ColorUtility.ColorControls.GetColorGradient(starColor, endColor, 6);

        var stops = new GradientStopCollection();

        float stopOffset = 0.0f;
        foreach (var c in colors)
        {
            stops.Add(new GradientStop(Color.FromArgb(c.Name), stopOffset));
            stopOffset += .2f;
        }

        // Dispose previous brush to avoid resource leak

        gradientBrush = new LinearGradientBrush(stops, new Point(0, 0), new Point(1, 1));
        Device.InvokeOnMainThreadAsync(() =>
        {
            background.BackgroundColor = Colors.White; // Set a solid background color if needed
            background.Background = gradientBrush;
        });
    }

    void Play_Clicked(System.Object sender, System.EventArgs e)
    {
        if (mediaElement.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
        {
            mediaElement.Pause(); Play.Text = "▶️";
        }
        else
        {
            if (mediaElement.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Paused)
            {
                mediaElement.Play(); Play.Text = "⏸️";
            }
        }

    }

    void Next_Clicked(System.Object sender, System.EventArgs e)
    {
        i++;
        if (i > 3)
        {
            i = 0;
            mediaElement.Source = musica[i].video;
            cancion.Text = musica[i].cancion;
            artista.Text = musica[i].artista;   
        }
        else
        {
            mediaElement.Source = musica[i].video;
            cancion.Text = musica[i].cancion;
            artista.Text = musica[i].artista;
        }
    }

    void Previous_Clicked(System.Object sender, System.EventArgs e)
    {
        i--;
        if (i < 0)
        {
            i = 3;

            mediaElement.Source = musica[i].video;
            cancion.Text = musica[i].cancion;
            artista.Text = musica[i].artista;
        }
        else
        {
            mediaElement.Source = musica[i].video;
            cancion.Text = musica[i].cancion;
            artista.Text = musica[i].artista;
        }
    }
}
