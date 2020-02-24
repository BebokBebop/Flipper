///////////// Intro
Witam!
Nazywam siê Hubert Przegendza, a to mój program zaliczeniowy zajêæ z grupy Junior .NET PolŒl.

Pisanie go sprawi³o mi du¿o frajdy i chêtnie go w przysz³oœci ulepszê, w zwi¹zku z czym Feedback jest mile widziany :)

///////////// Nazwa i Pomys³
Ten program to gra logiczna, któr¹ nazwa³em Flipper. Pomys³ wzi¹³em ze starych gier typu Escape The Room, gdzie czêsto pojawia³a siê tego typu ³amig³ówka.

///////////// Nazewnictwo
Seed - kod s³u¿¹cy do wygenerowania planszy

///////////// Dzia³anie
>Celem Gry jest oczyszczenie planszy (ca³a plansza na bia³o).

>Klikniêcie w guzik na kwadratowej planszy spowoduje zmianê koloru (fioletowy - bia³y i na odwrót) owego guzika, guzika pod nim, nad nim i na lewo i prawo.

>Klikniêcie przycisku "Shuffle" spowoduje wygenerowanie nowej mapy i wyzerowanie iloœci ruchów.

>Klikniêcie przycisku "Reset" zresetuje mapê oraz iloœæ ruchów.

>Zaznaczenie pola "Show Solution" w³¹czy pokazywanie rozwi¹zania (które przyciski trzeba nacisn¹æ, aby oczyœciæ planszê) oraz wy³¹czy liczenie ruchów.
  
Odznaczenie tego pola wy³¹czy pokazywanie rozwi¹zania, ale ruchy dalej nie bêd¹ liczone.
Aby znowu w³¹czyæ liczenie ruchów nale¿y zrestowaæ mapê lub stworzyæ now¹.

>"Moves: [pole tekstowe]" pokazuje aktualn¹ iloœæ klikniêæ w przyciski na planszy.

>Przycisk "Copy Seed" kopiuje do schowka aktualny Seed mapy, który wypisany jest poni¿ej tego przycisku w zacieniowanym polu tekstowym.

>Zaznaczenie pola "Create Seed Mode" w³¹czy czytanie Seeda mapy na bie¿¹co tzn. ka¿de klikniêcie w guzik na planszy spowoduje wyœwietlenie siê w polu tekstowym nowego, aktualnego Seeda.

Kiedy to pole jest zaznaczone, zaznaczenie pola "Show Solution" nie wy³¹czy liczenia ruchów.

>Naciœniêcie przycisku "New Map Options" otworzy nowe okno, w którym mo¿na stworzyæ now¹ mapê.
  S¹ na to dwa sposoby:
-Podanie w dwóch polach tekstowych u góry samych wymiarów nowej
 planszy (w pierwszym szerokoœæ, w drugim wysokoœæ)
-Zaznaczenie pola "Use Seed" oraz wlepienie (lub wpisanie(dla
 zaawansowanych)) Seeda do pola tekstowego poni¿ej.
Obydwie czynnoœci nale¿y zatwierdziæ przyciœniêciem przycisku "Save", po czym mapa wygeneruje siê na nowo, z podanymi wartoœciami. 

////////////// Zawarte elementy zaliczeniowe
Obs³uga wyj¹tków -> ConfigMenu.cs line: 79
Eventy (zdarzenia) -> np. GameButtonPress(object sender, EventArgs e) w flipper.cs
Praca z strumieniami (w tym pliki) -> ConfigMenu.cs
Interfejs Graficzny (liczony za dwa elementy)