using System.Text.Json;

/// <summary>
/// Tipo da entidade na configuracao
/// </summary>
public class EntityConfig
{
    /// <summary>
    /// Tipo de entidade
    /// </summary>
    /// <value></value>
    public string? type { get; set; }

    /// <summary>
    /// Coordenada X da posicao da entidade
    /// </summary>
    /// <value></value>
    public int x { get; set; }

    /// <summary>
    /// Coordenada Y da posicao da entidade
    /// </summary>
    /// <value></value>
    public int y { get; set; }
}


/// <summary>
/// Definicao do tipo de configuracao do jogo
/// </summary>
public class Config
{
    /// <summary>
    /// Largura do mapa
    /// </summary>
    /// <value></value>
    public int mapWidth { get; set; }

    /// <summary>
    /// Altura do mapa
    /// </summary>
    /// <value></value>
    public int mapHeight { get; set; }

    /// <summary>
    /// Coordenada X da posicao inicial do Robo
    /// </summary>
    /// <value></value>
    public int robotX { get; set; }

    /// <summary>
    /// Coordenada X da posicao inicial do Robo
    /// </summary>
    /// <value></value>
    public int robotY { get; set; }

    /// <summary>
    /// Lista de entidades a ser inserida na primeira fase
    /// </summary>
    /// <value></value>
    public IList<EntityConfig>? entities { get; set; }
}

/// <summary>
/// Classe main do aplicativo
/// </summary>
public class JewelCollector
{
    /// <summary>
    /// Metodo de entrada do aplicativo
    /// </summary>
    public static void Main()
    {
        string jsonString = File.ReadAllText("config.json");
        Config gameConfig = JsonSerializer.Deserialize<Config>(jsonString)!;
        Game game = new Game(gameConfig.mapWidth, gameConfig.mapHeight, gameConfig.robotX, gameConfig.robotY);
        if (gameConfig.entities != null)
        {
            foreach (EntityConfig e in gameConfig.entities)
            {
                // this ugly, fix this
                if (e.type == "Red") game.Insert(new Red(e.x, e.y));
                if (e.type == "Blue") game.Insert(new Blue(e.x, e.y));
                if (e.type == "Green") game.Insert(new Green(e.x, e.y));
                if (e.type == "Tree") game.Insert(new Tree(e.x, e.y));
                if (e.type == "Water") game.Insert(new Water(e.x, e.y));
            }
        }
        // make it count the total of points
        game.StartLoop();
    }
}