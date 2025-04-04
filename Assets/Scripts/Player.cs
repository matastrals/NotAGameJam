public class Player : Character
{
    private float Energy { get; set; }
    
    public Player(string name, float health, float atk, float def, float speed, float energy)
        : base(name, health, atk, def, speed)  // Appel du constructeur de la classe mere
    {
        Energy = 100;  // Initialisation de l'energie du Player
    }
        
}