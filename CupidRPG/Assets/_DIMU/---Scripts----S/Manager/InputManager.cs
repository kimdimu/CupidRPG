using UnityEngine;

//키보드 인풋 관리
public class InputManager : Singleton<InputManager>
{
    public delegate void InputEvent();
    public delegate void InputEventParam1(int x);
    public delegate void InputEventParam2(int x, int y);
    public InputEvent OnPressFDown;
    public InputEvent OnPressLeftShiftDown;
    //public InputEventParam1[] numberKeyDown = new InputEventParam1[10];
    public InputEventParam2 numberKeyDown;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("상호작용");
            OnPressFDown();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            print("화살 변경");
            OnPressLeftShiftDown();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            print("무기변경 -1");
            numberKeyDown(-1, 1);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            numberKeyDown(-1, 1);

        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            numberKeyDown(+1, 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("무기 변경1");
            numberKeyDown(0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("무기 변경2");
            numberKeyDown(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("무기 변경3");
            numberKeyDown(2, 0);
        }
    }
}
