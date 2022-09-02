using UnityEngine;

public class PressToStartGame : MonoBehaviour
{
    [SerializeField] KeyCode key;
    void Awake()
    {
        StopTime();
    }

    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            StartTime();

            Destroy(gameObject);
        }
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }

    private void StartTime()
    {
        Time.timeScale = 1;
    }
}
