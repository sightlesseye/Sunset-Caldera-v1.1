﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scott;

namespace Peng {
    public class EnemyProjectile : InteractiveObject {
        public GameObject projectilePrefab;

        private float nextAction;

        void Start() {
            ScheduleNextAction();
        }

        void Update() {
            if (Time.time >= nextAction) {
                ScheduleNextAction();

                if (projectilePrefab) {
                    Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
                    projectile.direction = GameObject.FindWithTag("Player").GetComponent<Player>().transform.position - transform.position;
                    Debug.Log(projectile.direction + " : " + projectile.speed);
                }
            }
        }

        private void ScheduleNextAction() {
            // magic, do not touch
            nextAction = Time.time + Random.Range(1.5f, 3.5f);
        }
    }
}