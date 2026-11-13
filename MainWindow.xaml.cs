using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KonyvekFeladat
{
    public class Konyv
    {
        public string Cim { get; set; } = string.Empty;
        public string Szerzo { get; set; } = string.Empty;
        public int Oldalszam { get; set; }
        public string Mufaj { get; set; } = string.Empty;
        public bool Elerheto { get; set; }
    }

    public partial class MainWindow : Window
    {
        private List<Konyv> konyvekLista = new List<Konyv>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            konyvekLista.Clear();

            konyvekLista.Add(new Konyv { Cim = "1984", Szerzo = "George Orwell", Oldalszam = 328, Mufaj = "Sci-fi", Elerheto = true });
            konyvekLista.Add(new Konyv { Cim = "A szolgálólány meséje", Szerzo = "Margaret Atwood", Oldalszam = 311, Mufaj = "Disztópia", Elerheto = true });
            konyvekLista.Add(new Konyv { Cim = "Az ember tragédiája", Szerzo = "Madách Imre", Oldalszam = 250, Mufaj = "Dráma", Elerheto = true });
            konyvekLista.Add(new Konyv { Cim = "Dűne", Szerzo = "Frank Herbert", Oldalszam = 604, Mufaj = "Sci-fi", Elerheto = true });
            konyvekLista.Add(new Konyv { Cim = "Egri csillagok", Szerzo = "Gárdonyi Géza", Oldalszam = 552, Mufaj = "Történelmi", Elerheto = false });

            dgKonyvek.ItemsSource = konyvekLista;
            dgKonyvek.Items.Refresh();
            pbHaladas.Value = 100;
        }

        private void BtnHanyKonyv_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Összesen {konyvekLista.Count} könyv van.", "Információ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnLeghosszabb_Click(object sender, RoutedEventArgs e)
        {
            if (konyvekLista.Count == 0) return;
            var leghosszabb = konyvekLista.OrderByDescending(k => k.Oldalszam).First();
            MessageBox.Show($"A leghosszabb könyv: {leghosszabb.Cim} ({leghosszabb.Szerzo} - {leghosszabb.Oldalszam} oldal)", "Leghosszabb könyv", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnAtlag_Click(object sender, RoutedEventArgs e)
        {
            if (konyvekLista.Count == 0) return;
            double atlag = konyvekLista.Average(k => k.Oldalszam);
            MessageBox.Show($"Átlagos oldalszám: {atlag:F2}", "Átlag oldalszám", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnElerheto_Click(object sender, RoutedEventArgs e)
        {
            var elerhetok = konyvekLista.Where(k => k.Elerheto).ToList();
            dgKonyvek.ItemsSource = elerhetok;
        }

        private void BtnCimek_Click(object sender, RoutedEventArgs e)
        {
            string cimek = string.Join("\n", konyvekLista.Select(k => k.Cim));
            MessageBox.Show(cimek, "Könyvek címei", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnRendezes_Click(object sender, RoutedEventArgs e)
        {
            var rendezett = konyvekLista.OrderBy(k => k.Szerzo).ToList();
            dgKonyvek.ItemsSource = rendezett;
        }
    }
}
