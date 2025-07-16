using UnityEngine;

public class ResumeMusic : MonoBehaviour
{ private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
