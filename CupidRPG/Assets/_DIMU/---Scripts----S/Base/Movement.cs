using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float[] Speed;//정지, 걷기, 뛰기
    private bool isJump = false;
    [SerializeField]
    private float moveSpeed;//현재 속도
    private Vector3 moveVector;
    private Vector3 goVec;
    private Vector3 rotateVector;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        SetSpeed(0);
    }

    public void Move(float h, float v, bool isRun)
    {
        if (isRun) SetSpeed(2);
        else SetSpeed(1);

        moveVector.x = h;
        moveVector.z = v;
        goVec = moveVector.normalized * Time.deltaTime * moveSpeed;
        transform.Translate(goVec);
        //anim.SetBool("isWalk", true);
    }
    public void MoveTo(Transform toPos)
    {
        SetSpeed(1);

        transform.LookAt(toPos);

        transform.Translate(0, 0, Time.deltaTime * moveSpeed);
    }
    public void Jump()
    {
        anim.SetTrigger("Jump");
        isJump = true;
    }
    void JumpEnd()
    {
        isJump = false;
    }
    public void UpdateAnimation()
    {
        anim.SetFloat("Blend", moveSpeed);
    }

    public void RotateTo(float camRotationY)
    {
        rotateVector = transform.localRotation.eulerAngles;
        rotateVector.y = camRotationY;
        transform.rotation = Quaternion.Euler(rotateVector.x, rotateVector.y, rotateVector.z);
    }
    public void SetSpeed(int multyNum)
    {
        moveSpeed = Speed[multyNum];
    }
}
