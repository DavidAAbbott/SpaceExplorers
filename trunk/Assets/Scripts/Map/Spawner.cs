using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public int Max;
    public List<GameObject> prefabList = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < Max; i++)
        {
            int prefabIndex = Random.Range(0, prefabList.Count - 1);
            Instantiate(prefabList[prefabIndex]);
        }
    }
}