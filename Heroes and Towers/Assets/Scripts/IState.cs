public interface IState
{
    /// <summary>
    /// Вход в состояние
    /// </summary>
    void Enter();
    /// <summary>
    /// Выход из состояния
    /// </summary>
    void Exit();
    /// <summary>
    /// Действия требующие высокой частоты
    /// </summary>
    void GraphicAction();
    /// <summary>
    /// Действия не трубующие высокой частоты
    /// </summary>
    void PhysicAction();
}