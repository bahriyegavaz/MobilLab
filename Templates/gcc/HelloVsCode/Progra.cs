class Program
{
    static List<LibraryItem> library = new List<LibraryItem>();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n📚 KÜTÜPHANE MENÜSÜ");
            Console.WriteLine("1. Kitap ekle");
            Console.WriteLine("2. DVD ekle");
            Console.WriteLine("3. Tüm materyalleri listele");
            Console.WriteLine("4. Ödünç alma işlemi");
            Console.WriteLine("0. Çıkış");
            Console.Write("Seçimin: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    AddDVD();
                    break;
                case "3":
                    ListItems();
                    break;
                case "4":
                    CheckoutItem();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim 😅");
                    break;
            }
        }
    }

    static void AddBook()
    {
        Console.Write("Kitap adı: ");
        string title = Console.ReadLine();
        Console.Write("Yazar: ");
        string author = Console.ReadLine();
        Console.Write("Sayfa sayısı: ");
        int pages = int.Parse(Console.ReadLine());

        library.Add(new Book(title, author, pages));
        Console.WriteLine("✅ Kitap eklendi!");
    }

    static void AddDVD()
    {
        Console.Write("DVD adı: ");
        string title = Console.ReadLine();
        Console.Write("Yönetmen: ");
        string director = Console.ReadLine();
        Console.Write("Süre (dk): ");
        int duration = int.Parse(Console.ReadLine());

        library.Add(new DVD(title, director, duration));
        Console.WriteLine("✅ DVD eklendi!");
    }

    static void ListItems()
    {
        Console.WriteLine("\n📦 KÜTÜPHANE ENVANTERİ:");
        foreach (var item in library)
        {
            item.DisplayInfo();
        }
    }

    static void CheckoutItem()
    {
        Console.WriteLine("\n🎁 Hangi item'i ödünç almak istiyorsun?");
        for (int i = 0; i < library.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            library[i].DisplayInfo();
        }

        Console.Write("Seçim numarası: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < library.Count)
        {
            library[index].Checkout();
        }
        else
        {
            Console.WriteLine("❌ Geçersiz seçim!");
        }
    }
}
