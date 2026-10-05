using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktów
{
    internal class Produkt
    {
        private string _nazwa;
        public string Nazwa
        {
            get { return _nazwa; }
            set
            {
                if (value == String.Empty)
                {
                    _nazwa = "Brak nazwy";
                    throw new ArgumentException("Nazwa nie może być pusta.");
                }
                else
                {
                    _nazwa = value;
                }
            }
        }
        private double _cena;
        public double Cena
        {
            get { return _cena; }
            set
            {
                if (value < 0)
                {
                    _cena = 0;
                    throw new ArgumentException("Cena nie może być ujemna.");
                }
                else
                {
                    _cena = value;
                }
            }
        }
        public string Kategoria;

        public int MinimalnyStan { get; set; }
        public int Ilosc { get; private set; }

        public double WartoscMagazynu
        {
            get
            {
                return Cena * Ilosc;
            }
        }
        //nadajemy konstruktor, który przyjmuje parametry i ustawia wartości pól
        public Produkt(string nazwa, double cena, string kategoria, int ilosc)
        {
            Nazwa = nazwa;
            Cena = cena;
            Kategoria = kategoria;
            Ilosc = ilosc;
            MinimalnyStan = 1;
        }
        public Produkt(string nazwa)
        {
            Nazwa = nazwa;
            Cena = 0;
            Kategoria = "Brak kategorii";
            Ilosc = 0;
            MinimalnyStan = 1;
        }
        //funkcja wypisująca informacje o produkcie w formacie tabelarycznym
        public void wypiszProdukt()
        {
            Console.WriteLine($"Nazwa: {Nazwa,-15}| Cena: {Cena,10:f2} zł | " +
                $"Kategoria: {Kategoria} | Ilość: {Ilosc,5} | Wartość: {WartoscMagazynu,10:f2} zł");
        }
        //ta metoda zwraca string z tymi samymi informacjami o produkcie, ale nie wypisuje ich na ekran
        public string infoProdukt()
        {
            return $"Nazwa: {Nazwa,-15}| Cena: {Cena,10:f2} zł | " +
                $"Kategoria: {Kategoria} | Ilość: {Ilosc,5} | Wartość: {WartoscMagazynu,10:f2} zł";
        }
        public static double obliczWartoscMagazynu(Produkt[] produkty)
        {
            double suma = 0; //inicjalizacja zmiennej suma na 0
            foreach (Produkt produkt in produkty) //iteracja po wszystkich produktach w tablicy
            {
                suma += produkt.WartoscMagazynu; //dodanie wartości magazynu produktu do sumy
            }
            return suma; //zwrócenie sumy wartości magazynu wszystkich produktów
        }


        public bool czyMoznaZamowic()
        {
            return Ilosc > MinimalnyStan; //zwraca true jeśli ilość jest większa od 0, w przeciwnym razie false
        }
        public void Sprzedaj()
        {
            if (czyMoznaZamowic()) //czy można zamówić - czy mamy dość na stanie?
            {
                //tak, zdejmij ze stanu jedną sztukę
                Ilosc--;
                //wypisz informację o sprzedaży
                Console.WriteLine($"Sprzedano produkt: {Nazwa}. Pozostało na stanie: {Ilosc}");
            }
            else
            {
                //nie, nie można sprzedać, bo nie ma na stanie
                Console.WriteLine($"Nie można sprzedać produktu: {Nazwa}. Brak na stanie.");
            }
        }
    }
}
