using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRepository:RepositoryBase
    {
        public List<User> List()
        {
            return context.Users.ToList();
        }

        public void Insert(User entity)
        {
            entity.IsAdmin = false;
            context.Users.Add(entity);
            context.SaveChanges();
        }

        public void Update(User entity)
        {
            User user = entity as User;
            context.SaveChanges();
        }

        public User Find(int? id)
        {
            return context.Users.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Delete(int id)
        {
            User user = context.Users.Where(c => c.Id == id).FirstOrDefault();
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public DataAccessLayerResult RegisterUser(RegisterViewModel data)
        {
            User user = context.Users.Where(x => x.Username == data.Username || x.Email == data.Email).FirstOrDefault();
            DataAccessLayerResult res = new DataAccessLayerResult();

            if (user != null)
            {
                if (user.Username == data.Username)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExist, "Email addresses is already exist.");
                }

                if (user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExist, "Email addresses is already exist.");
                }
            }
            else
            {
                Insert(new User()
                {
                    Username = data.Username,
                    Email = data.Email,
                    Password = data.Password,
                    IsAdmin = false
                });
                
            }

            return res;
        }

        public DataAccessLayerResult LoginUser(LoginViewModel data)
        {
            DataAccessLayerResult res = new DataAccessLayerResult();
            res.Result = context.Users.Where(x => x.Username == data.Username && x.Password == data.Password).FirstOrDefault();

            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.UsernameOrPasswordWrong, "Username or password do not match.");
            }

            return res;
        }

        public DataAccessLayerResult UpdateUser(User data)
        {
            User db_user = context.Users.Where(x => x.Id != data.Id && (x.Username == data.Username || x.Email == data.Email)).FirstOrDefault();
            DataAccessLayerResult res = new DataAccessLayerResult();

            if (db_user != null && db_user.Id != data.Id)
            {
                if (db_user.Username == data.Username)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExist, "Username is already exist.");
                }

                if (db_user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExist, "Email is already exist.");
                }

                return res;
            }

            res.Result = context.Users.Where(c => c.Id == data.Id).FirstOrDefault();
            res.Result.Email = data.Email;
            res.Result.Name = data.Name;
            res.Result.Surname = data.Surname;
            res.Result.Password = data.Password;
            res.Result.Username = data.Username;

            return res;
        }

        public DataAccessLayerResult GetUserById(int id)
        {
            DataAccessLayerResult res = new DataAccessLayerResult();
            res.Result = context.Users.Where(x => x.Id == id).FirstOrDefault();

            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.UserNotFound, "User can not found");

            }
            return res;
        }

    }
}
