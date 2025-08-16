using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Player/PlayerData", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{ 
    public float PlayerMoveSpeed { get => playerMoveSpeed;}
    public float EggSpeed { get => eggSpeed;}
    public GameObject EggPrefabs { get => eggPrefabs;}

    public float RayDistance { get => rayDistance;}

    [Header("Playerの動くスピード")]
    [SerializeField] private float playerMoveSpeed;
    [Header("Rayの届く距離")]
    [SerializeField] private float rayDistance;
    [Header("卵の発射スピード(12000がちょうどいい")]
    [SerializeField] private float eggSpeed;
    [Header("卵のprefabs")]
    [SerializeField] private GameObject eggPrefabs;
}
