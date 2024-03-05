namespace Extratinhos.Exceptions;

public class LimitException : System.Exception
{
	public LimitException() { }

	public LimitException(string message) : base(message) { }

	public LimitException(string message, Exception inner) : base(message, inner) { }
}