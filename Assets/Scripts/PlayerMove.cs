using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float axisRight;
    private float axisUp;
    public float moveSpeed = 5.0f;
    private Rigidbody2D rigid;

    public float upPower = 1;
    
    private bool isAttach = false;
    private bool onGround = false;
    public float DetachJump = 5;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale= 2;
    }

    // Update is called once per frame
    void Update()
    {   
        

        if(Input.GetKey(KeyCode.R)) transform.position = new Vector2(-30,-5);
        if(Input.GetKey(KeyCode.LeftShift)) isAttach = true;
        else isAttach = false;

        axisRight = Input.GetAxis("Horizontal");
        axisUp = Input.GetAxis("Vertical");
        if(axisRight !=0 && !isAttach){
            transform.Translate(Vector2.right* axisRight * moveSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKeyDown(KeyCode.Space) && !isAttach &&!onGround) rigid.AddForce(Vector2.up * upPower, ForceMode2D.Impulse);
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Attach(other.transform);
    }

    private void OnCollisionExit2D(Collision2D other) {
        Detach();
    }

    private void Attach(Transform barTran){
        if(isAttach){
            transform.SetParent(barTran);
            rigid.velocity = Vector2.zero;
            rigid.isKinematic = true;
        }
        else{
            Detach();
        }
    }
    private void Detach(){
        transform.SetParent(null);
        rigid.isKinematic = false;
        rigid.AddForce(Vector2.up * DetachJump * Time.deltaTime, ForceMode2D.Impulse);
    }
}
