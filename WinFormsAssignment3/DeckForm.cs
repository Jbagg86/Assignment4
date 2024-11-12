using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAssignment3
{
    public partial class Deckform : Form
    {
        private Deck _deck;
        public Deckform(Deck deck)
        {
            InitializeComponent();
            _deck = deck;
            this.Load += DeckForm_Load;
        }
        private void DeckForm_Load(object sender, EventArgs e)
        {
            UpdateDeck();
        }
        public void UpdateDeck()
        {
            deckListBox.Items.Clear(); // Clears the ListBox
            for (int i = 0; i < _deck.Count; i++)
            {
                deckListBox.Items.Add(_deck.GetCard(i)); // Adds each Card to the ListBox
            }
        }

        private void deckListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                // Handle the selection change to update PictureBox with selected card image
                Card? card = (Card?)deckListBox.SelectedItem;
                cardPictureBox.Image = card?.CardImage;
            }
        }

        private void cardPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void cardsLabel_Click(object sender, EventArgs e)
        {

        }

        private void upButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = deckListBox.SelectedIndex;
            if (selectedIndex > 0)
            {
                // Calculate new index
                int newIndex = selectedIndex - 1;

                // Swap cards in Deck
                _deck.SwapCards(selectedIndex, newIndex);

                // Update ListBox
                UpdateDeck();

                // Set selection to new index
                deckListBox.SelectedIndex = newIndex;
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = deckListBox.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < _deck.Count - 1)
            {
                // Calculate new index
                int newIndex = selectedIndex + 1;

                // Swap cards in Deck
                _deck.SwapCards(selectedIndex, newIndex);

                // Update ListBox
                UpdateDeck();

                // Set selection to new index
                deckListBox.SelectedIndex = newIndex;
            }

        }
    }
}
