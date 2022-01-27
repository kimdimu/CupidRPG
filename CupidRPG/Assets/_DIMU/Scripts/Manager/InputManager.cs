using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void InputEvent();
    public InputEvent OnPressFDown;

    private static InputManager _instance = null;
    public static InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(InputManager)) as InputManager;
                if (_instance == null)
                {
                    _instance = new GameObject("Singleton of " + typeof(InputManager).ToString(), typeof(InputManager)).GetComponent<InputManager>();
                }

            }
            return _instance;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("상호작용");
            OnPressFDown();
        }
    }
}
