using ContosoDDD.Aplicacao.DTO;
using ContosoDDD.Dominio.Entidade;
using System;
using System.Collections.Generic;

namespace ContosoDDD.Infraestrutura.Transversal.AutoMapper
{
    public interface IMapperAluno
    {
        Aluno MapperToEntity(AlunoDTO alunoDTO);

        IEnumerable<AlunoDTO> 
            MapperListAlunos(IEnumerable<Aluno> alunos);

        AlunoDTO MapperToDTO(Aluno aluno);
    }
}
