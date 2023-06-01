using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _moveSpeed;

    [SerializeField] private TMP_Text _label;
    [SerializeField] private Image _icon;

    private float _minHealth = 0f;
    public event UnityAction<float, float> HealthChange;
    private Weapon _currentWeapon;
    private int _currentWeaponNumber =0;
    private Animator _animator;

    public int Money { get; private set; }
    private float _currentHealth;

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChange?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            StartCoroutine(AnimationAfterDie());
        }
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
    }

    public IEnumerator AnimationAfterDie()
    {
        _animator.SetTrigger("Die");
        yield return new WaitForSeconds(2f);

        Die();
    }

    public void AddMoney(int money)
    {
        Money += money;
    }

    public void NextWeaponButton()
    {
        if (_currentWeaponNumber == _weapons.Count-1)
        {
            _currentWeaponNumber = 0;
        }
        else
        {
            _currentWeaponNumber++;
        }

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviesWeapon()
    {
        if (_currentWeaponNumber == 0 )
        {
            _currentWeaponNumber = _weapons.Count - 1;
        }
        else
        {
            _currentWeaponNumber--;
        }

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void Update()
    {
        ShootControl();
        _icon.sprite = _currentWeapon.Icon;
        _label.text = _currentWeapon.Label;
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

    private void ShootControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetBool("Shooting", true);
            _currentWeapon.Shoot(_shootPoint);
        }
        else
        {
            _animator.SetBool("Shooting", false);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
