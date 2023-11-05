using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobbing : MonoBehaviour
{
    Vector3 targetHeadPos;
    [SerializeField] float xAmplitude, yAmplitude, bobSpeed, bobSmoothing;
    float timer;

    public void EnableBobbing(Vector3 playerMoveDirection, Transform headTransform, Vector3 defaultHeadPos, bool isGrounded)
    {
        if(playerMoveDirection.magnitude > 0 && isGrounded)
        {
            Vector3 bobbingValue = defaultHeadPos + new Vector3(
                Mathf.Sin(timer/2 * bobSpeed) * xAmplitude, 
                Mathf.Cos(timer * bobSpeed) * yAmplitude, 0);

            targetHeadPos = bobbingValue;
            
            timer += Time.deltaTime;
        }
        else
        {
            targetHeadPos = defaultHeadPos;

            timer = 0;
        }

        headTransform.localPosition = Vector3.MoveTowards(headTransform.localPosition, targetHeadPos, 1/(bobSmoothing*10));

    }

}
