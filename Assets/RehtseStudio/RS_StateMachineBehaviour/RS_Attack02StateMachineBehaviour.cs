﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RehtseStudio.PlayerAnimatorController;

namespace RehtseStudio.AttackStateMachineBehaviour
{
    public class RS_Attack02StateMachineBehaviour : StateMachineBehaviour
    {

        private int _isPlayerAttackingBoolParameterAnim;
        private int _attackTriggerParameterAnim;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _isPlayerAttackingBoolParameterAnim = Animator.StringToHash("isPlayerAttacking");
            animator.SetBool(_isPlayerAttackingBoolParameterAnim, false);

        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

            _isPlayerAttackingBoolParameterAnim = Animator.StringToHash("isPlayerAttacking");

            animator.SetBool(_isPlayerAttackingBoolParameterAnim, RS_PlayerAnimatorController.Instance.IsPlayerAttacking());

            _attackTriggerParameterAnim = Animator.StringToHash("Attack_003");

            if (RS_PlayerAnimatorController.Instance.AttackClick() == 3)
                animator.SetTrigger(_attackTriggerParameterAnim);
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

            _attackTriggerParameterAnim = Animator.StringToHash("Attack_003");
            animator.ResetTrigger(_attackTriggerParameterAnim);

        }

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}

    }

}

