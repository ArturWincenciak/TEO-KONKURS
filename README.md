# TEO-KONKURS

## Nagroda: 0.7 Jacka i dziesięć setek Wiśniówki Lubelskiej

Tematem konkursu jest zoptymalizowanie procesu zamiany ciągu bajtów na obiekty. 

Poprzez socket z centrali telekomunikacyjnej przychodzi ciąg bajtów, który zawiera informacje o tym jakie zdarzenia wystąpiły w tej centrali. Chodzi o to aby w jak najbardziej optymalny sposób (jak najszybciej) zamienić te bajty na obiekty.

Do mierzenia wydajności wykorzystujemy DotNetBenchmark, który jest dołączony i odpowiednio skonfigurowany w projekcie.

Projekt zawiera już kilka wersji z moimi próbami optymalizacji. Podjąłem nawet próbę zarządzania pamięcią na własną rękę ale próba ta spaliła na panewkach. Osiągnąłem bardzo małe zużycie pamięci ale nie przełożyło się to na szybkość obliczeń. Czuję jednak, że da się jeszcze to lepiej zoptymalizować. Na tą chwilę nie wiem jak. Na każdego, któremu uda się poprawić wydajność, oprócz nagród rzeczowych, spadnie szacunkek ludzi naszej społeczności.

Projekt zawiera zestaw testów jednostkowych, które pilnują czy kolejne coraz to optymalniejsze wersje nadal poprawnie wykonują parsowanie.

**Wygrywa ten kto napisze najszybszą wersję parsowania. Konkurs trwa do 18-06-2017 do 23:59:59.999. Wersja uznana jest za najszybszą jeśli od poprzedniej najszybszej wersji będzie szybsza o 5% w każdym z 10 powtórzeń testu.**

## Motywacja

Niedawno natrafiłem na projekt `DotNetBenchmark`, który mnie zachwycił. Chcąc się nim pobawić wymyślałem sobie pretekst do tych zabaw - tym pretekstem jest właśnie temat tego konkursu.
 
Napisałem kilka wersji parsera eksperymentując z kodem. Robiłem niewielkie zmiany i odpalałem testy po czym sprawdzałem czy wydajność się poprawiła czy spadła. Nadal jednak jestem przekonany, że można osiągnąć większą wydajność, ale mi się już pomysły skończyły.
 
Śledząc kolejne wersje tych parserów będziecie mogli zobaczyć na żywo, na konkretnym przypadku:
- jak bardzo nie wydajny jest regex
- czy i o ile jest szybszy `switch` od `if`
- jakie metody `linq` są wolne i jak bardzo potrafią być wolne
- czy `StringBuilder` naprawdę jest szybszy od zwykłego `string`
- zarządzanie pamięcią na własną rękę tak aby `GC` miał jak najmniej pracy.
 
Będziecie mogli również zobaczyć jak się konfiguruje i odpala `DotNetBenchmark` oraz podejście do testów jednostkowych, które testują wszystkie wersje bibliotek parsera w jednym teście.
 
Na tego, któremu uda się napisać szybszą wersję parsera oprócz otrzymania nagród rzeczowych zostanie odkryty uznaniem w naszej społeczności, a ja z pewnością nauczę się czegoś nowego.

## Jak taki ciąg bajtów wygląda, jakie ma cechy? Jakie obiekty chcemy uzyskać w wyniku parsowania?

Wspomniany ciąg bajtów po zamianie na `string` wygląda przykładowo tak:
```
Event: Trying\r\n
SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n
SourceCallerID: 2222\r\n
DestinationCallerID: 5555\r\n
CallStartDate: 27/03/2017 15:34:34.281\r\n
Timestamp: 1490621674281\r\n
\r\n
Event: Dial\r\n
ActionID:\r\n
SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n
Source: 2121038905-5062-55@BJC.BGI.CA.EH\r\n
Destination: c99d694e382f2b92cdc27ca6f32a008b@10.10.10.124\r\n
SourceCallerID: 2222\r\n
DestinationCallerID: 5555\r\n
Status: New\r\n
Timestamp: 1490621675300\r\n
\r\n
Event: Ringing\r\n
SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n
SourceCallerID: 2222\r\n
DestinationCallerID: 5555\r\n
Timestamp: 1490621675932\r\n
\r\n
Event: Link\r\n
SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n
Source: 2121038905-5062-55@BJC.BGI.CA.EH\r\n
Destination: c99d694e382f2b92cdc27ca6f32a008b@10.10.10.124\r\n
SourceCallerID: 2222\r\n
DestinationCallerID: 5555\r\n
Timestamp: 1490621679681\r\n
\r\n
Event: UnLink\r\n
SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n
SoftHangupSrc: 1\r\n
SoftHangupDest: 0\r\n
Source: 2121038905-5062-55@BJC.BGI.CA.EH\r\n
Destination: c99d694e382f2b92cdc27ca6f32a008b@10.10.10.124\r\n
SourceCallerID: 2222\r\n
DestinationCallerID: 5555\r\n
Timestamp: 1490621684130\r\n
\r\n
Event: Hangup\r\n
SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n
Channel: c99d694e382f2b92cdc27ca6f32a008b@10.10.10.124\r\n
CallerID: 5555\r\n
Cause: 16\r\n
Cause-txt: DISCONNECTED\r\n
SoftHangupSrc: 0\r\n
SoftHangupDest: 1\r\n
Timestamp: 1490621684157\r\n
\r\n
Event: Hangup\r\n
SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n
Channel: 2121038905-5062-55@BJC.BGI.CA.EH\r\n
CallerID: 2222\r\n
Cause: 16\r\n
Cause-txt: DISCONNECTED\r\n
SoftHangupSrc: 1\r\n
SoftHangupDest: 0\r\n
Timestamp: 1490621684473\r\n
\r\n
Event: SessionClose\r\n
SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n
Timestamp: 1490621684574\r\n
\r\n
```

Protokół składa się więc z następujących typów wiadomości: 
- Trying, 
- Ringing, 
- Dial, 
- Hangup, 
- Hold
- Link, 
- PeerStatus, 
- UnLink, 
- SessionClose.
 
> **Przedmiotem zabaw z optymalizacją (konkursu) jest tylko jeden typ wiadomości - `Trying`. Zarówno w testach jednostkowych jak i w testach wydajności parsowana jest ramka `Trying` - inne olewamy.**
 
Cechy pojedynczego zdarzenia:
- każde zdarzenie składa się z kolekcji par: właściwość i wartość oddzielone dwukropkiem i spacją
- każda właściwość zdarzenia wraz z wartością oddzielona jest znakami: `\r\n`
- każde pojedyncze zdarzenie oddzielone jest od kolejnego znakami: `\r\n\r\n`
- kolejność właściwości i wartości w ramach pojedynczego zdarzenia zawsze jest taka sama
- zawsze na początku zdarzenia znajduje się właściwość `Event:` oraz wartość która określa jakiego typu jest to zdarzenie
 
Szczególne cechy zdarzenia Trying:
- wartości właściwości `SessionId`, `CallStartDate`, `Timestamp` mają stałą długość
- wartości właściwości `SourceCallerID` oraz `DestinationCallerID` mają zmienną długość
 
Ważną cechą jest to żę bajty spływają w losowej ilości. Pojedyncza porcja danych może zawierać tylko część zdarzenia, całe zdarzenie, całe zdarzenie i część następnego lub wiele zdarzeń. Oznacza to tyle, że należy buforować bajty do momentu aż nie otrzymamy całe poprawne zdarzenie.
 
W wyniku parsowania chcemy uzyskać instancję obiektu klasy `TryingEvent`, typu `CtiEvent`.

```c#
public abstract class CtiEvent
{
 public string SessionId { get; set; }
 public string Timestamp { get; set; }
}
 
public class TryingEvent : CtiEvent
{
 public string SourceCallerId { get; set; }
 public string DestinationCallerId { get; set; }
 public string CallStartDate { get; set; }
}
```

## Opis projektu w Visual Studio

Projekt składa się z:
- aplikacji konsolowej `Benchmark` którą odpalamy w celu wykonania testu wydajności,
- biblioteki `Common` w której zdefiniowane klasy obiektów, które chcemy uzyskać w wyniku parsowania,
- bibliotek `Parsers_v_*_*`, które zawierają kolejne moje próby implementacji parsowania,
- biblioteki `Parsers.UnitTests` z testami jednostkowymi wszystkich dotychczasowych wersji parserów zdefiniowanych w bibliotekach `Parsers_v_*_*`.

## Jak w łatwy i szybki sposób dodać własną wersję parsera?

1. Wchodzimy do głównego folderu projektu.
2. Kopiujemy folder z wybraną wersję parsera (np. `Parser_v_1_2`) i nadajemy nową nazwę temu folderowi (np. `Parser_v_5_0`).
3. Wchodzimy do folderu `Parser_v_5_0` i zmieniamy nazwę pliku projektu `Parser_v_1_2.csproj` na `Parser_v_5_0.csproj`.
4. Wracamy do Visual Studio oraz dodajemy do folderu `Parser` istniejący projekt (`Add -> Existing Projekt -> Parser_v_5_0.csproj`).
5. Odpalamy właściwości projektu `Parser_v_5_0` i zmieniamy `Assembly name` z wartości `Parser_v_1_2` na warstość `Parser_v_5_0` oraz zmieniamy `Default namespace` z wartości `v_1_2` na `v_5_0`.
6. Musimy teraz poprawić `namespace` we wszystkich plikach w projekcie `Parser_5_0`. Zamieniamy `namespace v_1_2` na `namespace v_5_0`.
7. Dodajemy referencję do biblioteki `Parser_v_5_0` w projekcie `Benchmark`.
8. Dodajemy referencję do biblioteki `Parser_v_5_0` w projekcie `Parsers.UnitTests`.
9. Nową wersję parsera (`Parser_v_5_0`) dodajemy do przypadków testowych w testach jednostkowych. Przechodzimy do klasy `TestCasesStore` oraz w tablicy `Transformators` dodajemy naszą nową wersję parsera, analogicznie jak dla innych parserów.

```c#
public class TestCasesStore
{
 public static readonly ISubject<ByteString, CtiEvent>[] Transformators = 
 {
  new v_0_1.CtiTransformator(new v_0_1.CtiParser()),
  new v_0_2.CtiTransformator(new v_0_2.CtiParser()),
  new v_0_3.CtiTransformator(new v_0_3.CtiParser()),
  new v_0_4.CtiTransformator(new v_0_4.CtiParser()),
  new v_0_5.CtiTransformator(new v_0_5.CtiParser()),
  new v_0_6.CtiTransformator(new v_0_6.CtiParser()),
  new v_0_7.CtiTransformator(new v_0_7.CtiParser()),
  new v_0_8.CtiTransformator(new v_0_8.CtiParser()),
  new v_0_9.CtiTransformator(new v_0_9.CtiParser()),
  new v_0_10.CtiTransformator(new v_0_10.CtiParser()),
  new v_0_11.CtiTransformator(new v_0_11.CtiParser()),
  new v_0_12.CtiTransformator(new v_0_12.CtiParser()),
  new v_1_1.CtiTransformator(new v_1_1.ByteBuffer(), new v_1_1.CtiParser()),
  new v_1_2.CtiTransformator(new v_1_2.ByteBuffer(), new v_1_2.CtiParser()),
  new v_2_0.CtiTransformator(),
  new v_3_0.CtiTransformator(new v_3_0.ByteBuffer(), new v_3_0.CtiParser()),
  new v_4_0.CtiTransformator(new v_4_0.ByteBuffer(), new v_4_0.CtiParser()),
  new v_4_1.CtiTransformator(new v_4_1.ByteBuffer(), new v_4_1.CtiParser()),
  new v_4_2.CtiTransformator(new v_4_2.ByteBuffer(), new v_4_2.CtiParser()),
  new v_5_0.CtiTransformator(new v_5_0.ByteBuffer(), new v_5_0.CtiParser()), // <- the new
 };
 // ...
}
```
10. Odpalamy testy jednostkowe. Wszystko powinno być zielone. Od tego momentu możemy modyfikować naszą nową wersję parsera i sprawdzać czy testy nadal są zielone.
11. Dodajemy naszą nową wersję parsera do testów wydajności. Otwieramy klasę `CtiTransformatorTester` i dodajemy nową prywatną właściwość analogicznie jak dla innych wersji parsera.
```c#
public class CtiTransformatorTester
{
 private static int iterationsCount;
 private static ByteString[] input;
 private static NullCtiEventConsumer consumer;

 private static v_0_1.CtiTransformator v_0_1_transformator;
 private static v_0_2.CtiTransformator v_0_2_transformator;
 private static v_0_3.CtiTransformator v_0_3_transformator;
 private static v_0_4.CtiTransformator v_0_4_transformator;
 private static v_0_5.CtiTransformator v_0_5_transformator;
 private static v_0_6.CtiTransformator v_0_6_transformator;
 private static v_0_7.CtiTransformator v_0_7_transformator;
 private static v_0_8.CtiTransformator v_0_8_transformator;
 private static v_0_9.CtiTransformator v_0_9_transformator;
 private static v_0_10.CtiTransformator v_0_10_transformator;
 private static v_0_11.CtiTransformator v_0_11_transformator;
 private static v_0_12.CtiTransformator v_0_12_transformator;
 private static v_1_1.CtiTransformator v_1_1_transformator;
 private static v_1_2.CtiTransformator v_1_2_transformator;
 private static v_2_0.CtiTransformator v_2_0_transformator;
 private static v_3_0.CtiTransformator v_3_0_transformator;
 private static v_4_0.CtiTransformator v_4_0_transformator;
 private static v_4_1.CtiTransformator v_4_1_transformator;
 private static v_4_2.CtiTransformator v_4_2_transformator;
 private static v_5_0.CtiTransformator v_5_0_transformator; // <- the new
 // ...
}
```
12. W metodzie `SetupData` w klasie `CtiTransformatorTester' tworzymy instancję naszego parsera analogicznie jak dla innych wersji parsera.
```c#
[Setup]
public void SetupData()
{
 iterationsCount = 1000;
 input = new[]
 {
  oneEventInOnePart,
  oneEventInTwoParts[0],
  oneEventInTwoParts[1],
  twoEventsInOnePart,
  oneEventInThreeParts[0],
  oneEventInThreeParts[1],
  oneEventInThreeParts[2]
 };

 consumer = new NullCtiEventConsumer();

 v_0_1_transformator = new v_0_1.CtiTransformator(new v_0_1.CtiParser());
 v_0_1_transformator.Subscribe(consumer);

 v_0_2_transformator = new v_0_2.CtiTransformator(new v_0_2.CtiParser());
 v_0_2_transformator.Subscribe(consumer);

 v_0_3_transformator = new v_0_3.CtiTransformator(new v_0_3.CtiParser());
 v_0_3_transformator.Subscribe(consumer);

 v_0_4_transformator = new v_0_4.CtiTransformator(new v_0_4.CtiParser());
 v_0_4_transformator.Subscribe(consumer);

 v_0_5_transformator = new v_0_5.CtiTransformator(new v_0_5.CtiParser());
 v_0_5_transformator.Subscribe(consumer);

 v_0_6_transformator = new v_0_6.CtiTransformator(new v_0_6.CtiParser());
 v_0_6_transformator.Subscribe(consumer);

 v_0_7_transformator = new v_0_7.CtiTransformator(new v_0_7.CtiParser());
 v_0_7_transformator.Subscribe(consumer);

 v_0_8_transformator = new v_0_8.CtiTransformator(new v_0_8.CtiParser());
 v_0_8_transformator.Subscribe(consumer);

 v_0_9_transformator = new v_0_9.CtiTransformator(new v_0_9.CtiParser());
 v_0_9_transformator.Subscribe(consumer);

 v_0_10_transformator = new v_0_10.CtiTransformator(new v_0_10.CtiParser());
 v_0_10_transformator.Subscribe(consumer);

 v_0_11_transformator = new v_0_11.CtiTransformator(new v_0_11.CtiParser());
 v_0_11_transformator.Subscribe(consumer);

 v_0_12_transformator = new v_0_12.CtiTransformator(new v_0_12.CtiParser());
 v_0_12_transformator.Subscribe(consumer);

 v_1_1_transformator = new v_1_1.CtiTransformator(new v_1_1.ByteBuffer(), new v_1_1.CtiParser());
 v_1_1_transformator.Subscribe(consumer);

 v_1_2_transformator = new v_1_2.CtiTransformator(new v_1_2.ByteBuffer(), new v_1_2.CtiParser());
 v_1_2_transformator.Subscribe(consumer);

 v_2_0_transformator = new v_2_0.CtiTransformator();
 v_2_0_transformator.Subscribe(consumer);

 v_3_0_transformator = new v_3_0.CtiTransformator(new v_3_0.ByteBuffer(), new v_3_0.CtiParser());
 v_3_0_transformator.Subscribe(consumer);

 v_4_0_transformator = new v_4_0.CtiTransformator(new v_4_0.ByteBuffer(), new v_4_0.CtiParser());
 v_4_0_transformator.Subscribe(consumer);

 v_4_1_transformator = new v_4_1.CtiTransformator(new v_4_1.ByteBuffer(), new v_4_1.CtiParser());
 v_4_1_transformator.Subscribe(consumer);

 v_4_2_transformator = new v_4_2.CtiTransformator(new v_4_2.ByteBuffer(), new v_4_2.CtiParser());
 v_4_2_transformator.Subscribe(consumer);

 v_5_0_transformator = new v_5_0.CtiTransformator(new v_5_0.ByteBuffer(), new v_5_0.CtiParser()); // <- the new
 v_5_0_transformator.Subscribe(consumer); // <- the new
}
```
13. W klasie `CtiTransformatorTester' definiujemy nową metodę, która będzie nowym przypadkiem testowym dla testów wydajności analogicznie jak dla innych wersji parsera.
```c#
[Benchmark]
public static void Test_v_5_0_transformator()
{
 for (int i = 0; i < iterationsCount; i++)
 {
  foreach (ByteString inp in input)
  {
   v_5_0_transformator.OnNext(inp);
  }
 }
}
```
14. Dokonujemy optymalizacji w naszej nowej wersji parsera. Gdy jesteśmy pewni, że jest szybciej kompilujemy projekt w trybie `release`, odpalamy aplikacje konsolową będącą wynikiem kompilacji projektu `Benchmark` i sprawdzamy wyniki. 
15. Wyniki pojawiają się w folderze `.\TeoVincentParser\Benchmark\bin\Release\BenchmarkDotNet.Artifacts\results`.
16. Jeśli chcemy odpalić te same testy wiele razy, odejść od komputera i wrócić po wyników za kilka godzin, to jest to możliwe ponieważ  wyniki testów są kopiowane do folderu z historią wyników `.\TeoVincentParser\Benchmark\bin\Release\TestResultsHistory`. Wystarczy w metodzie `Main` w klasie `Program` ustawić odpowiednią wartość w pętli (np: `for (int i = 0; i < 10; i++)`).

## Interfejs parsera

//TODO ...

## Dotychczasowe wyniki

**Obecnie najszybszą wersja parsera jest `Parser_v_1_2`. Tą wersję (do póki nie pojawi się szybsza) należy traktować jako wzorcową podczas porównywania z własnymi wynikami.** 

Wersję tą można skopiować i optymalizować, lub wogóle tam nie zaglądać aby się nie niepotrzebnie inspirować tym rozwiązaniem.

> Tak się składa, że równocześnie wersja ta w bardzo fajny sposób enkapsuluje odpowiedzialności w klasach - jest zarazem wydajnie i SOLID. Można tutaj zauważyć podejście reaktywne, w którym mamy nieskończoną kolekcję danych, które przepływając przez ByteBuffer oraz CtiParser tranformują do innej nieskończonej kolekcji danych.

> Muszę dodać że może pojawić się lepsza wersja - czego sobie i Wam życzę. Będzie ekstra setka wiśniówki za taką implementację.

Poniżej tabela z testów kolejnych wersji. 

> To są przykładowe wyniki. Więcej wyników znajdziecie we wspomnianej historii wyników.

Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_0_1_transformator | 37.452 ms | 0.6758 ms | 0.5644 ms | 37.193 ms | 1.00 | 4946.4286 | 16.31 MB
Test_v_0_2_transformator | 11.333 ms | 0.1685 ms | 0.1576 ms | 11.258 ms | 0.30 | 2417.7083 | 7.69 MB
Test_v_0_3_transformator	| 9.865 ms	| 0.0744 ms	| 0.0696 ms	| 9.853 ms	| 0.26	| 1835.4167	| 5.91 MB
Test_v_0_4_transformator	| 9.834 ms	| 0.0937 ms	| 0.0876 ms	| 9.806 ms	| 0.26	| 1843.75	| 5.91 MB
Test_v_0_5_transformator	| 5.602 ms	| 0.1288 ms	| 0.1378 ms	| 5.541 ms	| 0.15	| 1554.1667	| 4.88 MB
Test_v_0_6_transformator	| 5.172 ms	| 0.0941 ms	| 0.0786 ms	| 5.149 ms	| 0.14	| 2018.75	| 6.29 MB
Test_v_0_7_transformator	| 3.780 ms	| 0.0101 ms	| 0.0090 ms	| 3.781 ms	| 0.1	| 1992.7083	| 6.1 MB
Test_v_0_8_transformator	| 3.306 ms	| 0.0317 ms	| 0.0281 ms	| 3.297 ms	| 0.09	| 1403.9063	| 4.33 MB
Test_v_0_9_transformator	| 2.445 ms	| 0.0088 ms	| 0.0063 ms	| 2.446 ms	| 0.07	| 1430.1031	| 4.33 MB
Test_v_0_10_transformator	| 2.513 ms	| 0.0562 ms	| 0.1479 ms	| 2.432 ms	| 0.07	| 1401.8229	| 4.33 MB
Test_v_0_11_transformator	| 2.715 ms	| 0.0788 ms	| 0.2322 ms	| 2.671 ms	| 0.07	| 1434.5815	| 4.33 MB
Test_v_0_12_transformator	| 2.552 ms	| 0.0116 ms	| 0.0097 ms	| 2.552 ms	| 0.07	| 1518.75	| 4.69 MB
Test_v_1_1_transformator	| 2.445 ms	| 0.0641 ms	| 0.1250 ms	| 2.387 ms	| 0.07	| 1401.8229	| 4.33 MB
**Test_v_1_2_transformator**	| **2.425 ms**	| **0.0472 ms**	| **0.0442 ms**	| **2.411 ms**	| **0.06**	| **1401.8229**	| **4.33 MB**
Test_v_2_0_transformator	| 3.019 ms	| 0.0598 ms	| 0.1093 ms	| 2.966 ms	| 0.08	| 1409.3339	| 4.33 MB
Test_v_3_0_transformator	| 3.426 ms	| 0.0382 ms	| 0.0357 ms	| 3.413 ms	| 0.09	| 1108.8542	| 3.46 MB
Test_v_4_0_transformator	| 4.965 ms	| 0.0165 ms	| 0.0137 ms	| 4.963 ms	| 0.13	| 932.8125	| 3.04 MB
Test_v_4_1_transformator	| 5.408 ms	| 0.1041 ms	| 0.1198 ms	| 5.428 ms	| 0.14	| 939.0625	| 3.04 MB
Test_v_4_2_transformator	| 3.911 ms	| 0.0166 ms	| 0.0155 ms	| 3.909 ms	| 0.1	| 742.7083	| 2.35 MB


