using UnityEngine;
//using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private InputAction action;
    public static bool isGameStart = false;
    public static bool isGameEnd = false;
    bool isSettingOn = false;

    [SerializeField] GameObject setting;

    private void Start()
    {
        FindObjectOfType<CameraSwitcher>().SwitchState();
        //action.performed += _ => SettingONOFF();
    }
    private void OnEnable()
    {
        //action.Enable();
    }
    private void OnDisable()
    {
        //action.Disable();
    }
    public void GameStart()
    {
        isGameStart = true;
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<CameraSwitcher>().SwitchState();
    }
    public void GameEnd()
    {
        FindObjectOfType<CameraSwitcher>().SwitchState();
        isGameEnd = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape)) SettingONOFF();
    }
    public void SettingONOFF()
    {
        if (isSettingOn)
        {
            Cursor.lockState = CursorLockMode.Locked;
            setting.SetActive(false);
        }
        else
        {
            isGameStart = false;
            Cursor.lockState = CursorLockMode.None;
            setting.SetActive(true);
        }
        isSettingOn = !isSettingOn;
    }
}
