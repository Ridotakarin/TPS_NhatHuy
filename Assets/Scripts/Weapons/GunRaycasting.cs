using UnityEngine;

public class GunRaycasting : MonoBehaviour
{
    [SerializeField] private Transform _firingPos;
    [SerializeField] private Transform _aimingCamera;
    [SerializeField] private Transform _hitMarkerPrefab;
    [SerializeField] private float _damage = 10;
    [SerializeField] private Transform _firePrefabs;

    public void PerformRaycast()
    {

        Ray aimingRay = new(_aimingCamera.position, _aimingCamera.forward);
        if (Physics.Raycast(aimingRay, out var raycasthit))
        {
            var rayHit = Instantiate(_hitMarkerPrefab, raycasthit.point, Quaternion.LookRotation(raycasthit.normal), parent: raycasthit.collider.transform);
            if (raycasthit.collider.TryGetComponent<Mutant>(out var mutan))
            {

                mutan.TakeDamage(_damage);
            }
            if (raycasthit.collider.TryGetComponent<Mob>(out var mob))
            {
                mob.TakeDamage(_damage);
            }

        }
    }
    
    public void VFXShoot()
    {
        var vfx = Instantiate(_firePrefabs,_firingPos.position,_firingPos.rotation);


        Destroy(vfx.gameObject, 0.05f);
    }
}
    