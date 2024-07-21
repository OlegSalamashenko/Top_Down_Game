using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goinCoinPrefab;


    public void DropItem()
    { 
        Instantiate(goinCoinPrefab,transform.position,Quaternion.identity);
    }
}
