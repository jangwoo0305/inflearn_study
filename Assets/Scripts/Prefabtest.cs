using UnityEngine;

public class Prefabtest : MonoBehaviour
{
    GameObject Prefab;

    GameObject tank;

    void Start()
    {
        tank = Managers.Resource.Instantiate("Tank");

        // Managers.Resource.Destroy(tank);
        Destroy(tank, 3.0f);
    }
}
