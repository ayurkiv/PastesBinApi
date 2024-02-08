namespace Application.Exceptions;


public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException() : base()
    {
    }

    // Додатковий конструктор з можливістю передачі повідомлення та внутрішнього винятку
    public NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
