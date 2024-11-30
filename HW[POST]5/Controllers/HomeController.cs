using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task Index()
        {
            string content = @"<form method='post'>
        <p>Name: <input type='text' name='name'/></p>
        <p>Surname: <input type='text' name='surname'/></p>
        <p>Group: <input type='text' name='group'/></p>
        <p>Math grades: <input type=='number' name='Math'/></p>
        <p>English grades: <input type=='number' name='English'/></p>
        <p>Physics grages: <input type=='number' name='Physics'/></p>
        <p>Programming languages, you know: <input type='text' name='languages'/></p>
        <p><input type='submit' value='Отправить'/></p>
        </form>";
            Response.ContentType = "text/html;charset=utf-8";
            await Response.WriteAsync(content);
        }
        [HttpPost]
        public string Index(Dictionary<string, string> items)
        {
            string name = Request.Form["name"];
            string surname = Request.Form["surname"];
            string group = Request.Form["group"];
            string mathValue = Request.Form["Math"];
            string englishValue = Request.Form["English"];
            string physicsValue = Request.Form["Physics"];

            if (string.IsNullOrEmpty(mathValue) || string.IsNullOrEmpty(englishValue) || string.IsNullOrEmpty(physicsValue))
            {
                return "Error";
            }
            int math = int.Parse(mathValue);
            int english = int.Parse(englishValue);
            int physics = int.Parse(physicsValue);
            string prog = Request.Form["languages"];
            int average = (math+english+physics)/3;

            return $"Name:{name}\nSurname:{surname}\nGroup:{group}\nAverage grade:{average}\nProgramming languages, you know:{prog}";
        }
    }
}