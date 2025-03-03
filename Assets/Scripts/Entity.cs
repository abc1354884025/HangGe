using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Mirror.Examples.Benchmark
{
    public class Entity : MonoBehaviour
    {
        #region Attribute Info

        #endregion

        #region Components

        public Transform AttackPoint;

        public Animator anim { get; private set; }
        public NavMeshAgent agent { get; private set; }

        #endregion





        protected virtual void Awake()
        {
            anim = GetComponentInChildren<Animator>();
            agent = GetComponent<NavMeshAgent>();
        }
        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {
        }

        protected virtual void OnDrawGizmos()
        {

        }
    }
}
    
