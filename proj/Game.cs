
public delegate void KeyPressedHandler(ConsoleKey key);

/// <summary>
/// Classe teoricamnte Singleton que cuida todas as interacoes entre as instancias do jogo,
/// e a comunicacao com a classe Main
/// </summary>
public class Game
{
    /// <summary>
    /// Configuracao para a proporcao de joias vermelhas no mapa
    /// </summary>
    const double RED_MULTIPLIER = 0.02;

    /// <summary>
    /// Configuracao para a proporcao de joias vermelhas no mapa
    /// </summary>
    const double BLUE_MULTIPLIER = 0.02;

    /// <summary>
    /// Configuracao para a proporcao de joias vermelhas no mapa
    /// </summary>
    const double GREEN_MULTIPLIER = 0.02;

    /// <summary>
    /// Configuracao para a proporcao de joias vermelhas no mapa
    /// </summary>
    const double WATER_MULTIPLIER = 0.05;

    /// <summary>
    /// Configuracao para a proporcao de joias vermelhas no mapa
    /// </summary>
    const double TREE_MULTIPLIER = 0.07;

    /// <summary>
    /// A instancia do Mapa no jogo
    /// </summary>
    /// <value></value>
    private Map Map { get; set; }
    /// <summary>
    /// A instancia do Robo no jogo, note que ela sera incluida no Mapa tambem
    /// </summary>
    /// <value></value>
    private Robot Robot { get; set; }

    /// <summary>
    /// Evento para detectar quando uma tecla é pressionada
    /// </summary>
    private event KeyPressedHandler KeyPressed;

    /// <summary>
    /// Construtor do jogo, inicializa todas as instancias, 
    /// e faz a inscricao dos eventos, aqui ainda nao eh feito a inclusao de outras entidades
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="robotX"></param>
    /// <param name="robotY"></param>
    public Game(int width, int height, int robotX, int robotY)
    {
        Robot = new Robot(robotX, robotY, this);
        Map = new Map(width, height);
        Map.Insert(Robot);
        Robot.PositionChanged += Map.UpdatePosition;
        KeyPressed += Robot.OnKeyPress;
    }

    /// <summary>
    /// Reinicia o jogo, reinicializando todas as instancias
    /// </summary>
    private void Restart()
    {
        Robot.PositionChanged -= Map.UpdatePosition;
        KeyPressed -= Robot.OnKeyPress;
        int width = Map.Width + 1;
        int height = Map.Height + 1;
        if (width > 30) width = 30;
        if (height > 30) height = 30;
        int numberOfCells = width * height;
        Random rnd = new Random();
        Robot = new Robot(rnd.Next(0, width), rnd.Next(0, height), this);
        Map = new Map(width, height);
        Map.Insert(Robot);
        InsertBlue(numberOfCells);
        InsertGreen(numberOfCells);
        InsertRed(numberOfCells);
        InsertTree(numberOfCells);
        InsertWater(numberOfCells);
        Robot.PositionChanged += Map.UpdatePosition;
        KeyPressed += Robot.OnKeyPress;

    }

    /// <summary>
    /// Função auxiliar para incluir as jóias azuis
    /// </summary>
    /// <param name="numberOfCells">número total de células</param>
    private void InsertBlue(int numberOfCells)
    {
        int numberOfBlue = (int)Math.Floor(numberOfCells * BLUE_MULTIPLIER);
        for (int i = 0; i < numberOfBlue; i++)
        {
            Position position = Map.GetEmptyPosition();
            Map.Insert(new Blue(position));
        }
    }

    /// <summary>
    /// Função auxiliar para incluir as jóias verdes
    /// </summary>
    /// <param name="numberOfCells">número total de células</param>
    private void InsertGreen(int numberOfCells)
    {
        int numberOfGreen = (int)Math.Floor(numberOfCells * GREEN_MULTIPLIER);
        for (int i = 0; i < numberOfGreen; i++)
        {
            Position position = Map.GetEmptyPosition();
            Map.Insert(new Green(position));
        }
    }

    /// <summary>
    /// Função auxiliar para incluir as jóias vermelhas
    /// </summary>
    /// <param name="numberOfCells">número total de células</param>
    private void InsertRed(int numberOfCells)
    {
        int numberOfRed = (int)Math.Floor(numberOfCells * RED_MULTIPLIER);
        for (int i = 0; i < numberOfRed; i++)
        {
            Position position = Map.GetEmptyPosition();
            Map.Insert(new Red(position));
        }
    }

    /// <summary>
    /// Função auxiliar para incluir as árvores
    /// </summary>
    /// <param name="numberOfCells">número total de células</param>
    private void InsertTree(int numberOfCells)
    {
        int numberOfTree = (int)Math.Floor(numberOfCells * TREE_MULTIPLIER);
        for (int i = 0; i < numberOfTree; i++)
        {
            Position position = Map.GetEmptyPosition();
            Map.Insert(new Tree(position));
        }
    }

    /// <summary>
    /// Função auxiliar para incluir as células de água
    /// </summary>
    /// <param name="numberOfCells">número total de células</param>
    private void InsertWater(int numberOfCells)
    {
        int numberOfWater = (int)Math.Floor(numberOfCells * WATER_MULTIPLIER);
        for (int i = 0; i < numberOfWater; i++)
        {
            Position position = Map.GetEmptyPosition();
            Map.Insert(new Water(position));
        }
    }

    /// <summary>
    /// Insere uma Entity no jogo
    /// </summary>
    /// <param name="entity">A entidade a ser inserida</param>
    public void Insert(Entity entity)
    {
        Map.Insert(entity);
    }

    /// <summary>
    /// Loop principal do jogo
    /// O programa ficara nessa funcao ate que seja pressionada a tecla escape 
    /// ou quando os pontos de energia do robo chega a 0 (zero)
    /// </summary>
    public void StartLoop()
    {

        ConsoleKeyInfo keyinfo;
        Print();

        do
        {
            keyinfo = Console.ReadKey(true);
            KeyPressed(keyinfo.Key);
            Print();
            if (Robot.IsDead())
            {
                GameEnd();
                break;
            }
            if (Map.IsCleared())
            {
                NewGame();
                Print();

            }
        }
        while (keyinfo.Key != ConsoleKey.Escape);
    }

    /// <summary>
    /// Esse metodo sera executado quando os pontos de energia chegar a 0 (zero)
    /// </summary>
    private void GameEnd()
    {
        Console.WriteLine("Game Over!");
    }

    /// <summary>
    /// Esse metodo sera executado quando o jogador avancar para a proxima fase
    /// </summary>
    private void NewGame()
    {
        Console.WriteLine("Stage Completed!");
        Restart();
    }

    /// <summary>
    /// Imprime todo o grafico do jogo.
    /// Num cenario mais complexo, esse metodo sera substituida por um metodo da classe GraphicManager
    /// </summary>
    private void Print()
    {
        Map.Print();
        Console.WriteLine(Robot.BagInfo());
        Console.WriteLine(Robot.HealthInfo());

    }

    /// <summary>
    /// Wrapper para a interacao  do robo com o mapa
    /// </summary>
    public void GrabJewels()
    {
        Map.Interact(Robot);
    }

    /// <summary>
    /// Metodo Wrapper para verificar colisao
    /// </summary>
    /// <param name="nextPosition">a posicao a ser verificada</param>
    public void CheckCollision(Position nextPosition)
    {
        Map.CheckCollision(nextPosition);
    }

}
