using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuy;
    [SerializeField] protected Bullet PrefabsBullets;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuy => _isBuy;

    public abstract void Shoot(Transform shootPoint);
    public abstract void Reload();

    public  void Buy()
    {
        _isBuy = true;
    }
}
