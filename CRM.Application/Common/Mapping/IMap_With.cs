using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Application.Common.Mapping
{
    //интерфейс с реализацией по умолчанию
   public interface IMap_With<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
