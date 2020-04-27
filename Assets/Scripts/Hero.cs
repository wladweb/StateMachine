using UnityEngine;
using UnityEngine.Events;

public class Hero : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private Target _target;

    public Target Target { get; }

    public event UnityAction Died;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Died?.Invoke();
            Destroy(gameObject);
        }
    }
}
