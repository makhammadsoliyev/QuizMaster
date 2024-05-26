namespace QuizMaster.Service.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() { }

    public NotFoundException(string message) : base(message) { }

    public int StatusCode => 404;
}
