using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;
    public override void Enter()
    {
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
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject,gunbarrel.position, enemy.transform.rotation);
        Vector3 shootDirection = ((enemy.Player.transform.position + new Vector3(0,1.5f,0)) - gunbarrel.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().linearVelocity =Quaternion.AngleAxis(Random.Range(-3,3),Vector3.up )* shootDirection * 40;
        Debug.Log("Bằng bằng bằng");

        shotTimer = 0;
    }
 
}
