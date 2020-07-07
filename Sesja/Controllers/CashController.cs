using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace TrzymanieDanych.Controllers
{
    public class CashController : Controller
    {
        IMemoryCache memoryCache;
        MemoryCacheEntryOptions memoryCacheEntry = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(40)).SetSize(100);
        public CashController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;

        }
        static readonly string CountRefreshKey = typeof(CashController).FullName + nameof(CountRefresh);
        public int? CountRefresh
        {
            get => (int?)memoryCache.Get(CountRefreshKey);
            set => memoryCache.Set(CountRefreshKey, value, memoryCacheEntry);
        }
        public IActionResult Index()
        {
            if (CountRefresh == null)
            {
                CountRefresh = 0;
            }
            CountRefresh++;

            return View(CountRefresh);
        }
    }
}