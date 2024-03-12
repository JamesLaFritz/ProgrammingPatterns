#region Header
// GameManager.cs
// 
// From [Warped Imagination](https://www.youtube.com/@WarpedImagination)
#endregion

using UnityEngine;

namespace BuilderPattern
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            Enemy enemy = new Enemy.FluentBuilder()
                .WithName("Goblin")
                .WithHealth(100)
                .WithSpeed(5f)
                .WithDamage(10)
                .Build();

            Instantiate(enemy);
        }
    }
}