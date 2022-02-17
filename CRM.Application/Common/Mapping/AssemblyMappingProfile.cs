using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Reflection;

namespace CRM.Application.Common.Mapping
{
  public  class AssemblyMappingProfile:Profile
    {
        public AssemblyMappingProfile(Assembly assembly) =>
          ApplyMappingsFromAssembly(assembly);

        //Применить мэппинг из сборки
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            //Получает общедоступные типы, определенные в этой сборке, которые видны за пределами сборки.
            var types = assembly.GetExportedTypes()
                //При переопределении в производном классе получает все интерфейсы, реализованные или унаследованные текущим
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                    //Возвращает объект Type , представляющий определение универсального типа, из которого может быть создан текущий универсальный тип.
                    i.GetGenericTypeDefinition() == typeof(IMap_With<>)))
                .ToList();

            foreach (var type in types)
            {
               // Создает экземпляр указанного типа с помощью конструктора этого типа без параметров.
                var instance = Activator.CreateInstance(type);
                //Строка, содержащая имя общедоступного метода, который требуется получить.
                var methodInfo = type.GetMethod("Mapping");
                //Выполняет указанный делегат в потоке, которому принадлежит базовый дескриптор окна элемента управления, с указанным списком аргументов.
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
