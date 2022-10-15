using Domain.Shared;
using Identity.Data;
using Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task<ActionResult<AppUserDto>> SignIn(SignInDto signInDto)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(signInDto.UserName);
                if (user == null) return Unauthorized();

                var result = await _signInManager.CheckPasswordSignInAsync(user, signInDto.Password, false);

                if (!result.Succeeded) return Unauthorized();

                if (user.AccountExpire < DateTime.Now.AddDays(-1)) return BadRequest();

                user.LoginCount += 1;
                await _userManager.UpdateAsync(user);

                var userDto = new AppUserDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Company = user.Company,
                    Email = user.Email,
                    Role = user.Role,
                    Token = user.Role == "admin" ? _tokenService.CreateToken(user, true) : _tokenService.CreateToken(user),
                    AccountExpire = user.AccountExpire,
                };

                return Ok(userDto);
            }
            catch
            {
                return StatusCode(500);
            }
        }   

        [HttpGet("current")]
        [Authorize]
        public async Task<ActionResult<AppUserDto>> GetCurrent()
        {
            try
            {
                var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _userManager.FindByNameAsync(username);
                if (user == null) return NotFound();
                var userDto = new AppUserDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Company = user.Company,
                    Email = user.Email,
                    Role = user.Role,
                    AccountExpire = user.AccountExpire,
                };
                return Ok(userDto);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<AppUserDto>>> GetAll()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();

                var dtoList = new List<AccountManaged>();

                foreach (var user in users)
                {
                    if (user.Role == "admin") continue;

                    var dto = remapUserToManaged(user);

                    dtoList.Add(dto);
                }

                return Ok(dtoList);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("edit")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<AccountManaged>> CreateUser(AccountManaged dto)
        {
            try
            {
                var newUser = new AppUser
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    UserName = dto.UserName.ToLower(),
                    Email = dto.Email,
                    Company = dto.Company,
                    Role = "guest",
                    AccountExpire = dto.AccountExpire,
                };


                await _userManager.CreateAsync(newUser, dto.Password);
                var user = await _userManager.FindByNameAsync(dto.UserName);

                var managed = remapUserToManaged(user);
                return Ok(managed);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("edit")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<AccountManaged>> UpdateUser(AccountManaged dto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(dto.Id);
                if (user == null) return BadRequest();

                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.UserName = dto.UserName;
                user.Email = dto.Email;
                user.Company = dto.Company;
                user.AccountExpire = dto.AccountExpire;

                await _userManager.UpdateAsync(user);

                if (dto.Password != null)
                {
                    await _userManager.RemovePasswordAsync(user);
                    await _userManager.AddPasswordAsync(user, dto.Password);
                }

                var managed = remapUserToManaged(user);
                return Ok(managed);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("edit")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(RequestById id)
        {
            if (id == null) return BadRequest();
            try
            {
                var user = await _userManager.FindByIdAsync(id.Id.ToString());
                if (user == null) return NotFound();
                await _userManager.DeleteAsync(user);
                return Ok();
            } 
            catch 
            {
                return StatusCode(500);
            }
        }

        private AccountManaged remapUserToManaged(AppUser user)
        {
            var accountManaged = new AccountManaged
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                AccountExpire = user.AccountExpire,
                Company = user.Company,
                LoginCount = user.LoginCount,
                ExportedPdf = user.ExportedPdf,
            };

            return accountManaged;
        }
    }
}
