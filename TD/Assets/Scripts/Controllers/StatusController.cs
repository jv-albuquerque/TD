using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    [SerializeField] private int hp = 20;

    private void Start()
    {
        SetHpText.instance.SetText = hp;
    }

    public int Hp { get => hp; set => hp = value; }
}
