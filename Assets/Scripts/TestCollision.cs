using Unity.VisualScripting;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 1) 나 혹은 상대한테 Rigidbody가 있어야 한다.(IsKinematic : off)
    // 2) 나한테 Collider가 있어야 한다.(IsTrigger : off)
    // 3) 상대한테 Collider가 있어야 한다.(IsTrigger : off)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @ {collision.gameObject.name}");
    }

    // 1) 둘 다 Collider가 있어야 한다.
    // 2) 둘 중 하나는 Istrigger : On
    // 3) 둘 중 하나는 Rigidbody가 있어야 한다.
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($" Trigger @{other.gameObject.name}");            
    }
    void Start()
    {
        
    }

    void Update()
    {

        // local <-> world <-> viewport <-> screen(화면)

        // Debug.Log(Input.mousePosition);// 현재 마우스 좌표를 픽셀 좌표(스크린 좌표)로 뽑아온다.
        // 이 상태로 play를 한 후 마우스를 Game씬에서 왼쪽하단으로 가지고가면 (0,0)에 가까워 지고
        // 오른쪽 하단으로 가져가면 x좌표가 증가, 왼쪽 상단으로 가져가면 y좌표가 증가, 우측상단으로 가져가면 x,y좌표 전부 증가하는 모습을 볼 수 있다.

        // Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }

        // if(Input.GetMouseButtonDown(0))
        // {
        //     Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //     Vector3 dir = mousePos - Camera.main.transform.position;
        //     dir = dir.normalized;

        //     Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);

        //     RaycastHit hit;
        //     if(Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
        //     {
        //         Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        //     }
        // }
    }
}
