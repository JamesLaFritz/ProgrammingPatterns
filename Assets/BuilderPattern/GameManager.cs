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
        [SerializeField] private EnemyData m_enemyData = default;

        private EnemyDirector m_enemyDirector = new EnemyDirector(new EnemyBuilder());
        
        private void Start()
        {
            Enemy enemy = m_enemyDirector.Construct(m_enemyData);

            Instantiate(enemy);
        }
    }
}