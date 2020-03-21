using UnityEngine;

[CreateAssetMenu(fileName = "Reward", menuName = "Settings/Rewards")]

public class RewardSettings : ScriptableObject
{
    [SerializeField] public int points;
}

