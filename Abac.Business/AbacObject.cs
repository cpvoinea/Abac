using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Abac.Business
{
    /// <summary>
    ///     An object is an unordered set of name/value pairs.
    /// </summary>
    public class AbacObject : IDictionary<string, AbacValue>
    {
        private readonly Dictionary<string, AbacValue> _members = new Dictionary<string, AbacValue>();

        #region Deserialization

        internal static AbacObject FromJsonString(string json, out int nextIndex)
        {
            var result = new AbacObject();
            var i = 1;
            string name = null;
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
                        case '"':
                            name = AbacValue.ParseStringValue(json.Substring(i), out nextIndex);
                            i += nextIndex;
                            break;
                        case ',':
                            i++;
                            break;
                        case '}':
                            nextIndex = i + 1;
                            return result;
                        default:
                            if (c == ':' && !string.IsNullOrEmpty(name))
                            {
                                result.Add(name, AbacValue.FromJsonString(json.Substring(i + 1), out nextIndex));
                                i += nextIndex + 1;
                                name = null;
                            }
                            else
                            {
                                i = json.Length;
                            }
                            break;
                    }
            }

            nextIndex = i;
            return result;
        }

        #endregion

        #region Dictionary

        /// <summary>
        ///     Determines whether the <see cref="T:System.Collections.Generic.IDictionary`2" /> contains an element with the
        ///     specified key.
        /// </summary>
        /// <returns>
        ///     true if the <see cref="T:System.Collections.Generic.IDictionary`2" /> contains an element with the key; otherwise,
        ///     false.
        /// </returns>
        /// <param name="name">
        ///     The key to locate in the <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="name" /> is null.
        /// </exception>
        public bool ContainsKey(string name)
        {
            return _members.ContainsKey(name);
        }

        /// <summary>
        ///     Adds an element with the provided key and value to the <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <param name="name">
        ///     The object to use as the key of the element to add.
        /// </param>
        /// <param name="value">
        ///     The object to use as the value of the element to add.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="name" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     An element with the same key already exists in the <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.Generic.IDictionary`2" /> is read-only.
        /// </exception>
        public void Add(string name, AbacValue value)
        {
            _members[name] = value;
        }

        /// <summary>
        ///     Removes the element with the specified key from the <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <returns>
        ///     true if the element is successfully removed; otherwise, false.  This method also returns false if
        ///     <paramref name="key" /> was not found in the original <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </returns>
        /// <param name="name">The key of the element to remove.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="name" /> is null.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.Generic.IDictionary`2" /> is read-only.
        /// </exception>
        public bool Remove(string name)
        {
            return _members.Remove(name);
        }

        /// <summary>
        ///     Gets the value associated with the specified key.
        /// </summary>
        /// <returns>
        ///     true if the object that implements <see cref="T:System.Collections.Generic.IDictionary`2" /> contains an element
        ///     with the specified key; otherwise, false.
        /// </returns>
        /// <param name="name">The key whose value to get.</param>
        /// <param name="value">
        ///     When this method returns, the value associated with the specified key, if the key is found; otherwise, the default
        ///     value for the type of the <paramref name="value" /> parameter. This parameter is passed uninitialized.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="name" /> is null.
        /// </exception>
        public bool TryGetValue(string name, out AbacValue value)
        {
            return _members.TryGetValue(name, out value);
        }

        /// <summary>
        ///     Gets or sets the element with the specified key.
        /// </summary>
        /// <returns>The element with the specified key.</returns>
        /// <param name="name">
        ///     The key of the element to get or set.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="name" /> is null.
        /// </exception>
        /// <exception cref="T:System.Collections.Generic.KeyNotFoundException">
        ///     The property is retrieved and <paramref name="name" /> is not found.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///     The property is set and the <see cref="T:System.Collections.Generic.IDictionary`2" /> is read-only.
        /// </exception>
        public AbacValue this[string name]
        {
            get { return _members[name]; }
            set { _members[name] = value; }
        }

        /// <summary>
        ///     Gets an <see cref="T:System.Collections.Generic.ICollection`1" /> containing the keys of the
        ///     <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <returns>
        ///     An <see cref="T:System.Collections.Generic.ICollection`1" /> containing the keys of the object that implements
        ///     <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </returns>
        public ICollection<string> Keys
        {
            get { return _members.Keys; }
        }

        /// <summary>
        ///     Gets an <see cref="T:System.Collections.Generic.ICollection`1" /> containing the values in the
        ///     <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <returns>
        ///     An <see cref="T:System.Collections.Generic.ICollection`1" /> containing the values in the object that implements
        ///     <see cref="T:System.Collections.Generic.IDictionary`2" />.
        /// </returns>
        public ICollection<AbacValue> Values
        {
            get { return _members.Values; }
        }

        /// <summary>
        ///     Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">
        ///     The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        /// <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </exception>
        public void Add(KeyValuePair<string, AbacValue> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        ///     Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </exception>
        public void Clear()
        {
            _members.Clear();
        }

        /// <summary>
        ///     Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />;
        ///     otherwise, false.
        /// </returns>
        /// <param name="item">
        ///     The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </param>
        public bool Contains(KeyValuePair<string, AbacValue> item)
        {
            return _members.ContainsKey(item.Key);
        }

        /// <summary>
        ///     NOT IMPLEMENTED
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(KeyValuePair<string, AbacValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <returns>
        ///     The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public int Count
        {
            get { return _members.Count; }
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

        public bool Remove(KeyValuePair<string, AbacValue> item)
        {
            return _members.Remove(item.Key);
        }

        /// <summary>
        ///     Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<KeyValuePair<string, AbacValue>> GetEnumerator()
        {
            return _members.GetEnumerator();
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

        #region Equality

        public override bool Equals(object obj)
        {
            var v = (AbacObject) obj;
            if (v == null)
                return false;
            foreach (var k in Keys)
                if (!v.ContainsKey(k) || !v[k].Equals(this[k]))
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
            return string.Format("\r\n{0}{{\r\n{1}\r\n{0}}}", indent,
                string.Join(",\r\n", MembersToJsonStrings(indent + "\t")));
        }

        private string[] MembersToJsonStrings(string indent)
        {
            var strings = new List<string>();
            foreach (var key in Keys)
                strings.Add(string.Format("{0}\"{1}\": {2}", indent, key, this[key].ToJsonString(indent)));
            return strings.ToArray();
        }

        #endregion
    }
}