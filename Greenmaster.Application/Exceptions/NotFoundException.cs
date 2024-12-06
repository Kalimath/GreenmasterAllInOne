namespace Greenmaster.Application.Exceptions;

public class NotFoundException(string name, object id) : Exception($"{name} ({id}) is not found.");