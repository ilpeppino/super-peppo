using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{

    [SerializeField] private Animator _enemyAnimator;

    private void Awake()
    {
        _enemyAnimator = GetComponent<Animator>();

        switch (this.name)
        {
            case "TurtleShell": 
                { 
                    _enemyAnimator.Play("IdleNormal");
                    return;
                }

            case "Slime":
                {
                    _enemyAnimator.Play("IdleNormal");
                    return;
                }

        }     
        
    }

}
