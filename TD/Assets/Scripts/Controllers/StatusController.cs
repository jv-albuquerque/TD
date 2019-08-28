using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    [SerializeField] private int hp = 20;

    public int Hp { get => hp; set => hp = value; }
}
