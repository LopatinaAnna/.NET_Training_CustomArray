using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomArray
{
    public class CustomArray<T> : IEnumerable<T>
    {
        /// <summary>
        /// Should return first index of array
        /// </summary>
        public int First { get; private set; }

        /// <summary>
        /// Should return last index of array
        /// </summary>
        public int Last { get => Length - 1 + First; }

        /// <summary>
        /// Should return length of array
        /// <exception cref="ArgumentException">Thrown when value was smaller than 0</exception>
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Should return array
        /// </summary>
        public T[] Array { get; }

        /// <summary>
        /// Constructor with first index and length
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="length">Length</param>
        public CustomArray(int first, int length)
        {
            if (length <= 0)
                throw new ArgumentException("length is smaler than 0");

            First = first;
            Length = length;
            Array = new T[Length];
        }

        /// <summary>
        /// Constructor with first index and collection
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Collection</param>
        ///  <exception cref="NullReferenceException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when count is smaler than 0</exception>
        public CustomArray(int first, IEnumerable<T> list)
        {
            if (list is null)
                throw new NullReferenceException("list is null");

            if (list.Count() < 0)
                throw new ArgumentException("count is smaler than 0");

            if (list.ToArray().Length <= 0)
                throw new ArgumentException("length is smaler than 0");

            First = first;
            Array = list.ToArray();
            Length = Array.Length;
        }

        /// <summary>
        /// Constructor with first index and params
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Params</param>
        ///  <exception cref="ArgumentNullException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when list without elements </exception>
        public CustomArray(int first, params T[] list)
        {
            if (list is null)
                throw new ArgumentNullException("list");

            if (list.Length <= 0)
                throw new ArgumentException("list without elements");

            First = first;
            Array = list;
            Length = Array.Length;
        }

        /// <summary>
        /// Indexer with get and set
        /// </summary>
        /// <param name="item">Int index</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when index out of array range</exception>
        /// <exception cref="ArgumentNullException">Thrown in set  when value passed in indexer is null</exception>
        public T this[int item]
        {
            get
            {
                if (item < First || item > Last)
                    throw new ArgumentException("Index out of array range");
                return Array[item - First];
            }
            set
            {
                if (item < First || item > Last)
                    throw new ArgumentException("Index out of array range");
                if (value == null)
                    throw new ArgumentNullException("value");
                Array[item - First] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)Array).GetEnumerator();
        }
    }
}