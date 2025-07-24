class Book : LibraryItem 
{
    public int PageCount{ get;set;}

    public Book(string title,string author,int pages):base(title,author)
    {
        PageCount = pages;
    }


    public override void Checkout()
    {
        Console.WriteLine($"{Title} adlı kitap ödünç alındı. İade süresi 14 gün.");

    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Kitap: {Title} | Yazar: {AuthorOrCreator} | Sayfa: {PageCount}");

    }
}