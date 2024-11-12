using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace WinFormsAssignment3
{
    public class Deck
    {
        private List<Card> cards = new List<Card>(); // List to hold Card objects
        private ImageList imageList; // Reference to ImageList from the form

        // Constructor takes ImageList from the form and initializes it
        public Deck(ImageList imageList)    
        {
            this.imageList = imageList;
        }

        // Property to return the count of cards in the deck
        public int Count => cards.Count;

        // Method to shuffle the deck and reset the cards
        public void Shuffle()
        {
            cards.Clear(); // Clear existing cards

            // Populate the deck with Card objects using images and names from ImageList
            for (int i = 0; i < imageList.Images.Count; i++)
            {
                // Get the name from the ImageList key (this is the card name)
                string name = imageList.Images.Keys[i];

                // Create the Card object with id, image, and name
                cards.Add(new Card(i, imageList.Images[i],name ));
            }

            // Shuffle the card list
            Random random = new Random();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }
        }

        // Method to deal a card from the deck
        public Card DealCard()
        {
            if (cards.Count > 0)
            {
                Card dealtCard = cards[0];
                cards.RemoveAt(0);
                return dealtCard;
            }
            return Card.NoCard; // Return NoCard if deck is empty
        }

        // Method to save hand to a file
        public bool SaveHand(string filename, Card[] hand)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Card card in hand)
                    {
                        writer.WriteLine(card.Id);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Method to load hand from a file
        public bool LoadHand(string filename, Card[] hand)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    for (int i = 0; i < hand.Length; i++)
                    {
                        if (int.TryParse(reader.ReadLine(), out int cardId) && cardId >= 0 && cardId < imageList.Images.Count)
                        {
                            string name = imageList.Images.Keys[cardId];
                            hand[i] = new Card(cardId, imageList.Images[cardId], name);
                        }
                        else
                        {
                            hand[i] = Card.NoCard;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Method to get a card at a specific index
        public Card GetCard(int index)
        {
            return (index >= 0 && index < cards.Count) ? cards[index] : Card.NoCard;
        }
        public void SwapCards(int index1, int index2)
        {
            if (index1 >= 0 && index1 < cards.Count && index2 >= 0 && index2 < cards.Count)
            {
                // Swap the cards at index1 and index2
                Card temp = cards[index1];
                cards[index1] = cards[index2];
                cards[index2] = temp;
            }
        }
    }
}