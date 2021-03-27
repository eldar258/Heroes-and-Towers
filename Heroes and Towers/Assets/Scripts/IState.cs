public interface IState
{
    void Enter();
    void Exit();
    void GraphicAction();
    void PhysicAction();
}