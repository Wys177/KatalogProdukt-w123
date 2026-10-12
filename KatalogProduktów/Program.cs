using KatalogProduktów;

Console.OutputEncoding = System.Text.Encoding.UTF8;

string[] nazwy = { "Procesor", "Pamięć RAM", "Dysk SSD", "Zasilacz" };
double[] ceny = { 899.00, 249.50, 379.00, 189.99 };

//stwórz nowy obiekt procesor według definicji klasy Produkt
Produkt procesor = new Produkt("AMD Ryzen", 899.00, "Podzespoły", 10);
Produkt ram = new Produkt("Pamięć RAM", 249.50, "Podzespoły", 20); //celowo podajemy ujemną cenę, aby sprawdzić działanie walidacji
Produkt ssd = new Produkt("Dysk SSD", 379.00, "Podzespoły", 15);
Produkt zasilacz = new Produkt("Zasilacz", 189.99, "Podzespoły", 5);

//tworzymy tablicę produktów
Produkt[] produkty = { procesor, ram, ssd, zasilacz };
Produkt[] produkty2 = new Produkt[10]; //tworzymy pustą tablicę 10 produktów 

List<Produkt> listaProduktow = new List<Produkt >();

listaProduktow.Add(procesor);
listaProduktow.Add(ram);
listaProduktow.Add(ssd);
listaProduktow.Add(zasilacz);

foreach (Produkt produkt in listaProduktow)
{
    produkt.wypiszProdukt(); //wywołujemy metodę wypiszProdukt dla każdego produktu w tablicy
}


double suma = 0;
int licznik = 0;
//dla tablicy przechodzilismy "recznie" po indeksach
for (int i = 0; i < nazwy.Length; i++)
{
    // Do sumy trafiają tylko produkty droższe niż 200 zł
    if (ceny[i] > 200)
    {
        suma = suma + ceny[i];
        licznik++;
    }
}
//dla listy mozemy uzyc LINQ do zsumowania calosci 
double sumaListy = listaProduktow.Sum(p => p.Cena); //czytamy jako dla kazdego produktu sumuj jego pole cena

List<Produkt> drogieProdukty = listaProduktow.Where(p => p.Cena > 200).ToList(); //tworzymy nową listę z produktami droższymi niż 200 zł
//lub możemy od razu policzyć sumę cen produktów droższych niż 200 zł
double sumaDrogichProduktow = listaProduktow.Where(p => p.Cena > 200).Sum(p => p.Cena);

// Uwaga: przy pustym liczniku byłoby dzielenie przez zero
double srednia = suma / licznik;
//Console.WriteLine($"Ilość produktów w bazie: {nazwy.Length}");
//Console.WriteLine($"Średnia cena: {srednia:F2} zł z {licznik} produktów");

double sredniaCena = listaProduktow.Average(p => p.Cena); //obliczamy średnią cenę produktów w liście

double wartoscListy = Produkt.obliczWartoscMagazynu(listaProduktow);

double wartoscMagazynu = Produkt.obliczWartoscMagazynu(listaProduktow);
Console.WriteLine($"Suma wartości magazynu wszystkich produktów: {wartoscMagazynu:F2} zł");


foreach (Produkt produkt in produkty)
{
    produkt.Sprzedaj();
    produkt.Sprzedaj();
    produkt.Sprzedaj();
    produkt.Sprzedaj();
    produkt.Sprzedaj();
}
Produkt p = Produkt.znajdzPoNazwie(produkty, "Dysk SSD");
Console.WriteLine($"Znaleziono produkt: {p.Nazwa}, Cena: {p.Cena} zł, Ilość: {p.Ilosc}");
Produkt p2 = Produkt.znajdzPoNazwie(listaProduktow, "sila");
Console.WriteLine($"Znaleziono produkt: {p2.Nazwa}, Cena: {p2.Cena} zł, Ilość: {p2.Ilosc}");

