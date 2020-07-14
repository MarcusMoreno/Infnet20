using System;
using TestApp.RecuperaDados;
//using TestApp.RecuperaDados;
//using EASendMail;

namespace TestApp
{/*
    class Program
    {
        //static void Main(string[] args)
        //{
        //    SmtpMail oMail = new SmtpMail("TryIt");
        //    SmtpClient oSmtp = new SmtpClient();

        //    // Set sender email address, please change it to yours
        //    oMail.From = "douglas.csilva@al.infnet.edu.br";
        //    // Set recipient email address, please change it to yours
        //    oMail.To = "rodrigom.clemente@hotmail.com";

        //    // Set email subject
        //    oMail.Subject = "test email from c# project";

        //    // Set email body
        //    oMail.TextBody = "se voce esta recebendo isso, e porque eu consegui enviar o email atraves do projeto";

        //    // Your SMTP server address
        //    SmtpServer oServer = new SmtpServer("smtp.gmail.com");
        //    // User and password for ESMTP authentication, if your server doesn't require
        //    // User authentication, please remove the following codes.
        //    oServer.User = "douglas.csilva@al.infnet.edu.br";
        //    oServer.Password = "newP@ssw0rd";

        //    // If your smtp server requires TLS connection, please add this line
        //    // oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
        //    // If your smtp server requires implicit SSL connection on 465 port, please add this line
        //     oServer.Port = 465;
        //     oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

        //    try
        //    {
        //        Console.WriteLine("start to send email ...");
        //        oSmtp.SendMail(oServer, oMail);
        //        Console.WriteLine("email was sent successfully!");
        //    }
        //    catch (Exception ep)
        //    {
        //        Console.WriteLine("failed to send email with the following error:");
        //        Console.WriteLine(ep.Message);
        //    }
        //    Console.ReadLine();
        //}
    }
}

namespace TestApp
{*/
    class Program
    {
        static void Main(string[] args)
        {
            RecuperaDadosClient rd = new RecuperaDadosClient();
            
            foreach (Aluno aluno in rd.ListaDeAlunosDaTurma(rd.turmaPorNome("terca")))
            {
                Console.WriteLine(aluno.nomeAluno);
            }
            Console.ReadKey();

            foreach (Aluno aluno in rd.ListaDeAlunosDaTurmaPorNome("sabado"))
            {
                Console.WriteLine(aluno.nomeAluno);
            }
            Console.ReadKey();


            foreach(Curso curso in rd.RecuperaCursos())
            {
                Console.WriteLine(curso.nomeCurso);
                foreach(Turma turma in rd.ListaDeTurmasDoCurso(curso))
                {
                    Console.WriteLine(" " + turma.nomeTurma);
                    foreach(Aluno aluno in rd.ListaDeAlunosDaTurma(turma))
                    {
                        Console.WriteLine("     " + aluno.nomeAluno);
                        Console.WriteLine("     " + aluno.emailAluno);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}

