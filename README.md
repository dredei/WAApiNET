WAApiNET
========

.NET библиотека для работы с [WaspAce API](http://docs.waspace.net/doku.php/ru/api).

Реализованы не все методы. Отсутствуют такие методы, как: регистрация (и все, что с ней связано), изменение пароля (и все, что с ним связано), список диапазонов IP и операции с балансом.

Все, что касается работы с папками и заданиями (также рефералы и получение всех данных аккаунта) реализовано.

Разобраться достаточно легко, так что нет смысла в большом количестве примеров. Несколько примеров можно глянуть [здесь](https://github.com/dredei/WAApiNET/wiki/%D0%9D%D0%B5%D1%81%D0%BA%D0%BE%D0%BB%D1%8C%D0%BA%D0%BE-%D0%BF%D1%80%D0%B8%D0%BC%D0%B5%D1%80%D0%BE%D0%B2). Остальное можно посмотреть в [тестах](https://github.com/dredei/WAApiNET/tree/master/C%23/WAApiNETTests).

Классы, методы и свойства (и их описанием) можно глянуть [здесь](https://rawgit.com/dredei/WAApiNET/master/Help/Help/index.html).

Используется библиотека [Microsoft Async](https://www.nuget.org/packages/Microsoft.Bcl.Async/).

Changelog
------
**v1.0.1** (05.08.2014):
- Изменен тип **int?** на **double?** поля дохода рефералов;
- Добавлен перегруженный [метод для добавления папки](https://github.com/dredei/WAApiNET/commit/137ef0b436791750779c1e6545507946373cfff4#diff-0053273e8716ca61b8d6ab941160388cR67);
- Добавлено [игнорирование нескольких полей при сериализации](https://github.com/dredei/WAApiNET/commit/13827a3e4330ea5c372eb6e69c150c566d1f0041);
- Исправлен [тест геотаргетинга](https://github.com/dredei/WAApiNET/commit/e482f4d989f2ff3dec16e16091986e7ca8098f23#diff-87e99c393e623b9c1263688461ae5563L42).

**v1.0.2** (14.08.2014)
- Увеличена задержка между запросами;
- Добавлена [перегрузка для метода AddTask](https://github.com/dredei/WAApiNET/commit/0404abe39c704cea349728e311ca0d8c19351b43#diff-8f67a73ee8d1209a83f28ad4a234a7b6R89);
- Переопределен метод [ToString() для класса WAApiException](https://github.com/dredei/WAApiNET/commit/17e3bdb7c0a56ddc1493dda9e3ce256270419d97#diff-fe25ba9ac0efb8fde19b63db6b081758R70);
- Теперь сообщение об ошибке также записывается в поле Message класса WAApiException;
- Переопределен метод Equals для классов пространства имен Model;
- Добавлена [перегрузка для метода MoveTasks](https://github.com/dredei/WAApiNET/commit/dc1164bff1425bb1fb70cb1ac0e1d3f6aef5f341#diff-8f67a73ee8d1209a83f28ad4a234a7b6R505);
- Добавлены следующие методы: [удаление папки](https://github.com/dredei/WAApiNET/commit/5682063d1fcaf7a3037f88fca784694110b80383#diff-0053273e8716ca61b8d6ab941160388cR138), [удаление задания](https://github.com/dredei/WAApiNET/commit/0b356d04e77dd2fe23ac1a9751307e4813df7ea4#diff-8f67a73ee8d1209a83f28ad4a234a7b6R141), [изменение настроек задания](https://github.com/dredei/WAApiNET/commit/beb59a96166350c46b5952b4cf6c7789b4b7bab1#diff-8f67a73ee8d1209a83f28ad4a234a7b6R401), [перенос задания в другую папку](https://github.com/dredei/WAApiNET/commit/7b1c67d18cd514db76e8dc4f5f0ce3d31b3c7eff#diff-8f67a73ee8d1209a83f28ad4a234a7b6R505).
