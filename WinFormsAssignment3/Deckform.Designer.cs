namespace WinFormsAssignment3
{
    partial class Deckform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cardsLabel = new Label();
            deckListBox = new ListBox();
            cardPictureBox = new PictureBox();
            upButton = new Button();
            downButton = new Button();
            ((System.ComponentModel.ISupportInitialize)cardPictureBox).BeginInit();
            SuspendLayout();
            // 
            // cardsLabel
            // 
            cardsLabel.AutoSize = true;
            cardsLabel.Location = new Point(76, 69);
            cardsLabel.Name = "cardsLabel";
            cardsLabel.Size = new Size(37, 15);
            cardsLabel.TabIndex = 0;
            cardsLabel.Text = "&Cards";
            cardsLabel.Click += cardsLabel_Click;
            // 
            // deckListBox
            // 
            deckListBox.FormattingEnabled = true;
            deckListBox.ItemHeight = 15;
            deckListBox.Location = new Point(38, 97);
            deckListBox.Name = "deckListBox";
            deckListBox.Size = new Size(120, 124);
            deckListBox.TabIndex = 1;
            deckListBox.SelectedIndexChanged += deckListBox_SelectedIndexChanged;
            // 
            // cardPictureBox
            // 
            cardPictureBox.BackColor = SystemColors.InactiveCaptionText;
            cardPictureBox.Location = new Point(299, 86);
            cardPictureBox.Name = "cardPictureBox";
            cardPictureBox.Size = new Size(111, 162);
            cardPictureBox.TabIndex = 2;
            cardPictureBox.TabStop = false;
            cardPictureBox.Click += cardPictureBox_Click;
            // 
            // upButton
            // 
            upButton.Location = new Point(176, 120);
            upButton.Name = "upButton";
            upButton.Size = new Size(75, 23);
            upButton.TabIndex = 2;
            upButton.Text = "&Up";
            upButton.UseVisualStyleBackColor = true;
            upButton.Click += upButton_Click;
            // 
            // downButton
            // 
            downButton.Location = new Point(176, 168);
            downButton.Name = "downButton";
            downButton.Size = new Size(75, 23);
            downButton.TabIndex = 3;
            downButton.Text = "&Down";
            downButton.UseVisualStyleBackColor = true;
            downButton.Click += downButton_Click;
            // 
            // Deckform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 373);
            Controls.Add(downButton);
            Controls.Add(upButton);
            Controls.Add(cardPictureBox);
            Controls.Add(deckListBox);
            Controls.Add(cardsLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Deckform";
            Text = "Deck";
            ((System.ComponentModel.ISupportInitialize)cardPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label cardsLabel;
        private ListBox deckListBox;
        private PictureBox cardPictureBox;
        private Button upButton;
        private Button downButton;
    }
}