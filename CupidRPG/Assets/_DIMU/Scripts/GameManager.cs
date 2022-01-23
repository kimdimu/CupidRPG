using UnityEngine;
//using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
                if (_instance == null)
                {
                    _instance = new GameObject("Singleton of " + typeof(GameManager).ToString(), typeof(GameManager)).GetComponent<GameManager>();
                }

            }
            return _instance;
        }
    }


    //[SerializeField] private InputAction action;
    public  bool isGameStart = false;
    public  bool isGameEnd = false;
    bool isSettingOn = false;

    [SerializeField] GameObject setting;
    [SerializeField] GameObject EndUI;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this as GameManager;
        }
    }
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
    public  void GameEnd()
    {
        FindObjectOfType<CameraSwitcher>().SwitchState();
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
