using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewEngine.Logic
{
    public class MainView : IView
    {
        public string Path => string.Empty;

        public Task RenderAsync(ViewContext context)
        {
            return Task.Run(() =>
            {
                StringBuilder sn = new StringBuilder();
                foreach (var item in context.ViewData)
                {
                    sn.AppendLine($"{item.Key}: {item.Value}");
                }
                context.HttpContext.Response.WriteAsync(sn.ToString());
            });
        }
    }
}
