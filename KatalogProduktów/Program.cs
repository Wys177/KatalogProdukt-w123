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

foreach (Produkt produkt in produkty)
{
    produkt.wypiszProdukt(); //wywołujemy metodę wypiszProdukt dla każdego produktu w tablicy
}


double suma = 0;
int licznik = 0;

for (int i = 0; i < nazwy.Length; i++)
{
    // Do sumy trafiają tylko produkty droższe niż 200 zł
    if (ceny[i] > 200)
    {
        suma = suma + ceny[i];
        licznik++;
    }
}

// Uwaga: przy pustym liczniku byłoby dzielenie przez zero
double srednia = suma / licznik;
//Console.WriteLine($"Ilość produktów w bazie: {nazwy.Length}");
//Console.WriteLine($"Średnia cena: {srednia:F2} zł z {licznik} produktów");

double wartoscMagazynu = Produkt.obliczWartoscMagazynu(produkty);
Console.WriteLine($"Suma wartości magazynu wszystkich produktów: {wartoscMagazynu:F2} zł");
