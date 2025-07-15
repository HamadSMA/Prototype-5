using UnityEngine;

public class ResumeMusic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
