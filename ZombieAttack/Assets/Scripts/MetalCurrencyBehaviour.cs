using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalCurrencyBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            SaveProgress.PlusMetalPoints(1);
            Destroy(this.gameObject);
        }
    }
}
