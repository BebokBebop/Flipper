///////////// Intro
Witam!
Nazywam si� Hubert Przegendza, a to m�j program zaliczeniowy zaj�� z grupy Junior .NET Pol�l.

Pisanie go sprawi�o mi du�o frajdy i ch�tnie go w przysz�o�ci ulepsz�, w zwi�zku z czym Feedback jest mile widziany :)

///////////// Nazwa i Pomys�
Ten program to gra logiczna, kt�r� nazwa�em Flipper. Pomys� wzi��em ze starych gier typu Escape The Room, gdzie cz�sto pojawia�a si� tego typu �amig��wka.

///////////// Nazewnictwo
Seed - kod s�u��cy do wygenerowania planszy

///////////// Dzia�anie
>Celem Gry jest oczyszczenie planszy (ca�a plansza na bia�o).

>Klikni�cie w guzik na kwadratowej planszy spowoduje zmian� koloru (fioletowy - bia�y i na odwr�t) owego guzika, guzika pod nim, nad nim i na lewo i prawo.

>Klikni�cie przycisku "Shuffle" spowoduje wygenerowanie nowej mapy i wyzerowanie ilo�ci ruch�w.

>Klikni�cie przycisku "Reset" zresetuje map� oraz ilo�� ruch�w.

>Zaznaczenie pola "Show Solution" w��czy pokazywanie rozwi�zania (kt�re przyciski trzeba nacisn��, aby oczy�ci� plansz�) oraz wy��czy liczenie ruch�w.
  
Odznaczenie tego pola wy��czy pokazywanie rozwi�zania, ale ruchy dalej nie b�d� liczone.
Aby znowu w��czy� liczenie ruch�w nale�y zrestowa� map� lub stworzy� now�.

>"Moves: [pole tekstowe]" pokazuje aktualn� ilo�� klikni�� w przyciski na planszy.

>Przycisk "Copy Seed" kopiuje do schowka aktualny Seed mapy, kt�ry wypisany jest poni�ej tego przycisku w zacieniowanym polu tekstowym.

>Zaznaczenie pola "Create Seed Mode" w��czy czytanie Seeda mapy na bie��co tzn. ka�de klikni�cie w guzik na planszy spowoduje wy�wietlenie si� w polu tekstowym nowego, aktualnego Seeda.

Kiedy to pole jest zaznaczone, zaznaczenie pola "Show Solution" nie wy��czy liczenia ruch�w.

>Naci�ni�cie przycisku "New Map Options" otworzy nowe okno, w kt�rym mo�na stworzy� now� map�.
  S� na to dwa sposoby:
-Podanie w dw�ch polach tekstowych u g�ry samych wymiar�w nowej
 planszy (w pierwszym szeroko��, w drugim wysoko��)
-Zaznaczenie pola "Use Seed" oraz wlepienie (lub wpisanie(dla
 zaawansowanych)) Seeda do pola tekstowego poni�ej.
Obydwie czynno�ci nale�y zatwierdzi� przyci�ni�ciem przycisku "Save", po czym mapa wygeneruje si� na nowo, z podanymi warto�ciami. 

////////////// Zawarte elementy zaliczeniowe
Obs�uga wyj�tk�w -> ConfigMenu.cs line: 79
Eventy (zdarzenia) -> np. GameButtonPress(object sender, EventArgs e) w flipper.cs
Praca z strumieniami (w tym pliki) -> ConfigMenu.cs
Interfejs Graficzny (liczony za dwa elementy)