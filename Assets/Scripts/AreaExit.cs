using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            
        }
    }
}
