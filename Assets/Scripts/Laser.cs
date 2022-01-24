using System.Collections;
using UnityEngine;
public class Laser : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private float laserSpeed = 5f;
    [SerializeField] private int damage = 1;
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Debug.Log(true);
            other.GetComponent<EnemyController>().Hit(damage);
        }
    }
}
