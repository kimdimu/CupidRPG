using UnityEngine;

//키보드 인풋 관리
public class InputManager : Singleton<InputManager>
{
    public delegate void InputEvent();
    public InputEvent OnPressFDown;
    public InputEvent OnPressLeftShiftDown;

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
    }
}
