using IFCE.TodoList.Domain.Entities;

namespace IFCE.TodoList.Application.Interfaces;

public interface ITokenInterface
{
    string GenerateToken(Usuario usuario);
}