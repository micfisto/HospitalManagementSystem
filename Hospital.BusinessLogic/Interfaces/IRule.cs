namespace Hospital.BusinessLogic.Interfaces;

public interface IRule<T>
{
    Result<T> Check(T? entity);
}