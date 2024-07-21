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

- [Pré-Requisitos](#pré-requisitos)
- [Instalação pelo Visual Studio 2022](#instalação-pelo-visual-studio-2022)
- [Instalação pelo Visual Studio Code](#instalação-pelo-visual-studio-code)

<br />

## Pré-Requisitos

Antes de executar este projeto, os seguintes itens deverão estar instalados no computador:

* Docker
* Kubernetes
* Visual Studio 2022 ou Visual Studio Code
* Verificar e caso necessário, ajustar o arquivo appSettings.json para que os valores das connectionStrings fiquem conforme abaixo:
<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/e6cbc4a3-87bf-450a-bc39-4b36182c7223)

## Instalação pelo Visual Studio 2022

Passo a passo:

* Baixar o projeto através do repositório do **GitHub**
* Abrir o projeto no **Visual Studio 2022**
* Localizar o arquivo **docker-compose** no Solution Explorer:
<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/748435a2-1257-4b95-8cc8-7b63fef4cbc9)


<br />

* Clicar nele com o botão direito e selecionar **Set as Startup Projetct**:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/7f4ffe64-ed50-4061-b699-d148e50a2c3c)


<br />

* Clicar na opção **Docker Compose** da barra de ferramentas padrão:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/b3e01c69-daa8-4e97-98b0-6a3d608f628d)


<br />

* O Visual Studio criará os containers e exibirá a tela do Swagger da API:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/8854c72c-c280-450a-9b65-2b19f57a9ec9)


<br />

* Uma janela conforme abaixo abrirá:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/b489cf48-2bb9-445f-9817-c1caaf35648f)


<br />

* Na barra de endereços, digitar /swagger após o endereço para que fique desta forma "https://localhost:53699/swagger/" (**ao executar, a sua porta pode estar diferente**) e teclar enter. O resultado será conforme abaixo, exibindo o swagger da API:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/671a5e6d-816c-4539-be41-bb32e40970ee)


<br />

## Instalação pelo Visual Studio Code

Passo a passo:

* Baixar o projeto através do repositório do **GitHub**
* Abrir o projeto no **Visual Studio Code**
* Abrir alguma interface de linha de comando como, por exemplo, o **PowerShell** e navegar até a pasta **src** do Projeto:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/c0ac9833-55d6-4b44-8d0c-0c48220697b7)


<br />

* Executar o comando `docker-compose up -d`
* Os containeres são levantados conforme imagem abaixo e poderão ser listados através do comando `docker ps`

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/969a9138-7eb1-4ba6-a275-7c1f31ecd8a0)



<br />

* Abrir algum browser e informar o seguinte endereço http ou https:
  * HTTP: **http://localhost:8090/swagger/index.html**
  * HTTPS: **https://localhost:5046/swagger/index.html**

* O resultado deverá ser conforme abaixo:

<br />

![image](https://github.com/TechChallenge-4SOAT-G74/QuickOrder-backend/assets/44347862/0ef4ec5a-2b44-484f-bdf4-b7fd3f5cbd44)


<br />
