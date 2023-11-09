using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAI : MonoBehaviour
{
    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 30;
    public float attackRange;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public RaycastHit Shot;
    public int DealingDamage;

    bool chasePlayer, attackPlayer, duringAttack;

    private void Start()
    {
        EnemySpeed = 0.04f;
    }

    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot)) // смотріт
        {
            TargetDistance = Shot.distance;
            if (TargetDistance <= AllowedRange && Shot.transform.CompareTag("Player")) // відіт
            {
                print("vidit");
                if (TargetDistance <= attackRange) // атакует
                {
                    attackPlayer = true;
                    chasePlayer = false;
                    if (!duringAttack)
                        StartCoroutine(TakingDamage());
                }
                else // догоняет
                {
                    attackPlayer = false;
                    chasePlayer = true;
                    transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);
                }
            }
            else // не відіт
            {
                attackPlayer = false;
                chasePlayer = false;
            }


            TheEnemy.GetComponent<Animator>().SetBool("duringAttack", attackPlayer);
            TheEnemy.GetComponent<Animator>().SetBool("duringChase", chasePlayer);
        }

    }

    IEnumerator TakingDamage()
    {
        duringAttack = true;
        yield return new WaitForSeconds(0.5f);
        if (SpiderEnemy.GlobalSpider != 6)
            HealthMonitor.healthValue -= 10;
        yield return new WaitForSeconds(0.4f);
        duringAttack = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, AllowedRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
