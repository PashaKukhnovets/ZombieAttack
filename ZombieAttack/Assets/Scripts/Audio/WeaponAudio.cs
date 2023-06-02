using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : MonoBehaviour
{
    [SerializeField] private AudioSource m4Shoot;
    [SerializeField] private AudioSource zombieAttack;
    public void PlayAudioShoot() {
        m4Shoot.Play();
    }

    public void PlayAudioAttack() {
        zombieAttack.Play();
    }

}
