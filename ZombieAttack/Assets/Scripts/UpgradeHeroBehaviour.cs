using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHeroBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject UpgradeWindow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>()) 
        {
            UpgradeWindow.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            UpgradeWindow.SetActive(false);
        }
    }

    public void UpgradeHealth() {
        if (SaveProgress.GetZombiePoints() >= 4000) {
            SaveProgress.BuyUpgradeSkill(4000);
            SaveProgress.UpgradeHealth();
        }
    }

    public void UpgradeDamage()
    {
        if (SaveProgress.GetZombiePoints() >= 2000)
        {
            SaveProgress.BuyUpgradeSkill(2000);
            SaveProgress.UpgradeDamage();
        }
    }
}
