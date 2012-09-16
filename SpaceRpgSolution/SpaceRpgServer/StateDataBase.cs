using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceRpgServer
{
    class StateDataBase
    {
        public static StateDataBase Instance = new StateDataBase();

        private StatusDataSetTableAdapters.usersTableAdapter usersTA;
        private StatusDataSet.usersDataTable usersTable;

        private StateDataBase()
        {
            // Abrimos la conexion
            usersTA = new SpaceRpgServer.StatusDataSetTableAdapters.usersTableAdapter();
            usersTable = new StatusDataSet.usersDataTable();

            usersTA.Fill(usersTable);
        }

        public void RegisterUser(string userName, string email, string pass)
        {
            // Comprobamos si existe el user
            foreach (StatusDataSet.usersRow row in usersTable)
            {
                if ( row.username.Equals( userName ) )
                {
                    throw new GameException("User already exists");
                }
                else if (row.email.Equals(email))
                {
                    throw new GameException("The email provided is already used");
                }
            }

            // Añadimos esto
            StatusDataSet.usersRow newRow = (StatusDataSet.usersRow)usersTable.NewRow();
            newRow.username = userName;
            newRow.email = email;
            newRow.pass = pass;
            usersTable.Rows.Add(newRow);
        }
    }
}
