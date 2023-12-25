# CustomPairsGenerator

Утилита генерирует список пользовательских пар инструментов для TradingView.
Утилита предоставляется как есть, автор не дает никаких гарантий и не несет никакой ответственности.

## Как использовать
* [Скачать](https://github.com/vit-utility/CustomPairsGenerator/releases/tag/v1.0.2) и распаковать архив CustomPairsGenerator.
* В файле source.txt указать нужные инструменты в формате биржа : инструмент, например BINANCE:ATOMUSDT.
* Если строку начать с сивола *, то пары с этим инструментом не будут добавлены к другим инструментам. (Смотрите [пример](https://github.com/vit-utility/CustomPairsGenerator/tree/main/example) )
* Запустить CustomPairsGenerator.exe, результат будет в файлах result_(n).txt.
* [Импортировать](https://ru.tradingview.com/support/solutions/43000487233/) инструменты из файла result.txt.

## .NET Runtime
Для работы утилиты нужен [.NET Runtime](https://dotnet.microsoft.com/en-us/download/dotnet), обычно он уже установлен в Windows.
