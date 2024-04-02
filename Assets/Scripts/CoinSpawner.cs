using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private float _delay;
    [SerializeField] private Vector2 _spawnForce;

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
            coin.GetComponent<Rigidbody2D>().AddForce(GetForceVector(_spawnForce), ForceMode2D.Impulse);

            yield return _sleep;
        }
    }

    private Vector2 GetForceVector(Vector2 vector)
    {
        vector.x = Random.Range(-vector.x, vector.x); ;

        return vector;
    }
}
