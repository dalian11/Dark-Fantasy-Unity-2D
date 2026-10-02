using UnityEngine;

namespace KinghtAdventrue.Uniti
{
    public static class Uniti
    {

        public static Vector3 GetRandomDir()
        {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }

    }


}