using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mp5 : Weapon
{
    public override void Reload() { }

    public override void Shoot(Transform shootPoint)
    {
        Instantiate(PrefabsBullets, shootPoint.position, Quaternion.identity);
    }
}
