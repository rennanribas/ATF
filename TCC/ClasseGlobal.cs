using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace TCC
{
      abstract class ClasseGlobal
    {
        static Boolean logado, adm, primeiroLogin, contrato, backup;
        static int id_funcionario, id_treino, id_cliente;

        #region Variaveis Encapsuladas

        public static Boolean Backup
        {
            get { return ClasseGlobal.backup; }
            set { ClasseGlobal.backup = value; }
        }
          
        public static int Id_cliente
        {
            get { return ClasseGlobal.id_cliente; }
            set { ClasseGlobal.id_cliente = value; }
        }

        public static Boolean Contrato
        {
            get { return ClasseGlobal.contrato; }
            set { ClasseGlobal.contrato = value; }
        }

        public static int Id_treino
        {
            get { return ClasseGlobal.id_treino; }
            set { ClasseGlobal.id_treino = value; }
        }

        public static Boolean PrimeiroLogin
        {
            get { return ClasseGlobal.primeiroLogin; }
            set { ClasseGlobal.primeiroLogin = value; }
        }
          
        public static int Id_funcionario
        {
            get { return ClasseGlobal.id_funcionario; }
            set { ClasseGlobal.id_funcionario = value; }
        }

        public static Boolean Logado
        {
            get { return ClasseGlobal.logado; }
            set { ClasseGlobal.logado = value; }
        }

        public static Boolean Adm
        {
            get { return ClasseGlobal.adm; }
            set { ClasseGlobal.adm = value; }
        }
        #endregion
    }
}
