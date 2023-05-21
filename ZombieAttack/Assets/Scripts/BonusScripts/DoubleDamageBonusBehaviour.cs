using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamageBonusBehaviour : MonoBehaviour
{
    private GameObject player;
    private GameObject gameManager;
    private float currentDamage;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentDamage = player.GetComponent<PlayerController>().playerDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager");
            gameManager.GetComponent<GameManagerBehaviour>().SetDDTimer(true);
            player.GetComponent<PlayerController>().playerDamage *= 2.0f;
            StartCoroutine(DoubleDamageCoroutine());
            this.gameObject.transform.position = new Vector3(0.0f, 100.0f, 0.0f);
        }
    }

    private IEnumerator DoubleDamageCoroutine() { 
        yield return new WaitForSeconds(5.0f);
        player.GetComponent<PlayerController>().playerDamage = currentDamage;
        Destroy(this.gameObject);
    }
}
