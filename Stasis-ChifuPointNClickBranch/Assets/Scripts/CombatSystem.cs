using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public int playerSkill = 50;
    public int strength = 3;
    public int enemyEvasion = 30;
    public int weaponDamageMin = 3;
    public int weaponDamageMax = 12;
    public float attackRange = 3.0f;
    public Camera playerCamera;
    public LayerMask enemyLayerMask;
    private EnemyAI targetedEnemy;
    private bool alreadyAttacked;
    public float timeBetweenAttacks;
    


    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !PauseMenu.Is_in_pause)
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (!alreadyAttacked && Player.stamina >= 2f)
        {
            CheckForEnemy();
            if (targetedEnemy != null)
            {
                bool hit = CalculateHitChance();
                if (hit)
                {
                    int damage = CalculateDamage();
                    DealDamage(damage);
                    Debug.Log("Deal  " + damage + " to enemy");
                }
                else
                {
                    Debug.Log("Miss on enemy!");
                }
            }
            else
            {
                Debug.Log("Hit in air");
            }


            Player pl = FindAnyObjectByType<Player>();
            pl.ReduceStamina(2f);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private bool CalculateHitChance()
    {
        int hitChance = playerSkill - enemyEvasion;
        hitChance = Mathf.Clamp(hitChance, 0, 100);
        int roll = Random.Range(0, 100);
        return roll <= hitChance;
    }

    private int CalculateDamage()
    {
        int damage = Random.Range(weaponDamageMin, weaponDamageMax) + strength;
        return damage;
    }


    private void CheckForEnemy()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2);

        Ray ray = playerCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackRange, enemyLayerMask))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                targetedEnemy = hit.collider.GetComponent<EnemyAI>();
            }
            else
            {
                targetedEnemy = null;
                Debug.Log("This is not enemy");
            }
        }
        else
        {
            targetedEnemy = null;
            Debug.Log("No еnemy there");
        }
    }

    private void DealDamage(int damage)
    {
        targetedEnemy.TakeDamage(damage);
    }
    public void UpdateSkills(int s, int accuracy)
    {
        strength = s;
        playerSkill = accuracy;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}