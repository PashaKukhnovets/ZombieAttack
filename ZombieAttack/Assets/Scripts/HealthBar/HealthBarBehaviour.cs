using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthCount;

    private Slider healthBarSlider;
    private GameObject player;

    void Start()
    {
        healthBarSlider = this.GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player");

        healthBarSlider.maxValue = player.GetComponent<PlayerController>().playerHealth;
        healthBarSlider.value = player.GetComponent<PlayerController>().playerHealth;
        healthCount.text = player.GetComponent<PlayerController>().playerHealth.ToString() + "/" + SaveProgress.GetMaxHealth().ToString();
    }

    void Update()
    {
        UpdateHealth();
    }

    public void UpdateHealth() { 
        healthBarSlider.value = player.GetComponent<PlayerController>().playerHealth;
        if(player.GetComponent<PlayerController>().playerHealth > 0)
            healthCount.text = player.GetComponent<PlayerController>().playerHealth.ToString() + "/" 
                + SaveProgress.GetMaxHealth().ToString();
        if(player.GetComponent<PlayerController>().playerHealth <= 0)
            healthCount.text = "0/"
                + SaveProgress.GetMaxHealth().ToString();
    }
}   
