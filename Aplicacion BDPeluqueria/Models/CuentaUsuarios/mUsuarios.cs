using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Aplicacion_BDPeluqueria.Models.CuentaUsuarios
{
    public class mUsuarios
    {
        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Correo electrónico")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20,MinimumLength=6)]
        [Display(Name = "Contraseña")]
        public string contraseña { get; set; }

        [Display(Name = "Recordarme en este ordenador")]
        public bool recuerdame { get; set; }

        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="_username">User name</param>
        /// <param name="_password">User password</param>
        /// <returns>True if user exist and password is correct</returns>
        //public bool IsValid(string _username, string _password)
        //{
        //    using (var cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename" +
        //      @"='C:\Tutorials\1 - Creating a custom user login form\Creating " +
        //      @"a custom user login form\App_Data\Database1.mdf';Integrated Security=True"))
        //    {
        //        string _sql = @"SELECT [Username] FROM [dbo].[System_Users] " +
        //               @"WHERE [Username] = @u AND [Password] = @p";
        //        var cmd = new SqlCommand(_sql, cn);
        //        cmd.Parameters
        //            .Add(new SqlParameter("@u", SqlDbType.NVarChar))
        //            .Value = _username;
        //        cmd.Parameters
        //            .Add(new SqlParameter("@p", SqlDbType.NVarChar));
        //            //Helpers.SHA1.Encode(_password);
        //        cn.Open();
        //        var reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            reader.Dispose();
        //            cmd.Dispose();
        //            return true;
        //        }
        //        else
        //        {
        //            reader.Dispose();
        //            cmd.Dispose();
        //            return false;

        //        }
        //    }
        //}
    }
}