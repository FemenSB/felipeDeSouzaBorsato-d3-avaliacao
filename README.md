# Avaliação CTEDS D3

Projeto desenvolvido para a avaliação da disciplina D3 (Programação Avançada em C#) do curso Capacitação Tecnológica em Engenharia e Desenvolvimento de Software, da Escola Politécnica da Universidade de São Paulo (Poli-USP).  
Consiste em uma aplicação de console em que é possível realizar cadastro e login. Os logins e logoffs são registrados em um arquivo nomeado logs.txt. Os dados dos usuários são salvos em um banco de dados MariaDB. No banco são salvos hashes das senhas criados pelo BCrypt.

## Ambiente de desenvolvimento

O projeto foi desenvolvido no Visual Studio 2022.  
O Banco de dados utilizado foi o MariaDB, instalado pelo XAMPP v3.3.0.  
A criação da tabela e inserção do usuário admin são feitas pela execução dos comandos em ./createTable.sql

## Dependências

Foram utilizados os seguintes pacotes, instalados pelo NuGet:

- BCrypt.Net-Next (4.0.3)
- MySql.Data (8.0.29)