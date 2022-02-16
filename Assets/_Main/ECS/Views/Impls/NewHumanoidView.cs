using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ecs.Views.Linkable.Impl
{
    public abstract class NewHumanoidView : LinkableView
    {
        [SerializeField] protected Animator Animator;
        protected static readonly int IsRun = Animator.StringToHash("IsRun");
        
        public virtual void SetInputAngle(float inputAngle)
        {
            Animator.SetFloat("InputAngle", inputAngle);
        }
        
        public void OnWeaponFire(bool enable)
        {
            Animator.SetBool("IsShoot", enable);
        }

        public virtual void SetIsReload(bool reload)
        {
            Animator.SetBool("IsReload", reload);
        }
        
        public virtual void SetMoveDirection(float horizontal, float vertical)
        {
            Animator.SetFloat("Horizontal", horizontal);
            Animator.SetFloat("Vertical", vertical);
        }
        
        public virtual void SetMoveDirectionMagnitude(float magnitude)
        {
            Animator.SetFloat("InputMagnitude", magnitude);
        }
        
        public virtual void HorAimAngle(float horizontal, float vertical)
        {
            Animator.SetFloat("HorAimAngle", horizontal);
            Animator.SetFloat("VerAimAngle", vertical);
        }

        public virtual void StopLU(bool enable)
        {
            Animator.SetBool("IsStopLU", enable);
        }
        
        public virtual void SetWalkStopAngle(float angle)
        {
            Animator.SetFloat("WalkStopAngle", angle);
        }
        
        public virtual void SetIsDead(bool isDead)
        {
            Animator.SetBool("IsDead", isDead);
        }
        
        public virtual void SetIsShoot(bool isShoot)
        {
            Animator.SetBool("IsShoot", isShoot);
        }
        
        public virtual void Restart()
        {
            Animator.Rebind();
            Animator.Update(0f);
        }
    }
}