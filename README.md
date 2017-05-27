# TEO-KONKURS
 
## Nagroda: 0.7 Jacka i dziesięć setek Wiśniówki Lubelskiej
 
Tematem konkursu jest zoptymalizowanie procesu zamiany ciągu bajtów na obiekty. 
 
Poprzez socket z centrali telekomunikacyjnej przychodzi ciąg bajtów, który zawiera informacje o tym jakie zdarzenia wystąpiły w tej centrali. Chodzi o to aby w jak najbardziej optymalny sposób (jak najszybciej) zamienić te bajty na obiekty.
 
Do mierzenia wydajności wykorzystujemy DotNetBenchmark, który jest dołączony i odpowiednio skonfigurowany w projekcie.
 
Projekt zawiera już kilka wersji z moimi próbami optymalizacji. Podjąłem nawet próbę zarządzania pamięcią na własną rękę ale próba ta spaliła na panewkach. Osiągnąłem bardzo małe zużycie pamięci ale nie przełożyło się to na szybkość obliczeń. Czuję jednak, że da się jeszcze to lepiej zoptymalizować. Na tą chwilę nie wiem jak. Na każdego, któremu uda się poprawić wydajność, oprócz nagród rzeczowych, spadnie szacunek ludzi naszej społeczności.
 
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
 
> Obecny poziom wydajności dla projektu produkcyjnego już dawno jest zadowalający. Tutaj dalsze optymalizacji mają charakter rozrywki.
 
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
5. Odpalamy właściwości projektu `Parser_v_5_0` i zmieniamy `Assembly name` z wartości `Parser_v_1_2` na wartość `Parser_v_5_0` oraz zmieniamy `Default namespace` z wartości `v_1_2` na `v_5_0`.
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
14. Dokonujemy optymalizacji w naszej nowej wersji parsera. Gdy jesteśmy pewni, że jest szybciej kompilujemy projekt w trybie `release`, odpalamy aplikację konsolową będącą wynikiem kompilacji projektu `Benchmark` i sprawdzamy wyniki. 
15. Wyniki pojawiają się w folderze `.\TeoVincentParser\Benchmark\bin\Release\BenchmarkDotNet.Artifacts\results`.
16. Jeśli chcemy odpalić te same testy wiele razy, odejść od komputera i wrócić po wyników za kilka godzin, to jest to możliwe ponieważ  wyniki testów są kopiowane do folderu z historią wyników `.\TeoVincentParser\Benchmark\bin\Release\TestResultsHistory`. Wystarczy w metodzie `Main` w klasie `Program` ustawić odpowiednią wartość w pętli (np: `for (int i = 0; i < 10; i++)`).
 
## Interfejs parsera
 
//TODO ...
 
## Dotychczasowe wyniki
 
Obecnie najszybszą wersja parsera jest `Parser_v_1_2`. Tą wersję (dopóki nie pojawi się szybsza) należy traktować jako wzorcową podczas porównywania z własnymi wynikami. Wersję tą można skopiować i optymalizować, lub wogóle tam nie zaglądać aby się nie niepotrzebnie inspirować tym rozwiązaniem.
 
> Tak się składa, że równocześnie wersja ta w bardzo fajny sposób enkapsuluje odpowiedzialności w klasach - jest zarazem wydajnie i SOLID. Można tutaj zauważyć podejście reaktywne, w którym mamy nieskończoną kolekcję danych, które przepływając przez ByteBuffer oraz CtiParser transformują do innej nieskończonej kolekcji danych.
 
> Muszę dodać że może pojawić się lepsza wersja - czego sobie i Wam życzę. Będzie ekstra setka wiśniówki za taką implementację.
 
Poniżej tabela z testów kolejnych wersji. 
 
> To są przykładowe wyniki. Więcej wyników znajdziecie we wspomnianej historii wyników.

```
BenchmarkDotNet=v0.10.5, OS=Windows 10.0.15063
Processor=Intel Core i7-4710MQ CPU 2.50GHz (Haswell), ProcessorCount=8
Frequency=2435781 Hz, Resolution=410.5459 ns, Timer=TSC
  [Host]            : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2098.0
  LegacyJit-Clr-X86 : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2098.0
Job=LegacyJit-Clr-X86  Jit=LegacyJit  Platform=X86  
Runtime=Clr 
```
 
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
 
## Opis kolejnych wersji parsera
 
Z pierwszej wersji nie jestem zbytnio dumny. Jest to pierwsza wersja, która uknuła mi się w głowie, którą byłem wstanie bardzo szybko zaimplementować. Wersja ta ma wiele błędów pod względem wydajności i nie tylko. Implementując kolejne wersje sukcesywnie ulepszyłem te wersje mając przy tym dużą frajdę z uruchamiania `DotNetBenchmarka`.
 
O.K. To po tym wstępie zaczynamy. Przechodzimy do projektu `Parser_v_0_1`.
 
### Parser_v_0_1
 
Klasa, która wykonuje buforowanie i parsowanie to klasa `CtiTransformator`. Klas ta spełnia interfejs `ISubject<ByteString, CtiEvent>` co oznacza że jest obserwatorem oraz klasą obserwowaną. Obserwuje pojawienie się nowej porcji danych w postaci obiektu `ByteString` i równocześnie posiada obserwatora, któremu przekazuje kolejno parsowane obiekty `CtiEvent`. Czyli jest to taka transformacja jednej nieskończonej kolekcji danych na inną nieskończoną kolekcję danych.
 
Implementacja metody `OnNext` jest silnikiem tej klasy. Na początku zapamiętuje nowe dane dodając je do już zapamiętanych podczas poprzednich wywołań tej metody. Następnie w pętli `while(true)`, w jest wykonywane parsowanie kolejnych porcji bajtów tak długo jak długo w tych bajtach znajdują się poprawne całe porcje wiadomości umożliwiające wygenerowanie nowego obiekty typu `CtiEvent`. W każdym obiegu pętli jest sprawdzane czy odnaleziono ciąg znaków `\r\n\r\n` oznaczający koniec wiadomości. Sprawdzanie to odbywa się w linii `if (TryGetLastIndexOfEvent(out lastIndex))`. 
 
Następnie wywoływana jest metoda `Parse` na obiekcie `eventParser`. Wynik zwrócony z tej metody przekazywany jest obserwatorowi po czym następuje czyszczenie bufora z bajtów, które zostały przed momentem parsowane.
 
W metodzie `Parse` klasy `CtiParser` mamy kolejne testy `if`, które wybierają jakiego typu zdarzenie należy prasować oraz dokonują tego parsowania. Parsowanie wykonywane jest za pomocą metody prywatnej `Parse`, której podajemy nazwę właściwości (`string`) oraz wartość (`string`), która będzie parsowana. Jako wynik zwraca wartość danej właściwości odszukanej w tym stringu.
 
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_0_1_transformator | 37.452 ms | 0.6758 ms | 0.5644 ms | 37.193 ms | 1.00 | 4946.4286 | 16.31 MB
 
### Parser_v_0_2
 
W kolejnej wersji, klasie `Parser` zamieniłem wyrażenia regularne na zwykłe porównanie obiektów typu `string`. 
 
Było:
```#
if (Regex.IsMatch(input, $@"\A{CtiProtocol.PropertyType.EVENT}: {CtiProtocol.EventType.SESSION_CLOSE}")) 
{ 
 //...
}
```
Teraz jest:
```c#
if (firstLine == CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.DIAL)
{ 
 //...
}
```
 
Ten prosty zabieg pozwolił poprawić wydajność kilkukrotnie. Nie wiem co mnie podkusiło żeby użyć `regex` ale tutaj widać jak one są wolne.
 
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_0_2_transformator | 11.333 ms | 0.1685 ms | 0.1576 ms | 11.258 ms | 0.30 | 2417.7083 | 7.69 MB
 
### Parser_v_0_3
 
W kolejnej wersji zamieniłem `if`’y na switch’a. Teraz jest:
 
```c#
switch (firstLine)
{
 case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.DIAL:
 { 
  //...
 }
}
```
 
Wynik kolejnego testu mówi, że faktycznie `switch` jest szybszy.
 
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_0_3_transformator	| 9.865 ms	| 0.0744 ms	| 0.0696 ms	| 9.853 ms	| 0.26	| 1835.4167	| 5.91 MB
 
### Parser_v_0_4
 
W tej wersji względem poprzedniej postanowiłem się upewnić czy zmiana kolejności `case` w `switch` nie ma znaczenia :). Stwierdzam że nie.
 
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_0_4_transformator	| 9.834 ms	| 0.0937 ms	| 0.0876 ms	| 9.806 ms	| 0.26	| 1843.75	| 5.91 MB
 
### Parser_v_0_5
 
W tej wersji zrezygnowałem z prywatnej metody `private static string Parse(string input, string valueType)` w klasie `CtiParser`. Metoda ta miała tą zaletę, że mogła być wykorzystana do dowolnego typu wiadomości jednak była niewydajna. Napisałem nowę wersję `private CtiEvent ParseTryingEvent(string input)`, która wykorzystuje specyficzne cechy wiadomości typu `Trying`. Jedna z głównych różnic jest taka, że w tej metodzie tylko raz iteruję się przez cały `string`, a nie za każdym razem, dla każdej właściwości z osobna - jak to miało w wersji poprzedniej.
 
Było:
```c#
private static string Parse(string input, string valueType)
{
    int firstIndexOfType = input.IndexOf(valueType + ":", StringComparison.Ordinal);
    if (firstIndexOfType == -1)
    {
        return string.Empty;
    }
 
    int lastIndexOfType = firstIndexOfType + valueType.Length;
    int firstIndexOfValue = lastIndexOfType + 2;
    int lastIndexOfValue = input.IndexOf(value: '\r', startIndex: firstIndexOfValue);
    int lengthOfValue = lastIndexOfValue - firstIndexOfValue;
    string result = input.Substring(firstIndexOfValue, lengthOfValue);
    return result;
}
```
Teraz jest:
```c#
private CtiEvent ParseTryingEvent(string input)
{
    TryingEvent e = new TryingEvent();
 
    int idx = CtiProtocol.FIRST_TRYING_LINE_LEN + CtiProtocol.SESSION_ID_PROP_LEN + CtiProtocol.COLON_AND_SPACE_LEN;
    int limit = idx + CtiProtocol.SESSION_ID_VALU_LEN;
    e.SessionId = input.Substring(idx, CtiProtocol.SESSION_ID_VALU_LEN);
 
    idx = limit + CtiProtocol.END_LINE_LEN + CtiProtocol.SOURCE_CALLER_ID_PROP_LEN + CtiProtocol.COLON_AND_SPACE_LEN;
    for (int i = idx; ; i++)
    {
        if (input[i + 1] == CtiProtocol.CARRIAGE_RETURN && input[i + 2] == CtiProtocol.LINE_FEED)
        {
            e.SourceCallerId = input.Substring(idx, i - idx + 1);
            idx = i;
            break;
        }
    }
 
    idx += CtiProtocol.END_LINE_LEN + CtiProtocol.DESTINATION_CALLER_ID_PROP_LEN + CtiProtocol.COLON_AND_SPACE_LEN + 1;
    for (int i = idx; ; i++)
    {
        if (input[i + 1] == CtiProtocol.CARRIAGE_RETURN && input[i + 2] == CtiProtocol.LINE_FEED)
        {
            e.DestinationCallerId = input.Substring(idx, i - idx + 1);
            idx = i;
            break;
        }
    }
 
    idx += CtiProtocol.END_LINE_LEN + CtiProtocol.CALL_START_DATE_PROP_LEN + CtiProtocol.COLON_AND_SPACE_LEN + 1;
    limit = idx + CtiProtocol.CALL_START_DATE_VALU_LEN;
    e.CallStartDate = input.Substring(idx, limit - idx);
 
    idx = limit + CtiProtocol.END_LINE_LEN + CtiProtocol.TIMESTAMP_PROP_LEN + CtiProtocol.COLON_AND_SPACE_LEN;
    limit = idx + CtiProtocol.TIMESTAMP_VALU_LEN;
    e.Timestamp = input.Substring(idx, limit - idx);
 
    return e;
}
```
 
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_0_5_transformator	| 5.602 ms	| 0.1288 ms	| 0.1378 ms	| 5.541 ms	| 0.15	| 1554.1667	| 4.88 MB
 
### Parser_v_0_6
 
Tym razem optymalizacji podałem klasę `CtiTransformator`. Z profilowania aplikacji za pomocą `dotTrace` wyszło mi, że bardzo wolna jest metoda `TryGetLastIndexOfEvent`, a dokłądnie najwolniejszą jest linijka `endOfEventIndex = buffer.IndexOf(CtiProtocol.DELIMITER, StringComparison.Ordinal)`.
```c#
private bool TryGetLastIndexOfEvent(out int endOfEventIndex)
{
    endOfEventIndex = buffer.IndexOf(CtiProtocol.DELIMITER, StringComparison.Ordinal);
    if (endOfEventIndex == -1)
    {
        return false;
    }
 
    endOfEventIndex += CtiProtocol.DELIMITER.Length;
    return true;
}
```
Napisałem więc własną wersję znadowania ciągu znaków `CtiProtocol.DELIMITER` iterując się po obiekcie `string` za pomocą pętli `for`. Teraz jest:
```c#
private int FindDelimiter()
{
    for (int i = 0; i < buffer.Length - 3; i++)
    {
        if (buffer[i] == CtiProtocol.CARRIAGE_RETURN &&
            buffer[i + 1] == CtiProtocol.LINE_FEED &&
            buffer[i + 2] == CtiProtocol.CARRIAGE_RETURN &&
            buffer[i + 3] == CtiProtocol.LINE_FEED)
        {
            return i;
        }
    }
 
    return -1;
}
```
 
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_0_6_transformator	| 5.172 ms	| 0.0941 ms	| 0.0786 ms	| 5.149 ms	| 0.14	| 2018.75	| 6.29 MB
 
### Parser_v_0_7
 
W tej wersji na w klasie `CtiParser` na początku metody `public CtiEvent Parse(string input)` pozbyłem się tych dwóch linijek kodu:
```c#
int endOfFirstLineIndex = input.IndexOf(CtiProtocol.ENDL, StringComparison.Ordinal);
string firstLine = input.Substring(0, endOfFirstLineIndex);
```
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_0_7_transformator	| 3.780 ms	| 0.0101 ms	| 0.0090 ms	| 3.781 ms	| 0.1	| 1992.7083	| 6.1 MB
 
### Parser_v_0_8
 
W tej wersji w klasie `CtiTransformator`, w metodzie `public void OnNext(ByteString value)` pozbyłem się linijki kodu która nic nie wnosiła po za tym, że zżerała zasoby procesora:
 
```c#
string inputEvent = buffer.Substring(0, delimiterIdx + 2);
```
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_0_8_transformator	| 3.306 ms	| 0.0317 ms	| 0.0281 ms	| 3.297 ms	| 0.09	| 1403.9063	| 4.33 MB
 
### Parser_v_0_9
 
W tej wersji optymalizacji poddałem metodę `private int FindDelimiter()` w klasie `CtiTransformator`. Zmniejszyłem czterokrotnie ilość iteracji w pętli `for` wykorzystując specyficzną cechę ciągu znaków `\r\n\r\n` będących delimiterem. Wystarczy iterować co cztery i będziemy mieć pewność, że trafimy na ten delimiter.
 
Było:
```c#
private int FindDelimiter()
{
    for (int i = 0; i < buffer.Length - 3; i++)
    {
        if (buffer[i] == CtiProtocol.CARRIAGE_RETURN &&
            buffer[i + 1] == CtiProtocol.LINE_FEED &&
            buffer[i + 2] == CtiProtocol.CARRIAGE_RETURN &&
            buffer[i + 3] == CtiProtocol.LINE_FEED)
        {
            return i;
        }
    }
 
    return -1;
}
```
Teraz jest:
```c#
private int FindDelimiter()
{
    int bufferLength = buffer.Length;
    for (int i = 0; i < bufferLength - 2; i += 4)
    {
        switch (buffer[i])
        {
            case CtiProtocol.CARRIAGE_RETURN:
            {
                if (buffer[i + CtiProtocol.SHIFT_FOR_DELIMITER] == CtiProtocol.CARRIAGE_RETURN && bufferLength > i + 3)
                {
                    return i;
                }
                if (buffer[i - CtiProtocol.SHIFT_FOR_DELIMITER] == CtiProtocol.CARRIAGE_RETURN && bufferLength > i + 3)
                {
                    return i - 2;
                }
                break;
            }
            case CtiProtocol.LINE_FEED:
            {
                if (buffer[i + CtiProtocol.SHIFT_FOR_DELIMITER] == CtiProtocol.LINE_FEED)
                {
                    return i - 1;
                }
                if (buffer[i - CtiProtocol.SHIFT_FOR_DELIMITER] == CtiProtocol.LINE_FEED)
                {
                    return i - 3;
                }
                break;
            }
        }
    }
 
    return -1;
}
```
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_0_9_transformator	| 2.445 ms	| 0.0088 ms	| 0.0063 ms	| 2.446 ms	| 0.07	| 1430.1031	| 4.33 MB
 
### Parser_v_0_10
 
Zastosowałem ten sam typ optymalizacji co w wersji poprzedniej (`Parser_v_0_9`) ale tym razem w metodzie `private CtiEvent ParseTryingEvent(string input)` klasy `CtiParser`.
 
Było:
```c#
private CtiEvent ParseTryingEvent(string input)
{
    // ...
    for (int i = idx; ; i++)
    {
        if (input[i + 1] == CtiProtocol.CARRIAGE_RETURN && input[i + 2] == CtiProtocol.LINE_FEED)
        {
            e.DestinationCallerId = input.Substring(idx, i - idx + 1);
            idx = i;
            break;
        }
    }
    // ...
}
```
Teraz jest:
```c#
private CtiEvent ParseTryingEvent(string input)
{
    // ...
    for (int i = idx; ; i += 2)
    {
        switch (input[i])
        {
            case CtiProtocol.CARRIAGE_RETURN:
            {
                e.SourceCallerId = input.Substring(idx, i - idx);
                idx = i - 1;
                goto LEAVE_FOR_1;
            }
            case CtiProtocol.LINE_FEED:
            {
                e.SourceCallerId = input.Substring(idx, i - idx - 1);
                idx = i - 2;
                goto LEAVE_FOR_1;
            }
        }
    }
 
LEAVE_FOR_1:
    // ...
}
```
 
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_0_10_transformator	| 2.513 ms	| 0.0562 ms	| 0.1479 ms	| 2.432 ms	| 0.07	| 1401.8229	| 4.33 MB
 
### Parser_v_0_11
 
Tutaj zamieniłem obiekty typu `char` na `byte` w klasie `CtiProtocol`.
 
Było:
```c#
public static class CtiProtocol
{
    public const char T = 'T';
    public const char R = 'R';
    public const char D = 'D';
    public const char H = 'H';
    public const char a = 'a';
    public const char o = 'o';
    public const char L = 'L';
    public const char P = 'P';
    public const char U = 'U';
    public const char S = 'S';
    // ...
}
```
 
Teraz jest:
```c#
public static class CtiProtocol
{
    public const byte T = 84;
    public const byte R = 82;
    public const byte D = 68;
    public const byte H = 72;
    public const byte a = 97;
    public const byte o = 111;
    public const byte L = 76;
    public const byte P = 80;
    public const byte U = 85;
    public const byte S = 83;
    // ...
}
```
Wydajność się nie poprawiła - jak widać.
 
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_0_11_transformator	| 2.715 ms	| 0.0788 ms	| 0.2322 ms	| 2.671 ms	| 0.07	| 1434.5815	| 4.33 MB
 
### Parser_v_0_12
 
W tej wersji postanowiłem w klasie `CtiParser` w metodzie `private CtiEvent ParseTryingEvent(string input)` wydzielić kod w celu ponownego użycia (bez straty na wydajności).
 
Ta nowa metoda to:
```c#
private static int WithEndLineFound(int idx, string input, Action<string> onFoundPropertyValue)
{
    for (int i = idx; ; i += 2)
    {
        switch ((byte)input[i])
        {
            case CtiProtocol.CARRIAGE_RETURN:
                {
                    onFoundPropertyValue(input.Substring(idx, i - idx));
                    idx = i - 1;
                    goto LEAVE_FOR_1;
                }
            case CtiProtocol.LINE_FEED:
                {
                    onFoundPropertyValue(input.Substring(idx, i - idx - 1));
                    idx = i - 2;
                    goto LEAVE_FOR_1;
                }
        }
    }
 
LEAVE_FOR_1:
    return idx;
}
```
Jej użycie jest w metodzie: `ParseTryingEvent` co jak sądze zwiększyło czytelność tej metody. Teraz ona wygląda tak:
```c#
private CtiEvent ParseTryingEvent(string input)
{
    TryingEvent e = new TryingEvent();
 
    e.SessionId = input.Substring(CtiProtocol.SESSION_ID_IDX_SHIFT, CtiProtocol.SESSION_ID_VALU_LEN);
 
    int idx = WithEndLineFound(CtiProtocol.SOURCE_CALLER_ID_IDX_SHIFT, input, value => e.SourceCallerId = value);
    idx = WithEndLineFound(idx += CtiProtocol.DESTINATION_CALLER_ID_SHIFT, input, value => e.DestinationCallerId = value);
 
    idx += CtiProtocol.CALL_START_DATE_SHIFT;
    int limit = idx + CtiProtocol.CALL_START_DATE_VALU_LEN;
    e.CallStartDate = input.Substring(idx, limit - idx);
 
    idx = limit + CtiProtocol.TIMESTAMP_SHIFT;
    limit = idx + CtiProtocol.TIMESTAMP_VALU_LEN;
    e.Timestamp = input.Substring(idx, limit - idx);
 
    return e;
}
```
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_0_12_transformator	| 2.552 ms	| 0.0116 ms	| 0.0097 ms	| 2.552 ms	| 0.07	| 1518.75	| 4.69 MB
 
### Parser_v_1_1 & Parser_v_1_2
 
Są to dwie najszybsze wersje. Są identyczne. W wersji `v_1_2` jest dodane łapanie wyjątków co w ogóle nie wpływa na wydajność dopóki wyjątki się nie pojawiają. 
 
Wersja ta posiada oddzielone odpowiedzialności związane z buforowaniem oraz parsowaniem. Interfejs `ICtiParser` zastopiłem interfejsem `ISubject<string, CtiEvent>`. Uzyskałem dzięki temu efekt przepływania danych, które w trakcie tego przepływu zmieniają się na inny, oczekiwany ciąg danych.
 
Klasa `ByteBuffer` nasłuchuje kolejnych porcji danych, które przychodzą z socket. Gdy ten `ByteBuffer` uzbiera odpowiednią porcję danych powiadamia o tym `Parser`a, który nasłuchuje kolejnych elementów, które `ByteBuffer` wyprodukuje. `Parser` dokonuje zamiany obiektów `string` na `CtiEvent` i powiadamia swojego obserwatora o pojawieniu się kolejnego elementu. Tym kolejnym elementem jest ten nasz oczekiwany wynik parsowania.
 
Co ciekawe wraz z poprawą czytelności oraz odseparowaniem odpowiedzialności wzrosła również wydajność.
 
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_1_1_transformator	| 2.445 ms	| 0.0641 ms	| 0.1250 ms	| 2.387 ms	| 0.07	| 1401.8229	| 4.33 MB
Test_v_1_2_transformator	| 2.425 ms	| 0.0472 ms	| 0.0442 ms	| 2.411 ms	| 0.06	| 1401.8229	| 4.33 MB
 
### Parser_v_2_0
 
W tej wersji dokonałem karkołomnego wyczynu - z-inlajnowałem cały algorytm do jednej metody. Po prostu sieka jakaś - przy tym nie uzyskałem poprawy wydajności.
 
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_2_0_transformator	| 3.019 ms	| 0.0598 ms	| 0.1093 ms	| 2.966 ms	| 0.08	| 1409.3339	| 4.33 MB
 
### Parser_v_3_0
 
Wersja ta jest praktycznie identyczna z wersją Parser_1_2. Różnica tkwi w tym, że zamiast używać zwykłego gołego obiektu typu `string` do użyłem `StringBuilder`. Naczytałem się, że w tego typu sytuacjach `StringBuilder` jest szybszy od `string` więc powiedziałem - sprawdzam. Okazało się, że wcale szybszy nie jest. Zużywa mniej pamięci ale szybszy nie jest. To nie jest pierwsza sytuacja gdy sprawdziłem czy na pewno jest szybszy i kolejny raz mi wyszło, że nie. 
 
Jeśli ktoś to potrafi wytłumaczyć to dostaje jedną setkę wiśniówki ode mnie.
 
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_3_0_transformator	| 3.426 ms	| 0.0382 ms	| 0.0357 ms	| 3.413 ms	| 0.09	| 1108.8542	| 3.46 MB
 
### Parser_v_4_0 & Parser_v_4_1 & Parser_v_4_2
 
W tej wersji na własną rękę postanowiłem zarządzać pamięcią aby zmniejszyć ilość pracy jaką musi wykonać GC. W tej wersji jest Najmniej alokowanej pamięci ze wszystkich wersji ale czas wykonania jest dużo większy. 
 
Jeśli ktoś pociągnie ten koncept i doprowadzi do takiego stanu, że uzyska najlepszy wynik to otrzyma dodatkowo setkę wiśniówki.
 
Method | Mean | Error | StdDev | Median | Scaled | Gen 0 | Allocated
--- | --- | --- | --- | --- |--- | --- | ---
Test_v_4_0_transformator	| 4.965 ms	| 0.0165 ms	| 0.0137 ms	| 4.963 ms	| 0.13	| 932.8125	| 3.04 MB
Test_v_4_1_transformator	| 5.408 ms	| 0.1041 ms	| 0.1198 ms	| 5.428 ms	| 0.14	| 939.0625	| 3.04 MB
Test_v_4_2_transformator	| 3.911 ms	| 0.0166 ms	| 0.0155 ms	| 3.909 ms	| 0.1	| 742.7083	| 2.35 MB
 
### To już koniec. Jeśli coś źle opisałem, lub niejasno, lub macie pytania to zakładajcie `Issue` lub róbcie `pull request`. 
 
 
