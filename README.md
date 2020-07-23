# Infnet20
##Trabalho do modulo de Injeção de Dependência e Persistência


Esse sistema pretende gerenciar o cadastro de filmes incluindo seus atores e gêneros. 
###Tecnologia
* .Net 
* Sql server.

### Classes de Domínio
* Ator
* Filme
* Gênero

### Arquitetura
Devido ao pequeno prazo para entrega o sistema foi composto apenas com as camadas de Aplicação e repository. Sabemos que não é a melhor prática e vamos melhorar na próxima interação.

### Regras de negócio:
* Para inclusão de um gênero ao filme, deve ser cadastrado anteriormente o gênero na base;
* Para inclusão de um Ator ao filme, deve ser cadastrado anteriormente o ator na base;
* Para inclusão de um Filme ao gênero, deve ser cadastrado anteriormente o filme na base;
* Para inclusão de um Filme ao ator, deve ser cadastrado anteriormente o filme na base;
