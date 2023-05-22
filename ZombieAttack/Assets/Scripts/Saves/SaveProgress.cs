using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveProgress
{
    private static int metalPoints;
    private static int zombiePoints;
    private static float health = 100.0f;
    private static float damage = 15.0f;

    public static void SetMetalPoints(int value) {
        metalPoints = value;
    }

    public static void SetZombiePoints(int value) {
        zombiePoints = value;
    }

    public static void PlusZombiePoints(int value)
    {
        zombiePoints += value;
    }

    public static int GetMetalPoints() {
        return metalPoints;
    }

    public static int GetZombiePoints() {
        return zombiePoints;
    }

    public static void BuyUpgradeSkill(int value) {
        zombiePoints -= value;
    }

    public static void UpgradeHealth() {
        health += 15.0f;
    }

    public static void UpgradeDamage() {
        damage += 10.0f;
    }

    public static float GetMaxHealth() {
        return health;
    }

    public static float GetDamage() {
        return damage;
    }
}
