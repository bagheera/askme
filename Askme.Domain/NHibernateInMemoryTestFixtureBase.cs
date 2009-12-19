using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Askme.Domain
{
    public class NHibernateInMemoryTestFixtureBase
    {
        protected static ISessionFactory SessionFactory;
        protected static Configuration Config;

        public static void InitalizeSessionFactory(params FileInfo[] hbmFiles)
        {
            if (SessionFactory != null)
                return;

            var properties = new Dictionary<string, string>();
            properties.Add("connection.driver_class", "NHibernate.Driver.SQLite20Driver");
            properties.Add("dialect", "NHibernate.Dialect.SQLiteDialect");
            properties.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            properties.Add("connection.connection_string", "Data Source=:memory:;Version=3;New=True;");
            properties.Add("connection.release_mode", "on_close");
            properties.Add("show_sql", "true");
            properties.Add("proxyfactory.factory_class", "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle");
            

            Config = new Configuration();
            Config.Properties = properties;

            foreach (FileInfo mappingFile in hbmFiles)
            {
                Config = Config.AddFile(mappingFile);
            }
            Config.BuildMapping();
            SessionFactory = Config.BuildSessionFactory();
        }

        public ISession CreateSession()
        {
            ISession openSession = SessionFactory.OpenSession();
            IDbConnection connection = openSession.Connection;
            new SchemaExport(Config).Execute(false,true,false,connection,null);
            return openSession;
        }

    }
}
