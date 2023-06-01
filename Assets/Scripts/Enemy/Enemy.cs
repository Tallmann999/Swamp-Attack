using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private const string Died = "Die";

    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    private Player _target;
    [SerializeField] private Animator _animator;

    private WaitForSeconds _waitForSeconds;
    private float _waitingTime = 1f;

    public int Reward => _reward;
    public Player Target => _target;
    public event UnityAction<Enemy> Dying;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_waitingTime);
        _animator = GetComponent<Animator>();
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            StartCoroutine(DieAfterAnimation());
        }
    }

    private void Die()
    {
        Dying?.Invoke(this);
        Destroy(gameObject);
    }

    public IEnumerator DieAfterAnimation()
    {
        _animator.SetTrigger(Died);
        yield return _waitForSeconds;
        Die();
    }
}
