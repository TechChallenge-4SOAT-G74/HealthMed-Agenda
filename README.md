# HealthMed-Agenda - Hackaton - FIAP

Projeto Hackaton da FIAP Pos Tech

**INTEGRANTES DO GRUPO 74**

* Moisés Barboza de Figueiredo Junior
moises.figueiredo@gmail.com

* Gabriela da Silva Lopes
gabrieladslopes@gmail.com

* Francisco Tadeu da Silva e Souza
fsouza.thadeu@gmail.com

<br />

## Projeto

Sistema proprietário, que permite o gerenciamento eficiente de agendamentos, 
consultas e prontuário eletrônico. 

O sistema de cadastro permitirá o cadastro de médicos e pacientes. 
No cadastro de médico, haverá uma comunicação assíncrona com o sistema de agenda, 
com as dados que permita o cadastramento da agenda do médico.

O sistema de agenda permitirá que o médico cadastre sua agenda de consultas
em um calendário. E permite que o assistente do médico ou o paciente agente uma 
consulta após localizar o médico pela sua especialidade, nome ou registro. 
Após o agendamento da consulta, ocorre o envio de notificação para o paciente 
através de envio de email.

O sistema de consulta permitirá que o médico interaja com o paciente presencialmente
ou por teleatendimento. Além de efetuar a validação do convênio médico do paciente 
ou registro de pagamento.

O sistema de prontuário eletrônico permitirá o armazenamento e
compartilhamento de documentos, exames, cartão de vacinas, e outros registros
médicos entre as partes envolvidas.


<br />

## CI/CD

Projeto conta com automação do GitHub Actions para build e deploy na AWS ECR e ECS.
Também conta com execução do SonarCloud para validação da código e cobertura de testes.
https://sonarcloud.io/summary/overall?id=TechChallenge-4SOAT-G74_HealthMed-Agenda


<br />


## Conteúdos

- [Instalação pelo Visual Studio 2022](#instalação-pelo-visual-studio-2022)
- [Instalação pelo PowerShell](#instalação-pelo-PowerSell)

<br />

## Instalação pelo Visual Studio 2022

Passo a passo:

* Baixar o projeto através do repositório do **GitHub**
* Abrir o projeto no **Visual Studio 2022**
* Localizar o arquivo **docker-compose** no Solution Explorer:
<br />

![image](![image](https://github.com/user-attachments/assets/e3991977-1a3a-4a7d-82c2-9825c742578a)


<br />

* Clicar nele com o botão direito e selecionar **Set as Startup Projetct**:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/7f4ffe64-ed50-4061-b699-d148e50a2c3c)


<br />

* Clicar na opção **Docker Compose** da barra de ferramentas padrão:

<br />

![image](https://github.com/user-attachments/assets/a6d1f5c3-5dd9-42b4-b521-73206b49190d)


<br />

* O Visual Studio criará os containers e exibirá a tela do Swagger da API:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/8854c72c-c280-450a-9b65-2b19f57a9ec9)


<br />

* Uma janela conforme abaixo abrirá:

<br />

![image](https://github.com/user-attachments/assets/a1e68751-fdde-42c8-8292-5c114dbf259a)



<br />

## Instalação pelo PowerShell

Passo a passo:

* Baixar o projeto através do repositório do **GitHub**
* Abrir alguma interface de linha de comando como, por exemplo, o **PowerShell** e navegar até a pasta **src** do Projeto:

<br />

* Executar o comando `docker-compose up -d`
* Os containeres são levantados conforme imagem abaixo e poderão ser listados através do comando `docker ps`

<br />

* Abrir algum browser e informar o seguinte endereço http ou https:
  * HTTP: **http://localhost:50722/swagger/index.html**
  * HTTPS: **https://localhost:50723/swagger/index.html**

