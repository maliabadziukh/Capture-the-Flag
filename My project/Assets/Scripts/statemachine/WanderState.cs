using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace statemachine
{

    public class WanderState : State
    {
        private List<Vector3> Waypoints;

        private Vector3 target;
        private int pathIndex = 0;
        private float speed = 4;

        public WanderState(Agent owner, StateMachine machine) : base(owner, machine)
        {
            GenerateRandomWaypoints(owner);
        }

        /// <summary>
        /// Generate a few random waypoints to patrol along.
        /// The points are generated on the XZ plane. The Y position is taken from the GameObject
        /// </summary>
        /// <param name="owner">The gameobject that need to wander</param>
        private void GenerateRandomWaypoints(Agent owner)
        {
            Waypoints = new List<Vector3>()
            {
                new Vector3(Random.Range(-25, 25), owner.transform.position.y, Random.Range(-25, 25)),
                new Vector3(Random.Range(-25, 25), owner.transform.position.y, Random.Range(-25, 25)),
                new Vector3(Random.Range(-25, 25), owner.transform.position.y, Random.Range(-25, 25)),
                new Vector3(Random.Range(-25, 25), owner.transform.position.y, Random.Range(-25, 25))
            };
        }

        public override void EnterState()
        {
            renderer.material.color = Color.blue;
            NextTarget();
        }

        public override void UpdateState()
        {
            Wander();
            owner.UpdateHP(-0.2f);
            if (owner.HP < 10) //MAGIC NUMBER ALERT!
            {
                machine.SwitchState(machine.recoverState);
            }
        }

        /// <summary>
        /// Execute the 'wander logic'
        /// Nothing fancy, just move towards a vector 3 on the plane somewhere
        /// </summary>
        private void Wander()
        {
            Vector3 newPos = Vector3.MoveTowards(owner.transform.position, target, speed * Time.deltaTime);

            owner.transform.position = newPos;
            owner.transform.LookAt(target);

            // have I arrived? Then pick the next waypoint
            if (Vector3.Distance(newPos, target) == 0)
            {
                NextTarget();
            }
        }

        private void NextTarget()
        {
            pathIndex = ++pathIndex % Waypoints.Count;
            target = Waypoints[pathIndex];
        }

        public override void ExitState()
        {
            //throw new System.NotImplementedException();
        }
    }
}