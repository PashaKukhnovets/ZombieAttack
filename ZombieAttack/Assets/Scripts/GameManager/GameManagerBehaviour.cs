using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI zombieText;
    [SerializeField] private TextMeshProUGUI metalCurrencyText;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject zombieBossPrefab;
    [SerializeField] private GameObject healthBonusPrefab;
    [SerializeField] private GameObject doubleDamageBonusPrefab;
    [SerializeField] private GameObject DDTimer;
    [SerializeField] private GameObject metalCurrency;

    private GameObject player;
    private GameObject[] zombies;
    private bool isZombieBossInstance = true;
    private bool isHealthBonusInstance = true;
    private bool isDDBonusInstance = true;
    private bool isDDTimer = false;
    private bool isUpdateZombiePts = true;
    private bool isMetalCurrrencyInstance = true;

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
        UpdateMetalCurrencyText();
        InstanceZombie();
        InstanceZombieBoss();
        InstanceHealthBonus();
        InstanceDoubleDamageBonus();
        InstanceMetalCurrency();
        EnableDDTimer();
    }

    private void UpdateZombieCountText()
    {
        zombieText.text = (zombieDeathCount * 100).ToString();
    }

    private void UpdateMetalCurrencyText()
    {
        metalCurrencyText.text = SaveProgress.GetMetalPoints().ToString();
    }

    public void RestartLevel()
    {
        if (isUpdateZombiePts) {
            SaveProgress.PlusZombiePoints(zombieDeathCount * 100);
            isUpdateZombiePts = false;
        }
        deathScreen.SetActive(true);
    }

    private void InstanceMetalCurrency() { 
        if (zombieDeathCount % 10 == 0 && zombieDeathCount != 0 && isMetalCurrrencyInstance)
        {
            Instantiate(metalCurrency, new Vector3(Random.Range(-15.0f, 17.5f), 0.0f,
                Random.Range(-15.18f, 15.15f)), Quaternion.identity);
            isMetalCurrrencyInstance = false;
        }

        if (zombieDeathCount % 10 != 0)
            isMetalCurrrencyInstance = true;
    }

    private void InstanceZombie()
    {
        zombies = GameObject.FindGameObjectsWithTag("Zombie");

        if (zombies.Length < 10)
        {
            Instantiate(zombiePrefab, new Vector3(Random.Range(-15.0f, 17.5f), 0.0f,
                Random.Range(-15.18f, 15.15f)), Quaternion.identity);
        }
    }

    private void InstanceZombieBoss()
    {
        if (zombieDeathCount % 10 == 0 && zombieDeathCount != 0 && isZombieBossInstance)
        {
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

    private void EnableDDTimer()
    {
        if (isDDTimer)
        {
            DDTimer.SetActive(true);
            isDDTimer = false;
        }
    }

    public void SetDDTimer(bool isTimer)
    {
        this.isDDTimer = isTimer;
    }

}
