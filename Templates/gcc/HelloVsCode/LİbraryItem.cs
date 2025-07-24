abstract class LibraryItem
{
    public string Title {get;set;}
    public string AuthorOrCreator{get;set;}

    public LibraryItem(string title, string creator)
    {
        Title = title;
        AuthorOrCreator = creator;
    }

    public abstract void Checkout();
    public abstract void DisplayInfo();
}