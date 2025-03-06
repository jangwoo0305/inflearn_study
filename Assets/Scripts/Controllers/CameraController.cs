using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;

    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);

    [SerializeField]
    GameObject _player = null;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if(_mode == Define.CameraMode.QuarterView)
        {
            transform.position = _player.transform.position + _delta;
            transform.LookAt(_player.transform);
        }
        // 여기까지 작성하면 플레어어의 이동후에 카메라가 따라오거나 카메라가 이동하고 플레이어가 따라오거나 1/2확률이다.
        // -> 플레이어의 이동이 끝난 후에 카메라가 업데이트 되게 한다.
        // LateUpdate()를 사용하면 된다.
    }


    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
