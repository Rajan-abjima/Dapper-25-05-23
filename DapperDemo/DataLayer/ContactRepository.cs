﻿using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataLayer
{
    public class ContactRepository : IContactRepository
    {
        private IDbConnection db;
        public ContactRepository(string connString)
        {
            this.db = new SqlConnection(connString);
        }
        public Contact Add(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            return this.db.Query<Contact>("SELECT * FROM Contacts").ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Contact Update(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}