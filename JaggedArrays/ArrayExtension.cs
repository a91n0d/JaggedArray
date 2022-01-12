using System;

#pragma warning disable S2368

namespace JaggedArrays
{
    public static class ArrayExtension
    {
        private delegate int Order(int[] source);

        /// <summary>
        /// Orders of sort.
        /// </summary>
        public enum OrderOfSort
        {
            /// <summary>
            /// "Sum" - orders the rows in a jagged-array by ascending of the sum of the elements in them.
            /// </summary>
            Sum,

            /// <summary>
            /// "Max" - оrders the rows in a jagged-array by ascending of the max of the elements in them.
            /// </summary>
            Max,
        }

        /// <summary>
        /// Orders the rows in a jagged-array by ascending of the sum of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByAscendingBySum(this int[][] source)
        {
            source.BubbleSortByAscending(OrderOfSort.Sum);
        }
        
        /// <summary>
        /// Orders the rows in a jagged-array by descending of the sum of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByDescendingBySum(this int[][] source)
        {
            source.BubbleSortByDescending(OrderOfSort.Sum);
        }
        
        /// <summary>
        /// Orders the rows in a jagged-array by ascending of the max of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByAscendingByMax(this int[][] source)
        {
            source.BubbleSortByAscending(OrderOfSort.Max);
        }
        
        /// <summary>
        /// Orders the rows in a jagged-array by descending of the max of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByDescendingByMax(this int[][] source)
        {
            source.BubbleSortByDescending(OrderOfSort.Max);
        }

        /// <summary>
        /// Get sum element of array.
        /// </summary>
        /// <param name="source">The int-array to sort.</param>
        /// <returns>Sum element of array.</returns>
        public static int GetSumOfElements(this int[] source)
        {
            if (source is null)
            {
                return int.MinValue;
            }

            int sum = 0;
            foreach (int s in source)
            {
                sum += s;
            }

            return sum;
        }

        /// <summary>
        /// Get the the max of the elements of array.
        /// </summary>
        /// <param name="source">The int-array to sort.</param>
        /// <returns>The max of the elements of array.</returns>
        public static int GetMaxOfElements(this int[] source)
        {
            if (source is null)
            {
                return int.MinValue;
            }

            int maxOfElements = source[0];
            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] > maxOfElements)
                {
                    maxOfElements = source[i];
                }
            }

            return maxOfElements;
        }

        /// <summary>
        /// The bubble sort method by ascending.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <param name="order">"Sum" - orders the rows in a jagged-array by ascending of the sum of the elements in them.
        /// "Max" - оrders the rows in a jagged-array by ascending of the max of the elements in them.</param>
        public static void BubbleSortByAscending(this int[][] source, OrderOfSort order)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Array can not be null.");
            }

            Order orderDel = order switch
            {
                OrderOfSort.Sum => GetSumOfElements,
                OrderOfSort.Max => GetMaxOfElements,
                _ => throw new ArgumentException("Invalid value.", nameof(order)),
            };
            for (int i = source.Length; i > 0; i--)
            {
                for (int j = 1; j < i; j++)
                {
                    if (orderDel(source[j]) <= orderDel(source[j - 1]))
                    {
                        (source[j], source[j - 1]) = (source[j - 1], source[j]);
                    }
                }
            }
        }

        /// <summary>
        /// The bubble sort method by descending.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <param name="order">"Sum" - orders the rows in a jagged-array by ascending of the sum of the elements in them.
        /// "Max" - оrders the rows in a jagged-array by ascending of the max of the elements in them.</param>
        public static void BubbleSortByDescending(this int[][] source, OrderOfSort order)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Array can not be null.");
            }

            Order orderDel = order switch
            {
                OrderOfSort.Sum => GetSumOfElements,
                OrderOfSort.Max => GetMaxOfElements,
                _ => throw new ArgumentException("Invalid value.", nameof(order)),
            };
            for (int i = source.Length; i > 0; i--)
            {
                for (int j = 1; j < i; j++)
                {
                    if (orderDel(source[j]) > orderDel(source[j - 1]))
                    {
                        (source[j], source[j - 1]) = (source[j - 1], source[j]);
                    }
                }
            }
        }
    }
}
