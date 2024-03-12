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

		// Do Enemy Stuff

		/// <summary>
		/// A fluent builder that is easier to read.
		/// Stores all of the properties required to build an enemy and has a method that returns itself every time you set one of the properties.
		/// Finally have a build method to create a new enemy.
		/// </summary>
		public class FluentBuilder
		{
			private string m_name;
			private int m_health;
			private float m_speed;
			private int m_damage;
			private bool m_isBoss;

			public FluentBuilder WithName(string name)
			{
				m_name = name;
				return this;
			}

			public FluentBuilder WithHealth(int health)
			{
				m_speed = health;
				return this;
			}

			public FluentBuilder WithSpeed(float speed)
			{
				m_speed = speed;
				return this;
			}

			public FluentBuilder WithDamage(int damage)
			{
				m_damage = damage;
				return this;
			}

			public FluentBuilder WithIsBoss(bool isBoss)
			{
				m_isBoss = isBoss;
				return this;
			}

			public Enemy Build()
			{
				var enemy = new GameObject("Enemy").AddComponent<Enemy>();
				enemy.Name = m_name;
				enemy.Health = m_health;
				enemy.Speed = m_speed;
				enemy.Damage = m_damage;
				enemy.IsBoss = m_isBoss;

				return enemy;
			}
		}
	}
}

