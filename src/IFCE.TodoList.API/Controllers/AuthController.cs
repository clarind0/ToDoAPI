using System.Text;
using IFCE.TodoList.Application.Interfaces;
using IFCE.TodoList.Domain.Repositories;
using IFCE.TodoList.Domain.Entities;
using Konscious.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;


namespace IFCE.TodoList.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;
    
    private readonly ITokenInterface _tokenInterface;


    public AuthController(IUsuarioRepository usuarioRepository, ITokenInterface tokenInterface)
    {
        _usuarioRepository = usuarioRepository;
        _tokenInterface = tokenInterface;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var existingUser = await _usuarioRepository.GetByEmailAsync(request.Email!);
        if (existingUser != null)
        {
            return BadRequest("Email Já em uso");
        }

        if (request.Password != request.ConfirmPassword)
        {
            return BadRequest("A senhas não coincidem");
        }
        
        var passwordHash = HashPassword(request.Password!);

        // Criar o novo usuário
        var usuario = new Usuario
        {
            Email = request.Email,
            Nome = request.Nome,
            Password = passwordHash
        };
        await _usuarioRepository.AddAsync(usuario);
        return Ok(new { message = "Usuário cadastrado com sucesso" });
    }
    
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var usuario = await _usuarioRepository.GetByEmailAsync(request.Email);
        if (usuario == null || usuario.Password != request.Password)
            return Unauthorized("Credenciais inválidas.");

        var token = _tokenInterface.GenerateToken(usuario);

        return Ok(new { token });
    }


    private string HashPassword(string password)
    {
        using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
        argon2.DegreeOfParallelism = 8;
        argon2.MemorySize = 8192;
        argon2.Iterations = 4;
        return Convert.ToBase64String(argon2.GetBytes(32)); // 32 bytes para o hash
    }
}

public class RegisterRequest
{
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
}