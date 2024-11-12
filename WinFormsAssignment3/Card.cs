namespace WinFormsAssignment3
{
    public class Card
    {
        public string Name { get; init; }

        public int Id { get; }
        public Image? CardImage { get; } // Read-only property for image, allowing null values

        // Pseudo-constant for "no card" state
        public static readonly Card NoCard = new Card(-1, null, "No Card");

        public Card(int id, Image? image, string name)
        {
            Id = id;
            CardImage = image;
            Name = name;
        }
        // Override ToString to display the Id when added to ListBox
        public override string ToString()
        {
            return Name;
        }
    }
}