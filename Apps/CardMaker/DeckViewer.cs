using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TRW.GameLibraries.GameCore;

namespace TRW.Apps.CardMaker
{
    public partial class DeckViewer<T> : Form where T : IComparable
    {
        Deck<T> Cards { get; }
        Stack<Card<T>> Stack { get; set; }
        Bitmap _cardBack;

        private DeckViewer()
        {
            InitializeComponent();
            Cards = new Deck<T>();
        }

        public DeckViewer(Deck<T> cards)
            : this()
        {
            Cards = cards;
        }

        private Pen BlackPen { get; } = new Pen(Brushes.Black, 1);
        private Pen BlackOutlinePen { get; } = new Pen(Brushes.Black, 2);
        private Pen WhiteOutlinePen { get; } = new Pen(Brushes.Ivory, 2);
        private Pen ThickRedPen { get; } = new Pen(Brushes.DarkRed, 10);
        private Font TitleFont { get; } = new Font(FontFamily.GenericSerif, 14f, FontStyle.Bold | FontStyle.Underline);
        private Font FinePrintFont { get; } = new Font(FontFamily.GenericMonospace, 6f, FontStyle.Regular);
        private Font DescriptionFont { get; } = new Font(FontFamily.GenericSerif, 12, FontStyle.Regular);


        private void DrawCardImage(Card<T> card)
        {
            int w = CardPicture.Width;
            int h = CardPicture.Height;
            Bitmap cardImage = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(cardImage))
            {
                g.Clear(Color.White);
                g.DrawRectangle(BlackOutlinePen, new Rectangle(5, 5, w - 10, h - 10));

                // draw card title at top
                g.DrawString(card.Title, TitleFont, Brushes.Black, new RectangleF(15f, 7f, (w - 40f), 25f));
                g.DrawLine(BlackPen, 10, 30, w - 10, 30);

                Rectangle description;
                // if there is an image, put it in the box?
                if (card.Image != null)
                {
                    int pictureHeight = 200;
                    int pictureWidth = card.Image.Width / card.Image.Height * pictureHeight;

                    int x = w / 2 - pictureWidth / 2;

                    g.DrawImage(card.Image, x, 35, pictureWidth, pictureHeight);

                    description = new Rectangle(20, pictureHeight + 40, w - 40, 75);
                }
                else
                {
                    description = new Rectangle(20, 35, w - 40, 75);
                }

                // draw a Description box
                g.DrawRectangle(BlackOutlinePen, description);
                g.DrawString(card.Description, DescriptionFont, Brushes.Black, description);

                // put the value on a bottom corner
                string valueString = card.Value.ToString();
                int valueWidth = (valueString.Length * 12);
                g.DrawString(valueString, FinePrintFont, Brushes.Black, new RectangleF(w - 10 - valueWidth, h - 22f, valueWidth, 10f));
            }

            CardPicture.Image = cardImage;
            CardPicture.Invalidate();
        }

        private void DrawCardBack()
        {
            if (_cardBack == null)
            {
                int w = CardPicture.Width;
                int h = CardPicture.Height;
                int halfW = w / 2;
                int halfH = h / 2;
                int quartW = w / 4;
                int quartH = h / 4;

                _cardBack = new Bitmap(w, h);
                using (Graphics g = Graphics.FromImage(_cardBack))
                {
                    g.Clear(Color.Navy);
                    g.DrawRectangle(WhiteOutlinePen, new Rectangle(5, 5, w - 10, h - 10));
                    g.DrawRectangle(BlackOutlinePen, new Rectangle(8, 8, w - 16, h - 16));
                    g.DrawRectangle(WhiteOutlinePen, new Rectangle(11, 11, w - 22, h - 22));

                    g.FillPolygon(Brushes.Ivory, new Point[]
                        {
                        new Point(halfW + quartW, halfH),
                        new Point(halfW, halfH + quartH),
                        new Point(halfW - quartW, halfH),
                        new Point(halfW, halfH - quartH),
                        });
                    g.FillPolygon(Brushes.Ivory, new Point[]
                        {
                        new Point(quartW + quartW/2, quartH),
                        new Point(quartW, quartH + quartH/2),
                        new Point(quartW - quartW/2, quartH),
                        new Point(quartW, quartH - quartH/2),
                        });
                    g.FillPolygon(Brushes.Ivory, new Point[]
                        {
                        new Point(halfW + quartW + quartW/2, quartH),
                        new Point(halfW + quartW, quartH + quartH/2),
                        new Point(halfW + quartW - quartW/2, quartH),
                        new Point(halfW + quartW, quartH - quartH/2),
                        });
                    g.FillPolygon(Brushes.Ivory, new Point[]
                        {
                        new Point(quartW + quartW/2, halfH + quartH),
                        new Point(quartW, halfH + quartH + quartH/2),
                        new Point(quartW - quartW/2, halfH + quartH),
                        new Point(quartW, halfH + quartH - quartH/2),
                        });
                    g.FillPolygon(Brushes.Ivory, new Point[]
                        {
                        new Point(halfW + quartW + quartW/2, halfH + quartH),
                        new Point(halfW + quartW, halfH + quartH + quartH/2),
                        new Point(halfW + quartW - quartW/2, halfH + quartH),
                        new Point(halfW + quartW, halfH + quartH - quartH/2),
                        });

                    g.DrawPolygon(ThickRedPen, new PointF[]
                        {
                        new Point(halfW + quartW + 15, halfH),
                        new Point(halfW, halfH + quartH + 15),
                        new Point(halfW - quartW - 15, halfH),
                        new Point(halfW, halfH - quartH - 15),
                        });
                    g.DrawPolygon(ThickRedPen, new PointF[]
                        {
                        new Point(quartW + quartW/2, quartH),
                        new Point(quartW, quartH + quartH/2),
                        new Point(quartW - quartW/2, quartH),
                        new Point(quartW, quartH - quartH/2),
                        });
                    g.DrawPolygon(ThickRedPen, new PointF[]
                        {
                        new Point(halfW + quartW + quartW/2, quartH),
                        new Point(halfW + quartW, quartH + quartH/2),
                        new Point(halfW + quartW - quartW/2, quartH),
                        new Point(halfW + quartW, quartH - quartH/2),
                        });
                    g.DrawPolygon(ThickRedPen, new PointF[]
                        {
                        new Point(quartW + quartW/2, halfH + quartH),
                        new Point(quartW, halfH + quartH + quartH/2),
                        new Point(quartW - quartW/2, halfH + quartH),
                        new Point(quartW, halfH + quartH - quartH/2),
                        });
                    g.DrawPolygon(ThickRedPen, new PointF[]
                        {
                        new Point(halfW + quartW + quartW/2, halfH + quartH),
                        new Point(halfW + quartW, halfH + quartH + quartH/2),
                        new Point(halfW + quartW - quartW/2, halfH + quartH),
                        new Point(halfW + quartW, halfH + quartH - quartH/2),
                        });
                }
            }

            CardPicture.Image = _cardBack;
            CardPicture.Invalidate();
        }

        private void SetViewerState(bool hasStack)
        {
            ResetDeckButton.Enabled = true;
            ShuffleButton.Enabled = true;
            RandomCardButton.Enabled = true;

            DrawCardButton.Enabled = hasStack;

        }

        private void DeckViewer_Load(object sender, EventArgs e)
        {
            DrawCardBack();
            if (Cards != null)
            {
                Stack = Cards.Stack();
                SetViewerState(Stack.Count > 0);
            }
        }

        private void DrawCardButton_Click(object sender, EventArgs e)
        {
            DrawCardImage(Stack.Pop());
            SetViewerState(Stack.Count > 0);
        }

        private void RandomCardButton_Click(object sender, EventArgs e)
        {
            DrawCardImage(Cards.Random());
        }

        private void ShuffleButton_Click(object sender, EventArgs e)
        {
            if (Cards != null)
            {
                Stack = Cards.Shuffle();
                SetViewerState(Stack.Count > 0);
                DrawCardBack();
            }
        }

        private void ResetDeckButton_Click(object sender, EventArgs e)
        {
            if (Cards != null)
            {
                Stack = Cards.Stack();
                SetViewerState(Stack.Count > 0);
                DrawCardBack();
            }
        }
    }
}
