class DVD : LibraryItem
{
    public int DurationMinutes { get; set; }

    public DVD(string title, string creator, int duration) : base(title, creator)
    {
        DurationMinutes = duration;
    }

    public override void Checkout()
    {
        Console.WriteLine($"{Title} adlı DVD ödünç alındı. Geç iade: günlük 2 TL ceza.");
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"DVD: {Title} | Yönetmen: {AuthorOrCreator} | Süre: {DurationMinutes} dk");
    }
}
