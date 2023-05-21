using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    private ZombieController zombie;
    private Pursue zombiePursue;
    private Animator animator;

    void Start()
    {
        zombie = this.GetComponent<ZombieController>();
        animator = this.GetComponent<Animator>();
        zombiePursue = this.GetComponent<Pursue>();
        zombiePursue.ZombieWalk += ZombieWalk;
        zombie.ZombieAttack += ZombieAttack;
        zombie.ZombieAttackFalse += ZombieAttackFalse;
        zombie.ZombieDeath += ZombieDeath;
    }

    public void ZombieWalk() {
        animator.SetBool("isWalking", true);
    }

    public void ZombieAttack() {
        animator.SetBool("isAttacking", true);
        animator.SetBool("isWalking", false);
    }

    public void ZombieAttackFalse()
    {
        animator.SetBool("isAttacking", false);
        animator.SetBool("isWalking", true);
    }

    public void ZombieDeath() {
        animator.SetBool("isDead", true);
    }
}
