using System.Collections.Generic;
using System.Data;
using System.IO;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Askme.Domain
{
    public class NHibernateInMemoryBase
    {
        protected static ISessionFactory SessionFactory;
        protected static Configuration Config;

        public static void InitalizeSessionFactory(params FileInfo[] hbmFiles)
        {
            if (SessionFactory != null)
                return;

            var properties = new Dictionary<string, string>
                                 {
                                     {"connection.driver_class", "NHibernate.Driver.SQLite20Driver"},
                                     {"dialect", "NHibernate.Dialect.SQLiteDialect"},
                                     {"connection.provider", "NHibernate.Connection.DriverConnectionProvider"},
                                     {"connection.connection_string", "Data Source=:memory:;Version=3;New=True;"},
                                     {"connection.release_mode", "on_close"},
                                     {"show_sql", "true"},
                                     {"proxyfactory.factory_class", "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle"}
                                 };


            Config = new Configuration {Properties = properties};

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
            new SchemaExport(Config).Execute(false, true, false, connection, null);
            return openSession;
        }
    }
}