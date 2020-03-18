using UnityEngine;

[CreateAssetMenu(fileName = "Enemy data", menuName = "Settings/Enemy")]

public class EnemySettings : ScriptableObject
{

    bool canJump;
    bool canAttack;
    bool canMove;

}
