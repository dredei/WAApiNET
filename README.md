WAApiNET
========

.NET библиотека для работы с [WaspAce API](http://docs.waspace.net/doku.php/ru/api).

Реализованы не все методы. Отсутствуют такие методы, как: регистрация (и все, что с ней связано), изменение пароля (и все, что с ним связано), список диапазонов IP и операции с балансом.

Все, что касается работы с папками и заданиями (также рефералы и получение всех данных аккаунта) реализовано.

Разобраться достаточно легко, так что нет смысла в большом количестве примеров. Несколько примеров можно глянуть [здесь](https://github.com/dredei/WAApiNET/wiki/%D0%9D%D0%B5%D1%81%D0%BA%D0%BE%D0%BB%D1%8C%D0%BA%D0%BE-%D0%BF%D1%80%D0%B8%D0%BC%D0%B5%D1%80%D0%BE%D0%B2). Остальное можно посмотреть в [тестах](https://github.com/dredei/WAApiNET/tree/master/C%23/WAApiNETTests).

Классы, методы и свойства (и их описанием) можно глянуть [здесь](https://rawgit.com/dredei/WAApiNET/master/Help/Help/index.html).

Changelog
------
**v1.0.1** (05.08.2014):
- Изменен тип **int?** на **double?** поля дохода рефералов;
- Добавлен перегруженный метод для добавления папки (теперь можно передавать объект класса [WAFolder](https://github.com/dredei/WAApiNET/blob/master/C%23/WAApiNET/Model/Folder/WAFolder.cs#L12); также можно передавать и [WAFolderWhole](https://github.com/dredei/WAApiNET/blob/master/C%23/WAApiNET/Model/Folder/WAFolderWhole.cs#L13), т.к. он наследует [WAFolder](https://github.com/dredei/WAApiNET/blob/master/C%23/WAApiNET/Model/Folder/WAFolder.cs#L12));
- Добавлено игнорирование нескольких полей при сериализации;
- Исправлен тест геотаргетинга.

**v1.0.2**
- Увеличена задержка между запросами;
- Добавлена перегрузка для метода AddTask;
- Переопределен метод ToString() для класса WAApiException;
- Теперь сообщение об ошибке также записывается в поле Message класса WAApiException;
- Переопределен метод Equals для классов пространства имен Model.