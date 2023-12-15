using Pleberr.Models;
using Pleberr.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pleberr.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index(string firstName, string lastName, string email, string emailRepeat, string password, string passwordRepeat)
        {
            List<string> errors = new List<string>();
            bool isValid = true;
            int? id = null;
            string token = string.Empty;

            if (firstName == null && lastName == null && email == null && emailRepeat == null && password == null && passwordRepeat == null)
            {
                return View(errors);
            }
            else if (firstName == null && lastName == null && email != string.Empty && emailRepeat == null && password != string.Empty && passwordRepeat == null)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
                using (SHA384 sha = SHA384.Create())
                {
                    await conn.OpenAsync();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("SELECT [Id], [Password] FROM [User] WHERE [Email]='{0}'", email);

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        byte[] buffer = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                        password = BitConverter.ToString(buffer).Replace("-", string.Empty).ToLower();
                        id = reader.GetInt32(0);

                        if (reader.GetString(1) == BitConverter.ToString(buffer).Replace("-", string.Empty).ToLower())
                        {
                            token = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(password + email))).Replace("-", string.Empty).ToLower();

                            Response.Cookies["token"].Value = token;
                            Response.Cookies["token"].Expires = DateTime.Now.AddDays(25);
                            Response.Cookies["id"].Value = id.ToString();
                            Response.Cookies["id"].Expires = DateTime.Now.AddDays(25);

                            return RedirectToAction("member", new
                            {
                                id = id,
                                token = token
                            });
                        }
                        else
                        {
                            errors.Add("Incorrect password.");

                            return View(errors);
                        }
                    }
                    else
                    {
                        errors.Add("Incorrect email or password.");

                        return View(errors);
                    }
                }
            }
            else if (firstName != string.Empty && lastName != string.Empty && email != string.Empty && emailRepeat != string.Empty && password != string.Empty && passwordRepeat != string.Empty)
            {
                if (email != emailRepeat)
                {
                    errors.Add("Your E-Mail Addresses do not match.");
                    isValid = false;
                }

                if (password != passwordRepeat)
                {
                    errors.Add("Your Passwords do not match.");
                    isValid = false;
                }
                else if (password.Length < 6)
                {
                    errors.Add("Your password should be at least 6 characters long.");
                    isValid = false;
                }

                if (isValid)
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
                    using (SHA384 sha = SHA384.Create())
                    {
                        await conn.OpenAsync();

                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "SELECT [Email] FROM [User]";

                        SqlDataReader reader = await cmd.ExecuteReaderAsync();

                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                if (email == reader.GetString(0))
                                {
                                    errors.Add("There is already a user with this E-Mail Address.");
                                    return View(errors);
                                }
                            }
                        }

                        reader.Close();

                        byte[] buffer = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                        password = BitConverter.ToString(buffer).Replace("-", string.Empty).ToLower();

                        cmd.CommandText = string.Format(@"INSERT INTO [User] ([FirstName], [LastName], [Email], 
                                                        [School], [Work], [Location], [Relationship], [Birthdate], 
                                                        [Weight], [Height], [Friends], [Password], [Online], [Gender], [Email2], [Telephone]) VALUES ('{0}', 
                                                        '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', 
                                                        '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}')", firstName, lastName, email, "Your school", "Your work", "Your current location", "Your relationship status", DateTime.Now.AddYears(1000), 0, 0.0f, string.Empty, password, true, "Your gender", "Your email", "Your telephone");

                        await cmd.ExecuteNonQueryAsync();

                        cmd.CommandText = string.Format("SELECT [Id] FROM [User] WHERE [Email]='{0}'", email);
                        reader = await cmd.ExecuteReaderAsync();

                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                id = reader.GetInt32(0);
                            }
                        }

                        reader.Close();

                        cmd.CommandText = string.Format(@"INSERT INTO [Post] ([Owner], [Author], [DateCreated], 
                                                        [Content], [Likes], [Type], [Liked], [Privacy], [Name]) VALUES ('{0}', '{1}', '{2}', 
                                                        '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", id, id, DateTime.Now, "It seems empty in here. Why don''t you start by publishing your first post?", 0, "text", id.ToString(), "public", "Loukas Anastasiou");

                        await cmd.ExecuteNonQueryAsync();

                        cmd.CommandText = string.Format(@"INSERT INTO [Setting] ([User], [PostsPrivacy], [InfoPrivacy], [FriendsPrivacy], [PicturesPrivacy]) 
                                                        VALUES ('{0}', 'False', 'False', 'False', 'False')", id);

                        await cmd.ExecuteNonQueryAsync();

                        DirectoryInfo dInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "sample");
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + id);

                        foreach (FileInfo file in dInfo.GetFiles())
                        {
                            file.CopyTo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, id.ToString(), file.Name), true);
                        }

                        buffer = sha.ComputeHash(Encoding.UTF8.GetBytes(password + email));
                        token = BitConverter.ToString(buffer).Replace("-", string.Empty).ToLower();

                        Response.Cookies["token"].Value = token;
                        Response.Cookies["token"].Expires = DateTime.Now.AddDays(25);
                        Response.Cookies["id"].Value = id.ToString();
                        Response.Cookies["id"].Expires = DateTime.Now.AddDays(25);

                        return RedirectToAction("member", new
                        {
                            id = id,
                            token = token
                        });
                    }
                }
                else
                {
                    return View(errors);
                }
            }

            errors.Add("Please, fill in all required fields.");

            return View(errors);
        }

        public async Task<ActionResult> Member(int? id, string token)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

            if (id == null && token == null)
            {
                return RedirectToAction("Index");
            }
            else if (id != null && token == null)
            {
                if (Request.Cookies["token"] != null)
                {
                    token = Server.HtmlEncode(Request.Cookies["token"].Value);
                }
                else
                {
                    token = string.Empty;
                }
            }

            User user = await GetUser(id);

            return View(new Dictionary<string, User>() { { token, user } });
        }

        public async Task<ActionResult> Home(int? id, string token)
        {
            if (id == null && token == null)
            {
                return RedirectToAction("Index");
            }
            else if (id != null && token == null)
            {
                if (Request.Cookies["token"] != null)
                {
                    token = Server.HtmlEncode(Request.Cookies["token"].Value);
                }
                else
                {
                    token = string.Empty;
                }
            }

            User user = await GetUser(id);

            return View(user);
        }

        public async Task<ActionResult> Feed(int? id, string token)
        {
            List<Post> posts = new List<Post>();
            List<string> friends = new List<string>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT [Friends] FROM [User] WHERE [Id]='{0}'", id);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();

                    friends.AddRange(reader.GetString(0).Split(' ').Skip<string>(1));
                    friends.Add(id.ToString());
                }

                foreach (string friend in friends)
                {
                    reader.Close();
                    cmd.CommandText = string.Format("SELECT * FROM [Post] WHERE [Owner]='{0}'", friend);
                    reader = await cmd.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            posts.Add(new Pleberr.Models.Post()
                            {
                                Id = reader.GetInt32(0),
                                Owner = reader.GetInt32(1),
                                Author = reader.GetInt32(2),
                                DateCreated = reader.GetDateTime(3),
                                Content = reader.GetString(4),
                                Likes = reader.GetInt32(5),
                                Type = reader.GetString(6),
                                Privacy = reader.GetString(8),
                                Name = reader.GetString(9)
                            });
                        }
                    }
                }
            }

            posts.Sort(new PostComparer());
            posts.Reverse();

            return View(new Dictionary<User, List<Post>>() { { await GetUser(id), posts } });
        }

        public async Task<ActionResult> Friends(int? id, string token)
        {
            if (!Authenticate(id, token).Result)
            {
                return RedirectToAction("Empty");
            }

            return View(new Dictionary<User, List<User>>() { { await GetUser(id), await GetFriends(id) } });
        }

        public async Task<ActionResult> Pictures(int? id, string token)
        {
            if (!Authenticate(id, token).Result)
            {
                return RedirectToAction("Empty");
            }

            User user = await GetUser(id);

            return View(user);
        }

        public async Task<ActionResult> Settings(int? id, string token)
        {
            if (!Authenticate(id, token).Result)
            {
                return RedirectToAction("Empty");
            }

            User user = await GetUser(id);

            return View(user);
        }

        public async Task<ActionResult> Messages(int? id, string token)
        {
            if (!Authenticate(id, token).Result)
            {
                return RedirectToAction("Empty");
            }

            return View(new Dictionary<User, List<User>>() { { await GetUser(id), await GetFriends(id) } });
        }

        public async Task<ActionResult> UpdateInfo(int? id, string school, string work, string location, string relationship, string birthdate, string height, string weight, string gender, string email2, string telephone)
        {
            if (!Authenticate(id, null).Result)
            {
                return RedirectToAction("Empty");
            }

            DateTime b;
            DateTime.TryParse(birthdate, out b);
            double h;
            double.TryParse(height, out h);
            int w;
            int.TryParse(weight, out w);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format(@"UPDATE [User] SET [School]='{0}', [Work]='{1}', [Location]='{2}', [Relationship]='{3}', 
                                                [Birthdate]='{4}', [Height]='{5}', [Weight]='{6}', [Gender]='{8}', [Email2]='{9}', [Telephone]='{10}' WHERE [Id]='{7}'", school, work, location, relationship, b == null ? DateTime.Now.AddYears(1000) : b, h, w, id, gender, email2, telephone);

                try
                {
                    await cmd.ExecuteNonQueryAsync();

                    return Json(new { status = "Ok" }, JsonRequestBehavior.AllowGet);
                }
                catch (DbException)
                {
                    return Json(new { status = "Error" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public async Task<string> UpdateSettings(int? id, string firstName, string lastName, string email, string emailRepeat, string password, string passwordRepeat, bool postsPrivacy, bool infoPrivacy, bool friendsPrivacy, bool picturesPrivacy)
        {
            string result = "All changes have been saved.";
            Setting setting = new Setting();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT [PostsPrivacy], [InfoPrivacy], [FriendsPrivacy], [PicturesPrivacy] FROM [Setting] WHERE [User]='{0}'", id);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();

                    setting.PostsPrivacy = reader.GetBoolean(0);
                    setting.InfoPrivacy = reader.GetBoolean(1);
                    setting.FriendsPrivacy = reader.GetBoolean(2);
                    setting.PicturesPrivacy = reader.GetBoolean(3);
                }
            }

            if (firstName != string.Empty || lastName != string.Empty)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
                {
                    await conn.OpenAsync();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("UPDATE [User] SET [FirstName]='{0}', [LastName]='{1}' WHERE [Id]='{2}'", firstName, lastName, id);
                    await cmd.ExecuteNonQueryAsync();
                }

                if (email != string.Empty && emailRepeat != string.Empty)
                {
                    if (email == emailRepeat)
                    {
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
                        using (SHA384 sha = SHA384.Create())
                        {
                            await conn.OpenAsync();

                            SqlCommand cmd = conn.CreateCommand();
                            cmd.CommandText = string.Format("UPDATE [User] SET [Email]='{0}' WHERE [Id]='{1}'", email, id);
                            await cmd.ExecuteNonQueryAsync();

                            cmd.CommandText = string.Format("SELECT [Password] FROM [User] WHERE [Id]='{0}'", id);
                            SqlDataReader reader = await cmd.ExecuteReaderAsync();
                            await reader.ReadAsync();

                            var buffer = sha.ComputeHash(Encoding.UTF8.GetBytes(reader.GetString(0) + email));
                            var token = BitConverter.ToString(buffer).Replace("-", string.Empty).ToLower();

                            Response.Cookies["token"].Value = token;
                            Response.Cookies["token"].Expires = DateTime.Now.AddDays(25);
                        }
                    }
                    else
                    {
                        result = "The email addresses do not match.";
                    }
                }
                if (password != string.Empty && passwordRepeat != string.Empty && password.Length >= 6)
                {
                    if (password == passwordRepeat)
                    {
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
                        using (SHA384 sha = SHA384.Create())
                        {
                            await conn.OpenAsync();

                            SqlCommand cmd = conn.CreateCommand();
                            cmd.CommandText = string.Format("UPDATE [User] SET [Password]='{0}' WHERE [Id]='{1}'", BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", string.Empty).ToLower(), id);
                            await cmd.ExecuteNonQueryAsync();

                            cmd.CommandText = string.Format("SELECT [Email] FROM [User] WHERE [Id]='{0}'", id);
                            SqlDataReader reader = await cmd.ExecuteReaderAsync();
                            await reader.ReadAsync();

                            var token = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", string.Empty).ToLower() + reader.GetString(0)))).Replace("-", string.Empty).ToLower();

                            Response.Cookies["token"].Value = token;
                            Response.Cookies["token"].Expires = DateTime.Now.AddDays(25);
                        }
                    }
                    else
                    {
                        result = "The passwords do not match.";
                    }
                }
            }
            else
            {
                result = "Please, fill in all required fields.";
            }

            if (postsPrivacy != setting.PostsPrivacy && postsPrivacy)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
                {
                    await conn.OpenAsync();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("UPDATE [Post] SET [Privacy]='{0}' WHERE [Owner]='{1}'", "private", id);
                    await cmd.ExecuteNonQueryAsync();

                    cmd.CommandText = string.Format("UPDATE [Setting] SET [PostsPrivacy]='True' WHERE [User]='{0}'", id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            else if (postsPrivacy != setting.PostsPrivacy && !postsPrivacy)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
                {
                    await conn.OpenAsync();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("UPDATE [Post] SET [Privacy]='{0}' WHERE [Owner]='{1}'", "public", id);
                    await cmd.ExecuteNonQueryAsync();

                    cmd.CommandText = string.Format("UPDATE [Setting] SET [PostsPrivacy]='False' WHERE [User]='{0}'", id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            if (infoPrivacy != setting.InfoPrivacy && infoPrivacy)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
                {
                    await conn.OpenAsync();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("UPDATE [Setting] SET [InfoPrivacy]='True' WHERE [User]='{0}'", id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            else if (infoPrivacy != setting.InfoPrivacy && !infoPrivacy)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
                {
                    await conn.OpenAsync();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("UPDATE [Setting] SET [InfoPrivacy]='False' WHERE [User]='{0}'", id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            if (friendsPrivacy != setting.FriendsPrivacy && friendsPrivacy)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
                {
                    await conn.OpenAsync();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("UPDATE [Setting] SET [FriendsPrivacy]='True' WHERE [User]='{0}'", id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            else if (friendsPrivacy != setting.FriendsPrivacy && !friendsPrivacy)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
                {
                    await conn.OpenAsync();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("UPDATE [Setting] SET [FriendsPrivacy]='False' WHERE [User]='{0}'", id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            if (picturesPrivacy != setting.PicturesPrivacy && picturesPrivacy)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
                {
                    await conn.OpenAsync();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("UPDATE [Setting] SET [PicturesPrivacy]='True' WHERE [User]='{0}'", id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            else if (picturesPrivacy != setting.PicturesPrivacy && !picturesPrivacy)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
                {
                    await conn.OpenAsync();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("UPDATE [Setting] SET [PicturesPrivacy]='False' WHERE [User]='{0}'", id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return result;
        }

        [ValidateInput(false)]
        public async Task<ActionResult> Post(int? owner, int? author, string content, string type)
        {
            string name = string.Empty;

            if (!Authenticate(owner, null).Result)
            {
                return RedirectToAction("Empty");
            }

            bool privacy = false;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT [PostsPrivacy] FROM [Setting] WHERE [User]='{0}'", owner);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();
                    privacy = reader.GetBoolean(0);
                }

                reader.Close();

                cmd.CommandText = string.Format("SELECT [FirstName], [LastName] FROM [User] WHERE [Id]='{0}'", author);
                reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();
                    name = string.Format("{0} {1}", reader.GetString(0), reader.GetString(1));
                }

                reader.Close();

                cmd = conn.CreateCommand();
                cmd.CommandText = string.Format(@"INSERT INTO [Post] ([Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) 
                                                VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", owner, author, DateTime.Now, content, 0, type, author.ToString(), privacy ? "private" : "public", name);

                try
                {
                    await cmd.ExecuteNonQueryAsync();

                    return Json(new { status = "Ok" }, JsonRequestBehavior.AllowGet);
                }
                catch (DbException exc)
                {
                    return Json(new { status = "Error", Message = exc.Message }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public async Task<ActionResult> PostComment(int? post, int? user, string content, int? author)
        {
            string name = string.Empty;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT [FirstName], [LastName] FROM [User] WHERE [Id]='{0}'", author);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();

                    name = string.Format("{0} {1}", reader.GetString(0), reader.GetString(1));
                }

                reader.Close();

                cmd.CommandText = string.Format(@"INSERT INTO [Comment] ([Post], [User], [Content], [Author], [Name], [DateCreated]) VALUES 
                                                ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", post, user, content, author, name, DateTime.Now);

                try
                {
                    await cmd.ExecuteNonQueryAsync();

                    return Json(new { status = "Ok" });
                }
                catch (DbException exc)
                {
                    return Json(new { status = "Error", Message = exc.Message });
                }
            }
        }

        public async Task<ActionResult> Like(int? id, int? postId)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT [Liked] FROM [Post] WHERE [Id]='{0}'", postId);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();

                    if (reader.GetString(0).IndexOf(id.ToString()) == -1)
                    {
                        reader.Close();

                        cmd.CommandText = string.Format("UPDATE [Post] SET [Likes]=[Likes] + 1 WHERE [Id]='{0}'", postId);
                        await cmd.ExecuteNonQueryAsync();

                        cmd.CommandText = string.Format("UPDATE [Post] SET [Liked]=ISNULL([Liked], '') + '{0}' WHERE [Id]='{1}'", " " + id.ToString(), postId);
                        await cmd.ExecuteNonQueryAsync();

                        return Json(new { status = "Ok" });
                    }
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "User has already liked this post.");
        }

        public ActionResult UploadAvatar(int? id)
        {
            if (!Authenticate(id, null).Result)
            {
                return RedirectToAction("Empty");
            }

            return View(id);
        }

        public ActionResult UploadBg(int? id)
        {
            if (!Authenticate(id, null).Result)
            {
                return RedirectToAction("Empty");
            }

            return View(id);
        }

        public ActionResult UploadImg(int? id)
        {
            if (!Authenticate(id, null).Result)
            {
                return RedirectToAction("Empty");
            }

            var file = Request.Files[0];
            file.SaveAs(Server.MapPath("~/" + id + "/" + Path.GetFileName(file.FileName)));

            return RedirectToAction("post", new
            {
                owner = id,
                author = id,
                content = "<img class=\"img-post\" src=\"" + "../../" + id + "/" + Path.GetFileName(file.FileName) + "\" alt=\"\" style=\"width:100%;cursor:pointer;\" />",
                type = "image"
            });
        }

        public async Task<ActionResult> DeletePost(int? id)
        {
            if (!Authenticate(id, null).Result)
            {
                return RedirectToAction("Empty");
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("DELETE FROM [Post] WHERE [Id]='{0}'", id);

                try
                {
                    await cmd.ExecuteNonQueryAsync();

                    return Json(new { status = "Ok" }, JsonRequestBehavior.AllowGet);
                }
                catch (DbException)
                {
                    return Json(new { status = "Error" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public async Task<ActionResult> SetPrivacy(int? id, string level)
        {
            if (!Authenticate(id, null).Result)
            {
                return RedirectToAction("Empty");
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("UPDATE [Post] SET [Privacy]='{0}' WHERE [Id]='{1}'", level, id);

                try
                {
                    await cmd.ExecuteNonQueryAsync();

                    return Json(new { status = "Ok" });
                }
                catch (DbException)
                {
                    return Json(new { status = "Error" });
                }
            }
        }

        public ActionResult DeletePicture(int? id, string name)
        {
            if (!Authenticate(id, null).Result)
            {
                return RedirectToAction("Empty");
            }

            DirectoryInfo dInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + id);

            try
            {
                System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + id + "\\" + name);

                return Json(new { status = "Ok" });
            }
            catch (Exception)
            {
                return Json(new { status = "Error" });
            }
        }

        public async Task<ActionResult> DeleteFriend(int? id, int? friend)
        {
            if (!Authenticate(id, null).Result)
            {
                return RedirectToAction("Empty");
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT [Friends] FROM [User] WHERE [Id]='{0}'", id);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();

                    var temp = reader.GetString(0);
                    temp = temp.Replace(" " + friend.ToString(), string.Empty);

                    reader.Close();

                    cmd.CommandText = string.Format("UPDATE [User] SET [Friends]='{0}' WHERE [Id]='{1}'", temp, id);
                }

                await cmd.ExecuteNonQueryAsync();

                cmd.CommandText = string.Format("SELECT [Friends] FROM [User] WHERE [Id]='{0}'", friend);

                reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();

                    var temp = reader.GetString(0);
                    temp = temp.Replace(" " + id.ToString(), string.Empty);

                    reader.Close();

                    cmd.CommandText = string.Format("UPDATE [User] SET [Friends]='{0}' WHERE [Id]='{1}'", temp, friend);
                }

                await cmd.ExecuteNonQueryAsync();

                return Json(new { status = "Ok" });
            }
        }

        public string Logout()
        {
            Response.Cookies["token"].Expires = DateTime.Now.AddDays(-1);
            return "You are now logged out.";
        }

        public string Empty()
        {
            return "<script>document.location = '/'</script>";
        }

        public async Task<ActionResult> RequestFriend(int? id, int from)
        {
            string fromName = string.Empty;
            string toName = string.Empty;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT [FirstName], [LastName] FROM [User] WHERE [id]='{0}'", id);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();

                    toName = string.Format("{0} {1}", reader.GetString(0), reader.GetString(1));
                }

                reader.Close();

                cmd.CommandText = string.Format("SELECT [FirstName], [LastName] FROM [User] WHERE [id]='{0}'", from);

                reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();

                    fromName = string.Format("{0} {1}", reader.GetString(0), reader.GetString(1));
                }

                reader.Close();

                cmd.CommandText = string.Format(@"INSERT INTO [Request] ([From], [To], [Accepted], [Read], [Pending], [FromName], [ToName]) 
                                                VALUES ('{0}', '{1}', 'False', 'False', 'True', '{2}', '{3}')", from, id, fromName, toName);

                try
                {
                    await cmd.ExecuteNonQueryAsync();

                    return Json(new { status = "Ok" });
                }
                catch (Exception)
                {
                    return Json(new { status = "Error" });
                }
            }
        }

        public async Task<ActionResult> AddFriend(int? id, int from, bool add)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("UPDATE [Request] SET [Accepted]='{0}', [Pending]='False' WHERE [From]='{1}' AND [To]='{2}'", add, from, id);
                await cmd.ExecuteNonQueryAsync();

                if (add)
                {
                    cmd.CommandText = string.Format("UPDATE [User] SET [Friends]=ISNULL([Friends], '') + ' {0}' WHERE [Id]='{1}'", id, from);
                    await cmd.ExecuteNonQueryAsync();

                    cmd.CommandText = string.Format("UPDATE [User] SET [Friends]=ISNULL([Friends], '') + ' {0}' WHERE [Id]='{1}'", from, id);
                    await cmd.ExecuteNonQueryAsync();
                }

                return Json(new { status = "Ok" });
            }
        }

        public async Task<JsonResult> Search(string term)
        {
            List<SearchResult> result = new List<SearchResult>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT [Id], [FirstName], [LastName] FROM [User] WHERE CONCAT(LOWER([FirstName]), ' ', LOWER([LastName])) LIKE LOWER('%{0}%')", term);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        result.Add(new SearchResult
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                        });
                    }
                }
            }

            if (result.Count > 0)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Results = "None" }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> Share(int? id, int postId)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format(@"INSERT INTO [Post] ([Owner], [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name]) 
                                                SELECT '{0}', [Author], [DateCreated], [Content], [Likes], [Type], [Liked], [Privacy], [Name] FROM [Post] WHERE [Id]={1}", id, postId);

                await cmd.ExecuteNonQueryAsync();

                return Json(new { status = "Ok" });
            }
        }

        public async Task<ActionResult> GetMessages(int? id, int other)
        {
            List<Message> messages = new List<Message>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM [Message] WHERE ([From]='{0}' AND [To]='{1}') OR ([From]='{1}' AND [To]='{0}') ORDER BY [DateCreated] DESC", id, other);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        messages.Add(new Message()
                        {
                            Id = reader.GetInt32(0),
                            From = reader.GetInt32(1),
                            To = reader.GetInt32(2),
                            DateCreated = reader.GetDateTime(3),
                            Content = reader.GetString(4)
                        });
                    }
                }
            }

            messages.Sort(new MessageComparer());

            return View(new Dictionary<int, IEnumerable<Message>>() { { other, messages } });
        }

        public async Task<ActionResult> PostMessage(int? id, int to, DateTime dateCreated, string content)
        {
            List<Message> messages = new List<Message>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format(@"INSERT INTO [Message] ([From], [To], [DateCreated], [Content], [Read]) 
                                                VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", id, to, dateCreated, content, false);

                await cmd.ExecuteNonQueryAsync();
            }

            return Json(new { status = "Ok" });
        }

        public async Task<ActionResult> SetOnline(int? id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format(@"UPDATE [User] SET [Online]='True' WHERE [Id]='{0}'", id);

                await cmd.ExecuteNonQueryAsync();
            }

            return Json(new { status = "Ok" }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> SetOffline(int? id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format(@"UPDATE [User] SET [Online]='False' WHERE [Id]='{0}'", id);

                await cmd.ExecuteNonQueryAsync();
            }

            return Json(new { status = "Ok" }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> SetRead(int? id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format(@"UPDATE [Message] SET [Read]='True' WHERE [To]='{0}'", id);

                await cmd.ExecuteNonQueryAsync();
            }

            return Json(new { status = "Ok" }, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        public async Task<User> GetUser(int? id)
        {
            User user = new User();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            using (SHA384 sha = SHA384.Create())
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM [User] WHERE [Id]='{0}'", id);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        user.Id = id;
                        user.FirstName = reader.GetString(1);
                        user.LastName = reader.GetString(2);
                        user.Email = reader.GetString(3);
                        user.School = reader.GetString(4) ?? "Your school.";
                        user.Work = reader.GetString(5) ?? "Your work.";
                        user.Location = reader.GetString(6) ?? "Your current location.";
                        user.Relationship = reader.GetString(7) ?? "Your relationship status.";
                        user.Birthdate = reader.GetDateTime(8);
                        user.Weight = reader.GetInt32(9);
                        user.Height = reader.GetDouble(10);
                        user.Friends = reader.GetString(11);
                        user.Online = reader.GetBoolean(13);
                        user.Gender = reader.GetString(14) ?? "Your gender.";
                        user.Email2 = reader.GetString(15) ?? "Your secondary E-mail.";
                        user.Telephone = reader.GetString(16) ?? "Your telephone number.";
                    }
                }
            }

            return user;
        }

        [NonAction]
        public async Task<bool> Authenticate(int? id, string token)
        {
            if (id == null && token == null)
            {
                return false;
            }
            else if (id != null && token == null)
            {
                if (Request.Cookies["token"] != null)
                {
                    token = Server.HtmlEncode(Request.Cookies["token"].Value);
                }
                else
                {
                    return false;
                }
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            using (SHA384 sha = SHA384.Create())
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT [Email], [Password] FROM [User] WHERE [Id]='{0}'", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();

                    byte[] buffer = sha.ComputeHash(Encoding.UTF8.GetBytes(reader.GetString(1) + reader.GetString(0)));
                    string temp = BitConverter.ToString(buffer).Replace("-", string.Empty).ToLower();

                    if (token != BitConverter.ToString(buffer).Replace("-", string.Empty).ToLower())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        [NonAction]
        public async Task<List<User>> GetFriends(int? id)
        {
            List<int> ids = new List<int>();
            List<User> friends = new List<User>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT [Friends] FROM [User] WHERE [Id]='{0}'", id);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();

                    foreach (string item in reader.GetString(0).Split(' ').Skip<string>(1))
                    {
                        ids.Add(int.Parse(item));
                    }
                }

                foreach (int item in ids)
                {
                    reader.Close();
                    cmd.CommandText = string.Format("SELECT [Id], [FirstName], [LastName], [Online] FROM [User] WHERE [Id]='{0}'", item);
                    reader = await cmd.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        friends.Add(new User()
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Online = reader.GetBoolean(3)
                        });
                    }
                }
            }

            return friends;
        }
    }
}