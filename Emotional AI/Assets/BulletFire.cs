using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {

    public void ShootBullet(GameObject AttackParticle,GameObject Player, GameObject Particlescontainer)
    {
        GameObject particle = PlayParticle(AttackParticle, Player.transform.position + new Vector3(0.3f, 0.7f, 0), 3, Particlescontainer);
        Vector3 playerposition = Player.transform.forward;
        particle.transform.rotation = Quaternion.LookRotation(playerposition);
        Destroy(particle, 1);
    }

    public GameObject PlayParticle(GameObject particle, Vector3 position, float time, GameObject ParticlesContainer)
    {
        GameObject instance = Utils.CreateInstance(particle, ParticlesContainer, true);
        instance.transform.position = position;
        Destroy(instance, 5);
        return instance;
    }
}
