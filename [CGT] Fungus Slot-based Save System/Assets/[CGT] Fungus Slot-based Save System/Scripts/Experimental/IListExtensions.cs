using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGT.Unity.Fungus.SBSaveSys
{
    public static class IListExtensions 
    {
        public static void AddRange<T>(this IList<T> list, IList<T> toAdd)
        {
            for (int i = 0; i < toAdd.Count; i++)
            {
                var item = toAdd[i];
                list.Add(item);
            }
        }
    }
}