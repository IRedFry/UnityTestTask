using UnityEngine.SceneManagement;

public class PlayerHealth : LivingEntity
{
    protected override void OnDeath()
    {
        SceneManager.LoadScene(0);
    }
}
