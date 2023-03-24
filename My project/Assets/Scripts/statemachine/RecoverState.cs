using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace statemachine
{
    
    /// <summary>
    /// Recovery state. Just regenerates HP
    /// </summary>
    public class RecoverState : State
    {
        public RecoverState(Agent owner, StateMachine machine): base(owner, machine)
        {
        }
        
        public override void EnterState()
        {
            renderer.material.color = Color.red;
        }

        public override void UpdateState()
        {
            owner.UpdateHP(1);
            if (owner.HP >= owner.MaxHP)
            {
                machine.SwitchState(machine.wanderState);
            }
        }

        public override void ExitState()
        {
            //throw new System.NotImplementedException();
        }
    }

}
