using AutoMapper.Configuration.Annotations;
using Demo.DataAccess.Models.IdentityModels;
using Demo.Persentation.Helper;
using Demo.Persentation.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Persentation.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager) : Controller
    {
        #region Rigister
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                //Map From Regster ViewModel  To APllicationUser
                var user = new ApplicationUser()
                {

                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    UserName = viewModel.UserName

                };
                var result = _userManager.CreateAsync(user, viewModel.Password).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("LogIn");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(viewModel);

        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(LogInViewModel logInViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(logInViewModel.Email).Result;

                if (user is null)
                {
                    ModelState.AddModelError(string.Empty, "InvaildLogin");
                }
                else
                {
                    var Flag = _userManager.CheckPasswordAsync(user, logInViewModel.Password).Result;

                    if (Flag)
                    {

                        var result = _signInManager.PasswordSignInAsync(user, logInViewModel.Password, false, false).Result;
                        if (result.Succeeded) return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "InvaildLogin");
                    }
                }
            }

            return View(logInViewModel);
        }
        #endregion

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction(nameof(LogIn));
        }
        #region forgetPassword
        [HttpGet]
        public IActionResult ForgetPassword()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SendRestPasswordUrl(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            if(ModelState.IsValid)
            {

                var user = _userManager.FindByEmailAsync(forgetPasswordViewModel.Email).Result;

                if(user is not null)
                {
                    //Gerate Token
                    var token = _userManager.GeneratePasswordResetTokenAsync(user);
                    //Create Url
                    var url = Url.Action("ResetPassword","Account",new {email= forgetPasswordViewModel.Email, token },Request.Scheme);
                    //Create Email
                    var email = new Email()
                    {
                        TO= forgetPasswordViewModel.Email,
                        Subject= "Reset Password",
                        Body= url


                    };
                    // send Email

                  bool IsMailSent=  EmailSettings.SendEmail(email);
                    if(IsMailSent)
                    {
                        return RedirectToAction(nameof(CheckYourInBox));
                    }
                     
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Somthing Went Wrong , Try Again!");
                }
            }
            
            return View("ForgetPassword");
        }
        #endregion
        public IActionResult CheckYourInBox()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            TempData["email"] = email;
            TempData["token"] = token;

            return View();
        }
        [HttpPost]
        public IActionResult RestPassword(RestPasswordViewModel restPasswordViewModel)
        {
            if(ModelState.IsValid)
            {
                var email = TempData["email"] as string;
                var token = TempData["token"] as string;

                if (email is null || token is null) return BadRequest();
                else
                {
                    var user = _userManager.FindByEmailAsync(email).Result;
                    if (user is not null)
                    {
                     var res= _userManager.ResetPasswordAsync(user, token, restPasswordViewModel.Password).Result;

                        if(res.Succeeded)
                        {
                            return RedirectToAction(nameof(LogIn));
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Somthing Went Wrong , Try Again!");
                    }

                }
                


            }
            return View(restPasswordViewModel);
        }

    }
}
