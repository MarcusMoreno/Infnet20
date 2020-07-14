using System;
using System.Collections.Generic;
using System.Text;
using ContosoDDD.Aplicacao.DTO;
using ContosoDDD.Dominio.Entidade;

namespace ContosoDDD.Infraestrutura.Transversal.AutoMapper
{
    public class MapperAluno : IMapperAluno
    {
        List<AlunoDTO> alunosDTO = new List<AlunoDTO>();

        public IEnumerable<AlunoDTO> MapperListAlunos(IEnumerable<Aluno> alunos)
        {
            foreach (var a in alunos)
            {
                AlunoDTO alunoDTO = new AlunoDTO
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    Sobrenome = a.Sobrenome,
                    Email = a.Email
                };

                alunosDTO.Add(alunoDTO);
            }

            return alunosDTO;
        }

        public AlunoDTO MapperToDTO(Aluno aluno)
        {
            AlunoDTO alunoDTO = new AlunoDTO
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Sobrenome = aluno.Sobrenome,
                Email = aluno.Email
            };

            return alunoDTO;
        }

        public Aluno MapperToEntity(AlunoDTO alunoDTO)
        {
            Aluno aluno = new Aluno
            {
                Id = alunoDTO.Id,
                Nome = alunoDTO.Nome,
                Sobrenome = alunoDTO.Sobrenome,
                Email = alunoDTO.Email
            };

            return aluno;
        }
    }
}
