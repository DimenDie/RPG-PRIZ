using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    public int AttackTrigger;
    public int DealingDamage;

    void Update()
    {
        print(AttackTrigger);
        if (AttackTrigger == 0)
        {
            this.GetComponentInChildren<Animator>().Play("Walk");
        }
        if (AttackTrigger == 1)
        {
            if (DealingDamage == 0)
            {
                this.GetComponentInChildren<Animator>().Play("Attack");
                StartCoroutine(TakingDamage());
            }
        }
    }

    IEnumerator TakingDamage()
    {
        DealingDamage = 2;
        yield return new WaitForSeconds(1.1f);
        HealthMonitor.healthValue -= 20;
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
