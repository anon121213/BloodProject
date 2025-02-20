using System;
using System.Collections.Generic;

namespace _Scripts.Common.Extensions
{
  public static class DictionaryExtensions
  {
    public static Dictionary<TKey, TValue> With<TKey, TValue>(
      this Dictionary<TKey, TValue> dictionary, 
      TKey key, 
      TValue value)
    {
      if (dictionary == null)
      {
        throw new ArgumentNullException(nameof(dictionary));
      }

      dictionary[key] = value;

      return dictionary;
    }

    public static Dictionary<TKey, TValue> GetSameDefaultDictionary<TKey, TValue>(
      this Dictionary<TKey, TValue> dictionary)
    {
      if (dictionary == null)
      {
        throw new ArgumentNullException(nameof(dictionary));
      }

      var newDictionary = new Dictionary<TKey, TValue>();

      var keys = new List<TKey>(dictionary.Keys);

      foreach (var key in keys)
      {
        newDictionary.Add(key, default(TValue));
      }

      return newDictionary;
    }
  }
}