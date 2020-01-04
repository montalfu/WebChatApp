using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChatApp.Models;
using PusherServer;

namespace WebChatApp.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        public ActionResult Login()
        {
            string user_name = Request.Form["username"];
            if(user_name.Trim()=="")
            {
                return Redirect("/");
            }

            using(var db=new Models.ChatContext())
            {
                User user = db.Users.FirstOrDefault(u => u.name == user_name);
                if(user==null)
                {
                    user = new User { name = user_name };
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                Session["user"] = user;
            }
            return Redirect("/chat");
        }
        public JsonResult AuthForChannel (string channel_name, string socket_id)
        {
            if(Session["user"]==null)
            {
                return Json(new { status = "error", message = "User not logged in" });
            }
            var currentUser = (Models.User)Session["user"];
            var options = new PusherOptions();
            options.Cluster = "ap1";

            var pusher = new Pusher(
                "926524",
                "287a54845d56b48f18a9",
                "de8906963ac6a7d4d573",
                options);
            if(channel_name.IndexOf(currentUser.id.ToString())==-1)
            {
                return Json(new { status = "error", message = "User cannot join in this channel" });
            }

            var auth = pusher.Authenticate(channel_name, socket_id);

            return Json(auth);
        }
    }
}