﻿using Sacolao.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Api.Data
{
    public interface IRepository
    {
        void Add<T>(T item) where T : class;
        void Update<T>(T item) where T : class;
        void Delete<T>(T item) where T : class;
        bool SaveChanges();

        List<Fruta> GetAllFrutas();
        Fruta GetFrutaById(int frutaId);
    }
}
