using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace statemachine
{

    /// <summary>
    /// Abstract class to define the interface (the methods you can use) of states
    /// Abstract classes CANNNOT be instantiated. They can only be extended (google for OOP and inheritance)
    /// Their purpose is to define an interface. To make sure every state has the same methods/functions
    /// </summary>
    public abstract class State
    {
        // the following three variables are set from the specific states (WanderState, RecoverState)
        // as all states use it, it is defined here in the base class.
        protected Agent owner;
        protected StateMachine machine;

        protected Renderer renderer;

        public State(Agent owner, StateMachine machine)
        {
            this.owner = owner;
            this.machine = machine;

            renderer = owner.GetComponent<Renderer>();
        }

        // the following methods are defined as virtual
        // this means that a specific state _can_ implement them, but does not need to
        // as they are defined here as empty virtual methods, they are guaranteed to exist
        // and you can call them on any state without having to worry if they do exist

        #region virtualMethods

        /// <summary>
        /// EnterState is only called when the state becomes active
        /// </summary>
        public virtual void EnterState()
        {
        }

        /// <summary>
        /// UpdateState is called every frame.
        /// It executes the logic that belongs to the behavior of this state
        /// </summary>
        public virtual void UpdateState()
        {
        }

        /// <summary>
        /// ExitState is only called when the state becomes inactive
        /// </summary>
        public virtual void ExitState()
        {
        }

        #endregion
    }
}