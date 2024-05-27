using JobFinder.Domain.Entities.Concretes;
using JobFinderPractic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobFinderPractic.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVM)
    {
        if (!ModelState.IsValid)
        {
            return View(loginVM);
        }
        User user = new();
        if (loginVM.Email.Contains("@"))
        {
            user = await _userManager.FindByEmailAsync(loginVM.Email);
        }
        if (user == null)
        {
            ModelState.AddModelError("", "Invalid Username Or Password!");
            return View();
        }
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginVM.Password, true);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Invalid Username Or Password!");
            return View();
        }
        if (result.IsLockedOut)
        {
            ModelState.AddModelError("", "Try Again Later!");
            return View();
        }
        await _signInManager.SignInAsync(user, loginVM.RememberMe);
        return RedirectToAction("Index", "Home");
    }
    // Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        if (!ModelState.IsValid)
        {
            return View(registerVM);
        }
        User user = new User()
        {
            UserName = registerVM.Email,
            FullName = registerVM.FullName,
            Email = registerVM.Email,
            Role = registerVM.Role
        };
        var result = await _userManager.CreateAsync(user, registerVM.Password);
        if (!result.Succeeded)
        {

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View();
        }
        return RedirectToAction("Login");
    }
    // LogOut
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // Access Denied
    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }
}
