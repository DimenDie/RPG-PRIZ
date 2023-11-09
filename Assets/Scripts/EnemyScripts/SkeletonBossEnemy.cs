using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SkeletonBossEnemy : MonoBehaviour
{
    public int enemyHealth = 5;
    public SpiderBossAI skeletonAI;
    public static int GlobalSpider;
    public SkeletonAttack SpiderAttackScript;
    public GameObject fadeIn;
    bool ended = true;

    void Start()
    {
        skeletonAI = GetComponent<SpiderBossAI>();
        SpiderAttackScript = GetComponent<SkeletonAttack>();
    }

    void DeductPoints(int DamageAmount)
    {
        enemyHealth -= DamageAmount;
    }

    void Update()
    {
        if(enemyHealth == 0 && ended == false)
        {
            StartCoroutine(SkeletonDeath());

        }
    }

    IEnumerator SkeletonDeath()
    {
        ended = true;
        skeletonAI.enabled = false;
        SpiderAttackScript.enabled = false;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponentInChildren<Animator>().Play("Death");
        yield return new WaitForSeconds(0.3f);
        fadeIn.SetActive(true);
        fadeIn.GetComponent<Animation>().Play("FadeInAnimation");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(4);
    }
}
