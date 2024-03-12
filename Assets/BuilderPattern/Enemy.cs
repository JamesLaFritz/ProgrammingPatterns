using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderPattern
{
	public class Enemy : MonoBehaviour
	{
		public string Name { get; private set; }
		public int Health { get; private set; }
		public float Speed { get; private set; }
		public int Damage { get; private set; }
		public bool IsBoss { get; private set; }


		// Code smell
		// Too many constructor parameters
		// Telescoping Constructors

		public Enemy(string name) => Name = name;
		public Enemy(string name, int health) : this(name) => Health = health;
		public Enemy(string name, int health, float speed) : this(name, health) => Speed = speed;
		public Enemy(string name, int health, float speed, int damage) : this(name, health, speed) => Damage = damage;

		public Enemy(string name, int health, float speed, int damage, bool isBoss) : this(name, health, speed) =>
			IsBoss = isBoss;

		// Do Enemy Stuff
	}
}

