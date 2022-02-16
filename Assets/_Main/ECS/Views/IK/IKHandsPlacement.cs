using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKHandsPlacement : MonoBehaviour
{
    public Animator animator;
    
    public Transform targetPosLeft;
    private void OnAnimatorIK(int layerIndex)
    {
        if(layerIndex != animator.GetLayerIndex("Base Layer") || !targetPosLeft)
            return;
        
        if (animator)
        {
            //animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);

            //animator.SetIKPosition(AvatarIKGoal.RightHand, targetPosRight.position);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, targetPosLeft.position);
        }
    }
}
