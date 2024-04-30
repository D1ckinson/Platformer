using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _duration;
    [SerializeField] private float _radius;

    [SerializeField] private Health _health;
    [SerializeField] private LayerMask _enemy;
    [SerializeField] private Button _button;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _finalColor;

    private SpriteRenderer _spriteRenderer;
    private Coroutine _drainHealth;
    private float _step = 0.01f;
    private float _radiusMultiplier = 2;

    private void Awake()
    {
        transform.localScale *= _radius * _radiusMultiplier;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = _finalColor;

        _button.onClick.AddListener(Enable);

        enabled = false;
    }

    private void Enable() =>
        enabled = true;

    private void OnDestroy() =>
        _button.onClick.RemoveListener(Enable);

    private void OnEnable()
    {
        StartCoroutine(DrawAbilityArea());

        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _radius, _enemy);
        Collider2D enemyCollider = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D enemy in enemies)
        {
            float distance = CalculateDistance(enemy.transform.position);

            if (distance > closestDistance)
                continue;

            closestDistance = distance;
            enemyCollider = enemy;
        }

        if (enemyCollider == null)
            return;

        enemyCollider.TryGetComponent(out Health health);
        _drainHealth = StartCoroutine(DrainHealth(health));

        enabled = false;
    }

    private IEnumerator DrawAbilityArea()
    {
        for (float i = 0; i < 1; i += _step)
        {
            _spriteRenderer.color = Color.Lerp(_startColor, _finalColor, i);

            yield return null;
        }
    }

    private IEnumerator DrainHealth(Health enemyHealth)
    {
        float time = 0;
        float value;
        _button.interactable = false;

        while (time < _duration && enemyHealth != null)
        {
            value = _damage * Time.deltaTime;
            time += Time.deltaTime;

            enemyHealth.TakeDamage(value);
            _health.Heal(value);

            yield return null;
        }

        _button.interactable = true;
    }

    private float CalculateDistance(Vector3 enemyPosition) =>
        (enemyPosition - transform.position).magnitude;
}
