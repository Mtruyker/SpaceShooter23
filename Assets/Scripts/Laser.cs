using System.Collections;
using UnityEngine;
public class Laser : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private float laserSpeed = 5f;
    /// <summary>
    /// Запускается таймер 
    /// </summary>
    private void OnEnable()
    {
        StartCoroutine(SelfDestroyTimer());
    }
    /// <summary>
    /// Движение объекта вперёд
    /// </summary>
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * laserSpeed);
    }
    IEnumerator SelfDestroyTimer()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
