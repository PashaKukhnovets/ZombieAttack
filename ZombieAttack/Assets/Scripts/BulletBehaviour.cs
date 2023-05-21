using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Weapon"))
            Destroy(this.gameObject);
    }
}
