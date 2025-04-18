using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TRW.CommonLibraries.Serialization;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public class Deck<T> : IBinarySerializable, IEnumerable<Card<T>> where T : IComparable
    {
        private List<Card<T>> _cards;

        public Deck(int size)
        {
            _cards = new List<Card<T>>(size);
        }

        public Deck(IEnumerable<Card<T>> cards)
        {
            _cards = new List<Card<T>>(cards);
        }

        public Deck(params Card<T>[] cards)
        {
            _cards = new List<Card<T>>(cards);
        }

        private Random _r;
        protected Random R
        {
            get
            {
                if (_r == null)
                {
                    _r = new Random();
                }
                return _r;
            }
        }

        public int Count => _cards.Count;

        public Card<T> this[int index]
        {
            get
            {
                return _cards[index];
            }
            set
            {
                _cards[index] = value;
            }
        }

        public void Add(Card<T> card)
        {
            _cards.Add(card);
        }

        /// <summary>
        /// Removes the "first" card with matching Value
        /// </summary>
        /// <param name="card"></param>
        public void Remove(Card<T> card)
        {
            _cards.Remove(card);
        }
        /// <summary>
        /// Removes the "first" card with matching Value
        /// </summary>
        /// <param name="value"></param>
        public void Remove(T value)
        {
            _cards.Remove(new Card<T>(value));
        }

        public void RemoveAll(Predicate<Card<T>> predicate)
        {
            _cards.RemoveAll(predicate);
        }

        public void RemoveAllByValue(T value)
        {
            _cards.RemoveAll((Card<T> t) => t.Value.Equals(value));
        }

        public void RemoveAllByTitle(string title)
        {
            _cards.RemoveAll((Card<T> t) => t.Title.Equals(title));
        }

        public void Clear()
        {
            _cards.Clear();
        }

        public Card<T> Random()
        {
            return _cards[R.Next(0, Count - 1)];
        }

        /// <summary>
        /// Not super efficient, but creates a shuffled Stack of Cards
        /// </summary>
        /// <returns></returns>
        public Stack<Card<T>> Shuffle()
        {
            // we want to randomly assign values from an Array in to a Stack without duplicates
            Stack<Card<T>> cards = new Stack<Card<T>>();
            List<int> cardsInDeck = new List<int>(); // need to use an indexable collection
            for (int i = 0; i < Count; i++) // fill it with indices of _cards
                cardsInDeck.Add(i);

            while (true)
            {
                // randomly pick an index from the collection of indices
                int chosenCard;
                if (cardsInDeck.Count == 1)
                {
                    chosenCard = cardsInDeck[0];
                }
                else if (cardsInDeck.Count < Count / 2)
                {
                    // halfway through deck; we want to artificially increase the randomness a bit
                    // without this I was seeing the last card picked last every single time
                    int pick = R.Next(0, (cardsInDeck.Count - 1) * 2);
                    chosenCard = cardsInDeck[(int)Math.Ceiling(pick / 2m)];
                }
                else
                {
                    chosenCard = cardsInDeck[R.Next(0, cardsInDeck.Count - 1)];
                }

                cards.Push(_cards[chosenCard]);
                cardsInDeck.Remove(chosenCard);

                if (cardsInDeck.Count < 1)
                    break;
            }

            return cards;
        }

        public Stack<Card<T>> Sort()
        {
            return Sort(new DefaultCardComparer());
        }

        public Stack<Card<T>> Sort(IComparer<Card<T>> comparer)
        {
            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            List<Card<T>> sortedCards = new List<Card<T>>(_cards);
            sortedCards.Sort(comparer);

            Stack<Card<T>> cards = new Stack<Card<T>>(sortedCards);
            return cards;
        }

        public Stack<Card<T>> Stack()
        {
            Stack<Card<T>> stack = new Stack<Card<T>>(_cards);
            return stack;
        }

        public IEnumerator<Card<T>> GetEnumerator()
        {
            return ((IEnumerable<Card<T>>)_cards).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        public void WriteTo(BinaryWriter writer)
        {
            BinarySerializationRoutines.WriteCollection(writer, _cards.Count, _cards);
        }

        public void ReadFrom(BinaryReader reader)
        {
            int count = reader.ReadInt32();
            _cards = new List<Card<T>>();
            BinarySerializationRoutines.ReadCollection(reader, count, _cards);
        }
        public byte[] ToByteArray()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms))
            {
                WriteTo(bw);
                return ms.ToArray();
            }
        }

        public class DefaultCardComparer : IComparer<Card<T>>
        {
            public int Compare(Card<T> x, Card<T> y)
            {
                return x.Value.CompareTo(y.Value);
            }
        }
    }
}
