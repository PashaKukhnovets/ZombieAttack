using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController player;

    private void Start()
    {
        player.PlayerIdle += PlayerIdle;
        player.PlayerRun += PlayerRun;
        player.PlayerAttack += PlayerAttack;
        player.PlayerDeath += PlayerDeath;
        player.PlayerFireRifle += PlayerFireRifle;
    }

    public void PlayerRun()
    {
        animator.SetBool("IsFire", false);
        animator.SetBool("IsFireRifle", false);
        animator.SetBool("IsRunning", true);
        animator.speed = player.GetComponent<PlayerController>().DirectionSpeed;
    }

    public void PlayerAttack()
    {
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsFireRifle", false);
        animator.SetBool("IsFire", true);
    }

    public void PlayerIdle()
    {
        animator.SetBool("IsFireRifle", false);
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsFire", false);
    }

    public void PlayerDeath() {
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsFire", false);
        animator.SetBool("IsFireRifle", false);
        animator.SetBool("IsDeath", true);
    }

    public void PlayerFireRifle() {
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsFire", false);
        animator.SetBool("IsFireRifle", true);
    }
}
