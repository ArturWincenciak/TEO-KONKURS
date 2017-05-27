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
  new v_5_0.CtiTransformator(new v_5_0.ByteBuffer(), new v_5_0.CtiParser()),
 };
 // ...
}
```
10. Odpalamy testy jednostkowe. Wszystko powinno być zielone. Od tego momentu możemy modyfikować naszą nową wersję parsera i sprawdzać czy testy nadal są zielone.
11. Dodajemy naszą nową wersję parsera do testów wydajności. Otwieramy klasę `CtiTransformatorTester` i dodajemy nową prywatną właściwość analogicznie jak w linii 39 poniżej.



