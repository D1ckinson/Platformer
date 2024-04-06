using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private float _delay;
    [SerializeField] private Vector2 _spawnForce;

    private void Awake() =>
        StartCoroutine(Spawn());

    private IEnumerator Spawn()
    {
        WaitForSeconds sleep = new(_delay);

        while (true)
        {
            Coin coin = Instantiate(_coin, transform.position, Quaternion.identity);
            coin.GetComponent<Rigidbody2D>().AddForce(GetForceVector(), ForceMode2D.Impulse);

            yield return sleep;
        }
    }

    private Vector2 GetForceVector() =>
           new()
           {
               x = Random.Range(-_spawnForce.x, _spawnForce.x),
               y = Random.Range(0, _spawnForce.y)
           };
}
