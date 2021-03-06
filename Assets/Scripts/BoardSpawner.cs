using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpawner : MonoBehaviour
{
    [SerializeField] Token _tokenPrefab = null;

    public Token SpawnToken(Vector3 position)
    {
        // assign it into new variable, so we can return it
        Token newToken = Instantiate(_tokenPrefab, position, _tokenPrefab.transform.rotation);

        return newToken;
    }

    public void RemoveToken(Token spawnedToken)
    {
        spawnedToken.gameObject.SetActive(false);
    }
}
