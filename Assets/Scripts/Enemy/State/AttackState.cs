using UnityEngine;

public class AttackState : BaseState
{
    [SerializeField] private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;
    public override void Enter()
    {
        Debug.Log("Vào attack rồi");
        enemy.animator.SetTrigger("Shoot");
    }

    public override void Exit()
    {

    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if (shotTimer > enemy.fireRate)
            {
                Shoot();
            }
            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if(losePlayerTimer > 8)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }
    public void Shoot()
    {
        Transform gunbarrel = enemy.gunBarrel;
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunbarrel.position, enemy.transform.rotation);

        Vector3 shootDirection = ((enemy.Player.transform.position + new Vector3(0, 1.5f, 0)) - gunbarrel.transform.position).normalized;

        // Random độ lệch dựa trên bulletSpread
        float spreadAngle = Random.Range(-enemy.bulletSpread, enemy.bulletSpread);
        shootDirection = Quaternion.AngleAxis(spreadAngle, Vector3.up) * shootDirection;

        bullet.GetComponent<Rigidbody>().linearVelocity = shootDirection * 40;
        Debug.Log("Bằng bằng bằng");

        shotTimer = 0;
    }

}
