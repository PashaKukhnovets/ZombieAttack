using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletReleaser : StateMachineBehaviour
{
    private GameObject existingBullet;
    [SerializeField] private GameObject bullet;
    private Transform bulletSpawn;
    [SerializeField] private float speedAttack;
    [SerializeField] private ParticleSystem muzzle;
    private ParticleSystem existingMuzzle;

    private float currentTime = 0.0f;
    private float beginPoint = 0.0f;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bool isNextPlaying = (Time.time - beginPoint) > stateInfo.length;
        if (isNextPlaying) {
            ReleaseBullet();
            beginPoint = Time.time;
        }
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bulletSpawn = GameObject.FindGameObjectWithTag("Spawn").transform;
        beginPoint = Time.time;
    }

    public void ReleaseBullet()
    {
        existingBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        existingMuzzle = Instantiate(muzzle, bulletSpawn.position, Quaternion.identity);
        existingBullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * speedAttack);
    }

}
