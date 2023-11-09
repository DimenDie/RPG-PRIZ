using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBossAttack : MonoBehaviour
{
    public GameObject TheEnemy;
    public int AttackTrigger;
    public int DealingDamage;

    void Update()
    {
        if (AttackTrigger == 0)
        {
            TheEnemy.GetComponent<Animation>().Play("Walk");
        }
        if (AttackTrigger == 1)
        {
            if (DealingDamage == 0)
            {
                TheEnemy.GetComponent<Animation>().Play("Attack");
                StartCoroutine(TakingDamage());
            }
        }
    }

    IEnumerator TakingDamage()
    {
        DealingDamage = 2;
        yield return new WaitForSeconds(1.1f);
        if (SpiderEnemy.GlobalSpider != 6)
        {
            HealthMonitor.healthValue -= 20;
        }
        yield return new WaitForSeconds(0.4f);
        DealingDamage = 0;
    }

    void OnTriggerEnter()
    {
        AttackTrigger = 1;
    }

    void OnTriggerExit()
    {
        AttackTrigger = 0;
    }

}
