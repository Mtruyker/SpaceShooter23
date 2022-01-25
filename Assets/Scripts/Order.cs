using UnityEngine;
public class Order : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake");
    }

    void Start()
    {
        Debug.Log("Start");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
}
