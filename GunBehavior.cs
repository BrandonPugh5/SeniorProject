using UnityEngine;

public class GunBehavior : MonoBehaviour
{

    public GameObject bulletModel;
    public GameObject gun;
    public float speed = 5.0f;

    public static GunMode currentGunMode = GunMode.shrink;
    public enum GunMode
    {
        shrink,
        grow
    };

    void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector3 direction = target - gun.transform.position;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(bulletModel, gun.transform.position, rotation);
            currentGunMode = GunMode.shrink;
            projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

        if(Input.GetMouseButtonDown(1))
        {
            GameObject projectile = Instantiate(bulletModel, gun.transform.position, rotation);
            currentGunMode = GunMode.grow;
            projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

    }


}






