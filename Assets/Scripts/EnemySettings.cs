using UnityEngine;

[CreateAssetMenu(fileName = "Enemy data", menuName = "Settings/Enemy")]

public class EnemySettings : ScriptableObject
{
    [SerializeField] bool canJump;
    [SerializeField] bool canAttack;
    [SerializeField] bool canMove;
    [SerializeField] bool canBouncePlayer;
    [SerializeField] int damageAmount;

}
