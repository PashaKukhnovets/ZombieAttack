using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI zombieText;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject zombieBossPrefab;
    [SerializeField] private GameObject healthBonusPrefab;
    [SerializeField] private GameObject doubleDamageBonusPrefab;
    [SerializeField] private GameObject DDTimer;

    private GameObject player;
    private GameObject[] zombies;
    private bool isZombieBossInstance = true;
    private bool isHealthBonusInstance = true;
    private bool isDDBonusInstance = true;
    private bool isDDTimer = false;
    
    public static int zombieDeathCount = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().PlayerDeath += RestartLevel;
        zombieDeathCount = 0;
    }
    
    void Update()
    {
        UpdateZombieCountText();
        InstanceZombie();
        InstanceZombieBoss();
        InstanceHealthBonus();
        InstanceDoubleDamageBonus();
        EnableDDTimer();
    }

    private void UpdateZombieCountText() {
        zombieText.text = (zombieDeathCount * 100).ToString();
    }

    public void RestartLevel() {
        deathScreen.SetActive(true);
    }

    private void InstanceZombie() {
        zombies = GameObject.FindGameObjectsWithTag("Zombie");

        if (zombies.Length < 10) {
            Instantiate(zombiePrefab, new Vector3(Random.Range(-15.0f, 17.5f), 0.0f, 
                Random.Range(-15.18f, 15.15f)), Quaternion.identity);
        }
    }

    private void InstanceZombieBoss() {
        if (zombieDeathCount % 10 == 0 && zombieDeathCount != 0 && isZombieBossInstance) {
            Instantiate(zombieBossPrefab, new Vector3(Random.Range(-15.0f, 17.5f), 0.0f,
                Random.Range(-15.18f, 15.15f)), Quaternion.identity);
            isZombieBossInstance = false;
        }

        if (zombieDeathCount % 10 != 0)
            isZombieBossInstance = true;
    }

    private void InstanceHealthBonus()
    {
        if (zombieDeathCount % 10 == 0 && zombieDeathCount != 0 && isHealthBonusInstance)
        {
            Instantiate(healthBonusPrefab, new Vector3(Random.Range(-15.0f, 17.5f), 0.9f,
                Random.Range(-15.18f, 15.15f)), Quaternion.identity);
            isHealthBonusInstance = false;
        }

        if (zombieDeathCount % 10 != 0)
            isHealthBonusInstance = true;
    }

    private void InstanceDoubleDamageBonus()
    {
        if (zombieDeathCount % 10 == 0 && zombieDeathCount != 0 && isDDBonusInstance)
        {
            Instantiate(doubleDamageBonusPrefab, new Vector3(Random.Range(-15.0f, 17.5f), 0.9f,
                Random.Range(-15.18f, 15.15f)), Quaternion.identity);
            isDDBonusInstance = false;
        }

        if (zombieDeathCount % 10 != 0)
            isDDBonusInstance = true;
    }

    private void EnableDDTimer() {
        if (isDDTimer) {
            DDTimer.SetActive(true);
            isDDTimer = false;
        }
    }

    public void SetDDTimer(bool isTimer) {
        this.isDDTimer = isTimer;
    }

}
