public delegate void PositionChangedHandler(Position oldPosition, Position newPosition, Entity entity);

/// <summary>
/// Classe Robo
/// </summary>
public class Robot : Entity
{
    /// <summary>
    /// O Robo precisa interagir com metodos do jogo para poder acessar outras instancias
    /// </summary>
    /// <value></value>
    private Game Game { get; }

    /// <summary>
    /// Pontos de energia do robo
    /// </summary>
    private int HealthPoints = 5;

    /// <summary>
    /// Sacola do Robo
    /// </summary>
    private List<ICollectable> Bag = new List<ICollectable>();

    /// <summary>
    /// Construtor
    /// </summary>
    /// <param name="robotX">Coordenada X da posicao inicial</param>
    /// <param name="robotY">Coordenada X da posicao inicial</param>
    /// <param name="game">Referencia a instancia do jogo</param>
    /// <returns></returns>
    public Robot(int robotX, int robotY, Game game) : base(new Position(robotX, robotY))
    {
        Game = game;
    }

    /// <summary>
    /// Event a ser ativado quando muda a posicao do robo
    /// </summary>
    public event PositionChangedHandler? PositionChanged;

    /// <summary>
    /// Move o robo de acordo com a chave pressionada
    /// </summary>
    /// <param name="key">Chave pressionada</param>
    public void OnKeyPress(ConsoleKey key)
    {
        try
        {
            switch (key)
            {
                case ConsoleKey.W:
                    {
                        Move(new Position(0, -1));
                        break;
                    }
                case ConsoleKey.A:
                    {
                        Move(new Position(-1, 0));
                        break;
                    }
                case ConsoleKey.S:
                    {
                        Move(new Position(0, 1));
                        break;
                    }
                case ConsoleKey.D:
                    {
                        Move(new Position(1, 0));
                        break;
                    }
                case ConsoleKey.G:
                    {
                        Game.GrabJewels();
                        break;
                    }
            }

        }
        catch (OutOfBoundsException) { }
        catch (CollisionException) { }
    }

    /// <summary>
    /// Mover o robo para a posicao nova
    /// </summary>
    /// <param name="newPosition">A posicao nova</param>
    public void MoveTo(Position newPosition)
    {
        Position = newPosition;
    }

    /// <summary>
    /// Mover o robo dado a variacao da posicao
    /// </summary>
    /// <param name="deltaPosition"></param>
    public void Move(Position deltaPosition)
    {
        Position oldPosition = Position;
        Position newPosition = Position + deltaPosition;
        Game.CheckCollision(newPosition); // this can trigger errors
        Position = newPosition;
        HealthPoints--;
        if (PositionChanged != null)
        {
            PositionChanged(oldPosition, newPosition, this);
        }
    }

    /// <summary>
    /// Aumenta os pontos de energia
    /// </summary>
    /// <param name="value">Quantidade a ser adicionada</param>
    public void AddHealth(int value)
    {
        HealthPoints += value;
    }

    /// <summary>
    /// Verifica se os pontos de energia do robo chegou a 0 (zero)
    /// </summary>
    public bool IsDead()
    {
        return HealthPoints == 0;
    }

    /// <summary>
    /// Adicionar o colecionavel na sacola
    /// </summary>
    /// <param name="collectable"></param>
    public void AddToBag(ICollectable collectable)
    {
        Bag.Add(collectable);
    }

    /// <summary>
    /// Imprime as informacoes da sacola
    /// </summary>
    /// <returns></returns>
    public string BagInfo()
    {
        int total = 0;
        foreach (Jewel jewel in Bag)
        {
            total += jewel.GetValue();
        }
        return $"Bag total items: {Bag.Count} | Bag total value: {total}";
    }

    /// <summary>
    /// Imprime as informacoes gerais do robo
    /// </summary>
    /// <returns></returns>
    public string HealthInfo()
    {
        return $"Health: {HealthPoints}";
    }


    /// <summary>
    /// Representacao em String da entidade
    /// </summary>
    public override string ToString()
    {
        return "ME";
    }
}