using UnityEngine;
//using UnityEngine.InputSystem;

//게임의 흐름 시작과 정지 등 관리
public class GameManager : Singleton<GameManager>
{
    //[SerializeField] private InputAction action;
    public  bool isGameStart = false;
    public  bool isGameEnd = false;
    bool isSettingOn = false;

    [SerializeField] GameObject setting;
    [SerializeField] GameObject EndUI;
    private void Start()
    {
        //FindObjectOfType<CameraSwitcher>().SwitchState();
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
        //FindObjectOfType<CameraSwitcher>().SwitchState();
    }
    public  void GameEnd()
    {
        //FindObjectOfType<CameraSwitcher>().SwitchState();
        EndUI.SetActive(true);
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
