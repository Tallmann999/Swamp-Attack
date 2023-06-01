using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChange += OnValueChange;
        Slider.value = 1;
    }

    public void OnDisable()
    {
        _player.HealthChange -= OnValueChange;
    }
}
