using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Enemy _enemy;
    private Transform[] _points;
    private Coroutine _createEnemyJob;

    private void Start()
    {
        _points = new Transform[_transform.childCount];
        _createEnemyJob = StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        for (int i = 0; i < _transform.childCount; i++)
        {
            _points[i] = _transform.GetChild(i);
            Instantiate(_enemy, _points[i].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
