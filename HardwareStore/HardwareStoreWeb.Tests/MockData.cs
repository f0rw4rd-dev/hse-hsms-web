using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardwareStoreWeb.Models;

namespace HardwareStoreWeb.Tests
{
    public class MockData
    {
        public static readonly List<ComponentType> ComponentTypes = new()
        {
            new() { Name = "Процессоры" },
            new() { Name = "Материнские платы" },
            new() { Name = "Видеокарты" },
            new() { Name = "Оперативная память" },
            new() { Name = "Корпуса" },
            new() { Name = "Блоки питания" },
            new() { Name = "Кулеры для процессоров" },
            new() { Name = "Системы жидкостного охлаждения" },
            new() { Name = "Вентиляторы для корпуса" },
            new() { Name = "SSD накопители" },
            new() { Name = "SSD M.2 накопители" },
            new() { Name = "Серверные SSD M.2" },
            new() { Name = "Серверные SSD" },
            new() { Name = "Жесткие диски 3.5\"" },
            new() { Name = "Жесткие диски 2.5\"" },
            new() { Name = "Серверные HDD" },
        };

        public static readonly List<Component> Components = new()
        {
            new() { ComponentTypeId = 1, Name = "Intel Core i5-12400F BOX", Warranty = 12 },
            new() { ComponentTypeId = 3, Name = "GIGABYTE AMD Radeon RX 6650 XT GAMING OC", Warranty = 36 },
            new() { ComponentTypeId = 3, Name = "Palit GeForce RTX 3060 DUAL OC (LHR)", Warranty = 36 },
        };
    }
}
