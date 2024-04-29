using System.Collections;
using UnityEngine;

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _duration;
    [SerializeField] private float _range;
    [SerializeField] private Health _health;

    private Coroutine _coroutine;

    public void UseAbility()
    {
        Health enemyHealth = FindTarget();

        if (enemyHealth == null)
            return;

        _coroutine = StartCoroutine(DrainHealth(enemyHealth));
    }

    private Health FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Health enemyHealth = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = CalculateDistance(enemy.transform.position);

            if (distance > closestDistance)
                continue;

            closestDistance = distance;
            enemy.TryGetComponent(out Health health);
            enemyHealth = health;
        }

        return enemyHealth;
    }

    private IEnumerator DrainHealth(Health enemyHealth)
    {
        float time = 0;
        float value;

        while (time < _duration)
        {
            value = _damage * Time.deltaTime;
            time += Time.deltaTime;

            enemyHealth.TakeDamage(value);
            _health.Heal(value);

            LookRange(enemyHealth);

            yield return null;
        }
    }

    private void LookRange(Health enemy)
    {
        if (CalculateDistance(enemy.transform.position) < _range)
            return;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private float CalculateDistance(Vector3 enemyPosition) =>
        (enemyPosition - transform.position).sqrMagnitude;
}
