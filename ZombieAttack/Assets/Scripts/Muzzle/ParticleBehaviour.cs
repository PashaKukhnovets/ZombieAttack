using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine(DeleteMuzzle());
    }

    private IEnumerator DeleteMuzzle() {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}
