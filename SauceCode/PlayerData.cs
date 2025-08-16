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

    [Header("Player�̓����X�s�[�h")]
    [SerializeField] private float playerMoveSpeed;
    [Header("Ray�̓͂�����")]
    [SerializeField] private float rayDistance;
    [Header("���̔��˃X�s�[�h(12000�����傤�ǂ���")]
    [SerializeField] private float eggSpeed;
    [Header("����prefabs")]
    [SerializeField] private GameObject eggPrefabs;
}
