# TEO-KONKURS

## Nagroda: 0.7 Jacka i dziesięć setek Wiśniówki Lubelskiej

Tematem konkursu jest zoptymalizowanie procesu zamiany ciągu bajtów na obiekty. 

Poprzez socket z centrali telekomunikacyjnej przychodzi ciąg bajtów, który zawiera informacje o tym jakie zdarzenia wystąpiły w tej centrali. Chodzi o to aby w jak najbardziej optymalny sposób (jak najszybciej) zamienić te bajty na obiekty.

Do mierzenia wydajności wykorzystujemy DotNetBenchmark, który jest dołączony i odpowiednio skonfigurowany w projekcie.

Projekt zawiera już kilka wersji z moimi próbami optymalizacji. Podjąłem nawet próbę zarządzania pamięcią na własną rękę ale próba ta spaliła na panewkach. Osiągnąłem bardzo małe zużycie pamięci ale nie przełożyło się to na szybkość obliczeń. Czuję jednak, że da się jeszcze to lepiej zoptymalizować. Na tą chwilę nie wiem jak. Na każdego, któremu uda się poprawić wydajność, oprócz nagród rzeczowych, spadnie szacunkek ludzi naszej społeczności.

Projekt zawiera zestaw testów jednostkowych, które pilnują czy kolejne coraz to optymalniejsze wersje nadal poprawnie wykonują parsowanie.

**Wygrywa ten kto napisze najszybszą wersję parsowania. Konkurs trwa do 18-06-2017 do 23:59:59.999. Wersja uznana jest za najszybszą jeśli od poprzedniej najszybszej wersji będzie szybsza o 5% w każdym z 10 powtórzeń testu.**
