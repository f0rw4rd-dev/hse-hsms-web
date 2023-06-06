INSERT INTO public."Users" ("Password", "RegistrationDate", "LastVisitDate", "Group") VALUES ('a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', '2023-05-10 11:27:50.115327+05', '2023-05-10 11:27:50.115327+05', 4);
INSERT INTO public."Users" ("Password", "RegistrationDate", "LastVisitDate", "Group") VALUES ('a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', '2023-05-10 11:27:50.115327+05', '2023-05-10 11:27:50.115327+05', 3);

INSERT INTO public."Suppliers" ("Name") VALUES ('ООО "НВИДИА"');
INSERT INTO public."Suppliers" ("Name") VALUES ('ООО "Логитек"');
INSERT INTO public."Suppliers" ("Name") VALUES ('ООО "МСИ"');
INSERT INTO public."Suppliers" ("Name") VALUES ('ООО "Гигабайт"');

INSERT INTO public."Warehouses" ("City", "Street", "House", "Zip") VALUES ('Пермь', 'Уральская', '85', 614012);
INSERT INTO public."Warehouses" ("City", "Street", "House", "Zip") VALUES ('Пермь', 'Попова', '16', 614000);
INSERT INTO public."Warehouses" ("City", "Street", "House", "Zip") VALUES ('Пермь', 'Революции', '5а', 614048);
INSERT INTO public."Warehouses" ("City", "Street", "House", "Zip") VALUES ('Пермь', 'Мира', '2', 614032);

INSERT INTO public."DetailTypes" ("Name") VALUES ('Сокет');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Год релиза');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Система охлаждения в комплекте');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Общее количество ядер');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Максимальное число потоков');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Количество производительных ядер');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Количество энергоэффективных ядер');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Объем кэша L2');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Объем кэша L3');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Техпроцесс');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Ядро');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Базовая частота процессора');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Максимальная частота в турбо режиме');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Базовая частота энергоэффективных ядер');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Частота в турбо режиме энергоэффективных ядер');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Тип памяти');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Максимально поддерживаемый объем памяти');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Количество каналов');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Максимальная частота оперативной памяти');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Тепловыделение (TDP)');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Базовое тепловыделение');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Максимальная температура процессора');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Встроенный контроллер PCI Express');
INSERT INTO public."DetailTypes" ("Name") VALUES ('LHR');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Графический процессор');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Микроархитектура');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Объем видеопамяти');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Разрядность шины памяти');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Максимальная пропускная способность памяти');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Эффективная частота памяти');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Штатная частота работы видеочипа');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Турбочастота');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Количество универсальных процессоров (ALU)');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Число текстурных блоков');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Число блоков растеризации');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Поддержка трассировки лучей');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Аппаратное ускорение трассировки лучей (RT-ядра)');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Тензорные ядра');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Версия шейдеров');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Видеоразъемы');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Версия HDMI');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Версия DisplayPort');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Количество подключаемых одновременно мониторов');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Максимальное разрешение');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Интерфейс подключения');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Форм-фактор разъема подключения');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Разъемы дополнительного питания');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Рекомендуемый блок питания');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Длина видеокарты');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Ширина видеокарты');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Толщина видеокарты');
INSERT INTO public."DetailTypes" ("Name") VALUES ('Подсветка элементов видеокарты');

INSERT INTO public."ComponentTypes" ("Name") VALUES ('Процессоры');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('Материнские платы');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('Видеокарты');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('Оперативная память');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('Корпуса');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('Блоки питания');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('Кулеры для процессоров');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('Системы жидкостного охлаждения');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('Вентиляторы для корпуса');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('SSD накопители');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('SSD M.2 накопители');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('Серверные SSD M.2');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('Серверные SSD');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('Жесткие диски 3.5"');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('Жесткие диски 2.5"');
INSERT INTO public."ComponentTypes" ("Name") VALUES ('Серверные HDD');

INSERT INTO public."Components" ("ComponentTypeId", "Name", "Warranty") VALUES (1, 'Intel Core i5-12400F BOX', 12);
INSERT INTO public."Components" ("ComponentTypeId", "Name", "Warranty") VALUES (3, 'GIGABYTE AMD Radeon RX 6650 XT GAMING OC', 36);
INSERT INTO public."Components" ("ComponentTypeId", "Name", "Warranty") VALUES (3, 'Palit GeForce RTX 3060 DUAL OC (LHR)', 36);

INSERT INTO public."ComponentStorages" ("Price", "Amount", "WarehouseId", "ComponentId") VALUES (14699, 13, 1, 1);
INSERT INTO public."ComponentStorages" ("Price", "Amount", "WarehouseId", "ComponentId") VALUES (17999, 4, 1, 1);
INSERT INTO public."ComponentStorages" ("Price", "Amount", "WarehouseId", "ComponentId") VALUES (36499, 23, 1, 2);
INSERT INTO public."ComponentStorages" ("Price", "Amount", "WarehouseId", "ComponentId") VALUES (31990, 6, 2, 2);

INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (1, 1, 'LGA 1700');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (2, 1, '2022');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (3, 1, 'есть');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (4, 1, '6');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (5, 1, '12');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (6, 1, '6');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (7, 1, 'нет');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (8, 1, '7.5 МБ');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (9, 1, '18 МБ');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (10, 1, 'Intel 7');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (11, 1, 'Intel Alder Lake-S');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (12, 1, '2.5 ГГц');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (13, 1, '4.4 ГГц');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (24, 2, 'нет');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (25, 2, 'Radeon RX 6650 XT');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (26, 2, 'AMD RDNA 2');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (10, 2, '7 нм');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (27, 2, '8 ГБ');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (16, 2, 'GDDR6');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (28, 2, '128 бит');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (31, 2, '2523 МГц');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (32, 2, '2694 МГц');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (33, 2, '2048');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (34, 2, '128');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (35, 2, '64');
INSERT INTO public."ComponentDetails" ("DetailTypeId", "ComponentId", "Value") VALUES (36, 2, 'есть');

INSERT INTO public."Configurations" ("ConfigurationId", "Amount", "ComponentId") VALUES (1, 1, 1);
INSERT INTO public."Configurations" ("ConfigurationId", "Amount", "ComponentId") VALUES (1, 1, 2);

INSERT INTO public."Supplies" ("SupplyPrice", "Amount", "Date", "SupplierId", "ComponentId", "WarehouseId") VALUES (15390, 23, '2023-05-24 11:27:50.115327+05', 1, 1, 1);
INSERT INTO public."Supplies" ("SupplyPrice", "Amount", "Date", "SupplierId", "ComponentId", "WarehouseId") VALUES (12380, 19, '2023-05-27 11:27:50.115327+05', 2, 1, 1);
INSERT INTO public."Supplies" ("SupplyPrice", "Amount", "Date", "SupplierId", "ComponentId", "WarehouseId") VALUES (32870, 32, '2023-05-27 11:27:50.115327+05', 2, 2, 1);
INSERT INTO public."Supplies" ("SupplyPrice", "Amount", "Date", "SupplierId", "ComponentId", "WarehouseId") VALUES (33650, 45, '2023-05-30 11:27:50.115327+05', 3, 2, 2);

INSERT INTO public."Orders" ("Date", "Status") VALUES ('2023-05-29 11:27:50.115327+05', 0);

INSERT INTO public."OrderComponents" ("Price", "Amount", "IsPartOfConfiguration", "OrderId", "WarehouseId", "ComponentId") VALUES (13890, 2, false, 1, 1, 1);