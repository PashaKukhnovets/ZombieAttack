using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomeLocationBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI zombiePointsText;

    private void Start()
    {
        zombiePointsText.text = SaveProgress.GetZombiePoints().ToString();
    }

    private void Update()
    {
        zombiePointsText.text = SaveProgress.GetZombiePoints().ToString();
    }
}
