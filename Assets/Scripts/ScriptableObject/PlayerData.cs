using UnityEngine;

// MenuName ini yang bikin kamu bisa Klik Kanan > Create > Game > Player Data
[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/Player Data")]
public class PlayerData : ScriptableObject
{

    public float maxHP = 100f;
    public float moveSpeed = 5f;

    public float takeDamage = 0.1f; 
}