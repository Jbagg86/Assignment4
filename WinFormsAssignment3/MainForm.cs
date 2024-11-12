using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WinFormsAssignment3;

namespace WinFormsAssignment3
{
    public partial class MainForm : Form
    {
        private const string HANDS_FOLDER = @"C:\Users\jbagg\Source\Repos\Assignment4\WinFormsAssignment3\images\";
        private const string DEFAULT_EXT = "txt";
        private Deck deck;
        private Card[] hand = new Card[5];
        private Deckform deckForm;
        public MainForm()
        {
            InitializeComponent();
            deck = new Deck(cardsImageList); // Initialize Deck with ImageList reference
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Starting hand
            deck.Shuffle();
            for (int i = 0; i < hand.Length; i++)
            {
                DealCard(i);
            }
            UpdateHandPics();
            
        }

        private void DealCard(int pos)
        {
            if (pos < 0 || pos >= hand.Length) return;
            hand[pos] = deck.DealCard();
        }

        private void dealButton_Click(object sender, EventArgs e)
        {
            // If we aren't redrawing, reshuffle the deck to start fresh
            if (!IsRedraw())
            {
                deck.Shuffle();
                
            }

            // Deal out the cards
            if (!keep1CheckBox.Checked) DealCard(0);
            if (!keep2CheckBox.Checked) DealCard(1);
            if (!keep3CheckBox.Checked) DealCard(2);
            if (!keep4CheckBox.Checked) DealCard(3);
            if (!keep5CheckBox.Checked) DealCard(4);

            UpdateHandPics();
            ResetKeepCheckboxes();
            
        }

        private void UpdateHandPics()
        {
            // Simplified code for setting PictureBox images
            hand1PictureBox.Image = hand[0].CardImage;
            hand2PictureBox.Image = hand[1].CardImage;
            hand3PictureBox.Image = hand[2].CardImage;
            hand4PictureBox.Image = hand[3].CardImage;
            hand5PictureBox.Image = hand[4].CardImage;

            if ((deckForm != null) && (deckForm.Visible))
            {
                deckForm.UpdateDeck();
            }
        }

        private bool IsRedraw()
        {
            return keep1CheckBox.Checked || keep2CheckBox.Checked || keep3CheckBox.Checked || keep4CheckBox.Checked || keep5CheckBox.Checked;
        }

        private void ResetKeepCheckboxes()
        {
            keep1CheckBox.Checked = false;
            keep2CheckBox.Checked = false;
            keep3CheckBox.Checked = false;
            keep4CheckBox.Checked = false;
            keep5CheckBox.Checked = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = HANDS_FOLDER;
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = DEFAULT_EXT;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            if (!deck.SaveHand(saveFileDialog.FileName, hand))
            {
                MessageBox.Show("Failed to save hand.");
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = HANDS_FOLDER;
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            if (!deck.LoadHand(openFileDialog.FileName, hand))
            {
                MessageBox.Show("Failed to load hand.");
            }
            UpdateHandPics();
        }

        private void showDeckButton_Click(object sender, EventArgs e)
        {
            // Check if the form is null or not visible
            if (deckForm == null || !deckForm.Visible)
            {
                // Create a new instance if needed
                deckForm = new Deckform(deck);
                deckForm.Show(); // Show the form modelessly
            }
            else
            {
                // If the form is already open, bring it to the front
                deckForm.BringToFront();
            }
        }
    }
}
