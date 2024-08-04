
namespace TRW.Apps.CardMaker
{
    partial class DeckViewer<T>
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
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.RandomCardButton = new System.Windows.Forms.Button();
            this.ResetDeckButton = new System.Windows.Forms.Button();
            this.DrawCardButton = new System.Windows.Forms.Button();
            this.ShuffleButton = new System.Windows.Forms.Button();
            this.CardPicture = new System.Windows.Forms.PictureBox();
            this.ControlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CardPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ControlsPanel.Controls.Add(this.RandomCardButton);
            this.ControlsPanel.Controls.Add(this.ResetDeckButton);
            this.ControlsPanel.Controls.Add(this.DrawCardButton);
            this.ControlsPanel.Controls.Add(this.ShuffleButton);
            this.ControlsPanel.Location = new System.Drawing.Point(12, 368);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(350, 100);
            this.ControlsPanel.TabIndex = 0;
            // 
            // RandomCardButton
            // 
            this.RandomCardButton.Location = new System.Drawing.Point(176, 55);
            this.RandomCardButton.Name = "RandomCardButton";
            this.RandomCardButton.Size = new System.Drawing.Size(90, 34);
            this.RandomCardButton.TabIndex = 3;
            this.RandomCardButton.Text = "Random Card";
            this.RandomCardButton.UseVisualStyleBackColor = true;
            this.RandomCardButton.Click += new System.EventHandler(this.RandomCardButton_Click);
            // 
            // ResetDeckButton
            // 
            this.ResetDeckButton.Location = new System.Drawing.Point(80, 55);
            this.ResetDeckButton.Name = "ResetDeckButton";
            this.ResetDeckButton.Size = new System.Drawing.Size(90, 34);
            this.ResetDeckButton.TabIndex = 2;
            this.ResetDeckButton.Text = "Reset";
            this.ResetDeckButton.UseVisualStyleBackColor = true;
            this.ResetDeckButton.Click += new System.EventHandler(this.ResetDeckButton_Click);
            // 
            // DrawCardButton
            // 
            this.DrawCardButton.Location = new System.Drawing.Point(248, 4);
            this.DrawCardButton.Name = "DrawCardButton";
            this.DrawCardButton.Size = new System.Drawing.Size(90, 34);
            this.DrawCardButton.TabIndex = 1;
            this.DrawCardButton.Text = "Draw Card";
            this.DrawCardButton.UseVisualStyleBackColor = true;
            this.DrawCardButton.Click += new System.EventHandler(this.DrawCardButton_Click);
            // 
            // ShuffleButton
            // 
            this.ShuffleButton.Location = new System.Drawing.Point(5, 4);
            this.ShuffleButton.Name = "ShuffleButton";
            this.ShuffleButton.Size = new System.Drawing.Size(90, 34);
            this.ShuffleButton.TabIndex = 0;
            this.ShuffleButton.Text = "Shuffle";
            this.ShuffleButton.UseVisualStyleBackColor = true;
            this.ShuffleButton.Click += new System.EventHandler(this.ShuffleButton_Click);
            // 
            // CardPicture
            // 
            this.CardPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardPicture.Location = new System.Drawing.Point(12, 12);
            this.CardPicture.Name = "CardPicture";
            this.CardPicture.Size = new System.Drawing.Size(350, 350);
            this.CardPicture.TabIndex = 1;
            this.CardPicture.TabStop = false;
            // 
            // DeckViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 480);
            this.Controls.Add(this.CardPicture);
            this.Controls.Add(this.ControlsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DeckViewer";
            this.Text = "Deck Viewer";
            this.Load += new System.EventHandler(this.DeckViewer_Load);
            this.ControlsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CardPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlsPanel;
        private System.Windows.Forms.PictureBox CardPicture;
        private System.Windows.Forms.Button ResetDeckButton;
        private System.Windows.Forms.Button DrawCardButton;
        private System.Windows.Forms.Button ShuffleButton;
        private System.Windows.Forms.Button RandomCardButton;
    }
}