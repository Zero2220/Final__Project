using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UI.Models;
using LoginRequest = UI.Models.LoginRequest;
using RegisterRequest = UI.Models.RegisterRequest;

namespace UI.Controllers
{
        public class AccountController : Controller
        {
            private HttpClient _client;
            public AccountController()
            {
                _client = new HttpClient();
            }
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login(LoginRequest loginRequest)
            {
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var content = new StringContent(JsonSerializer.Serialize(loginRequest, options), System.Text.Encoding.UTF8, "application/json");
                using (var response = await _client.PostAsync("https://localhost:7127/login", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var loginResponse = JsonSerializer.Deserialize<LoginResponse>(await response.Content.ReadAsStringAsync(), options);

                        Response.Cookies.Append("token", "Bearer " + loginResponse.Token);
                        return RedirectToAction("index", "Home");
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        ModelState.AddModelError("", "Email or Password incorrect!");
                        return View();
                    }
                    else
                    {
                        TempData["Error"] = "Something went wrong";
                    }
                }

                return View();
            }

            public IActionResult Register()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Register(RegisterRequest registerRequest)
            {
                if (!ModelState.IsValid)
                {
                    return View(registerRequest);
                }

                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var content = new StringContent(JsonSerializer.Serialize(registerRequest, options), System.Text.Encoding.UTF8, "application/json");
                using (var response = await _client.PostAsync("https://localhost:7127/api/Auth/register", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Success"] = "Registration successful. Please log in.";
                        return RedirectToAction("Login");
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        var registerResponse = JsonSerializer.Deserialize<RegisterResponse>(await response.Content.ReadAsStringAsync(), options);
                        foreach (var error in registerResponse.Errors)
                        {
                            ModelState.AddModelError("", error);
                        }
                        return View(registerRequest);
                    }
                    else
                    {
                        TempData["Error"] = "Something went wrong during registration.";
                    }
                }

                return View(registerRequest);
            }
        }
    
}
