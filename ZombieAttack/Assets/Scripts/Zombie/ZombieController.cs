using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private ParticleSystem zombieBlood;
    private GameObject player;
    private bool isZombieCount = true;

    public float zombieHealth = 100.0f;
    public float damage = 7.0f;

    public event UnityAction ZombieAttack;
    public event UnityAction ZombieAttackFalse;
    public event UnityAction ZombieDeath;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (this.zombieHealth <= 0.0f)
        {
            if (isZombieCount)
            {
                GameManagerBehaviour.zombieDeathCount++;
            }
            isZombieCount = false;
            ZombieDeath?.Invoke();
            this.gameObject.GetComponent<Pursue>().enabled = false;
            this.gameObject.GetComponent<Face>().enabled = false;
            StartCoroutine(DeathCoroutine());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
            ZombieAttack?.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            this.zombieHealth -= player.GetComponent<PlayerController>().playerDamage;
            Instantiate(zombieBlood, new Vector3(this.transform.position.x + 0.3f, 1.1f, this.transform.position.z), Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.GetComponent<PlayerController>())
            ZombieAttackFalse?.Invoke();

    }

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(this.gameObject);
    }
}
