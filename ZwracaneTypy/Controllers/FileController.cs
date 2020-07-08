using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZwracaneTypy.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Obraz1()
        {
            Bitmap bp = CreateImage();
            using (MemoryStream ms = new MemoryStream())
            {
                bp.Save(ms, ImageFormat.Png);
                ms.Close();
                return new FileContentResult(ms.ToArray(), "image/png");
            }
        }
        public IActionResult Obraz2()
        {
            Bitmap bp = CreateImage();
            MemoryStream ms = new MemoryStream();
            bp.Save(ms, ImageFormat.Png);
            ms.Seek(0, SeekOrigin.Begin);
            return new FileStreamResult(ms, "image/png");

        }
        public IActionResult Obraz3()
        {
            return new PhysicalFileResult(@$"C:\Users\jarek\Desktop\kb.PNG", "image/png");
        }

        public IActionResult Obraz4()
        {
            //plik musi się znajdować w nazwaprojektu//wwwroute
            return new VirtualFileResult($"ja.jpg", "image/jpg");
        }
        private static Bitmap CreateImage()
        {
            Bitmap bp = new Bitmap(100, 100);
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    bp.SetPixel(i, j, Color.FromArgb(i + j, 0, 0));
                }
            }
            return bp;
        }
    }
}