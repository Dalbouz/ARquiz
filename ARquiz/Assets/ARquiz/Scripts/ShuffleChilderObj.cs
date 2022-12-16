using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShuffleChilderObj : MonoBehaviour
{
    public List<Transform> item = new List<Transform>();
    public void Shuffle()
    {
        List<int> Index = new List<int>();

        for (int i = 0; i < transform.childCount; i++)
        {
            Index.Add(i);
            item.Add(transform.GetChild(i));
        }
        foreach (Transform transform in item)
        {
            transform.SetSiblingIndex(Index[Random.Range(0, Index.Count)]);
        }
        
    }
}
