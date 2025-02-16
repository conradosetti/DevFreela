# DevFreela API

## 📌 Sobre a API

A **DevFreela API** é um sistema para gerenciamento de freelancers e projetos, permitindo cadastro de usuários, habilidades e interações entre clientes e freelancers. A API suporta operações CRUD e funcionalidades específicas para controle de projetos e comentários.

## 🛠️ Tecnologias Utilizadas

- **.NET** (C#)
- **Entity Framework Core**
- **SQL Server**
- **Swagger** (para documentação da API)

---

## 📦 Entidades e Relacionamentos

A API possui cinco entidades principais:

1. **User**
2. **Project**
3. **Skill**
4. **UserSkill**
5. **ProjectComment**

### 🔗 Relacionamentos

- **User 1****:N**** Project** → Um usuário pode criar vários projetos.
- **User N****:N**** Skill** → Um usuário pode ter várias habilidades, e uma habilidade pode pertencer a vários usuários.
- **Project 1****:N**** ProjectComment** → Um projeto pode ter vários comentários.

---

## 📌 Endpoints Disponíveis

### **🔹 User**

- `GET api/user/{id}` → Buscar usuário por ID.
- `POST api/user` → Criar um novo usuário.
- `PUT api/user/{id}/skills` → Atualizar habilidades do usuário.
- `PUT api/user/profile-picture/{id}` → Atualizar foto de perfil do usuário.

### **🔹 Project**

- `GET api/project` → Buscar todos os projetos.
- `GET api/project/{id}` → Buscar projeto por ID.
- `POST api/project` → Criar um novo projeto.
- `PUT api/projects/{id}` → Atualizar um projeto.
- `DELETE api/project/{id}` → Deletar um projeto.
- `PUT api/project/start/{id}` → Iniciar um projeto.
- `PUT api/project/complete/{id}` → Marcar um projeto como concluído.
- `POST api/project/comment/{id}` → Adicionar comentário ao projeto.

### **🔹 Skill**

- `GET api/skill` → Buscar todas as habilidades.
- `GET api/skill/{id}` → Buscar habilidade por ID.
- `POST api/skill` → Criar uma nova habilidade.

---

## 🚀 Como Rodar o Projeto Localmente

### **1️⃣ Pré-requisitos**

Antes de iniciar, certifique-se de ter instalado:

- **.NET SDK** 6.0+
- **SQL Server**
- **Rider** ou **Visual Studio**

### **2️⃣ Configurar o Banco de Dados**

1. No **SQL Server**, crie um novo banco de dados:
   ```sql
   CREATE DATABASE DevFreelaDB;
   ```
2. Configure a **connection string** no `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=DevFreelaDB;User Id=seu_usuario;Password=sua_senha"
     }
   }
   ```
3. Aplicar as migrações do **Entity Framework**:
   ```sh
   dotnet ef migrations add PrimeiraMigration -o Persistence/Migrations
   dotnet ef database update
   ```

### **3️⃣ Rodar a API**

1. No terminal, dentro da pasta do projeto, execute:
   ```sh
   dotnet run
   ```
2. A API estará disponível em: `http://localhost:5227`

### **4️⃣ Acessar o Swagger**

Abra o navegador e acesse:

```
http://localhost:5227/index.html
```

Aqui você pode testar os endpoints da API!

---


## ✨ Contribuições

Fique à vontade para abrir um **Pull Request** ou relatar problemas na aba de **Issues**!

---

🚀 API pronta para ser utilizada e expandida! Se precisar de ajustes, só me avisar! 😃

