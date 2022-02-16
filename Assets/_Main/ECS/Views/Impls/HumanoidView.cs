using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public abstract class HumanoidView : LinkableView
    {
        private int _runIndex = -1;
        protected float _idleIndex = 0;
        protected float _fearIndex = 0;
        private float _deathSpeed = -1;
        protected float _walkSpeed = 1;
        [SerializeField] protected Animator Animator;
        protected static readonly int IsRun = Animator.StringToHash("IsRun");
        protected static readonly int Attack = Animator.StringToHash("OnAttack");
        protected static readonly int Hit = Animator.StringToHash("OnHit");
        protected static readonly int Dance = Animator.StringToHash("OnDance");
        protected static readonly int Death = Animator.StringToHash("OnDeath");
        protected static readonly int BlendDeathIndex = Animator.StringToHash("Blend_Death_Index");
        protected static readonly int BlendRunIndex = Animator.StringToHash("Blend_Run_Index");
        protected static readonly int DeathSpeed = Animator.StringToHash("Death_Speed");
        protected static readonly int BlendAttackIndex = Animator.StringToHash("Blend_Attack_Index");
        protected static readonly int BlendHitIndex = Animator.StringToHash("Blend_Hit_Index");
        protected static readonly int Restart = Animator.StringToHash("Restart");
        protected static readonly int BlendDanceIndex = Animator.StringToHash("Blend_Dance_Index");
        protected static readonly int BlendIdleIndex = Animator.StringToHash("Blend_Idle_Index");
        protected static readonly int BlendIdleTypeIndex = Animator.StringToHash("Blend_Idle_Type_Index");
        protected static readonly int BlendFearIndex = Animator.StringToHash("Blend_Fear_Index");
        protected static readonly int Fear = Animator.StringToHash("OnFear");
        protected static readonly int IsSneak = Animator.StringToHash("IsSneak");
        protected static readonly int WalkSpeed = Animator.StringToHash("Walk_Speed");
        protected static readonly int IsWalk = Animator.StringToHash("IsWalk");
        protected static readonly int BlendFallIndex = Animator.StringToHash("Blend_Fall_Index");
        protected static readonly int Fall = Animator.StringToHash("OnFall");
        protected static readonly int Speed = Animator.StringToHash("Speed");
        protected static readonly int Joy = Animator.StringToHash("OnJoy");
        private static readonly int OnHeadSpin = Animator.StringToHash("SpinOnHead");


        public void SetSpeed(float speed)
        {
            Animator.SetFloat(Speed, speed);
        }
        

        public virtual void OnFear()
        {
            Animator.SetFloat(BlendFearIndex, _fearIndex);
            Animator.SetTrigger(Fear);
            Animator.SetBool(IsRun, false);

        }

        public virtual void OnAttack()
        {
            Animator.SetFloat(BlendAttackIndex, Random.Range(0, 8));
            Animator.SetTrigger(Attack);
        }

        public virtual void OnJoy()
        {
            if(Animator.GetCurrentAnimatorStateInfo(0).IsName("Joy"))
                return;
            Animator.SetTrigger(Joy);
        }

        public virtual void OnHit()
        {
            Animator.SetFloat(BlendHitIndex, Random.Range(0, 6));
            Animator.SetTrigger(Hit);
        }

        public virtual void OnDance()
        {
            if(Animator.GetCurrentAnimatorStateInfo(0).IsName("Dance"))
                return;
            
            Animator.SetFloat(BlendDanceIndex, Random.Range(0, 6));
            Animator.SetTrigger(Dance);
        }
        
        public virtual void OnRun()
        {
            if (_runIndex == -1)
            {
                //_runIndex = Random.Range(0, 12);
                Animator.SetFloat(BlendRunIndex, 0);
            }
            
            Animator.SetBool(IsRun, true);
            Animator.SetBool(IsSneak, false);
            Animator.SetBool(IsWalk, false);
        }
        
        public virtual void OnIdle()
        {
            Animator.SetFloat(BlendIdleIndex, 0);
            Animator.SetBool(IsRun, false);
            Animator.SetBool(IsSneak, false);
            Animator.SetBool(IsWalk, false);
        }
        
        public virtual void OnSneak()
        {
            Animator.SetBool(IsRun, false);
            Animator.SetBool(IsWalk, false);
            Animator.SetBool(IsSneak, true);
        }

        public virtual void OnWalk()
        {
            Animator.SetFloat(WalkSpeed, _walkSpeed);
            Animator.SetBool(IsRun, false);
            Animator.SetBool(IsSneak, false);
            Animator.SetBool(IsWalk, true);
        }
        public virtual void SpinOnHead()
        {
            Animator.SetTrigger(OnHeadSpin);
        }

        public virtual void OnFall()
        {
            Animator.SetFloat(BlendFallIndex, Random.Range(0, 7));
            Animator.SetTrigger(Fall);
        }

        public virtual void OnDeath()
        {
            if (_deathSpeed <= 0)
            {
                _deathSpeed = 1.5f;
                Animator.SetFloat(DeathSpeed, _deathSpeed);
            }  
            
            Animator.SetFloat(BlendDeathIndex, Random.Range(0, 7));
            Animator.SetTrigger(Death);
        }

        public virtual void OnRestart()
        {
            Animator.SetTrigger(Restart);
        }
    }
}