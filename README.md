![GitHub commit activity](https://img.shields.io/github/commit-activity/y/SenseiMori/EXIFRemover)
[![Telegram](https://img.shields.io/badge/Telegram-Sensei__Mori-2CA5E0?style=flat&logo=telegram)](https://t.me/Sensei_Mori)

Маленькая библиотека для удаления метаданных из изображений формата jpeg. Реализует два метода: 
- Поиск меток APP0-APP15 + COM, отвечающих за сегменты метаданных в изображении;
- Возврат массива байтов нового изображения без меток;

И класс-прослойку, через который к этим методам можно обратиться.
