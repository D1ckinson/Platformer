using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private float _delay;
    [SerializeField] private float _xForce;
    [SerializeField] private float _yForce;

    private WaitForSeconds _sleep;

    private void Awake()
    {
        StartCoroutine(Spawn());
        _sleep = new(_delay);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Coin coin = Instantiate(_coin, transform.position, Quaternion.identity);
            coin.GetComponent<Rigidbody2D>().AddForce(GetForce(), ForceMode2D.Impulse);

            yield return _sleep;
        }
    }

    private Vector2 GetForce()
    {
        float xForce = Random.Range(-_xForce, _xForce);

        return new(xForce, _yForce);
    }
}
