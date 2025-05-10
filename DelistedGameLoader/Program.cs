using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelistedGameLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "steam_links.txt"; // Aynı klasörde olmalı

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"HATA: {filePath} bulunamadı.");
                return;
            }

            string[] links = File.ReadAllLines(filePath);

            foreach (string link in links)
            {
                if (string.IsNullOrWhiteSpace(link)) continue;

                try
                {
                    Console.WriteLine("Açılıyor: " + link);
                    Process.Start(link.Trim());
                    Thread.Sleep(3000); // Steam'e yükleme penceresini açması için zaman tanı
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                }
            }

            Console.WriteLine("Tüm bağlantılar işlendi.");
            Console.ReadLine();
        }
    }
}
