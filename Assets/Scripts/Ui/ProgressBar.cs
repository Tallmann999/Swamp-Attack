using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.EnemyCountChange += OnValueChange;
        Slider.value = 0;
    }

    public void OnDisable()
    {
        _spawner.EnemyCountChange -= OnValueChange;
    }
}
