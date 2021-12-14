using Cinemachine;
using UnityEngine;
//using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook vcamOrg;
    [SerializeField] CinemachineFreeLook vcamZoom;
    //[SerializeField] private InputAction action;
    Animator anim;
    bool isOrgCam = true;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        //action.Enable();
    }
    private void OnDisable()
    {
        //action.Disable();
    }

    void Start()
    {
        //action.performed += _=>SwitchState();
    }
    private void Update()
    {
        //if (Input.GetMouseButton(1))
        //{
        //    if (isOrgCam)
        //        SwitchState();

        //    return;
        //}
        //else if (!isOrgCam)
        //{
        //    SwitchState();
        //}
    }
    private void SwitchState2()
    {
        Debug.Log(isOrgCam);
        if (isOrgCam)
        {
            anim.Play("OrgCam");
        }
        else
        {
            anim.Play("ZoomCam");
        }
        isOrgCam = !isOrgCam;
    }
    public void SwitchState()
    {
        Debug.Log(isOrgCam);
        if (isOrgCam)
        {
            vcamOrg.gameObject.SetActive(false);
            vcamZoom.gameObject.SetActive(true);
            vcamOrg.Priority = 0;
            vcamZoom.Priority = 1;
        }
        else
        {
            vcamZoom.gameObject.SetActive(false);
            vcamOrg.gameObject.SetActive(true);
            vcamOrg.Priority = 1;
            vcamZoom.Priority = 0;
        }
        isOrgCam = !isOrgCam;
    }
}
