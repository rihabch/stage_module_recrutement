using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Recrute.Models
{
    public class UserService : IDisposable
    {
        private RecruteContext entities;

        public UserService(RecruteContext entities)
        {
            this.entities = entities;
        }

        public UserService()
        {
            // TODO: Complete member initialization
        }

        public IEnumerable<User> Read()
        {
            return entities.Users.Select(user => new User
            {
                userID = user.userID,
                userFirstName = user.userFirstName,
                userName = user.userName,
                email = user.email,
                password = user.password,
                DateOfBirth = user.DateOfBirth,
                adress = user.adress,
                famSituation = user.famSituation,
                gsmNum = user.gsmNum,
                phoneNum = user.phoneNum,
                nationality = user.nationality,
                country = user.country,
                city = user.city,
                codePoste = user.codePoste,
                DateOfInscri = user.DateOfInscri

            });
        }

        public void Create(User user)
        {
            var entity = new User();

            entity.userName = user.userName;
            entity.userFirstName = user.userFirstName;
            entity.userName = user.userName;
            entity.email = user.email;
            entity.password = user.password;
            entity.DateOfBirth = user.DateOfBirth;
            entity.adress = user.adress;
            entity.famSituation = user.famSituation;
            entity.gsmNum = user.gsmNum;
            entity.phoneNum = user.phoneNum;
            entity.nationality = user.nationality;
            entity.country = user.country;
            entity.city = user.city;
            entity.codePoste = user.codePoste;
            entity.DateOfInscri = user.DateOfInscri;

            entities.Users.Add(entity);
            entities.SaveChanges();

            user.userID = entity.userID;
        }

        public void Update(User user)
        {
            var entity = new User();

            entity.userName = user.userName;
            entity.userFirstName = user.userFirstName;
            entity.email = user.email;
            entity.password = user.password;
            entity.DateOfBirth = user.DateOfBirth;
            entity.adress = user.adress;
            entity.famSituation = user.famSituation;
            entity.gsmNum = user.gsmNum;
            entity.phoneNum = user.phoneNum;
            entity.nationality = user.nationality;
            entity.country = user.country;
            entity.city = user.city;
            entity.codePoste = user.codePoste;
            entity.DateOfInscri = user.DateOfInscri;
            entities.Users.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(User user)
        {
            var entity = new User();

            entity.userID = user.userID;

            entities.Users.Attach(entity);

            entities.Users.Remove(entity);

            /*var orderDetails = entities.Order_Details.Where(pd => pd.ProductID == entity.ProductID);

            foreach (var orderDetail in orderDetails)
            {
                entities.Order_Details.Remove(orderDetail);
            }
            */
            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}