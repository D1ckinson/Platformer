using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _duration;
    [SerializeField] private float _radius;
    [SerializeField] private float _cooldown;

    [SerializeField] private Health _health;
    [SerializeField] private Button _button;
    [SerializeField] private LayerMask _enemy;
    [SerializeField] private TMP_Text _buttonName;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _finalColor;

    private float _radiusMultiplier = 2;
    private float _fadeStep = 0.01f;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        transform.localScale *= _radius * _radiusMultiplier;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = _finalColor;

        _button.onClick.AddListener(Enable);

        enabled = false;
    }

    private void OnEnable()
    {
        StartCoroutine(DrawAbilityArea());
        StartCoroutine(DisableButton());

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
        {
            enabled = false;
            return;
        }

        if (enemyCollider.TryGetComponent(out Health health) == false)
        {
            enabled = false;
            return;
        }

        StartCoroutine(DrainHealth(health));

        enabled = false;
    }

    private void OnDestroy() =>
        _button.onClick.RemoveListener(Enable);

    private void Enable() =>
        enabled = true;

    private IEnumerator DrawAbilityArea()
    {
        for (float i = 0; i < 1; i += _fadeStep)
        {
            _spriteRenderer.color = Color.Lerp(_startColor, _finalColor, i);

            yield return null;
        }
    }

    private IEnumerator DrainHealth(Health enemyHealth)
    {
        float time = 0;
        float deltaTime;
        float value;

        while (time < _duration && CalculateDistance(enemyHealth.transform.position) < _radius)
        {
            deltaTime = Time.deltaTime;
            value = _damage * deltaTime;
            time += deltaTime;

            if (enemyHealth == null || enemyHealth.Value < 0)
                yield return null;

            enemyHealth.TakeDamage(value);

            if (_health.IsFull)
                yield return null;

            _health.Heal(value);

            yield return null;
        }
    }

    private IEnumerator DisableButton()
    {
        float time = _cooldown;
        string buttonName = _buttonName.text;
        _button.interactable = false;

        while (time > 0)
        {
            _buttonName.text = Mathf.Round(time).ToString();
            time -= Time.deltaTime;
            yield return null;
        }

        _buttonName.text = buttonName;
        _button.interactable = true;
    }

    private float CalculateDistance(Vector3 enemyPosition) =>
        (enemyPosition - transform.position).magnitude;
}
