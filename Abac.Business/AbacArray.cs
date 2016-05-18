using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Abac.Business
{
    /// <summary>
    ///     An array is an ordered collection of values.
    /// </summary>
    public class AbacArray : ICollection<AbacValue>
    {
        private readonly List<AbacValue> _elements = new List<AbacValue>();

        #region Collection

        /// <summary>
        ///     Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="element">
        ///     The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        /// <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </exception>
        public void Add(AbacValue element)
        {
            _elements.Add(element);
        }

        /// <summary>
        ///     Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </exception>
        public void Clear()
        {
            _elements.Clear();
        }

        /// <summary>
        ///     Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="element" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />;
        ///     otherwise, false.
        /// </returns>
        /// <param name="element">
        ///     The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        public bool Contains(AbacValue element)
        {
            return _elements.Contains(element);
        }

        /// <summary>
        ///     Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1" /> to an
        ///     <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
        /// </summary>
        /// <param name="array">
        ///     The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from
        ///     <see cref="T:System.Collections.Generic.ICollection`1" />. The <see cref="T:System.Array" /> must have zero-based
        ///     indexing.
        /// </param>
        /// <param name="arrayIndex">
        ///     The zero-based index in <paramref name="array" /> at which copying begins.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="array" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="arrayIndex" /> is less than 0.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="array" /> is multidimensional.
        ///     -or-
        ///     <paramref name="arrayIndex" /> is equal to or greater than the length of <paramref name="array" />.
        ///     -or-
        ///     The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1" /> is greater than the
        ///     available space from <paramref name="arrayIndex" /> to the end of the destination <paramref name="array" />.
        ///     -or-
        ///     Type <paramref name="T" /> cannot be cast automatically to the type of the destination <paramref name="array" />.
        /// </exception>
        public void CopyTo(AbacValue[] array, int arrayIndex)
        {
            _elements.CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///     Removes the first occurrence of a specific object from the
        ///     <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="element" /> was successfully removed from the
        ///     <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if
        ///     <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        /// <param name="element">
        ///     The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        /// <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </exception>
        public bool Remove(AbacValue element)
        {
            return _elements.Remove(element);
        }

        /// <summary>
        ///     Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <returns>
        ///     The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public int Count
        {
            get { return _elements.Count; }
        }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        /// <returns>
        ///     true if the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only; otherwise, false.
        /// </returns>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        ///     Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<AbacValue> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        /// <summary>
        ///     Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        ///     An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        [DispId(-4)]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Deserialization

        internal static AbacArray FromJsonString(string json, out int nextIndex)
        {
            var result = new AbacArray();
            var i = 1;
            while (i < json.Length)
            {
                var c = json[i];
                if (char.IsWhiteSpace(c))
                {
                    i++;
                }
                else
                    switch (c)
                    {
                        case ',':
                            i++;
                            break;
                        case ']':
                            nextIndex = i + 1;
                            return result;
                        default:
                            result.Add(AbacValue.FromJsonString(json.Substring(i), out nextIndex));
                            i += nextIndex;
                            break;
                    }
            }

            nextIndex = i;
            return result;
        }

        #endregion

        #region Equality

        public override bool Equals(object obj)
        {
            var v = (AbacArray) obj;
            if (v == null)
                return false;
            foreach (var e in this)
                if (!v.Contains(e))
                    return false;
            return true;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        #endregion

        #region Serialization

        public override string ToString()
        {
            return ToJsonString("");
        }

        internal string ToJsonString(string indent)
        {
            return string.Format("[{0}]", string.Join(", ", ElementsToStrings(indent)));
        }

        private string[] ElementsToStrings(string indent)
        {
            var strings = new List<string>();
            foreach (var e in this)
                strings.Add(e.ToJsonString(indent));
            return strings.ToArray();
        }

        #endregion
    }
}